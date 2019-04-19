<template>
  <div class="keepModal">
    <modal @closeModal="$emit('closeModal')">
      <span slot="header">{{keep.name}}</span>
      <span slot="content" class="d-flex justify-content-center">
        <div class="col-4">
          <div class="card shadow p-3">
            <img class="card-img-top" :src="keep.img" alt="Card image cap">
            <div class="card-body">
              <h5 class="card-title">{{keep.name}}</h5>
              <p class="card-text">{{keep.description}}</p>
              <p v-if="user.id">{{keep.isPrivate ? "Private" : "Public"}}</p>
              <span class="d-flex flex-row justify-content-center">
                <i class="far fa-eye mt-1 mr-1"></i>
                <p class="mx-1">{{keep.views}}</p>
                <i v-if="user.id == keep.userId" class="fas fa-trash-alt mx-1" @click="deleteKeep(keep.id)"></i>
              </span>
              <p>Shares: {{keep.shares}}</p>
              <div v-if="user.id" class="dropdown">
                <button class="btn btn-secondary dropdown-toggle button-color-go " type="button" id="dropdownMenuButton"
                  data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                  Add to Vault
                </button>
                <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                  <a v-for="vault in vaults" class="dropdown-item" @click="addToVault(keep.id, vault.id)">{{vault.name}}</a>
                  <a class="dropdown-item" href="#">Cancel</a>
                </div>
              </div>
            </div>
          </div>
        </div>
      </span>
    </modal>
  </div>
</template>

<script>
  import modal from "@/components/modal.vue"
  export default {
    name: "keepModal",
    props: ["keep"],
    data() {
      return {}
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      },
      user() {
        return this.$store.state.user
      }
    },
    methods: {
      addToVault(keepId, vaultId) {
        this.$store.dispatch('addToVault', { keepId: keepId, vaultId: vaultId })
      },
      deleteKeep(id) {
        this.$store.dispatch("deleteKeep", id)
      }
    },
    components: {
      modal,

    }
  }
</script>