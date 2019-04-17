<template>
  <div class="publicKeepModal">
    <modal @closemodal="$emit('closemodal')">
      <span slot="header">{{keep.name}}</span>
      <span slot="content" class="d-flex justify-content-center">
        <div class="col-4">
          <div class="card" style="width: 18rem;">
            <img class="card-img-top" :src="keep.img" alt="Card image cap">
            <div class="card-body">
              <h5 class="card-title">{{keep.name}}</h5>
              <p class="card-text">{{keep.description}}</p>
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
    name: "publicKeepModal",
    props: ["keep"],
    data() {
      return {}
    },
    computed: {
      vaults() {

        return this.$store.state.vaults
      }
    },
    methods: {

    },
    components: {
      modal,

    }
  }
</script>