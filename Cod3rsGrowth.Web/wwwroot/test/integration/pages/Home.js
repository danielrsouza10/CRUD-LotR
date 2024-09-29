sap.ui.define(
  [
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/Properties",
  ],
  function (Opa5, Press, Properties) {
    "use strict";

    const NOME_VIEW = "Home.Home",
      ID_PAGINA_HOME = "paginaHome",
      ID_BTN_LISTA_PERSONAGENS = "personagensListBtn",
      ID_BTN_LISTA_RACAS = "racasListBtn",
      TITULO_DA_PAGINA = "O Senhor dos Anéis",
      ROTA_ERRADA = "adwkao";

    Opa5.createPageObjects({
      naPaginaHome: {
        actions: {
          euApertoOBotaoDePersonagens: function () {
            return this.waitFor({
              id: ID_BTN_LISTA_PERSONAGENS,
              viewName: NOME_VIEW,
              actions: new Press(),
              errorMessage: "No path page was found.",
            });
          },
          euApertoOBotaoDeRacas: function () {
            return this.waitFor({
              id: ID_BTN_LISTA_RACAS,
              viewName: NOME_VIEW,
              actions: new Press(),
              errorMessage: "No path page was found.",
            });
          },
          euNavegoParaUmaPaginaInexistente: function () {
            return this.waitFor({
              success: function () {
                sap.ui.test.Opa5.getHashChanger().setHash(ROTA_ERRADA);
              },
            });
          },
        },
        assertions: {
          oTituloDaPaginaHomeDeveraSer: function () {
            return this.waitFor({
              success: function () {
                return this.waitFor({
                  id: ID_PAGINA_HOME,
                  viewName: NOME_VIEW,
                  matchers: new Properties({
                    title: TITULO_DA_PAGINA,
                  }),
                  success: function (pagina) {
                    Opa5.assert.ok(pagina, "O título da página está correto.");
                  },
                  errorMessage:
                    "Não foi encontrado título correspondente a 'O Senhor dos Anéis' ou não foi possível navegar até a página",
                });
              },
            });
          },
          aUrlDaPaginaHomeDeveraSer: function () {
            return this.waitFor({
              success: function () {
                const hash = Opa5.getHashChanger().getHash();
                Opa5.assert.strictEqual(hash, "", "Navegou para a pagina Home");
              },
              errorMessage: "A URL é diferente da esperada",
            });
          },
        },
      },
    });
  }
);
