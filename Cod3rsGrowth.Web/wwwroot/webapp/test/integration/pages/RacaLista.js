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

        var nomeView = "ListaRacas",
            idPagina = "paginaListaDeRacas",
            idLista = "listaDeRacas",
            idSearchField = "searchFieldRacas",
            buscaRaca = "Humano",
            idBotaoReset = "resetBtn",
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
                    euDigitoONomeDeUmaRacaNoSearchField: function () {
                        return this.waitFor({
                            id: idSearchField,
                            viewName: nomeView,
                            actions: new EnterText({
                                text: buscaRaca
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
                                Opa5.assert.ok(true, "A lista contem 10 raças");
                            },
                            errorMessage:
                                "A lista nao contem 10 raças ou não foi possível verificar o seu tamanho",
                        });
                    },
                    aListaDeveApresentar5Racas: function () {
                        return this.waitFor({
                            id: idLista,
                            viewName: nomeView,
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
                            id: idLista,
                            viewName: nomeView,
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
                },
            },
        });
    }
);
