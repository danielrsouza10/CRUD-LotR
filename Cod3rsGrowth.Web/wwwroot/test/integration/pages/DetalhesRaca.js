sap.ui.define(
    [
        "sap/ui/test/Opa5",
        "sap/ui/test/matchers/I18NText",
        "sap/ui/test/actions/Press",
        "sap/ui/test/matchers/Properties",
        "sap/ui/test/matchers/PropertyStrictEquals",
        "sap/ui/test/matchers/Ancestor",

    ],
    function (Opa5, I18NText, Press, Properties, PropertyStrictEquals, Ancestor) {
        "use strict";

        const NOME_VIEW = "DetalhesRaca",
            ID_PAGINA = "paginaDetalhesRaca";
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
                                key: "BotaoEditar"
                            }),
                            actions: new Press(),
                            errorMessage: "Não foi possível encontrar o botão editar na página",
                        });
                    },
                    euPressionoBotaoRemover: function () {
                        return this.waitFor({
                            controlType: "sap.m.Button",
                            matchers: new I18NText({
                                propertyName: "text",
                                key: "BotaoRemover"
                            }),
                            actions: new Press(),
                            errorMessage: "Não foi possível encontrar o botão remover na página",
                        });
                    },
                    euPressionoSimParaConfirmarAEsclusao: function () {
                        return this.waitFor({
                            controlType: "sap.m.Button",
                            matchers: [
                                new Properties({text: "Sim"}),
                                new Ancestor(Opa5.getContext().dialog, false)
                            ],
                            actions: new Press(),
                            errorMessage: "Não foi possível pressionar o botão 'Sim' para confirmar a exclusão"
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
                            errorMessage: "Não foi encontrada a MessageBox solicitando confirmação para excluir",
                        })
                    }
                },
            },
        });
    }
);
