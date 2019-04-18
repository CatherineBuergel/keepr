<template>
  <div class="col-12 createKeep centerStuff">
    <button v-if="!showForm" @click="showForm = !showForm" class="btn button-color-go my-3">Create Keep</button>
    <form v-else @submit.prevent="createKeep" class="form-inline mb-5 centerStuff">
      <input class="form-control form-border mx-1" type="text" placeholder="Keep Name" v-model="newKeep.name" required>
      <input class="form-control form-border mx-1" type="text" placeholder="Keep Description" v-model="newKeep.description"
        required>
      <input class="form-control form-border mx-1" type="text" placeholder="Keep Image" v-model="newKeep.img">
      <input class="form-check-input mx-1" type="checkbox" value="true" v-model="newKeep.isPrivate" id="defaultCheck1">
      <label class="form-check-label mx-1" for="defaultCheck1">
        Private
      </label>
      <button type="submit" class="btn button-color-go my-1 mx-1" @click="showForm = !showForm">Submit</button>
      <button class="btn button-color-stop my-1 mx-1" @click="showForm = !showForm">Cancel</button>
    </form>
  </div>
</template>

<script>
  export default {
    name: "createKeep",
    props: [],
    data() {
      return {
        newKeep: {

        },
        showForm: false
      }
    },
    computed: {},
    methods: {
      createKeep() {
        this.$store.dispatch('createKeep', this.newKeep)
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

  .form-border {
    border-color: #444444;
  }
</style>