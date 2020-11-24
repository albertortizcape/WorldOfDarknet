<template>
    <li class="flex-item ">
      <div class="recuadro">
        <div class="recuadro-icono">
          <img :src="stats.image" />
        </div>
        <div class="recuadro-info">
          <p class="title">{{stats.name}}</p>

          <div class="btn btn-info mb-1" @click="changeForm(stats.name,'hominid')">hominid</div>
          <div class="btn btn-primary mb-1" @click="changeForm(stats.name,'glabro')">glabro</div>
          <div class="btn btn-danger mb-1" @click="changeForm(stats.name, 'crinos')">crinos</div>
          <div class="btn btn-warning mb-1" @click="changeForm(stats.name,'hispo')">hispo</div>
          <div class="btn btn-info mb-1" @click="changeForm(stats.name,'lupus')">lupus</div>

          <div v-for="(att, index) in stats.actualStats" :key="index" class="d-flex justify-content-between align-items-center mb-2">
            <p class="m-0 attribute">{{att.name}}:</p>
            <p class="m-0">{{att.value}}</p>
            <div class="btn btn-launch" @click="launchDices(att.value, true)"></div>
          </div>
        </div>
      </div>
    </li>


</template>

<script>
import { APP_GETTERS, APP_MUTATIONS } from '@/store'
export default {
  props: {
    stats: {
      type: Object,
      required: true
    }
  },
  components: {
  },
  computed: {
  },
  methods :{
    launchDices (diceTimes, speciality) {
      const times = parseInt(diceTimes)
      const name = this.stats.name
      this.$emit('launchDices', {times, speciality, name})
    },
    changeForm (name, newForm) {
      // this.stats.image = `./img/${name.toLowerCase()}-${newForm}.png`
      // switch (newForm) {
      //   case 'hominid':
      //     this.stats.actualStats[0].value = parseInt(this.stats.stats[0].value)
      //     this.stats.actualStats[1].value = parseInt(this.stats.stats[1].value)
      //     this.stats.actualStats[2].value = parseInt(this.stats.stats[2].value)
      //     break;
      //   case 'crinos':
      //     this.stats.actualStats[0].value = parseInt(this.stats.stats[0].value) + 4
      //     this.stats.actualStats[1].value = parseInt(this.stats.stats[1].value) + 1
      //     this.stats.actualStats[2].value = parseInt(this.stats.stats[2].value) + 3
      //     break
      // }
      // const newStats = {
      //   name: this.stats.name,
      //   values: this.stats.actualStats
      // }
      // $nuxt.$store.commit(APP_MUTATIONS.ACTUALSTATS, newStats)
      const newFormToSend = {
        name: name,
        value: newForm
      }
      this.$emit('transformacion', newFormToSend)
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
