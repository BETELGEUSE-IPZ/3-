<template>
  <div>Loading...</div>
</template>

<script>
import oktaAuth from "../plugins/okta";
import { checkAuthentication } from "../authState";

export default {
  async mounted() {
    try {
      await oktaAuth.revokeAccessToken();
      await oktaAuth.revokeRefreshToken();
      await checkAuthentication();
      this.$router.push("/");
    } catch (error) {
      console.error(error);
    }
  },
};
</script>
