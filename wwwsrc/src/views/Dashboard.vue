<template>
  <div class="dashboard">
    <div class="row">
      <createKeepForm></createKeepForm>
    </div>
    <div class="row">
      <personalKeeps v-for="keep in personalKeeps" :keep="keep"></personalKeeps>
    </div>
  </div>
</template>

<script>
  import createKeepForm from "@/components/createKeepForm.vue"
  import personalKeeps from "@/components/PersonalUserKeeps.vue"
  export default {
    name: "dashboard",
    props: [],
    data() {
      return {}
    },
    mounted() {
      //blocks users not logged in
      this.$store.dispatch("authenticate")
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
      // this.$store.dispatch("getPersonalKeeps")
    },
    computed: {
      personalKeeps() {
        return this.$store.personalKeeps
      }
    },
    methods: {},
    components: {
      createKeepForm,
      personalKeeps
    }
  }
</script>