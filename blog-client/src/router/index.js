import Vue from "vue";
import VueRouter from "vue-router";

import HomePage from "../router/HomePage.vue";
import TechnicalNote from "../router/TechnicalNote.vue";
import Recipe from "../router/Recipe.vue";
import Interview from "../router/Interview.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: HomePage,
  },
  {
    path: "/SomethingWrong",
    name: "TechnicalNote",
    component: TechnicalNote,
  },
  {
    path: "/Recipe",
    name: "Recipe",
    component: Recipe,
  },
  {
    path: "/Interview",
    name: "Interview",
    component: Interview,
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
