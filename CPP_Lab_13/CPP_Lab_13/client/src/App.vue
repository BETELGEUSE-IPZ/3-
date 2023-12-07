<template>
  <nav>
    <nav>
      <div class="nav-wrapper">
        <a class="brand-logo" href="#">ЛР 13 | Александрук Андрій</a>
        <ul id="nav-mobile" class="right hide-on-med-and-down">
          <li>
            <router-link to="/">Головна</router-link>
          </li>

          <li v-if="isAuthenticated">
            <router-link to="/profile">Профіль</router-link>
          </li>
          <li v-if="isAuthenticated">
            <router-link to="/lab1">ЛР 1</router-link>
          </li>
          <li v-if="isAuthenticated">
            <router-link to="/lab2">ЛР 2</router-link>
          </li>
          <li v-if="isAuthenticated">
            <router-link to="/lab3">ЛР 3</router-link>
          </li>
          <li>
            <a
              v-if="!isAuthenticated"
              class="waves-effect waves-light btn"
              @click="login"
              >Ввійти</a
            >
            <a
              v-if="isAuthenticated"
              class="waves-effect waves-light btn"
              @click="signOut"
              >Вийти</a
            >
          </li>
        </ul>
      </div>
    </nav>
  </nav>
  <router-view />
</template>

<style lang="scss"></style>
<script lang="ts">
import { onMounted } from "vue";
import oktaAuth from "./plugins/okta";
import { checkAuthentication, isAuthenticated } from "./authState";

export default {
  setup() {
    onMounted(checkAuthentication);

    return { isAuthenticated };
  },
  methods: {
    async login() {
      await oktaAuth.signInWithRedirect();
    },
    async signOut() {
      await oktaAuth.signOut();
    },
  },
};
</script>
