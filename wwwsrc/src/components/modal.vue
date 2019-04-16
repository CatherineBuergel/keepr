<template>

  <div class="my-modal-backdrop">
    <div class="my-modal">
      <header class="my-modal-header">
        <slot name="header">
          This is the default tile!

        </slot>
        <button type="button" class="my-btn-close" @click="close">
          x
        </button>
      </header>
      <section class="my-modal-body">
        <slot name="content">
          I'm the default body!
        </slot>
      </section>
      <footer class="my-modal-footer">
        <button type="button" class="my-btn-green" @click="close">
          Close me!
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
        this.$emit('closemodal')
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
    background: #FFFFFF;
    box-shadow: 2px 2px 20px 1px;
    overflow-x: auto;
    display: flex;
    flex-direction: column;
    width: 70%;
    max-height: 95%
  }

  .my-modal-header,
  .my-modal-footer {
    padding: 15px;
    display: flex;
  }

  .my-modal-header {
    border-bottom: 1px solid #eeeeee;
    color: #4AAE9B;
    justify-content: space-between;
  }

  .my-modal-footer {
    border-top: 1px solid #eeeeee;
    justify-content: flex-end;
  }

  .my-modal-body {
    position: relative;
    padding: 20px 10px;
  }

  .my-btn-close {
    border: none;
    font-size: 20px;
    padding: 20px;
    cursor: pointer;
    font-weight: bold;
    color: #4AAE9B;
    background: transparent;
  }

  .my-btn-green {
    color: white;
    background: #4AAE9B;
    border: 1px solid #4AAE9B;
    border-radius: 2px;
  }
</style>