<template>
    <v-toolbar app>
            <v-toolbar-side-icon></v-toolbar-side-icon>
    <v-spacer></v-spacer>
            <v-icon>search</v-icon>
      <v-toolbar-title class="headline text-uppercase">
      </v-toolbar-title>
    </v-toolbar>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component({
  components: {
  }
})
export default class Header extends Vue {}
</script>