sap.ui.define(
  [
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/AggregationLengthEquals",
    "sap/ui/test/matchers/Properties",
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText",
  ],
  function (Opa5, AggregationLengthEquals, Properties, Press, EnterText) {
    "use strict";

    const NOME_VIEW = "Personagem.ListaPersonagens",
      ID_PAGINA = "paginaListaDePersonagens",
      ID_LISTA = "listaDePersonagens",
      ID_SEARCH_FIELD = "searchFieldPersonagens",
      ID_BOTAO_RESET = "resetBtn",
      ID_BOTAO_FILTRO = "filtroBtn",
      ID_COMBOBOX_PROFISSAO = "profissaoComboBox",
      ID_COMBOBOX_RACAS = "comboBoxRacas",
      ID_BOTAO_OK = "okBtn",
      ID_DATA_INICIAL = "dataInicial",
      ID_DATA_FINAL = "dataFinal",
      TITULO_DA_PAGINA = "O Senhor dos Anéis",
      KEY_PROFISSAO = "1",
      KEY_RACA = "2";
    Opa5.createPageObjects({
      naPaginaDaListaDePersonagens: {
        actions: {
          euApertoParaCarregarMaisItensDaListaDePersonagens: function () {
            return this.waitFor({
              id: ID_LISTA,
              viewName: NOME_VIEW,
              actions: new Press(),
              errorMessage: "A Lista não tem a opção de listar mais itens",
            });
          },
          euDigitoONomeDeUmPersonagemNoSearchField: function (nomePersonagem) {
            return this.waitFor({
              id: ID_SEARCH_FIELD,
              viewName: NOME_VIEW,
              actions: new EnterText({
                text: nomePersonagem,
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
          euPressionoBotaoFiltro: function () {
            return this.waitFor({
              id: ID_BOTAO_FILTRO,
              viewName: NOME_VIEW,
              actions: new Press(),
              errorMessage:
                "Não foi possível encontrar ou pressionar o botão de filtro",
            });
          },
          euSelecionoUmaProfissao: function () {
            return this.waitFor({
              id: ID_COMBOBOX_PROFISSAO,
              viewName: NOME_VIEW,
              actions: function (comboBox) {
                comboBox.setSelectedKey(KEY_PROFISSAO);
                comboBox.fireChange({
                  selectedItem: comboBox.getSelectedItem(),
                });
              },
              errorMessage:
                "Não foi possível selecionar a profissão no ComboBox",
            });
          },
          euSelecionoUmaRaca: function () {
            return this.waitFor({
              id: ID_COMBOBOX_RACAS,
              viewName: NOME_VIEW,
              actions: function (comboBox) {
                comboBox.setSelectedKey(KEY_RACA);
                comboBox.fireChange({
                  selectedItem: comboBox.getSelectedItem(),
                });
              },
              errorMessage: "Não foi possível selecionar a raça no ComboBox",
            });
          },
          euSelecionoUmaDataInicial: function (dataInicial) {
            return this.waitFor({
              id: ID_DATA_INICIAL,
              viewName: NOME_VIEW,
              actions: new EnterText({
                text: dataInicial,
              }),
              errorMessage: "Não foi possível selecionar uma data inicial",
            });
          },
          euSelecionoUmaDataFinal: function (dataFinal) {
            return this.waitFor({
              id: ID_DATA_FINAL,
              viewName: NOME_VIEW,
              actions: new EnterText({
                text: dataFinal,
              }),
              errorMessage: "Não foi possível selecionar uma data final",
            });
          },
          euDouCheckEmVivo: function () {
            return this.waitFor({
              id: "checkBoxVivo",
              viewName: NOME_VIEW,
              actions: new Press(),
              errorMessage: "Não foi possível dar check no box 'Vivo'",
            });
          },
          euDouCheckEmMorto: function () {
            return this.waitFor({
              id: "checkBoxMorto",
              viewName: NOME_VIEW,
              actions: new Press(),
              errorMessage: "Não foi possível dar check no box 'Morto'",
            });
          },
          euPressionoBotaoOk: function () {
            return this.waitFor({
              searchOpenDialogs: true,
              controlType: "sap.m.Button",
              check: function (botoes) {
                return botoes.some(function (botao) {
                  return botao.getId(ID_BOTAO_OK);
                });
              },
              success: function (botoes) {
                var botao = botoes.find(function (botao) {
                  return botao.getId(ID_BOTAO_OK);
                });
                if (botao) {
                  botao.firePress();
                } else {
                  throw new Error(
                    "Não foi possível encontrar ou pressionar o botão Ok no diálogo"
                  );
                }
              },
              errorMessage: "Não foi possível encontrar o diálogo de filtro",
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
        },
        assertions: {
          oTituloDaPaginaDePersonagensDeveraSer: function () {
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
          aUrlDaPaginaDePersonagensDeveraSer: function () {
            return this.waitFor({
              success: function () {
                const hash = Opa5.getHashChanger().getHash();
                Opa5.assert.strictEqual(
                  hash,
                  "personagens",
                  "Navegou para a pagina de personagens"
                );
              },
              errorMessage: "A URL é diferente da esperada",
            });
          },
          aListaDeveApresentar10Personagens: function () {
            return this.waitFor({
              id: ID_LISTA,
              viewName: NOME_VIEW,
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
          aListaDeveApresentar5Personagens: function () {
            return this.waitFor({
              id: ID_LISTA,
              viewName: NOME_VIEW,
              matchers: new AggregationLengthEquals({
                name: "items",
                length: 5,
              }),
              success: function () {
                Opa5.assert.ok(true, "A lista contem 5 personagens");
              },
              errorMessage:
                "A lista nao contem 10 personagens ou não foi possível verificar o seu tamanho",
            });
          },
          aListaDeveApresentarApenas1Personagem: function () {
            return this.waitFor({
              id: ID_LISTA,
              viewName: NOME_VIEW,
              matchers: new AggregationLengthEquals({
                name: "items",
                length: 1,
              }),
              success: function () {
                Opa5.assert.ok(true, "A lista contem 1 personagem apenas");
              },
              errorMessage:
                "A lista nao contem apenas 1 persoangem ou não foi possível verificar o seu tamanho",
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
              errorMessage: "A lista nao está vazia",
            });
          },
        },
      },
    });
  }
);
