sap.ui.define([], function () {
  "use strict";

  const URL_TODAS_AS_RACAS = "https://localhost:7244/api/Raca/racas";
  const URL_POST_RACA = "https://localhost:7244/api/Raca/raca";

  return {
    obterTodos: async function (filtros) {
      let urlRacas = new URL(URL_TODAS_AS_RACAS);

      Object.keys(filtros).forEach((key) => {
        urlRacas.searchParams.append(key, filtros[key]);
      });

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
    adicionarRaca: async function (raca) {
      let urlRacas = new URL(URL_POST_RACA);

      try {
        const response = await fetch(urlRacas.href, {
          method: "POST",
          body: JSON.stringify(raca),
          headers: {
            "Content-type": "application/json; charset=UTF-8",
          },
        });
        if (!response.ok) {
          const erro = await response.json();
          throw erro;
        }

        return await response.json();
      } catch (erro) {
        throw erro;
      }
    },
  };
});
