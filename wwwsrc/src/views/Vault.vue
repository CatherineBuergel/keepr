<template>
  <div class="vault container">
    <div class="row">
      <div class="col-12 text-center mt-4" v-if="vaultKeeps.length == 0">
        <h1 class="pink-text">This Vault Is Empty</h1>
      </div>
      <div class="card-columns mt-2">
        <vaultKeeps v-for="keep in vaultKeeps" :keep="keep" :vaultId="vaultId"></vaultKeeps>
      </div>
    </div>
  </div>
</template>

<script>
  import vaultKeeps from "@/components/vaultKeeps.vue"
  export default {
    name: "vault",
    props: ["vaultId"],
    mounted() {
      this.$store.dispatch('getVaultKeeps', this.$route.params.vaultId)

    },
    data() {
      return {}
    },
    computed: {
      vaultKeeps() {
        return this.$store.state.vaultKeeps
      },


    },
    methods: {},
    components: {
      vaultKeeps
    }
  }
</script>
<style>
  .pink-text {
    color: #f30067;
    text-shadow: -1px 0px 1px #444444;
  }
</style>