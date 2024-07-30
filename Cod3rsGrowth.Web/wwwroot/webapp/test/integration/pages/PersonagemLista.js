sap.ui.define(
    [
        "sap/ui/test/Opa5",
        "sap/ui/test/matchers/AggregationLengthEquals",
        "sap/ui/test/matchers/I18NText",
        "sap/ui/test/matchers/Properties",
        "sap/ui/test/actions/Press",
        "sap/ui/test/actions/EnterText",
    ],
    function (Opa5, AggregationLengthEquals, I18NText, Properties, Press, EnterText) {
        "use strict";

        var nomeView = "ListaPersonagens",
            idPagina = "paginaListaDePersonagens",
            idLista = "listaDePersonagens",
            idSearchField = "searchFieldPersonagens",
            idBotaoReset = "resetBtn",
            idBotaoFiltro = "filtroBtn",
            idComboBoxProfissoes = "profissaoComboBox",
            idComboBoxRacas = "comboBoxRacas",
            idBotaoOk = "okBtn",
            tituloDaPagina = "O Senhor dos Anéis",
            buscaPersonagem = "Aragorn",
            keyProfissao = "1",
            keyRaca = "2";
        ;
        Opa5.createPageObjects({
            naPaginaDaListaDePersonagens: {
                actions: {
                    euApertoParaCarregarMaisItensDaListaDePersonagens: function () {
                        return this.waitFor({
                            id: idLista,
                            viewName: nomeView,
                            actions: new Press(),
                            errorMessage: "A Lista não tem a opção de listar mais itens",
                        });
                    },
                    euDigitoONomeDeUmPersonagemNoSearchField: function () {
                        return this.waitFor({
                            id: idSearchField,
                            viewName: nomeView,
                            actions: new EnterText({
                                text: buscaPersonagem
                            }),
                            errorMessage: "SearchField não encontrado."
                        });
                    },
                    euPressionoBotaoReset: function () {
                        return this.waitFor({
                            id: idBotaoReset,
                            viewName: nomeView,
                            actions: new Press(),
                            errorMessage: "Não foi possível encontrar ou pressionar o botão reset"
                        });
                    },
                    euPressionoBotaoFiltro: function () {
                        return this.waitFor({
                            id: idBotaoFiltro,
                            viewName: nomeView,
                            actions: new Press(),
                            errorMessage: "Não foi possível encontrar ou pressionar o botão de filtro"
                        });
                    },
                    euSelecionoUmaProfissao: function () {
                        return this.waitFor({
                            id: idComboBoxProfissoes,
                            viewName: nomeView,
                            actions: function (comboBox) {
                                comboBox.setSelectedKey(keyProfissao);
                                comboBox.fireChange({selectedItem: comboBox.getSelectedItem()});
                            },
                            errorMessage: "Não foi possível selecionar a profissão no ComboBox"
                        });
                    },
                    euSelecionoUmaRaca: function () {
                        return this.waitFor({
                            id: idComboBoxRacas,
                            viewName: nomeView,
                            actions: function (comboBox) {
                                comboBox.setSelectedKey(keyRaca);
                                comboBox.fireChange({selectedItem: comboBox.getSelectedItem()});
                            },
                            errorMessage: "Não foi possível selecionar a raça no ComboBox"
                        });
                    },
                    euPressionoBotaoOk: function () {
                        return this.waitFor({
                            searchOpenDialogs: true,
                            controlType: "sap.m.Button",
                            check: function (botoes) {
                                return botoes.some(function (botao) {
                                    return botao.getId(idBotaoOk);
                                });
                            },
                            success: function (botoes) {
                                var botao = botoes.find(function (botao) {
                                    return botao.getId(idBotaoOk);
                                });
                                if (botao) {
                                    botao.firePress();
                                } else {
                                    throw new Error("Não foi possível encontrar ou pressionar o botão Ok no diálogo")
                                }
                            },
                            errorMessage: "Não foi possível encontrar o diálogo de filtro"
                        });
                    },

                },
                assertions: {
                    oTituloDaPaginaDePersonagensDeveraSer: function () {
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
                    aListaDeveApresentar5Personagens: function () {
                        return this.waitFor({
                            id: idLista,
                            viewName: nomeView,
                            matchers: new AggregationLengthEquals({
                                name: "items",
                                length: 5,
                            }),
                            success: function () {
                                Opa5.assert.ok(true, "A lista contem 10 personagens");
                            },
                            errorMessage:
                                "A lista nao contem 10 personagens ou não foi possível verificar o seu tamanho",
                        });
                    },
                    aListaDeveApresentarApenas1Personagem: function () {
                        return this.waitFor({
                            id: idLista,
                            viewName: nomeView,
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
                            id: idLista,
                            viewName: nomeView,
                            matchers: new AggregationLengthEquals({
                                name: "items",
                                length: 0,
                            }),
                            success: function () {
                                Opa5.assert.ok(true, "A lista está vazia");
                            },
                            errorMessage:
                                "A lista nao está vazia",
                        });
                    },
                },
            },
        });
    }
);
