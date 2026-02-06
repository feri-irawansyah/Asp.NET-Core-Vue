<script setup>
import { ref, watchEffect } from 'vue';

let data = ref([]);
const mode = __MODE__;

watchEffect(async () => {
    const response = await fetch('/api/weather/list');
    const result = await response.json();
    data.value = result.data;
});
</script>

<template>
    <div class="about">
        <h1>This is an about page {{ mode }}</h1>
        <ul>
            <li v-for="d in data" :key="d.date">
                <h2>{{ d.summary }}</h2>
                <p>{{ d.date }}</p>
                <p>{{ d.temperatureC }}</p>
            </li>
        </ul>
    </div>
</template>

<style>
@media (min-width: 1024px) {
    .about {
        min-height: 100vh;
        display: flex;
        flex-direction: column;
        justify-content: center;
    }
}
</style>
