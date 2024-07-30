sap.ui.define(
  [
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/AggregationLengthEquals",
    "sap/ui/test/matchers/I18NText",
    "sap/ui/test/matchers/Properties",
    "sap/ui/test/actions/Press",
  ],
  function (Opa5, AggregationLengthEquals, I18NText, Properties, Press) {
    "use strict";

    var nomeView = "ListaRacas",
      idPagina = "paginaListaDeRacas",
      idLista = "listaDeRacas",
      tituloDaPagina = "O Senhor dos Anéis";
    Opa5.createPageObjects({
      naPaginaDaListaDeRacas: {
        actions: {
          euApertoParaCarregarMaisItensDaListaDeRacas: function () {
            return this.waitFor({
              id: idLista,
              viewName: nomeView,
              actions: new Press(),
              errorMessage: "A Lista de raças não tem a opção de listar mais itens",
            });
          },
        },
        assertions: {
          oTituloDaPaginaDeRacasDeveraSer: function () {
            return this.waitFor({
              success: function () {
                return this.waitFor({
                  id: idPagina,
                  viewName: nomeView,
                  matchers: new Properties({
                    title: tituloDaPagina,
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
          aUrlDaPaginaDeRacasDeveraSer: function () {
            return this.waitFor({
              success: function () {
                const hash = Opa5.getHashChanger().getHash();
                Opa5.assert.strictEqual(
                  hash,
                  "racas",
                  "Navegou para a pagina de racas"
                );
              },
              errorMessage: "A URL é diferente da esperada",
            });
          },
          aListaDeveApresentar10Racas: function () {
            return this.waitFor({
              id: idLista,
              viewName: nomeView,
              matchers: new AggregationLengthEquals({
                name: "items",
                length: 10,
              }),
              success: function () {
                Opa5.assert.ok(true, "A lista contem 10 personagens");
              },
              errorMessage:
                "A lista nao contem 10 personagens ou não foi possível verificar o seu tamanho",
            });
          },
        },
      },
    });
  }
);
