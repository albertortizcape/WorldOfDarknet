<template>
    <!-- <div class="col-2 m-2 card char-card">
      {{stats.name}}
      <div >
        <label class="mr-2">STR:</label>
        <label>{{stats.str}}</label>
        <div class="btn btn-launch" @click="launchDices(stats.str, true)"></div>
      </div>
    </div> -->

    <li class="flex-item ">
      <div class="recuadro">
        <div class="recuadro-icono">
          <img :src="stats.image" />
        </div>
        <div class="recuadro-info">
          <p class="title">{{stats.name}}</p>
          <div v-for="(att, index) in stats.stats" :key="index" class="d-flex justify-content-between align-items-center mb-2">
            <p class="m-0 attribute">{{att.name}}:</p>
            <p class="m-0">{{att.value}}</p>
            <div class="btn btn-launch" @click="launchDices(att.value, true)"></div>
          </div>
        </div>
      </div>
    </li>


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
.flex-item {
  padding:5px;    
}
.title{
  color: black;
  font-size: 14px;
}
.recuadro {
  border-radius: 3px;
  box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.16), 0 2px 10px 0 rgba(0, 0, 0, 0.12);
  display: block;
  margin-top: 80px;
  min-height: 100px;
  width: 200px;
  padding: 10px 25px;
  text-align: center;
  z-index: 2;
  position: relative;
}

.recuadro-icono {
  border-radius: 50%;
  height: 125px;
  margin: 0 auto;
  margin-top: -80px;
  padding-top: 5px;
  width: 125px;
  box-shadow: 0px -15px 10px rgba(0, 0, 0, 0.16);
  z-index: 1;
  position: relative;
}
.recuadro-icono img {
  height: 4rem;
  border-radius: 50%;
}

</style>
