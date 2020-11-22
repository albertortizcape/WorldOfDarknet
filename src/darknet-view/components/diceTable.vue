<template>
  <div class="col-12 my-2 dice-table">
    <dice v-for="index in diceTimes" :key="index" class="" />
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
    }
  },
  data () {
    return {
      
    }
  },
  computed: {
  },
  methods :{
    
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
</style>
