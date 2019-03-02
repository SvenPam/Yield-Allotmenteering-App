<template>
    <div>
        {{id}}
    </div>
</template>
<script lang="ts">
import Vue from 'vue'
import { Prop } from 'vue-property-decorator';

export default class BedSummary extends Vue{
    @Prop() 
    private Bed bed;
}
</script>

