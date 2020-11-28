import Vue from 'vue'
import Router from 'vue-router'
import NotFound from '@/pages/NotFound.vue'
import action from '@/pages/action.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/notfound',
      name: 'notfound',
      component: NotFound
    },
    {
      path: '/action',
      name: 'action',
      component: action
    }
  ]
})