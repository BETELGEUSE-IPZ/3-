<template>
  <div class="container">
    <h1 class="center">Лабораторна робота 1</h1>
    <p class="center">
      Програма має знайти N-й доданок заданої послідовності натуральних чисел.
    </p>

    <form @submit.prevent="submitForm">
      <div class="input-field">
        <label for="input">Введіть N:</label>
        <input id="input" v-model="input" class="validate" type="number" />
      </div>
      <button class="btn waves-effect waves-light" type="submit">
        Обчислити
      </button>
    </form>

    <div class="input-field">
      <label for="output">Результат:</label>
      <input
        id="output"
        v-model="output"
        class="validate"
        readonly
        type="text"
      />
    </div>

    <h2>Вводу</h2>
    <p>Вхід містить одну ціле число N (1 ≤ N ≤ 2147483647).</p>

    <h2>Вихід</h2>
    <p>У результаті вивести N-й член заданої послідовності.</p>

    <h2>Приклади</h2>
    <p>INPUT: 1, OUTPUT: 7</p>
    <p>INPUT: 6, OUTPUT: 21</p>
  </div>
</template>

<script>
import oktaAuth from "@/plugins/okta";
import { API } from "@/config";

export default {
  name: "LabForm",
  data() {
    return {
      input: "",
      output: "",
    };
  },
  methods: {
    async submitForm() {
      const postData = { labNumber: 1, input: this.input };

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
