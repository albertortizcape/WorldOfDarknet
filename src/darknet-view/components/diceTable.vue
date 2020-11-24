<template>
  <div class="col-12 p-0">
    <p>{{name}}</p>
    <div class="col-12 my-2 dice-table">
      <dice v-for="index in diceTimes" v-if="defaultValues.length === 0" :key="index" v-on:diceValue="setDiceValue" class="" />
      <div v-for="(val, index) in defaultValues" class="single-dice" :key="index">
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
    diceTimes: {
      type: Number,
      required: true
    },
    speciality: {
      type: Boolean,
      required: true
    },
    name: {
      type: String,
      required: true
    },
    defaultValues: {
      type: Array,
      required: false
    }
  },
  computed: {
  },
  methods :{
    setDiceValue(val, index) {
      if(index === this.diceTimes) {
        this.$emit('diceValue', this.name)
      }
    }
  },
  watch: {
  }

}
</script>
<style scoped>
.dice-table {
  border: 1px solid cadetblue;
  border-radius: 5px;
  display: flex;
  flex-wrap: wrap;
  padding: 2rem;
}
.single-dice {
  border: 1px solid rebeccapurple;
  padding: 1rem;
  max-width: 3rem;
  margin: 1rem;
}
</style>
