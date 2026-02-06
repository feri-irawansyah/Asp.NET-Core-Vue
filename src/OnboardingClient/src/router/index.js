import { useAppStore } from '@/stores/app'
import HomeView from '@/views/HomeView.vue'
import { createRouter, createWebHistory } from 'vue-router'

const routes = [
    {
        path: '/',
        name: 'home',
        component: HomeView,
    },
    {
        path: '/about',
        name: 'about',
        component: () => import('../views/AboutView.vue'),
    },
]

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes,
})

router.beforeEach((to, from, next) => {
    const appStore = useAppStore()
    const brokerId = appStore.appInfo.brokerId || 'Default'

    if (brokerId === 'Default' && to.name === 'about') {
        next({ name: 'home' })
    } else {
        next()
    }
})

export default router
