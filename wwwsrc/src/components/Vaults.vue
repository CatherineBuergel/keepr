<template>
  <div class="vaults mt-2">
    <div class="card vault-border">
      <div class="card-body my-2">
        <h5 class="card-title">Vault: {{vault.name}}</h5>
        <p class="card-text">Description: {{vault.description}}</p>
        <i class="fas fa-trash-alt mx-1" @click="deleteVault(vault.id)"></i>
        <button class="btn button-color-go" @click="pushToVault(vault.id)">View Vault</button>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "vaults",
    props: ["vault"],
    data() {
      return {}
    },
    computed: {},
    methods: {
      deleteVault(id) {

        this.$store.dispatch('deleteVault', id)
      },

      pushToVault(id) {
        this.$router.push({ name: 'vault', params: { vaultId: id } })
      }
    },
    components: {

    }
  }
</script>
<style>
  .vault-border {
    border-color: #444444;
    border-radius: 10%;
    overflow: hidden;
  }
</style>