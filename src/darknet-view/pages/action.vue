<template>
  <div class="container">
    <ul class="flex-container col-12">
      <character v-for="(stats, index) in statsArray" v-on:launchDices="launchDices" :key="index" :stats="stats"/>
    </ul>
    <div class="col-12 d-flex flex-wrap justify-content-center">
      <dice-table class="" :key="tableKey" :diceTimes="numberOfDices" :speciality="spec" :name="name" :defaultValues="defaultValues" v-on:diceValue="setDiceValue" />
    </div>
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
      defaultValues: [],
      tableKey: 0
    }
  },
  mounted() {
    let _self = this
    characterService.getPack().then(response => {
      console.log(response)
      _self.statsArray = response
    });


  },
  created() {
    getNotifications.$on('playerJoin', progress => {
      console.log('got it!!!!')
      
    });
    getNotifications.$on('DiceRolls', diceRoll => {
      console.log('recibida la tirada!!!!')
      const receivedRoll = JSON.parse(diceRoll)
      this.defaultValues = receivedRoll.values
      this.name = receivedRoll.name
      // getNotifications.$off('DiceRolls')
    });
    getNotifications.start('alex')
    getNotifications.rollDices('{"name": "alex", "values": []}')
  },
  methods :{
    launchDices(diceSet) {
      $nuxt.$store.commit(APP_MUTATIONS.DICEEMPTY)
      this.defaultValues = []
      this.indexDiceValue = 0;
      this.tableKey++
      this.numberOfDices = diceSet.times
      this.spec = diceSet.speciality
      this.name = diceSet.name
    },
    setDiceValue(name) {
      console.log(`val Action - ${name}`)
      const dices = $nuxt.$store.getters[APP_GETTERS.DICETABLE]
      const emitedRoll = {
        name: name,
        values: dices
      }
      getNotifications.rollDices(JSON.stringify(emitedRoll))
      
    }
  }


}
</script>

<style>
.container {
  margin: 0 auto;
  min-height: 100vh;
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  align-items: center;
  text-align: center;
}

.flex-container{
  padding: 0;
  margin: 0;
  list-style: none;
  display: flex;
  flex-flow: row wrap;
  flex-wrap: wrap;
  justify-content: flex-start;
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
