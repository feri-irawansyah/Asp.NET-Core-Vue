import './assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'

console.log('🚀 Running in Broker', __MODE__)

const app = createApp(App)

app.use(createPinia())
app.use(router)

app.mount('#app')
