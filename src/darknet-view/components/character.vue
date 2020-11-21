<template>
  <div class="col-2 m-2 card char-card">
    {{stats.name}}
    <div ><label class="mr-2">STR:</label><label>{{stats.str}}</label></div>
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
</style>
