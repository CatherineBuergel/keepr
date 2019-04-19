<template>
  <div class="personalKeeps">
    <keepModal v-if="showKeepModal" @closeModal="closeModal" :keep="keep"></keepModal>
    <div class="card shadow p-3 card-border card-img-size my-2" @click="openKeepModal">
      <img class="card-img-top" :src="keep.img" alt="Card image cap">
      <div class="card-body">
        <h5 class="card-title">{{keep.name}}</h5>
        <p class="card-text">{{keep.description}}</p>
        <p>{{keep.isPrivate ? "Private" : "Public"}}</p>
        <span class="d-flex flex-row justify-content-center">
          <i class="far fa-eye mt-1 mr-1"></i>
          <p class="mx-1">{{keep.views}}</p>
          <i class="fas fa-trash-alt mx-1" @click="deleteKeep(keep.id)"></i>
        </span>
        <p>Shares: {{keep.shares}}</p>
      </div>

    </div>
  </div>
</template>

<script>
  import keepModal from "@/components/keepModal.vue"

  export default {
    name: "personalKeeps",
    props: ["keep"],
    data() {
      return {
        showKeepModal: false
      }
    },
    mounted() { },
    computed: {},
    methods: {
      deleteKeep(id) {
        this.$store.dispatch("deleteKeep", id)
      },
      openKeepModal() {
        this.showKeepModal = true
      },
      closeModal() {
        this.showKeepModal = false
      }
    },
    components: {
      keepModal
    }
  }
</script>