<template id="login-form">
  <div>
    <b-form @submit="onSubmit" @reset="onReset" v-if="show">
      <b-form-group
        id="input-group-1"
        label="Email address:"
        label-for="input-1"
      >
        <b-form-input
          id="input-1"
          v-model="form.email"
          type="email"
          required
          placeholder="Enter email"
        ></b-form-input>
      </b-form-group>
      <b-form-group id="input-group-2" label="Password:" label-for="input-2" @submit.stop.prevent>
          <b-input type="password" id="text-password" v-model="form.password" aria-describedby="password-help-block"></b-input>
      </b-form-group>
      <b-button type="submit" variant="primary">Submit</b-button>
    </b-form>
    
  </div>
</template>

<script>

import { login, sampleRequest } from '@/service'
import { APP_GETTERS } from '@/store'

export default {
  props: {
  },
  components: {
  },
  data () {
    return {
      form: {
        email: 'root@root.com',
        password: 'root123',
      },
      show: true
    }
  },
  computed: {
  },
  methods :{
    onSubmit(evt) {
      evt.preventDefault()
      let email = this.form.email
      let password = this.form.password
      return login({ email, password }).then((result) => {
        console.log(result)
        console.log('hemos logeado, probamos una petición con token')
        sampleRequest().then((resultRequest) => {
          console.log(resultRequest)
        })
      })
    },
    onReset(evt) {
      evt.preventDefault()
      // Reset our form values
      this.form.email = ''
      this.form.password = ''
      // Trick to reset/clear native browser form validation state
      this.show = false
      this.$nextTick(() => {
        this.show = true
      })
    }
  },
  watch: {
  }

}
</script>
<style scoped>
</style>