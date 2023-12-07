<template>
  <div>Loading...</div>
</template>

<script>
import oktaAuth from "../plugins/okta";
import { checkAuthentication } from "../authState";

export default {
  async mounted() {
    try {
      await oktaAuth.handleLoginRedirect();
      await checkAuthentication();
      this.$router.push("/");
    } catch (error) {
      console.error(error);
    }
  },
};
</script>
