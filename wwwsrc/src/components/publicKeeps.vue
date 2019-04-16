<template>
  <div class="publicKeeps">
    <div class="col-3">
      <div class="card" style="width: 18rem;">
        <img class="card-img-top" src="" alt="Card image cap">
        <div class="card-body">
          <h5 class="card-title">{{keep.name}}</h5>
          <p class="card-text">{{keep.description}}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "publicKeeps",
    props: ["keep"],
    data() {
      return {}
    },
    mounted() {

    },
    computed: {},
    methods: {},
    components: {}
  }
</script>