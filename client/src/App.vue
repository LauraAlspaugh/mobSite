<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer class="bg-light text-dark">
    <p class="m-5 fs-5"><i class="mdi mdi-copyright"></i> 2023 by Laura Alspaugh.</p>
  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}

body {
  background-image: url("https://www.figma.com/file/D6GwKeWX8ENfrS8eqvHRUu/Mobs?type=design&node-id=108-3&mode=design&t=SXst09xG8LAhbC0t-4");
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
