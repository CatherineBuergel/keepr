<template>
  <div class="personalKeeps">
    <keepModal v-if="showKeepModal" @closemodal="closeModal" :keep="keep"></keepModal>
    <div class="col-3">
      <div class="card" @click="openKeepModal" style="width: 18rem;">
        <img class="card-img-top" :src="keep.img" alt="Card image cap">
        <div class="card-body">
          <h5 class="card-title">{{keep.name}}</h5>
          <p class="card-text">{{keep.description}}</p>
          <p>{{keep.isPrivate ? "Private" : "Public"}}</p>
          <i class="fas fa-trash-alt" @click="deleteKeep(keep.id)"></i>
          <i class="fas fa-plus-square"></i>
        </div>
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