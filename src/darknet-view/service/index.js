import axios from 'axios'
import { HOST } from '@/environment'

const httpClient = axios.create()

const requestHeader = function () {
  return {
    'Content-Type': 'application/json',
    'DYNAMICLOADER_TOKEN': $nuxt.$store.getters[APP_GETTERS.TOKEN]
  }
}

export const login = async ({ email, password }) => {
  console.log('lallala')
  const response = await httpClient({
    method: 'post',
    url: '/users/login',
    baseURL: 'http://localhost:50205/api',
    headers: {
      'accept': 'application/json',
      'Content-Type': 'application/json'
    },
    data: {
      'email': email,
      'password': password
    }
  })
  return response.data
}

export const sample = () => {
  console.log('sample')
}

