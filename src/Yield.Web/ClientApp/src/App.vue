<template>
  <v-app>
    <v-toolbar app>
      <v-toolbar-title class="headline text-uppercase">
        <div>
          <span>Yield</span>
            <span class="font-weight-light">Allotmenteering</span>
            <router-link to="/home">
              <span class="font-weight-light">
                Home
              </span>
            </router-link>
            <router-link to="/bed">
            <span class="font-weight-light">
              Bed
            </span>
            </router-link>
        </div>
      </v-toolbar-title>
    </v-toolbar>

    <v-content>
      <v-container fluid>
        <router-view></router-view>
      </v-container>
    </v-content>
  </v-app>
</template>

<script>
export default {
  name: "App",
  components: {},
  data() {
    return {};
  }
};
</script>
