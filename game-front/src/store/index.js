import Vue from 'vue'

export const APP_GETTERS = {
  IS_LOGGED: 'isLogged',
  IS_DIRECTOR: 'isDirector',
  PLAYER: 'player',
  TOKEN: 'token',
  DICETABLE: 'diceTable',
  ACTUALSTATS: 'actualStats'
}

export const APP_MUTATIONS = {
  LOGIN: 'login',
  LOGOUT: 'logout',
  DICEIN: 'diceIn',
  DICEEMPTY: 'diceEmpty',
  ACTUALSTATS: 'actualStats'
}

export const APP_ACTIONS = {
  LOGIN: 'login'
}

export const state = () => ({
  user: {
    is_director: false,
    token: undefined,
    player: undefined
  },
  diceTable: [],
  actualStats: []
})

export const getters = {
  [APP_GETTERS.IS_DIRECTOR]: (state) => {
    return state.user.is_director
  },
  [APP_GETTERS.IS_LOGGED]: (state) => {
    return state.user.token !== undefined
  },
  [APP_GETTERS.TOKEN]: (state) => {
    return state.user.token
  },
  [APP_GETTERS.PLAYER]: (state) => {
    return state.user.player
  },
  [APP_GETTERS.DICETABLE]: (state) => {
    return state.diceTable
  },
  [APP_GETTERS.ACTUALSTATS]: (state) => {
    return state.actualStats
  }
}

export const mutations = {
  [APP_MUTATIONS.LOGIN]: (state, { user }) => {
    Vue.set(state, 'user', user)
  },
  [APP_MUTATIONS.LOGOUT]: (state) => {
    Vue.set(state, 'user', {})
  },
  [APP_MUTATIONS.DICEEMPTY]: (state) => {
    Vue.set(state, 'diceTable', [])
  },
  [APP_MUTATIONS.DICEIN]: (state, val) => {
    state.diceTable.push(val)
  },
  [APP_MUTATIONS.ACTUALSTATS]: (state) => {
    Vue.set(state, 'actualStats', [])
  }
}
