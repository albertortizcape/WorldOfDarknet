import Vue from "vue";
import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr'

export const getNotifications = new Vue({
  methods: {
    async start(playerName) {
      const connection = new HubConnectionBuilder()
        .withUrl('https://localhost:5001/hub/game')
        .configureLogging(LogLevel.Information)
        .build()

      await connection.start()

      connection.invoke('playerJoin', playerName)
        .then(resp => console.log(resp))
        .catch(err => console.error(err))

      connection.on('playerJoin', (data) => {
        console.log('playerJoin received')
        this.$emit('playerJoin', data);
      })
    },

    async rollDices(playerName) {
      const connection = new HubConnectionBuilder()
        .withUrl('https://localhost:5001/hub/game')
        .configureLogging(LogLevel.Information)
        .build()

      if (connection.state === 0) {
        await connection.start()
      }

      connection.invoke('DiceRolls', playerName)
        .then(resp => console.log(resp))
        .catch(err => console.error(err))

      connection.on('DiceRolls', (data) => {
        console.log('DiceRolls received')
        this.$emit('DiceRolls', data);
      })
    },
    
    async changeForm(playerStats) {
      console.log('changeForm')
      const connection = new HubConnectionBuilder()
        .withUrl('https://localhost:5001/hub/game')
        .configureLogging(LogLevel.Information)
        .build()

      if (connection.state === 0) {
        await connection.start()
      }

      connection.invoke('PlayerStats', playerStats)
        .then(resp => console.log(resp))
        .catch(err => console.error(err))

      connection.on('PlayerStats', (data) => {
        console.log('PlayerStats received')
        this.$emit('PlayerStats', data);
      })
    }
  }
})