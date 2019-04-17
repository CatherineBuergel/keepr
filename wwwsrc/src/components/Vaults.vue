<template>
  <div class="vaults col-3">
    <div class="card mx-1 my-1" style="width: 18rem;">
      <div class="card-body">
        <h5 class="card-title">{{vault.name}}</h5>
        <p class="card-text">{{vault.description}}</p>
        <i class="fas fa-trash-alt" @click="deleteVault(vault.id)"></i>
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