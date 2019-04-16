<template>
  <div class="keepModal">
    <modal @closemodal="$emit('closemodal')">
      <span slot="header">This is the keep header</span>
      <span slot="content">
        <div class="col-3">
          <div class="card" style="width: 18rem;">
            <img class="card-img-top" :src="keep.img" alt="Card image cap">
            <div class="card-body">
              <h5 class="card-title">{{keep.name}}</h5>
              <p class="card-text">{{keep.description}}</p>
              <p>{{keep.isPrivate ? "Private" : "Public"}}</p>
              <i class="fas fa-trash-alt"></i>
              <i class="fas fa-plus-square"></i>
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
    computed: {},
    methods: {},
    components: {
      modal
    }
  }
</script>