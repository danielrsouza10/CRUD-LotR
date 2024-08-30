sap.ui.define(
  [
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/I18NText",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/Properties",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/matchers/Ancestor",
    "sap/ui/test/actions/EnterText",
  ],
  function (
    Opa5,
    I18NText,
    Press,
    Properties,
    PropertyStrictEquals,
    Ancestor,
    EnterText
  ) {
    "use strict";

    const NOME_VIEW = "DetalhesRaca",
      ID_PAGINA = "paginaDetalhesRaca",
      ID_LISTA_REGISTROS_FILHOS = "listaDePersonagens",
      ID_COMBOBOX_PROFISSAO = "profissaoComboBox",
      ID_INPUT_NOME = "inputNome",
      ID_INPUT_IDADE = "inputIdade",
      ID_INPUT_ALTURA = "inputAltura",
      ID_RADIO_BUTTON_VIVO = "radioBtnVivo",
      ID_RADIO_BUTTON_MORTO = "radioBtnMorto";
    Opa5.createPageObjects({
      naPaginaDeDetalhesDaRaca: {
        actions: {
          euPressionoBotaoVoltar: function () {
            return this.waitFor({
              id: ID_PAGINA,
              viewName: NOME_VIEW,
              actions: new Press(),
              errorMessage:
                "Não foi possível encontrar o botão voltar na página",
            });
          },
          euPressionoBotaoEditar: function () {
            return this.waitFor({
              controlType: "sap.m.Button",
              matchers: new I18NText({
                propertyName: "text",
                key: "BotaoEditar",
              }),
              actions: new Press(),
              errorMessage:
                "Não foi possível encontrar o botão editar na página",
            });
          },
          euPressionoBotaoRemover: function () {
            return this.waitFor({
              controlType: "sap.m.Button",
              matchers: new I18NText({
                propertyName: "text",
                key: "BotaoRemover",
              }),
              actions: new Press(),
              errorMessage:
                "Não foi possível encontrar o botão remover na página",
            });
          },
          euPressionoSimParaConfirmarAEsclusao: function () {
            return this.waitFor({
              controlType: "sap.m.Button",
              matchers: [
                new Properties({ text: "Sim" }),
                new Ancestor(Opa5.getContext().dialog, false),
              ],
              actions: new Press(),
              errorMessage:
                "Não foi possível pressionar o botão 'Sim' para confirmar a exclusão",
            });
          },
          euPressionoOBotaoAdicionarPersonagem: function () {
            return this.waitFor({
              controlType: "sap.m.Button",
              matchers: new I18NText({
                propertyName: "text",
                key: "BotaoAdicionarPersonagem",
              }),
              actions: new Press(),
              errorMessage:
                "Não foi possível encontrar o botão adicionar personagem na página",
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
        },
        assertions: {
          oTituloDaPaginaDetalhesDaRacaDeveraSer: function () {
            return this.waitFor({
              success: function () {
                return this.waitFor({
                  controlType: "sap.m.Page",
                  matchers: new I18NText({
                    propertyName: "title",
                    key: "TituloPaginaDetalhesRaca",
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
          aUrlDaPaginaDeDetalhesDaRacaDeveraSer: function (id) {
            return this.waitFor({
              success: function () {
                const hash = Opa5.getHashChanger().getHash();
                Opa5.assert.strictEqual(
                  hash,
                  `raca/${id}`,
                  `Navegou para a pagina de detalhes da raca de id: ${id}`
                );
              },
              errorMessage: "A URL é diferente da esperada",
            });
          },
          oNomeNosDetalhesDaRacaDeveraSer: function (nomeDaRaca) {
            return this.waitFor({
              controlType: "sap.m.ObjectHeader",
              matchers: new Properties({
                title: nomeDaRaca,
              }),
              success: function (raca) {
                Opa5.assert.ok(raca, "O nome da raça esta correto");
              },
              errorMessage: "Não foi encontrado o nome da raça na propriedade",
            });
          },
          oIdNosDetalhesDaRacaDeveraSer: function (idDaRaca) {
            return this.waitFor({
              controlType: "sap.m.ObjectHeader",
              matchers: new Properties({
                intro: `Id:${idDaRaca}`,
              }),
              success: function (raca) {
                Opa5.assert.ok(raca, "O id da raça esta correto");
              },
              errorMessage: "Não foi encontrado o id da raça na propriedade",
            });
          },
          aLocalizacaoGeograficaNosDetalhesDaRacaDeveraSer: function (
            localizacaoGeografica
          ) {
            return this.waitFor({
              controlType: "sap.m.ObjectAttribute",
              matchers: new Properties({
                text: localizacaoGeografica,
              }),
              success: function (raca) {
                Opa5.assert.ok(
                  raca,
                  "A localizacao geografica da raça esta correto"
                );
              },
              errorMessage:
                "Não foi encontrado localizacao geografica da raça na propriedade",
            });
          },
          aHabilidadeRacialNosDetalhesDaRacaDeveraSer: function (
            habilidadeRacial
          ) {
            return this.waitFor({
              controlType: "sap.m.ObjectAttribute",
              matchers: new Properties({
                text: habilidadeRacial,
              }),
              success: function (raca) {
                Opa5.assert.ok(
                  raca,
                  "A habilidade Racial da raça esta correto"
                );
              },
              errorMessage:
                "Não foi encontrado habilidade Racial da raça na propriedade",
            });
          },
          oEstaExtintaNosDetalhesDaRacaDeveraSer: function (estaExtinta) {
            return this.waitFor({
              controlType: "sap.m.ObjectStatus",
              matchers: new Properties({
                text: estaExtinta,
              }),
              success: function (raca) {
                Opa5.assert.ok(raca, "O esta extinto esta correto");
              },
              errorMessage:
                "Não foi encontrado o valor esta Extinta da raça na propriedade",
            });
          },
          aFormatacaoDoEstaExtintaDeveraSer: function (statusEstaExtinta) {
            return this.waitFor({
              controlType: "sap.m.ObjectStatus",
              matchers: new Properties({
                state: statusEstaExtinta,
              }),
              success: function (raca) {
                Opa5.assert.ok(
                  raca,
                  "A formatação do status de Esta Extinta está correta"
                );
              },
              errorMessage:
                "Não  está correta a formatação do status de Esta Extinta",
            });
          },
          deveAparecerUmaMessageBoxDeConfirmacao: function () {
            return this.waitFor({
              searchOpenDialogs: true,
              controlType: "sap.m.Dialog",
              matchers: new PropertyStrictEquals({
                name: "title",
                value: "Excluir registro",
              }),
              success: function () {
                Opa5.assert.ok(
                  true,
                  "Foi encontrada a MessageBox solicitando confirmação para excluir"
                );
              },
              errorMessage:
                "Não foi encontrada a MessageBox solicitando confirmação para excluir",
            });
          },
          deveAparecerUmaMessageBoxDeErro: function () {
            return this.waitFor({
              searchOpenDialogs: true,
              controlType: "sap.m.Dialog",
              matchers: new PropertyStrictEquals({
                name: "title",
                value: "Erro de Registro com Dependentes",
              }),
              success: function () {
                Opa5.assert.ok(
                  true,
                  "Foi encontrada a MessageBox mostrando que um Erro de Registro com Dependentes ocorreu"
                );
              },
              errorMessage:
                "Não encontrada a MessageBox mostrando que um Erro de Registro com Dependentes ocorreu",
            });
          },
          deveExistirUmaListaNaPagina: function () {
            return this.waitFor({
              id: ID_LISTA_REGISTROS_FILHOS,
              viewName: NOME_VIEW,
              success: function (lista) {
                Opa5.assert.ok(lista, "Existe um item de lista na pagina");
              },
              errorMessage: "Não existe um item de lista na pagina",
            });
          },
          deveConterUmaListaComRegistrosFilhosNaPagina: function () {
            return this.waitFor({
              id: ID_LISTA_REGISTROS_FILHOS,
              viewName: NOME_VIEW,
              success: function (lista) {
                const modeloDaLista = lista.getModel("personagens");
                const listaDePersonagens = modeloDaLista.getProperty("/");
                if (listaDePersonagens.length === 3) {
                  Opa5.assert.ok(true, "A lista tem 3 registros");
                }
              },
              errorMessage: "A lista não contem 3 registros",
            });
          },
          deveAparecerOModalDeCriacaoDePersonagem: function () {
            return this.waitFor({
              searchOpenDialogs: true,
              controlType: "sap.m.Dialog",
              matchers: new PropertyStrictEquals({
                name: "title",
                value: "Criar Personagem",
              }),
              success: function () {
                Opa5.assert.ok(
                  true,
                  "Foi encontrada o Modal de criação de personagem"
                );
              },
              errorMessage:
                "Não foi encontrado o Modal de criação de personagem",
            });
          },
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
        },
      },
    });
  }
);
