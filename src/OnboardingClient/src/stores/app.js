// store/appStore.js
import { ref } from 'vue'
import { defineStore } from 'pinia'

export const useAppStore = defineStore('app', () => {
    const appInfo = ref({})
    const loaded = ref(false) // flag kalau sudah fetch

    // Action fetch sekali
    const fetchAppInfo = async () => {
        if (loaded.value) return appInfo.value // kalau sudah fetch, return langsung

        try {
            const res = await fetch('/api')
            appInfo.value = await res.json()
            loaded.value = true
        } catch (err) {
            console.error('Gagal fetch appInfo', err)
        }
        return appInfo.value
    }

    return { appInfo, fetchAppInfo }
})
