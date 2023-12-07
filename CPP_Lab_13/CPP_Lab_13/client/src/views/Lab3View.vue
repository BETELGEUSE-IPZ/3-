<template>
  <div class="container">
    <h1 class="header center">Лабораторна робота 3</h1>
    <p class="center">
      Умова задачі: Петя потрапив у альтернативну реальність, яка представляє
      собою лабіринт. Щоб знайти вихід, йому потрібно купити ключі різних
      кольорів. Задача - знайти мінімальну суму для закупівлі потрібних ключів,
      враховуючи наступні умови: Ключі многоразові. Щоб пройти через двері
      певного кольору, потрібен відповідний ключ. Треба знайти мінімальну суму
      для закупівлі ключів, щоб вийти з лабіринту.
    </p>

    <form @submit.prevent="submitForm">
      <div class="row">
        <div class="input-field col s12">
          <label for="input"
            >Введіть розміри лабіринту, вартість ключів та схему
            лабіринту:</label
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
        <label for="output">Мінімальна сума для закупівлі ключів:</label>
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
    <p>
      Вхідний файл містить: Розміри лабіринту та вартість ключів. Схему
      лабіринту. Вихідний файл має містити одне число - мінімальну суму для
      закупівлі ключів для виходу з лабіринту.
    </p>

    <h2 class="header">Приклади</h2>
    <p>
      INPUT:<br />
      3 7<br />
      1 1 1 1<br />
      XXXXXXX<br />
      XS.X.EX<br />
      XXXXXXX<br />
      OUTPUT: Sleep
    </p>
  </div>
</template>

<script>
import oktaAuth from "@/plugins/okta";
import { API } from "@/config";

export default {
  name: "LabFormThree",
  data() {
    return {
      input: "",
      output: "",
    };
  },
  methods: {
    async submitForm() {
      const postData = { labNumber: 3, input: this.input };

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

<style scoped></style>
