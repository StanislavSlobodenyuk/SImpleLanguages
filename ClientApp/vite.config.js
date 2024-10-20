import { defineConfig } from 'vite'
import React from '@vitejs/plugin-react'
import Inspect from 'vite-plugin-inspect'
import { ViteImageOptimizer } from 'vite-plugin-image-optimizer'

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [
        React(),
        Inspect(),
        ViteImageOptimizer({

        }),
    ],
    css: {
        preprocessorOptions: {
            sass: {
            },
        },
    }
})
