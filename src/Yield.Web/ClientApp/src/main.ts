import Vue from "vue";
import './plugins/vuetify'
import App from "./App.vue";
import store from "./store";
import "./registerServiceWorker";
import 'roboto-fontface/css/roboto/roboto-fontface.css'
import 'material-design-icons-iconfont/dist/material-design-icons.css'
import router from './router';


Vue.config.productionTip = false;


// tslint:disable-next-line:no-unused-expression
new Vue({
  el: "#app",
  store,
  router,
  render: h => h(App)
});
