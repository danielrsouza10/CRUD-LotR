sap.ui.define([], function () {
  "use strict";

  const URL_PERSONAGENS = "https://localhost:7244/api/Personagem/personagens";

  return {
    obterTodos: async function (filtros) {
      let urlPersonagens = new URL(URL_PERSONAGENS);

      Object.keys(filtros).forEach((key) => {
        urlPersonagens.searchParams.append(key, filtros[key]);
      });

      try {
        const response = await fetch(urlPersonagens.href);
        if (!response.ok) {
          throw new Error("Sem resposta: " + response.statusText);
        }
        return response.json();
      } catch (erro) {
        throw new Error("Sem resposta: " + response.statusText);
      }
    },
  };
});
