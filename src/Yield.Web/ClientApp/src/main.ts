import Vue from "vue";
import './plugins/vuetify'
import App from "./App.vue";
import VueRouter from "vue-router";
import store from "./store";
import "./registerServiceWorker";
import 'roboto-fontface/css/roboto/roboto-fontface.css'
import 'material-design-icons-iconfont/dist/material-design-icons.css'

import Home from "./views/Home.vue";
import Bed from "./views/Bed.vue";


Vue.use(VueRouter);

Vue.config.productionTip = false;

const routes: any = [
  {
    path: "/",
    redirect: "loading"
  },
  // {
  //   path: "/loading",
  //   component: Loading,
  //   name: "loading"
  // },
  {
    path: "/home",
    component: Home
  }, 
  {
    path: "/bed",
    component: Bed
  }
]

const router: VueRouter = new VueRouter({
  routes
});

// tslint:disable-next-line:no-unused-expression
new Vue({
  el: "#app",
  router,
  store,
  render: h => h(App)
});
