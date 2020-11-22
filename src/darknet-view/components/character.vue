<template>
  <div class="col-2 m-2 card char-card">
    {{stats.name}}
    <div >
      <label class="mr-2">STR:</label>
      <label>{{stats.str}}</label>
      <div class="btn btn-launch" @click="launchDices(stats.str, true)"></div>
    </div>
  </div>
</template>

<script>

export default {
  props: {
    stats: {
      type: Object,
      required: true
    }
  },
  components: {
  },
  data () {
    return {
      
    }
  },
  computed: {
  },
  methods :{
    launchDices (diceTimes, speciality) {
      const times = parseInt(diceTimes)
      this.$emit('launchDices', {times, speciality})
    }
  },
  watch: {
  }

}
</script>
<style scoped>
.char-card {
  height: 12rem;
  display: flex;
  flex-direction: column;
}
.btn-launch {
  height: 1rem;
  width: 2rem;
  border: 1px solid salmon;
}
</style>
