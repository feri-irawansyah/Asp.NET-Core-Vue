import './assets/css/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'
import { useAppStore } from './stores/app'

async function bootstrap() {
    const app = createApp(App)
    const pinia = createPinia()
    app.use(pinia)

    // Fetch app info dulu sebelum mount
    const appStore = useAppStore(pinia)
    await appStore.fetchAppInfo()

    if (appStore.appInfo.brokerId === 'CP') {
        await import('./assets/css/cp/main.css')
    }

    app.use(router)

    app.mount('#app')
}

bootstrap()
