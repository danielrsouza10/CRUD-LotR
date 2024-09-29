sap.ui.define(
  [
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/matchers/PropertyStrictEquals",
  ],
  function (Opa5, Press, EnterText, PropertyStrictEquals) {
    "use strict";

    const NOME_VIEW = "Personagem.CriarPersonagem",
      NOME_VIEW_HOME = "Home.Home",
      ID_PAGINA = "paginaCriarPersonagem",
      ID_COMBOBOX_PROFISSAO = "comboBoxProfissoes",
      ID_COMBOBOX_RACAS = "comboBoxRacas",
      ID_INPUT_NOME = "inputNome",
      ID_INPUT_IDADE = "inputIdade",
      ID_INPUT_ALTURA = "inputAltura",
      ID_RADIO_BUTTON_VIVO = "radioBtnVivo",
      ID_RADIO_BUTTON_MORTO = "radioBtnMorto";
    Opa5.createPageObjects({
      naPaginaDeCriarPersonagem: {
        actions: {
          aTelaFoiCarregadaCorretamente: function () {
            return this.waitFor({
              viewName: NOME_VIEW,
              success: () =>
                Opa5.assert.ok(true, "A tela foi carregada corretamente"),
              errorMessage: "A tela não foi carregada corretamente",
            });
          },
          euDigitoUmNomeNoInputField: function (nomePersonagem) {
            return this.waitFor({
              id: ID_INPUT_NOME,
              viewName: NOME_VIEW,
              actions: new EnterText({
                text: nomePersonagem,
              }),
              errorMessage: "Input não encontrado",
            });
          },
          euSelecionoUmaRaca: function (idRaca) {
            return this.waitFor({
              id: ID_COMBOBOX_RACAS,
              viewName: NOME_VIEW,
              actions: function (comboBox) {
                comboBox.setSelectedKey(idRaca);
                comboBox.fireChange({
                  selectedItem: comboBox.getSelectedItem(),
                });
              },
              errorMessage: "Não foi possível selecionar a raça no ComboBox",
            });
          },
          euSelecionoUmaProfissao: function (idProfissao) {
            return this.waitFor({
              id: ID_COMBOBOX_PROFISSAO,
              viewName: NOME_VIEW,
              actions: function (comboBox) {
                comboBox.setSelectedKey(idProfissao);
                comboBox.fireChange({
                  selectedItem: comboBox.getSelectedItem(),
                });
              },
              errorMessage:
                "Não foi possível selecionar a profissão no ComboBox",
            });
          },
          euDigitoUmaIdadeNoInputField: function (idade) {
            return this.waitFor({
              id: ID_INPUT_IDADE,
              viewName: NOME_VIEW,
              actions: new EnterText({
                text: idade,
              }),
              errorMessage: "Não foi possível inserir um valor para a idade",
            });
          },
          euDigitoUmaAlturaNoInputField: function (altura) {
            return this.waitFor({
              id: ID_INPUT_ALTURA,
              viewName: NOME_VIEW,
              actions: new EnterText({
                text: altura,
              }),
              errorMessage: "Não foi possível inserir um valor para a altura",
            });
          },
          euSelecionoCondicaoVivo: function () {
            return this.waitFor({
              id: ID_RADIO_BUTTON_VIVO,
              viewName: NOME_VIEW,
              actions: new Press(),
              errorMessage: "Não foi possível selecionar o box 'Vivo'",
            });
          },
          euSelecionoCondicaoMorto: function () {
            return this.waitFor({
              id: ID_RADIO_BUTTON_MORTO,
              viewName: NOME_VIEW,
              actions: new Press(),
              errorMessage: "Não foi possível selecionar o box 'Morto'",
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
          euPressionoOBotaoCancelar: function () {
            return this.waitFor({
              controlType: "sap.m.Button",
              matchers: new PropertyStrictEquals({
                name: "type",
                value: "Reject",
              }),
              actions: new Press(),
              success: function () {
                Opa5.assert.ok(true, "O botão cancelar foi pressionado");
              },
              errorMessage: "Não foi possível encontrar o botao cancelar",
            });
          },
          euPressionoBotaoFechar: function () {
            return this.waitFor({
              searchOpenDialogs: true,
              controlType: "sap.m.Button",
              actions: new Press(),
              success: function () {
                Opa5.assert.ok(true, "O botão 'Fechar' foi pressionado");
              },
              errorMessage: "Não foi possível encontrar o botao 'Fechar'",
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
          deveAparecerUmaMessageBoxDeErro: function () {
            return this.waitFor({
              searchOpenDialogs: true,
              controlType: "sap.m.Dialog",
              matchers: new PropertyStrictEquals({
                name: "title",
                value: "Erro ao criar registro",
              }),
              success: function () {
                Opa5.assert.ok(
                  true,
                  "Foi encontrada a MessageBox indicando um erro"
                );
              },
              errorMessage: "Não foi encontrada a MessageBox indicando um erro",
            });
          },
          deveAparecerUmaMessageBoxDeErroVindoDoServidor: function () {
            return this.waitFor({
              searchOpenDialogs: true,
              controlType: "sap.m.Dialog",
              matchers: new PropertyStrictEquals({
                name: "title",
                value: "Ocorreram um ou mais erros de validação",
              }),
              success: function () {
                Opa5.assert.ok(
                  true,
                  "Foi encontrada a MessageBox indicando um erro"
                );
              },
              errorMessage: "Não foi encontrada a MessageBox indicando um erro",
            });
          },
          aTelaHomeFoiCarregadaCorretamente: function () {
            return this.waitFor({
              viewName: NOME_VIEW_HOME,
              success: () =>
                Opa5.assert.ok(
                  true,
                  "A tela 'Home' foi carregada corretamente"
                ),
              errorMessage: "A tela 'Home' não foi carregada corretamente",
            });
          },
        },
      },
    });
  }
);
