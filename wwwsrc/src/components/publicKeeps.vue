<template>
  <div class="publicKeeps">
    <publicKeepModal v-if="showKeepModal" @closemodal="closeModal" :keep="keep"></publicKeepModal>
    <div class="col-3 mt-2">
      <div class="card card-border" @click="openKeepModal" style="width: 18rem;">
        <img class="card-img-top card-img-size" :src="keep.img" alt="Card image cap">
        <div class="card-body">
          <h5 class="card-title">{{keep.name}}</h5>
          <p class="card-text">{{keep.description}}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import publicKeepModal from "@/components/publicKeepModal.vue"

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
    computed: {},
    methods: {
      openKeepModal() {
        this.showKeepModal = true
      },
      closeModal() {
        this.showKeepModal = false
      }
    },
    components: {
      publicKeepModal
    }
  }
</script>