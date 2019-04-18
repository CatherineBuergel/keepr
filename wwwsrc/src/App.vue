<template>
  <div id="app">
    <nav class="navbar navbar-expand-lg navbar-dark bgc navbar-color">
      <a class="navbar-brand logo" @click="goHome"><img class="k-logo" src="@/assets/K-Logo.png" alt=""></a>
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
    font-family: 'Varela Round', sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #000000;
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #000000;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }

  body {
    background-color: #eaeaea;
    /* height: 100vh; */
  }

  .navbar-color {
    background-color: #444444;
  }

  .nav-item {
    color: #f30067;
  }

  .button-color-stop {
    background-color: #f30067;
    color: #eaeaea;
    border-color: #444444;
    font-weight: bold;
  }

  .button-color-go {
    background-color: #00d1cd;
    color: #eaeaea;
    border-color: #444444;
    font-weight: bold;

  }

  .k-logo {
    max-height: 55px;
    cursor: pointer;
    border-radius: 40%;
  }

  .card-border {
    border-color: #f30067;
    border-radius: 10%;
    overflow: hidden;
  }

  .card-img-size {
    max-width: 100%;
    object-fit: contain;
  }

  a {
    cursor: pointer;
  }
</style>