<template>
  <v-app>

<header-bar></header-bar>
    <v-content>
      <v-container fluid>
        <router-view></router-view>
      </v-container>
    </v-content>
  </v-app>
</template>

<script>
  import { Component, Vue } from "vue-property-decorator";
import Header from "./components/Header.vue";
  
  @Component ({
    components: {
        'header-bar': Header

  }
  })
export default class App extends Vue  {
  data() {
    return {};
  }
};
</script>
