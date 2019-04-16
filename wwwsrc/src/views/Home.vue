<template>
  <div class="home">
    <h1>Welcome Home</h1>
    <div class="row">
      <publicKeeps v-for="keep in publicKeeps" :keep="keep"></publicKeeps>
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