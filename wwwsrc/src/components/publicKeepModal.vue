<template>
  <div class="publicKeepModal">
    <modal @closemodal="$emit('closemodal')">
      <span slot="header">{{keep.name}}</span>
      <span slot="content" class="d-flex justify-content-center">
        <div class="col-6">
          <div class="card shadow p-3">
            <img class="card-img-top" :src="keep.img" alt="Card image cap">
            <div class="card-body">
              <h5 class="card-title">{{keep.name}}</h5>
              <p class="card-text">{{keep.description}}</p>
              <span class="d-flex flex-row justify-content-center">
                <i class="far fa-eye mt-1 mr-1"></i>
                <p>{{keep.views}}</p>
              </span>
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