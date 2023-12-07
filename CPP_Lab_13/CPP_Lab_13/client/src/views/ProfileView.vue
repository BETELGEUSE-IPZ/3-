<template>
  <div class="container">
    <div class="card hoverable">
      <div v-if="userInfo" class="card-content">
        <span class="card-title"
          >{{ userInfo.firstName }} {{ userInfo.lastName }}</span
        >
        <p><strong>Email:</strong> {{ userInfo.email }}</p>
        <p><strong>Phone:</strong> {{ userInfo.phoneNumber }}</p>
        <p><strong>Nickname:</strong> {{ userInfo.nickname }}</p>
        <p><strong>First Name:</strong> {{ userInfo.firstName }}</p>
        <p><strong>Last Name:</strong> {{ userInfo.lastName }}</p>
        <p><strong>Middle Name:</strong> {{ userInfo.middleName }}</p>
      </div>
      <div v-if="!userInfo" class="progress">
        <div class="indeterminate"></div>
      </div>
    </div>
  </div>
</template>

<script>
import oktaAuth from "../plugins/okta";
import { ref } from "vue";
import { API } from "@/config";

export default {
  name: "UserInfo",
  setup() {
    const userInfo = ref(null);

    async function fetchUserInfo() {
      let accessToken;
      try {
        const tokenResponse = await oktaAuth.tokenManager.get("accessToken");
        if (tokenResponse) {
          accessToken = tokenResponse.accessToken;
        }
      } catch (error) {
        console.error("Error getting token", error);
        return;
      }

      if (accessToken) {
        fetch(`${API}/profile/get-user-info`, {
          method: "GET",
          headers: new Headers({
            Authorization: `Bearer ${accessToken}`,
            "Content-Type": "application/json",
          }),
        })
          .then((response) => response.json())
          .then((data) => {
            userInfo.value = data;
          })
          .catch((error) => {
            console.error("Error:", error);
          });
      }
    }

    fetchUserInfo();

    return { userInfo };
  },
};
</script>

<style scoped>
.container {
  margin-top: 50px;
}

.card {
  background-color: #fafafa;
}

.card-title {
  color: #26a69a;
}

p {
  margin: 5px 0;
}
</style>
