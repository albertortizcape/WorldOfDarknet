<template>
    <li class="flex-item ">
      <div class="recuadro">
        <div class="recuadro-icono">
          <img :src="stats.image" />
        </div>
        <div class="recuadro-info">
          <p class="title" @click="changePage()">{{stats.name}}</p>

          <div class="btn btn-info mb-1" @click="changeForm(stats.name,'hominid')">hominid</div>
          <div class="btn btn-primary mb-1" @click="changeForm(stats.name,'glabro')">glabro</div>
          <div class="btn btn-danger mb-1" @click="changeForm(stats.name, 'crinos')">crinos</div>
          <div class="btn btn-warning mb-1" @click="changeForm(stats.name,'hispo')">hispo</div>
          <div class="btn btn-info mb-1" @click="changeForm(stats.name,'lupus')">lupus</div>

          <div class="stat-square mt-3" :class="stats.name.replaceAll(' ', '_')">
            <div v-for="(att, index) in stats.actualStats" :key="index" class="d-flex justify-content-between align-items-center mb-1">
              <div class="btn-stat" :id="`btn-${att.name}`" @click="selectAttribute(att.value, att.name)">
                {{att.name}}
                {{att.value}}
              </div>
            </div>
          </div>

          <div class="ability-square mt-3" v-if="page===0" :class="`ability-${stats.name.replaceAll(' ', '_')}`">
            <div v-for="(abi, index) in stats.abilities" :key="index" class="d-flex justify-content-between align-items-center mb-1">
              <div class="btn-abi" :id="`btn-${abi.name}`" @click="selectAbility(abi.value, abi.name)">
                {{abi.name}}
                <b>{{abi.value}}</b>
              </div>
            </div>
          </div>

          <div class="ability-square photo mt-3" v-if="page===1">
            <img :src="stats.image" />
          </div>

          <div class="dados col-12 p-1 mt-3 mb-3">
            <div class="btn btn-launch" @click="launchDices()">Launch!</div>
            <input type="text" class="total-dices" v-model="totalDices">
            <input type="text" class="dificulty" v-model="dificulty">
            <div>
              <label for="spec">spec</label>
              <input id="spec" type="checkbox" v-model="speciality">
            </div>
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
      dificulty: 6,
      page:0,
      maxPage:1
    }
  },
  components: {
  },
  computed: {
  },
  methods :{
    selectAttribute (diceTimes, attName) {
      console.log(`select attr ${attName}`)
      this.totalDices = parseInt(this.totalDices) - parseInt(this.attributeDices)
      document.querySelectorAll(`.${this.stats.name.replaceAll(' ', '_')} .btn-stat`).forEach(item => { 
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
      console.log(`select ability ${attName}`)
      this.totalDices = parseInt(this.totalDices) - parseInt(this.abilityDices)
      document.querySelectorAll(`.ability-${this.stats.name.replaceAll(' ', '_')} .btn-abi`).forEach(item => { 
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
      const times = parseInt(this.totalDices)
      const spec = this.speciality
      const name = this.stats.name
      const dificulty = this.dificulty
      this.$emit('launchDices', {times, spec, name, dificulty})
      this.totalDices = 0
      this.attributeDices = 0
      this.abilityDices = 0
      document.querySelectorAll(`.${this.stats.name.replaceAll(' ', '_')} .btn-stat`).forEach(item => {
        item.classList.remove('btn-secondary')
      })
      document.querySelectorAll(`.ability-${this.stats.name.replaceAll(' ', '_')} .btn-abi`).forEach(item => {
        item.classList.remove('btn-secondary')
      })
    },
    changeForm (name, newForm) {
      const newFormToSend = {
        name: name,
        value: newForm
      }
      this.$emit('transformacion', newFormToSend)
    },
    changePage() {
      this.page++;
      if(this.page > this.maxPage) {
        this.page = 0;
      }
    }
  },
  watch: {
  }

}
</script>
<style scoped>
.stat-square, .ability-square {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
  
}
.ability-square {
  box-shadow: 1px 2px 4px 5px rgba(120, 90, 120, 0.4);
}
.photo {
  height: 220px;
}
.photo img {
  height: 220px;
  max-width: 100%;
  margin-left: auto;
  margin-right: auto;
}
.char-card {
  height: 12rem;
  display: flex;
  flex-direction: column;
}
.btn {
  line-height: 5px;
}

.btn-info, .btn-primary, .btn-danger,
.btn-warning, .btn-info {
  background: transparent;
  color: #ddd;
}



.btn-launch {
  border: 1px solid #867830;
  color: #867830;
  display: flex;
  align-items: center;
}
.btn-stat {
  /* border: 1px solid rgb(112, 16, 16); */
  width: 5rem;
  color: #867830;
  cursor: pointer;
}
.btn-abi {
  /* border: 1px solid rgb(122, 133, 196); */
  width: 6rem;
  font-size: 12px;
  color: rgb(98, 102, 125);
  cursor: pointer;
}
.btn-abi b {
  font-size: 12px;
}
.btn-secondary {
  color: white;
  border-radius: 5px;
}
.flex-item {
  padding:5px;    
}
.title{
  color: #eee;
  font-size: 14px;
  font-weight: bold;
  cursor: pointer;
}
.recuadro {
  border-radius: 3px;
  box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.16), 0 2px 10px 0 rgba(0, 0, 0, 0.12);
  display: block;
  margin-top: 80px;
  min-height: 300px;
  width: 20rem;
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
  color: blue;
  width: 3rem;
  font-weight: bold;
}
.dificulty {
  color: red;
  width: 2rem;
  font-weight: bold;
}

</style>
