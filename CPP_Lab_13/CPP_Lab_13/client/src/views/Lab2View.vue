<template>
  <div class="container">
    <h1 class="header center">Лабораторна робота 2</h1>
    <p class="center">
      Умова задачі: в одній військовій частині вирішено перейти від портянок до
      носків. Прапорщику Недалекому потрібно закупити n пар носків. Задача -
      знайти мінімальну суму для закупівлі потрібної кількості носків.
    </p>

    <form @submit.prevent="submitForm">
      <div class="row">
        <div class="input-field col s12">
          <label for="input"
            >Введіть n та m, а потім m рядків з ai та bi:</label
          >
          <textarea
            id="input"
            v-model="input"
            class="materialize-textarea"
          ></textarea>
        </div>
        <div class="col s12 center">
          <button class="btn waves-effect waves-light" type="submit">
            Обчислити
          </button>
        </div>
      </div>
    </form>

    <div class="row">
      <div class="input-field col s12">
        <label for="output">Мінімальна сума:</label>
        <input
          id="output"
          v-model="output"
          class="validate"
          readonly
          type="text"
        />
      </div>
    </div>

    <h2 class="header">Вхідні та вихідні дані</h2>
    <p>Вхідний файл містить: В першому рядку два числа n і m...</p>

    <h2 class="header">Приклади</h2>
    <p>
      INPUT: <br />
      4 1<br />
      2 2<br />
      1 1<br />
      OUTPUT: 4
    </p>
  </div>
</template>

<script>
import oktaAuth from "@/plugins/okta";
import { API } from "@/config";

export default {
  name: "LabFormTwo",
  data() {
    return {
      input: "",
      output: "",
    };
  },
  methods: {
    async submitForm() {
      const postData = { labNumber: 2, input: this.input };

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

      fetch(`${API}/labs/calculate`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${accessToken}`,
        },
        body: JSON.stringify(postData),
      })
        .then((response) => response.json())
        .then((data) => {
          this.output = data.output;
        })
        .catch((error) => {
          console.error("Error:", error);
        });
    },
  },
};
</script>

<style scoped>
/* Add any additional styling here */
</style>
