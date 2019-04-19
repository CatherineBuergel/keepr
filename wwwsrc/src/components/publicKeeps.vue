<template>
  <div class="publicKeeps">
    <keepModal v-if="showKeepModal" @closeModal="closeModal" :keep="keep"></keepModal>
    <div class="mt-2">
      <div class="card shadow p-3 card-border" @click="openKeepModal(keep, user.id)">
        <img class="card-img-top card-img-size" :src="keep.img" alt="Card image cap">
        <div class="card-body">
          <h5 class="card-title">{{keep.name}}</h5>
          <p class="card-text">{{keep.description}}</p>
          <span class="d-flex flex-row justify-content-center">
            <i class="far fa-eye mt-1 mr-1"></i>
            <p>{{keep.views}}</p>
          </span>
          <p>Shares: {{keep.shares}}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  // import publicKeepModal from "@/components/publicKeepModal.vue"
  import keepModal from "@/components/keepModal.vue"
  export default {
    name: "publicKeeps",
    props: ["keep"],
    data() {
      return {
        showKeepModal: false
      }
    },
    mounted() {

    },
    computed: {
      user() {
        return this.$store.state.user
      }
    },
    methods: {
      openKeepModal(keep, uid) {
        this.showKeepModal = true
        if (keep.userId != uid) {
          this.increaseViewCount(keep.id)
        }
      },
      closeModal() {
        this.showKeepModal = false
      },
      increaseViewCount(id) {

        this.$store.dispatch('increaseViewCount', id)
      }
    },
    components: {
      // publicKeepModal
      keepModal
    }
  }
</script>