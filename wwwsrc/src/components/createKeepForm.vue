<template>
  <div class="createKeep">
    <form @submit.prevent="createKeep" class="form-inline mb-5">
      <input class="form-control" type="text" placeholder="Keep Name" v-model="newKeep.name" required>
      <input class="form-control" type="text" placeholder="Keep Description" v-model="newKeep.description" required>
      <input class="form-control" type="text" placeholder="Keep Image" v-model="newKeep.img">
      <input class="form-check-input" type="checkbox" value="true" v-model="newKeep.isPrivate" id="defaultCheck1">
      <label class="form-check-label" for="defaultCheck1">
        Private
      </label>
      <button type="submit" class="btn btn-success">Create Keep</button>
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

        }
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