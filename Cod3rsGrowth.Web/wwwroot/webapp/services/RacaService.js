sap.ui.define([], function () {
  "use strict";

  const URL_RACAS = "https://localhost:7244/api/Raca/racas";

  return {
    obterTodos: async function (filtros) {
      let urlRacas = new URL(URL_RACAS);

      Object.keys(filtros).forEach((key) => {
        urlRacas.searchParams.append(key, filtros[key]);
      });

      console.log(urlRacas.href);

      try {
        const response = await fetch(urlRacas.href);
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
