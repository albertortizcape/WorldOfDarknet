import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr'

export default {
  
  async start (playerName) {
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
      console.log(data)
    })
  }
}