<template>
  <div class="container">
    <ul class="flex-container col-12 mt-5">
      <character v-for="(stats, index) in statsArray.pjs" v-on:launchDices="launchDices" v-on:transformacion="transformacion" :key="index" :stats="stats"/>
      <!-- <div v-for="(stats, index) in statsArray.pjs" :key="index" class="col-2 d-flex flex-wrap justify-content-center mt-5">
        <dice-table class="" :name="name" :diceValues="diceValues" :dificulty="dificulty" :speciality="spec" />
      </div> -->
    </ul>

    <div class="col-12 d-flex flex-wrap justify-content-center mt-5">
      <dice-table class="" :name="name" :diceValues="diceValues" :dificulty="dificulty" :speciality="spec" />
    </div>

    <p class="pnjs mt-4">PNJS<p>
    <div class="col-12 d-flex flex-wrap justify-content-center mt-1">
      <dice-table class="" :name="pnjName" :diceValues="pnjDiceValues" :dificulty="pnjDificulty" :speciality="pnjSpec" />
    </div>
    <ul class="flex-container col-12">
      <character v-for="(stats, index) in statsArray.pnjs" v-on:launchDices="launchPnjDices" v-on:transformacion="transformacion" :key="index" :stats="stats"/>
    </ul>
  </div>
</template>

<script>
import Vue from 'vue'
import Character from '~/components/character.vue'
import diceTable from '~/components/diceTable.vue'
import characterService from "~/service/characterService"
import {getNotifications} from "~/service/gameHubService"
import { APP_GETTERS, APP_MUTATIONS } from '@/store'

export default {
  components: {
    Character,
    diceTable
  },
  data () {
    return {
      statsArray: [],
      numberOfDices: 0,
      spec: false,
      name: "",
      dificulty: 6,
      diceValues: [],
      pnjDiceValues: [],
      pnjSpec: false,
      pnjName: "",
      pnjDificulty: 6,
      tableKey: 0,
      diceResults: []
    }
  },
  mounted() {
    let _self = this
    characterService.getPack().then(response => {
      _self.statsArray = response
    });
  },
  created() {
    const _self = this;
    getNotifications.$on('playerJoin', progress => {
      
    });
    getNotifications.$on('DiceRolls', diceRoll => {
      const receivedRoll = JSON.parse(diceRoll)
      if(receivedRoll.pj) {
        this.diceValues = receivedRoll.values
        this.name = receivedRoll.name
        this.dificulty = parseInt(receivedRoll.dificulty)
        this.spec = receivedRoll.spec ? true : false
      }
      else {
        this.pnjDiceValues = receivedRoll.values
        this.pnjName = receivedRoll.name
        this.pnjDificulty = parseInt(receivedRoll.dificulty)
        this.pnjSpec = receivedRoll.spec ? true : false
      }
      
      // getNotifications.$off('DiceRolls')
    });
    getNotifications.$on('PlayerStats', playerStats => {
      this.changeForm(playerStats);
    });
    const name = $nuxt.$store.getters[APP_GETTERS.PLAYER]
    if(name) {
      getNotifications.start(name['name'])
      getNotifications.rollDices(`{"name": "${name['name']}", "values": [], "dificulty": 5, "spec": true, "pj": true}`)
      getNotifications.changeForm(`{"name": "${name['name']}", "value": "zooooorrooooo"}`)
    } else {
      getNotifications.start('alexxx')
      getNotifications.rollDices('{"name": "alex", "values": [], "dificulty": 5, "spec": true, "pj": true}')
      getNotifications.changeForm('{"name": "alex", "value": "zooooorrooooo"}')
    }
    
    
  },
  methods :{
    launchDices(diceSet) {
      $nuxt.$store.commit(APP_MUTATIONS.DICEEMPTY)
      this.numberOfDices = diceSet.times
      this.name = diceSet.name
      const rolls = this.rollDices()

      const emitedRoll = {
        name: this.name,
        values: rolls,
        dificulty: diceSet.dificulty,
        spec: diceSet.spec,
        pj: true
      }
      getNotifications.rollDices(JSON.stringify(emitedRoll))
    },
    launchPnjDices(diceSet) {
      $nuxt.$store.commit(APP_MUTATIONS.DICEEMPTY)
      this.numberOfDices = diceSet.times
      // this.pnjName = diceSet.name
      const rolls = this.rollDices()

      const emitedRoll = {
        name: diceSet.name,
        values: rolls,
        dificulty: diceSet.dificulty,
        spec: diceSet.spec,
        pj: false
      }
      getNotifications.rollDices(JSON.stringify(emitedRoll))
    },
    setDiceValue(name) {
      const dices = $nuxt.$store.getters[APP_GETTERS.DICETABLE]
      const emitedRoll = {
        name: name,
        values: dices
      }
      getNotifications.rollDices(JSON.stringify(emitedRoll))
    }, 
    rollDices () {
      const results = []
      for(var iDice = 1; iDice <= this.numberOfDices; iDice++) {
        results.push(this.roll())
      }
      return results
    },
    roll() {
      return Math.floor(Math.random() * 10) + 1
    },
    sendChangeForm(newStats) {
      getNotifications.changeForm(JSON.stringify(newStats))
    }
    ,
    transformacion (newForm) {
      getNotifications.changeForm(JSON.stringify(newForm))
    },
    changeForm (newForm) {
      const newFormReceived = JSON.parse(newForm)
      this.statsArray.pjs.forEach(character => {
        if (character.name === newFormReceived.name) {
          character.image = `./img/${newFormReceived.name.toLowerCase()}-${newFormReceived.value}.png`
          switch (newFormReceived.value) {
            case 'hominid':
              character.actualStats[0].value = parseInt(character.stats[0].value)
              character.actualStats[1].value = parseInt(character.stats[1].value)
              character.actualStats[2].value = parseInt(character.stats[2].value)
              break;
            case 'glabro':
              character.actualStats[0].value = parseInt(character.stats[0].value) + 2
              character.actualStats[1].value = parseInt(character.stats[1].value)
              character.actualStats[2].value = parseInt(character.stats[2].value) + 2
              break;
            case 'crinos':
              character.actualStats[0].value = parseInt(character.stats[0].value) + 4
              character.actualStats[1].value = parseInt(character.stats[1].value) + 1
              character.actualStats[2].value = parseInt(character.stats[2].value) + 3
              break
            case 'hispo':
              character.actualStats[0].value = parseInt(character.stats[0].value) + 3
              character.actualStats[1].value = parseInt(character.stats[1].value) + 2
              character.actualStats[2].value = parseInt(character.stats[2].value) + 3
              break;
            case 'lupus':
              character.actualStats[0].value = parseInt(character.stats[0].value) + 1
              character.actualStats[1].value = parseInt(character.stats[1].value) + 2
              character.actualStats[2].value = parseInt(character.stats[2].value) + 2
              break;
          }
        }
      })
    }
  },
  watch: {
  }


}
</script>

<style>
.container {
  max-width: 90% !important;
  min-height: 100vh;
}

.flex-container{
  padding: 0;
  margin: 0;
  list-style: none;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
}

.title {
  font-family: 'Quicksand', 'Source Sans Pro', -apple-system, BlinkMacSystemFont,
    'Segoe UI', Roboto, 'Helvetica Neue', Arial, sans-serif;
  display: block;
  font-weight: 300;
  font-size: 100px;
  color: #35495e;
  letter-spacing: 1px;
}

.subtitle {
  font-weight: 300;
  font-size: 42px;
  color: #526488;
  word-spacing: 5px;
  padding-bottom: 15px;
}

.links {
  padding-top: 15px;
}
</style>
