<template>
  <div class="container">
    <div class="d-flex flex-wrap col-12">
      <character v-for="(stats, index) in statsArray" :key="index" :stats="stats"/>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import Logo from '~/components/Logo.vue'
import Character from '~/components/character.vue'
import characterService from "~/service/characterService"

@Component({
  components: {
    Logo,
    Character
  }
})

export default class Action extends Vue {
  private statsArray: string[] = []

  public mounted() {
    characterService.getPack().then(response => {
      console.log(response)
      this.statsArray = response
    });

  }
}
</script>

<style>
.container {
  margin: 0 auto;
  min-height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
}

.title {
  font-family: 'Quicksand', 'Source Sans Pro', -apple-system, BlinkMacSystemFont,
    'Segoe UI', Roboto, 'Helvetica Neue', Arial, sans-serif;
  display: block;
  font-weight: 300;
  font-size: 100px;
  color: #35495e;
  letter-spacing: 1px;
}

.subtitle {
  font-weight: 300;
  font-size: 42px;
  color: #526488;
  word-spacing: 5px;
  padding-bottom: 15px;
}

.links {
  padding-top: 15px;
}
</style>
