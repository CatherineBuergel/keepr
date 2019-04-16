import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let auth = Axios.create({
  baseURL: baseUrl + "account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    publicKeeps: [],
    personalKeeps: [],
    vaults: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setPublicKeeps(state, data) {
      state.publicKeeps = data
    },
    setPersonalKeeps(state, data) {
      state.personalKeeps = data
    },
    setVaults(state, data) {
      state.vaults = data
    }
  },
  actions: {
    //#region AUTH
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          // router.push({ name: 'home' })
          dispatch('getPublicKeeps')
          dispatch('getPersonalKeeps')
          dispatch('getVaults')
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logOut({ commit, dispatch }) {
      auth.delete('Logout')
        .then(res => {
          router.push({ name: 'login' })
          let data = {}
          commit('setUser', data)
        })
    },
    //#endregion
    //#region Keeps
    getPublicKeeps({ commit, dispatch }) {
      api.get('/keeps')
        .then(res => {
          console.log("got keeps")
          commit('setPublicKeeps', res.data)
        })
    },
    createKeep({ commit, dispatch }, payload) {
      api.post('/keeps', payload)
        .then(res => {
          console.log(res.data);
          dispatch('getPersonalKeeps')
        })
    },
    getPersonalKeeps({ commit, dispatch }) {
      api.get('keeps/user/personal')
        .then(res => {
          commit('setPersonalKeeps', res.data)
        })
    },
    deleteKeep({ commit, dispatch }, payload) {

      api.delete('keeps/' + payload)
        .then(res => {
          dispatch('getPersonalKeeps')
        })
    },
    //#endregion

    //#region VAULTS
    getVaults({ commit, dispatch }) {
      api.get('vault')
        .then(res => {
          commit('setVaults', res.data)
        })
    },
    createVault({ commit, dispatch }, payload) {

      api.post('vault', payload)
        .then(res => {
          console.log(res.data)
          dispatch('getVaults')
        })
    },
    deleteVault({ commit, dispatch }, payload) {
      api.delete('vault/' + payload)
        .then(res => {
          dispatch('getVaults')
        })
    }
    //#endregion
  }
})
