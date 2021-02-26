<template>
  <div class="single-dice">
    {{value}}
  </div>
</template>
<script lang="ts">
import Vue from 'vue'
import { APP_MUTATIONS } from '@/store'

export default {
  name: 'dice',
  data () {
    return {
      value: 0
    }
  },
  methods: {
    // roll() {
    //   const val = Math.floor(Math.random() * 10) + 1
    //   this.$store.commit(APP_MUTATIONS.DICEIN, val)
    //   this.$emit('diceValue', val, this.$vnode.key)
    //   this.value =  val
    // }
  },
  mounted() {
    //this.roll()
  }
  
}
</script>

<style scoped>
.single-dice {
  border: 1px solid goldenrod;
  padding: 1rem;
  max-width: 3rem;
  margin: 1rem;
  text-align: center;
  
}

</style>