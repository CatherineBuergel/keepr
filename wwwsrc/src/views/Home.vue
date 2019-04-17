<template>
  <div class="home background">
    <h1>Public landing page</h1>
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