sap.ui.define(
  [
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/Properties",
  ],
  function (Opa5, Press, Properties) {
    "use strict";

    const NOME_VIEW = "NotFound.NotFound",
      ID_PAGINA_NOTFOUND = "paginaNotFound",
      TITULO_DA_PAGINA = "NotFound";

    Opa5.createPageObjects({
      naPaginaDeNotFound: {
        actions: {
          euPressionoBotaoVoltar: function () {
            return this.waitFor({
              controlType: "sap.m.Button",
              viewName: NOME_VIEW,
              actions: new Press(),
              errorMessage:
                "Não foi possível encontrar o botão voltar na página",
            });
          },
        },
        assertions: {
          oTituloDaPaginaNotFoundDeveraSer: function () {
            return this.waitFor({
              success: function () {
                return this.waitFor({
                  id: ID_PAGINA_NOTFOUND,
                  viewName: NOME_VIEW,
                  matchers: new Properties({
                    title: TITULO_DA_PAGINA,
                  }),
                  success: function (pagina) {
                    Opa5.assert.ok(pagina, "O título da página está correto.");
                  },
                  errorMessage:
                    "Não foi encontrado título correspondente a 'NotFound' ou não foi possível navegar até a página",
                });
              },
            });
          },
        },
      },
    });
  }
);
