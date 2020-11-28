import axios from 'axios'
import { VUE_APP_HOST, VUE_APP_FOO } from '@/environment/index.js'
import { APP_GETTERS, APP_MUTATIONS } from '@/store'

const httpClient = axios.create()

const requestHeader = function () {
  return {
    'Content-Type': 'application/json',
    Authorization: `Bearer ${$nuxt.$store.getters[APP_GETTERS.TOKEN]}`
  }
}

export const login = async ({ email, password }) => {
  console.log('lallala')
  console.log(process.env.VUE_APP_NOT_SECRET_CODE)
  console.log(VUE_APP_HOST)
  console.log(VUE_APP_FOO)
  const response = await httpClient({
    method: 'post',
    url: '/users/login',
    baseURL: 'http://localhost:5000/api',
    headers: {
      'accept': 'application/json',
      'Content-Type': 'application/json'
    },
    data: {
      'email': email,
      'password': password
    }
  })
  // mutation del token o hacer una action en el store
  const result = {
    is_director: false,
    token: response.data.token,
    player: { name: 'rootPlayer' }
  }
  $nuxt.$store.commit(APP_MUTATIONS.LOGIN, { user: result })
  return response.data
}

/*llamadas a otros con requestHeader*/

export const sampleRequest = async () => {
  console.log('sample Request')
  const response = await httpClient({
    method: 'get',
    url: '/players',
    baseURL: 'http://localhost:5000/api',
    headers: requestHeader()
  })
  return response.data
}



/*

para coger uno a uno en el destino, export const login  = function
*/

