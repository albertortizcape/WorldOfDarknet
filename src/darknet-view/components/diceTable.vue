<template>
  <div class="col-12 p-0">
    <div class="d-flex justify-content-between">
      <p class="name">{{name}}</p>
      <p>Dificultad: {{dificulty}}</p>
      <p>Especialidad: {{speciality ? 'Sí' : 'No'}}</p>
      <p><b>Éxitos: {{exitos}}</b></p>
    </div>
    <div class="col-12 my-2 dice-table">
      <!-- <dice v-for="index in diceTimes" v-if="diceValues.length === 0" :key="index" v-on:diceValue="setDiceValue" class="" /> -->
      <div v-for="(val, index) in diceValues" class="single-dice" :class="{'fail': val === 1, 'succeed': val >= dificulty, 'great': val === 10 && speciality}" :key="index">
        {{val}}
      </div>
    </div>
  </div>
</template>

<script>
import Vue from 'vue'
import dice from '~/components/dice'


export default {
  components: {
    dice
  },
  props: {
    // diceTimes: {
    //   type: Number,
    //   required: true
    // },
    speciality: {
      type: Boolean,
      required: true
    },
    name: {
      type: String,
      required: true
    },
    dificulty: {
      type: Number,
      required: true
    },
    diceValues: {
      type: Array,
      required: false
    }
  },
  data () {
    return {
      exitos: 0
    }
  },
  computed: {
  },
  mounted () {
    this.initComponent()
  },
  methods :{
    initComponent () {
      console.log('-----------------init table dice!!!!!!!!')
    },
    setDiceValue(val, index) {
      if(index === this.diceTimes) {
        this.$emit('diceValue', this.name)
      }
    },
    getExitos () {
      let exitosParcial = 0
      let unos = 0
      let dieces = 0
      this.diceValues.forEach(val => {
        if(val === 1) {
          unos++
        } else if (val === 10 && this.speciality) {
          dieces++
        } else if (val >= this.dificulty) {
          exitosParcial++
        }
      })

      console.log('exitos: ' + exitosParcial)
      console.log('unos: ' + unos)
      console.log('dieces: ' + dieces)
      if (dieces > unos) {
        this.exitos = exitosParcial + (dieces - unos) * 2
      } else {
        this.exitos = exitosParcial - (unos - dieces)
      }

    }
  },
  watch: {
    diceValues (neuVal) {
      this.getExitos()
    }
  }

}
</script>
<style scoped>
.dice-table {
  border: 1px solid cadetblue;
  border-radius: 5px;
  display: flex;
  flex-wrap: wrap;
  padding: 1rem;
  height: 5rem;
}
.single-dice {
  border: 1px solid rgb(90, 88, 88);
  padding: 0.5rem 0rem;
  width: 2.5rem;
  margin: 0 1rem;
}
.fail {
  border: 1px solid rgb(180, 57, 57);
  background: rgb(180, 57, 57);
  color: white;
  font-weight: bold;
}
.succeed {
  border: 2px solid rgb(15, 187, 15);
}
.great {
  border-color: rgb(13, 240, 240);
  background: rgb(13, 240, 240);
  color: black;
}
.name, p b {
  font-size: 1.5rem;
}
</style>
