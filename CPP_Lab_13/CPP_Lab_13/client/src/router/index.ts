import { createRouter, createWebHistory } from "vue-router";
import Home from "../views/HomeView.vue";
import CallbackView from "../views/LoginCallbackView.vue";
import SignOutCallback from "../views/LogoutCallbackView.vue";
import Profile from "../views/ProfileView.vue";
import oktaAuth from "@/plugins/okta";
import Lab1View from "@/views/Lab1View.vue";
import Lab2View from "@/views/Lab2View.vue";
import lab3View from "@/views/Lab3View.vue";

const routes = [
  { path: "/", component: Home },
  {
    path: "/authorization-code/callback",
    component: CallbackView,
  },
  {
    path: "/signout-callback-oidc",
    component: SignOutCallback,
  },
  { path: "/profile", component: Profile, meta: { requiresAuth: true } },
  { path: "/lab1", component: Lab1View, meta: { requiresAuth: true } },
  { path: "/lab2", component: Lab2View, meta: { requiresAuth: true } },
  { path: "/lab3", component: lab3View, meta: { requiresAuth: true } },
  // other routes
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

router.beforeEach(async (to, from, next) => {
  const requiresAuth = to.matched.some((record) => record.meta.requiresAuth);
  const isAuthenticated = await oktaAuth.isAuthenticated();

  if (requiresAuth && !isAuthenticated) {
    next("/");
  } else {
    next();
  }
});

export default router;
