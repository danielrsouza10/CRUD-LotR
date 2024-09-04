sap.ui.define(
  [
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/AggregationLengthEquals",
    "sap/ui/test/matchers/Properties",
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/matchers/PropertyStrictEquals",
  ],
  function (
    Opa5,
    AggregationLengthEquals,
    Properties,
    Press,
    EnterText,
    PropertyStrictEquals
  ) {
    "use strict";

    const NOME_VIEW = "ListaRacas",
      ID_PAGINA = "paginaListaDeRacas",
      ID_LISTA = "listaDeRacas",
      ID_ITEM_LIST = "customListItemRaca",
      ID_SEARCH_FIELD = "searchFieldRacas",
      ID_BOTAO_RESET = "resetBtn",
      TITULO_DA_PAGINA = "O Senhor dos Anéis";
    Opa5.createPageObjects({
      naPaginaDaListaDeRacas: {
        actions: {
          euApertoParaCarregarMaisItensDaListaDeRacas: function () {
            return this.waitFor({
              id: ID_LISTA,
              viewName: NOME_VIEW,
              actions: new Press(),
              errorMessage:
                "A Lista de raças não tem a opção de listar mais itens",
            });
          },
          euDigitoONomeDeUmaRacaNoSearchField: function (nomeDaRaca) {
            return this.waitFor({
              id: ID_SEARCH_FIELD,
              viewName: NOME_VIEW,
              actions: new EnterText({
                text: nomeDaRaca,
              }),
              errorMessage: "SearchField não encontrado.",
            });
          },
          euPressionoBotaoReset: function () {
            return this.waitFor({
              id: ID_BOTAO_RESET,
              viewName: NOME_VIEW,
              actions: new Press(),
              errorMessage:
                "Não foi possível encontrar ou pressionar o botão reset",
            });
          },
          euPressionoBotaoVoltar: function () {
            return this.waitFor({
              id: ID_PAGINA,
              viewName: NOME_VIEW,
              actions: new Press(),
              errorMessage:
                "Não foi possível encontrar o botão voltar na página",
            });
          },
          euSelecionoUmaRacaNaLista: function (racaSelecionada) {
            return this.waitFor({
              controlType: "sap.m.ObjectIdentifier",
              viewName: NOME_VIEW,
              matchers: new Properties({
                title: racaSelecionada,
              }),
              actions: new Press(),
              errorMessage: "Não foi possível selecionar o item na lista",
            });
          },
          euPressionoOBotaoAdicionar: function () {
            return this.waitFor({
              controlType: "sap.m.Button",
              matchers: new PropertyStrictEquals({
                name: "type",
                value: "Accept",
              }),
              actions: new Press(),
              success: function () {
                Opa5.assert.ok(true, "O botão adicionar foi pressionado");
              },
              errorMessage: "Não foi possível encontrar o botao adicionar",
            });
          },
          euPressionoOkNaMessageBoxDeSucesso: function () {
            return this.waitFor({
              searchOpenDialogs: true,
              controlType: "sap.m.Button",
              matchers: new Properties({
                text: "OK",
              }),
              actions: new Press(),
              errorMessage:
                "Não foi possível pressionar o botão 'OK' para fechar o diálogo",
            });
          },
        },
        assertions: {
          oTituloDaPaginaDeRacasDeveraSer: function () {
            return this.waitFor({
              success: function () {
                return this.waitFor({
                  id: ID_PAGINA,
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
              id: ID_LISTA,
              viewName: NOME_VIEW,
              matchers: new AggregationLengthEquals({
                name: "items",
                length: 10,
              }),
              success: function () {
                Opa5.assert.ok(true, "A lista contem 10 raças");
              },
              errorMessage:
                "A lista nao contem 10 raças ou não foi possível verificar o seu tamanho",
            });
          },
          aListaDeveApresentar5Racas: function () {
            return this.waitFor({
              id: ID_LISTA,
              viewName: NOME_VIEW,
              matchers: new AggregationLengthEquals({
                name: "items",
                length: 5,
              }),
              success: function () {
                Opa5.assert.ok(true, "A lista contem 5 raças");
              },
              errorMessage:
                "A lista nao contem 5 raças ou não foi possível verificar o seu tamanho",
            });
          },
          aListaDeveApresentarApenas1Raca: function () {
            return this.waitFor({
              id: ID_LISTA,
              viewName: NOME_VIEW,
              matchers: new AggregationLengthEquals({
                name: "items",
                length: 1,
              }),
              success: function () {
                Opa5.assert.ok(true, "A lista contem apenas 1 raça");
              },
              errorMessage:
                "A lista nao contem apenas 1 raça ou não foi possível verificar o seu tamanho",
            });
          },
          aListaDeveEstarVazia: function () {
            return this.waitFor({
              id: ID_LISTA,
              viewName: NOME_VIEW,
              matchers: new AggregationLengthEquals({
                name: "items",
                length: 0,
              }),
              success: function () {
                Opa5.assert.ok(true, "A lista está vazia");
              },
              errorMessage:
                "A lista nao está vazia ou não foi possível verificar o seu tamanho",
            });
          },
          euVerificoSeAListaTem10Registros: function () {
            return this.waitFor({
              id: ID_LISTA,
              viewName: NOME_VIEW,
              success: function (lista) {
                const modeloDaLista = lista.getModel("racas");
                const listaDeRacas = modeloDaLista.getProperty("/");
                if (listaDeRacas.length === 10) {
                  Opa5.assert.ok(true, "A lista tem 10 registros");
                }
              },
              errorMessage: "A lista não contem 10 registros",
            });
          },
        },
      },
    });
  }
);
