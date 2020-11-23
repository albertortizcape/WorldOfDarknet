<template>
  <div class="single-dice">
    {{value}}
  </div>
</template>
<script lang="ts">
import Vue from 'vue'

export default {
  name: 'dice',
  computed: {
    value() {
      return Math.floor(Math.random() * 10) + 1 
    }
  }
  
}
</script>

<style scoped>
.single-dice {
  border: 1px solid goldenrod;
  padding: 1rem;
  max-width: 3rem;
  margin: 1rem;
}

</style>