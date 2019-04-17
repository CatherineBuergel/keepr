<template>
  <div class="dashboard background">
    <div class="row">
      <createVaultForm></createVaultForm>
      <createKeepForm></createKeepForm>

    </div>
    <div class="row">

      <div class="col-12 text-center">
        <h4 v-if="!showCurrent" class="text-center d-flex justify-content-around"><span class="pointer font" :class="showKeeps ? 'selected' : ''"
            @click="showKeeps = true">My Keeps</span> <span class="pointer font" :class="!showKeeps ? 'selected' : ''"
            @click="showKeeps = false">My
            Vaults</span></h4>
      </div>
      <personalKeeps v-if="showKeeps" v-for="keep in personalKeeps" :keep="keep"></personalKeeps>
      <vaults v-if="!showKeeps" v-for="vault in vaults" :vault="vault"></vaults>
    </div>
  </div>
</template>

<script>
  import createKeepForm from "@/components/createKeepForm.vue"
  import personalKeeps from "@/components/PersonalUserKeeps.vue"
  import createVaultForm from "@/components/createVaultForm.vue"
  import vaults from "@/components/Vaults.vue"


  export default {
    name: "dashboard",
    props: [],
    data() {
      return {
        showCurrent: false,
        showKeeps: true
      }
    },
    mounted() {
      //blocks users not logged in
      this.$store.dispatch("authenticate")

      // this.$store.dispatch("getPersonalKeeps")
    },
    computed: {
      personalKeeps() {
        return this.$store.state.personalKeeps
      },
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {

    },
    components: {
      createKeepForm,
      personalKeeps,
      createVaultForm,
      vaults
    }
  }
</script>
<style>
  .pointer {
    cursor: pointer;
  }

  .on-top {
    z-index: 10
  }

  .selected {
    border-bottom: solid 5px #13abc4;
  }
</style>