import { fileURLToPath, URL } from 'node:url'

import { defineConfig, loadEnv } from 'vite'
import vue from '@vitejs/plugin-vue'
import vueDevTools from 'vite-plugin-vue-devtools'

// https://vite.dev/config/
export default ({ mode }) => {
    // load semua env dari file .env*.js
    const env = loadEnv(mode, process.cwd(), 'VITE_')

    // VITE_MODE bisa dari env, kalau gaada default ke ''
    const MODE = env.VITE_MODE || ''

    return defineConfig({
        plugins: [vue(), vueDevTools()],
        resolve: {
            alias: {
                '@': fileURLToPath(new URL('./src', import.meta.url)),
            },
        },
        server: {
            proxy: {
                '/api': {
                    target: 'http://localhost:5162',
                    changeOrigin: true,
                    rewrite: (path) => path.replace(/^\/api/, ''),
                },
            },
        },
        define: {
            __MODE__: JSON.stringify(MODE), // global variable di frontend
        },
    })
}
