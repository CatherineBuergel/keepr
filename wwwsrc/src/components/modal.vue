<template>

  <div class="my-modal-backdrop">
    <div class="my-modal">
      <header class="my-modal-header">
        <slot name="header">
          this is where the header stuff goes, will be name of keeps
        </slot>
      </header>
      <section class="my-modal-body">
        <slot name="content">
          this is where all of the cards will go
        </slot>
      </section>
      <footer class="my-modal-footer">
        <button type="button" class="btn button-color-stop" @click="close">
          Close
        </button>
      </footer>
    </div>
  </div>
</template>

<script>
  export default {
    name: "modal",
    props: [],
    data() {
      return {}
    },
    computed: {},
    methods: {
      close() {
        this.$emit('closeModal')
      }
    },
    components: {}
  }
</script>

<style>
  .my-modal-backdrop {
    position: fixed;
    z-index: 3;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    background-color: rgba(0, 0, 0, 0.3);
    display: flex;
    justify-content: center;
    align-items: center;
  }

  .my-modal {
    background: #eaeaea;
    box-shadow: 2px 2px 20px 1px;
    overflow-x: auto;
    display: flex;
    flex-direction: column;
    width: 60%;
    max-height: 90%;
  }

  .my-modal-header,
  .my-modal-footer {
    padding: 15px;
    display: flex;

  }

  .my-modal-header {
    background-color: #444444;
    border-bottom: 1px solid #eaeaea;
    color: #eaeaea;
    justify-content: center;
    font-weight: bold;
    font-size: 2em;
  }

  .my-modal-footer {
    border-top: 1px solid #eaeaea;
    justify-content: center;
    background-color: #444444;


  }

  .my-modal-body {
    margin: 10px, auto
  }
</style>