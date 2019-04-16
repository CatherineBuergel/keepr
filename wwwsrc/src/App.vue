<template>
  <div id="app">
    <nav class="navbar navbar-expand-lg navbar-light bgc">
      <a class="navbar-brand logo" @click="goHome">Keepr</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
        aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav mr-auto">
          <li class="nav-item">
            <a class="nav-link" @click="goHome" data-toggle="collapse" data-target="#navbarSupportedContent">Home</a>
          </li>
          <li v-if="!user.id" class="nav-item">
            <a class="nav-link" @click="login" data-toggle="collapse" data-target="#navbarSupportedContent">Login</a>
          </li>
          <li v-else class="nav-item">
            <a class="nav-link" @click="logOut" data-toggle="collapse" data-target="#navbarSupportedContent">Logout</a>
          </li>
          <li v-if="user.id" class="nav-item">
            <a class="nav-link" @click="goToDashboard" data-toggle="collapse" data-target="#navbarSupportedContent">Dashboard
            </a>
          </li>
        </ul>
      </div>
    </nav>
    <router-view />
  </div>
</template>
<script>
  import router from './router'
  export default {
    name: 'App',
    mounted() {
      //Authenticate on startup
      this.$store.dispatch('authenticate')
    },

    methods: {
      logOut() {
        this.$store.dispatch('logOut')
      },
      goHome() {
        router.push({ name: 'home' })
      },
      goToDashboard() {
        router.push({ name: 'dashboard' })
      },
      login() {
        router.push({ name: 'login' })
      }

    },
    components: {
      router
    },
    computed: {
      user() {
        return this.$store.state.user
      },
      // loggedOut(){
      //   return this.$store.state.user ? true : false
      // }

    }
  }
</script>
<style>
  #app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }
</style>