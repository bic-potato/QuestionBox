/*
 * @Author: ZuoXichen
 * @Date: 2022-11-03 17:19:43
 * @LastEditTime: 2022-11-06 20:56:11
 * @LastEditors: ZuoXichen
 * @Description:
 */
import { createRouter, RouteRecordRaw, createWebHistory } from "vue-router";
import HomePage from "./App.vue";
import QuestionPage from"./components/Question.vue";
import NewQuestion from"./components/NewQuestion.vue";

const routes: Array<RouteRecordRaw> = [
  { path: "/", name: "home", component: HomePage },
  { path: "/question/:gid", name: "question", component: QuestionPage },
  { path: "/ask-new", name: "new", component: NewQuestion },
];

const vuerouter = createRouter({
  history: createWebHistory(),
  routes,
});

export default vuerouter;
