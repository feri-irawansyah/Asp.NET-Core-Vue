<script setup>
import { ref, watchEffect } from 'vue';

let data = ref([]);

watchEffect(async () => {
    const res = await fetch('/api/WeatherForecast');
    data.value = await res.json();
})

</script>

<template>
    <div class="about">
        <h1>This is an about page</h1>
        <h1>
            This is an about page
        </h1>
        <ul>
            <li v-for="item in data">
                {{ item.summary }}
            </li>
        </ul>
    </div>
</template>

<style>
@media (min-width: 1024px) {
    .about {
        min-height: 100vh;
        display: flex;
        align-items: start;
        flex-direction: column;
        justify-content: center;
    }
}
</style>
