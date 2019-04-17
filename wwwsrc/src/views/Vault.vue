<template>
  <div class="vault">
    <div class="row">
      <vaultKeeps v-for="keep in vaultKeeps" :keep="keep" :vaultId="vaultId"></vaultKeeps>
    </div>
  </div>
</template>

<script>
  import vaultKeeps from "@/components/vaultKeeps.vue"
  export default {
    name: "vault",
    props: ["vaultId"],
    mounted() {

      // debugger
      this.$store.dispatch('getVaultKeeps', this.$route.params.vaultId)

    },
    data() {
      return {}
    },
    computed: {
      vaultKeeps() {
        return this.$store.state.vaultKeeps
      }
    },
    methods: {},
    components: {
      vaultKeeps
    }
  }
</script>