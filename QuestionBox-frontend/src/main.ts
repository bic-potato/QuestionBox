/*
 * @Author: ZuoXichen
 * @Date: 2022-11-03 16:15:54
 * @LastEditTime: 2022-11-06 10:00:12
 * @LastEditors: ZuoXichen
 * @Description: 
 */
import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import vuerouter from './routes'
import 'vfonts/Lato.css'
import 'vfonts/FiraCode.css'

createApp(App).use(vuerouter).mount('#app')
