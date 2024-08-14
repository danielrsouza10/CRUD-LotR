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

    const NOME_VIEW = "CriarPersonagem",
      ID_PAGINA = "paginaCriarPersonagem",
      ID_COMBOBOX_PROFISSAO = "comboBoxProfissoes",
      ID_COMBOBOX_RACAS = "comboBoxRacas",
      ID_BOTAO_OK = "okBtn",
      TITULO_DA_PAGINA = "O Senhor dos Anéis",
      KEY_PROFISSAO = "1",
      KEY_RACA = "2";
    Opa5.createPageObjects({
      naPaginaDeCriarPersonagem: {
        actions: {
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
        assertions: {},
      },
    });
  }
);
