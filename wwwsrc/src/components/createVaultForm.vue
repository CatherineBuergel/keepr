<template>
  <div class="col-12 createVault centerStuff mt-5">
    <button v-if="!showForm" @click="showForm = !showForm" class="btn button-color-go my-3">Create a Vault</button>
    <form v-else @submit.prevent="createVault" class="form-inline mb-5 centerStuff">
      <input class="form-control form-border mx-1" type="text" placeholder="Vault Name" v-model="newVault.name"
        required>
      <input class="form-control form-border mx-1" type="text" placeholder="Vault Description" v-model="newVault.description"
        required>
      <button type="submit" class="btn button-color-go my-1 mx-1" @click="showForm = !showForm">Submit</button>
      <button class="btn button-color-stop my-1 mx-1" @click="showForm = !showForm">Cancel</button>

    </form>
  </div>
</template>

<script>
  export default {
    name: "createVault",
    props: [],
    data() {
      return {
        newVault: {

        },
        showForm: false
      }
    },
    computed: {},
    methods: {
      createVault() {
        this.$store.dispatch('createVault', this.newVault)
      }
    },
    components: {}
  }
</script>
<style>
  .centerStuff {
    display: flex;
    flex-direction: row;
    justify-content: center;
  }
</style>