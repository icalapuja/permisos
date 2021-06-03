import Vue from 'vue';
import Vuex from 'vuex';
import router from './router';
import VueResource from 'vue-resource';
import App from './App.vue';
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import VueSimpleAlert from "vue-simple-alert";


Vue.config.productionTip = false
Vue.use(VueResource);
Vue.use(Vuex);
Vue.use(VueSimpleAlert);
Vue.use(require('vue-moment'));

const store = new Vuex.Store({
  state: {
      types:[],
      permissions: [],
      permission:{}
  },
  mutations:{
      setTypes(state, data){
        state.types = data;
      },
      setPermissions(state, data){
          state.permissions = data;
      },
      setPermission(state, data){
        state.permission = data;
      }
  }
});

new Vue({
  render: h => h(App),
  router,
  store,
}).$mount('#app')
