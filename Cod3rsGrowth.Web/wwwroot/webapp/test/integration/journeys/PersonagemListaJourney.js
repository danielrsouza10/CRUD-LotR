sap.ui.define(
    ["sap/ui/test/opaQunit", "../pages/Home", "../pages/PersonagemLista"],
    function (opaTest) {
        "use strict";

        QUnit.module("Personagens");

        opaTest(
            "Deve ser possível carregar mais itens da lista de personagens",
            function (Given, When, Then) {
                // Arrangements
                Given.iStartMyApp();

                //Actions
                When.naPaginaHome.euApertoOBotaoDePersonagens();
                When.naPaginaDaListaDePersonagens.euApertoParaCarregarMaisItensDaListaDePersonagens();

                // Assertions
                Then.naPaginaDaListaDePersonagens.aListaDeveApresentar10Personagens();

                // Cleanup
                Then.iTeardownMyApp();
            }
        );
        opaTest(
            "Deve filtrar de acordo com o nome do personagem inserido no search field",
            function (Given, When, Then) {
                // Arrangements
                Given.iStartMyApp();

                //Actions
                When.naPaginaHome.euApertoOBotaoDePersonagens();
                When.naPaginaDaListaDePersonagens.euDigitoONomeDeUmPersonagemNoSearchField();

                // Assertions
                Then.naPaginaDaListaDePersonagens.aListaDeveApresentarApenas1Personagem();

                // Cleanup
                Then.iTeardownMyApp();
            }
        );
        opaTest(
            "Deve apresentar todos os personagens após pressionar em reset",
            function (Given, When, Then) {
                // Arrangements
                Given.iStartMyApp();

                //Actions
                When.naPaginaHome.euApertoOBotaoDePersonagens();
                When.naPaginaDaListaDePersonagens.euDigitoONomeDeUmPersonagemNoSearchField();
                When.naPaginaDaListaDePersonagens.euPressionoBotaoReset();

                // Assertions
                Then.naPaginaDaListaDePersonagens.aListaDeveApresentar5Personagens();

                // Cleanup
                Then.iTeardownMyApp();
            }
        );
        opaTest(
            "Deve apresentar somente um personagem ao filtrar por nome e profissao",
            function (Given, When, Then) {
                // Arrangements
                Given.iStartMyApp();

                //Actions
                When.naPaginaHome.euApertoOBotaoDePersonagens();
                When.naPaginaDaListaDePersonagens.euDigitoONomeDeUmPersonagemNoSearchField();
                When.naPaginaDaListaDePersonagens.euPressionoBotaoFiltro();
                When.naPaginaDaListaDePersonagens.euSelecionoUmaProfissao();
                When.naPaginaDaListaDePersonagens.euPressionoBotaoOk();

                // Assertions
                Then.naPaginaDaListaDePersonagens.aListaDeveApresentarApenas1Personagem();

                // Cleanup
                Then.iTeardownMyApp();
            }
        );
        opaTest(
            "Deve apresentar uma lista vazia ao filtrar por nome e raça",
            function (Given, When, Then) {
                // Arrangements
                Given.iStartMyApp();

                //Actions
                When.naPaginaHome.euApertoOBotaoDePersonagens();
                When.naPaginaDaListaDePersonagens.euDigitoONomeDeUmPersonagemNoSearchField();
                When.naPaginaDaListaDePersonagens.euPressionoBotaoFiltro();
                When.naPaginaDaListaDePersonagens.euSelecionoUmaRaca();
                When.naPaginaDaListaDePersonagens.euPressionoBotaoOk();

                // Assertions
                Then.naPaginaDaListaDePersonagens.aListaDeveEstarVazia();

                // Cleanup
                Then.iTeardownMyApp();
            }
        );
    }
);
