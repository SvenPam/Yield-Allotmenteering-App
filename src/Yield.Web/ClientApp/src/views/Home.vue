<template>
  <div class="home">
    <ul>
      <li v-for="bed in beds" :key="bed.id">
        {{ bed.id }}
      </li>
    </ul>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import BedRepository from "../repositories/BedRepository";
import Bed from "../models/Bed";


@Component

export default class Home extends Vue {

  private readonly bedRepository = new BedRepository();
  private beds: Bed[] = [];


  private async created() {
    this.beds = await this.bedRepository.getBeds("", "");
}

}
</script>
