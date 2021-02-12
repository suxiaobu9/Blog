import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import { BootstrapVue, IconsPlugin } from "bootstrap-vue";
import VueSidebarMenu from "vue-sidebar-menu";
import axios from "axios";
import VueAxios from "vue-axios";
import MarkdownItVue from "markdown-it-vue";
import "markdown-it-vue/dist/markdown-it-vue.css";

import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import "vue-sidebar-menu/dist/vue-sidebar-menu.css";
import "@fortawesome/fontawesome-free/css/all.css";
import "@fortawesome/fontawesome-free/js/all.js";
import "./Content/Site.css";

Vue.config.productionTip = false;

// Make BootstrapVue available throughout your project
Vue.use(BootstrapVue);
// Optionally install the BootstrapVue icon components plugin
Vue.use(IconsPlugin);
// vue-sidebar
Vue.use(VueSidebarMenu);
Vue.use(VueAxios, axios);
Vue.use(MarkdownItVue);

new Vue({
  router,
  render: (h) => h(App),
}).$mount("#app");
