<template>
  <div class="home container">
    <h1>Welcome to Pin - I mean Keepr!</h1>
    <div class="row background">
      <div class="card-columns">
        <publicKeeps v-for="keep in publicKeeps" :keep="keep"></publicKeeps>
      </div>
    </div>

  </div>
</template>

<script>
  import publicKeeps from "@/components/publicKeeps.vue"
  export default {
    name: "home",
    mounted() {
      this.$store.dispatch('getPublicKeeps')
    },

    computed: {
      publicKeeps() {
        return this.$store.state.publicKeeps
      }
    },
    components: {
      publicKeeps
    }
  }

</script>