<template>
  <div class="vaultKeeps">
    <div class="card card-border card-img-size">
      <img class="card-img-top" :src="keep.img" alt="Card image cap">
      <div class="card-body">
        <h5 class="card-title">{{keep.name}}</h5>
        <p class="card-text">{{keep.description}}</p>
        <i class="fas fa-trash-alt" @click="deleteFromVault(keep.id, vaultId)"></i>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "vaultKeeps",
    props: ["keep", "vaultId"],
    data() {
      return {}
    },
    computed: {

    },
    methods: {
      deleteFromVault(keepId, vaultId) {
        this.$store.dispatch('deleteFromVault', { keepId: keepId, vaultId: vaultId })
      }
    },
    components: {}
  }
</script>