import Vue from 'vue'

export const APP_GETTERS = {
  IS_LOGGED: 'isLogged',
  IS_ADMIN: 'isAdmin',
  TOKEN: 'token'
}

export const APP_MUTATIONS = {
  LOGIN: 'login',
  LOGOUT: 'logout'
}

export const APP_ACTIONS = {
  LOGIN: 'login'
}

export const state = () => ({
  user: {
    is_admin: true,
    token: undefined
  }
})

export const getters = {
  [APP_GETTERS.IS_ADMIN]: (state) => {
    return state.user.is_admin
  },
  [APP_GETTERS.IS_LOGGED]: (state) => {
    return state.user.token !== undefined
  },
  [APP_GETTERS.TOKEN]: (state) => {
    return state.user.token
  }
}

export const mutations = {
  [APP_MUTATIONS.LOGIN]: (state, { user }) => {
    Vue.set(state, 'user', user)
  },
  [APP_MUTATIONS.LOGOUT]: (state) => {
    Vue.set(state, 'user', {})
  }
}
