import { ref } from "vue";
import oktaAuth from "../src/plugins/okta";

const isAuthenticated = ref(false);

async function checkAuthentication() {
  isAuthenticated.value = await oktaAuth.isAuthenticated();
}

checkAuthentication(); // Check on initial load

// Export so other components can use
export { isAuthenticated, checkAuthentication };
