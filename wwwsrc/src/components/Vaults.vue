<template>
  <div class="vaults col-3 mt-2">

    <div class="card">
      <div class="card-body my-2">
        <h5 class="card-title">Vault: {{vault.name}}</h5>
        <p class="card-text">Description: {{vault.description}}</p>
        <i class="fas fa-trash-alt mx-1" @click="deleteVault(vault.id)"></i>
        <button class="btn btn-danger" @click="pushToVault(vault.id)">View Vault</button>
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