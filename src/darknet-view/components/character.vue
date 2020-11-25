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

          <div class="stat-square" :class="stats.name">
            <div v-for="(att, index) in stats.actualStats" :key="index" class="d-flex justify-content-between align-items-center mb-2">
              <div class="btn btn-stat" :id="`btn-${att.name}`" @click="selectAttribute(att.value, att.name)">
                {{att.name}}
                {{att.value}}
              </div>
            </div>
          </div>

          <div class="ability-square mt-3" :class="`ability-${stats.name}`">
            <div v-for="(abi, index) in stats.abilities" :key="index" class="d-flex justify-content-between align-items-center mb-2">
              <div class="btn btn-abi" :id="`btn-${abi.name}`" @click="selectAbility(abi.value, abi.name)">
                {{abi.name}}
                {{abi.value}}
              </div>
            </div>
          </div>
        </div>
        <div class="dados col-12 p-1">
            <div class="btn btn-launch" @click="launchDices()">Launch!</div>
            <!-- <input id="total-dices" type="textbox" v-model="diceTimes"> -->
            <input type="text" class="total-dices" v-model="totalDices">
            <input type="text" class="dificulty" v-model="dificulty">
            <div>
              <label for="spec">spec</label>
              <input id="spec" type="checkbox" v-model="speciality">
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
  }, data () {
    return {
      attributeDices: 0,
      abilityDices: 0,
      speciality: false,
      totalDices: 0,
      dificulty: 6
    }
  },
  components: {
  },
  computed: {
  },
  methods :{
    selectAttribute (diceTimes, attName) {
      this.totalDices = parseInt(this.totalDices) - parseInt(this.attributeDices)
      document.querySelectorAll(`.${this.stats.name} .btn-stat`).forEach(item => { 
        if(item.id === `btn-${attName}`) {
          if(Array.from(item.classList).includes('btn-secondary')) {
            item.classList.remove('btn-secondary')
            this.attributeDices = 0
          } else {
            item.classList.add('btn-secondary')
            this.attributeDices = diceTimes
            this.totalDices = parseInt(this.totalDices) + parseInt(diceTimes)
          }
        } else {
          item.classList.remove('btn-secondary')
        }
      })
    },
    selectAbility (diceTimes, attName) {
      console.log('selectAbility')
      this.totalDices = parseInt(this.totalDices) - parseInt(this.abilityDices)
      document.querySelectorAll(`.ability-${this.stats.name} .btn-abi`).forEach(item => { 
        if(item.id === `btn-${attName}`) {
          if(Array.from(item.classList).includes('btn-secondary')) {
            item.classList.remove('btn-secondary')
            this.abilityDices = 0
          } else {
            item.classList.add('btn-secondary')
            this.abilityDices = diceTimes
            this.totalDices = parseInt(this.totalDices) + parseInt(diceTimes)
          }
        } else {
          item.classList.remove('btn-secondary')
        }
      })
    },
    launchDices () {
      const times = parseInt(this.totalDices)//parseInt(this.attributeDices) + parseInt(this.AbilityDices)
      const spec = this.speciality
      const name = this.stats.name
      this.$emit('launchDices', {times, spec, name})
      this.totalDices = 0
      this.attributeDices = 0
      this.abilityDices = 0
      document.querySelectorAll(`.${this.stats.name} .btn-stat`).forEach(item => {
        item.classList.remove('btn-secondary')
      })
      document.querySelectorAll(`.ability-${this.stats.name} .btn-abi`).forEach(item => {
        item.classList.remove('btn-secondary')
      })
    },
    changeForm (name, newForm) {
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
.stat-square {
  display: flex;
  justify-content: space-between;
}
.char-card {
  height: 12rem;
  display: flex;
  flex-direction: column;
}
.btn-launch {
  border: 1px solid salmon;
}
.btn-stat {
  border: 1px solid rgb(112, 16, 16);
}
.btn-abi {
  border: 1px solid rgb(122, 133, 196);
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
  min-height: 300px;
  width: 18rem;
  padding: 10px 10px;
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
.dados {
  width: 100%;
  display: flex;
  justify-content: space-between;
}
.total-dices {
  border-color: blue;
  width: 3rem;
}
.dificulty {
  border-color: red;
  width: 2rem;
}

</style>
