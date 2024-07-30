sap.ui.define(
    ["sap/ui/test/opaQunit", "../pages/Home", "../pages/RacaLista"],
    function (opaTest) {
        "use strict";

        QUnit.module("Raças");

        opaTest(
            "Deve ser possível carregar mais itens da lista de raças",
            function (Given, When, Then) {
                // Arrangements
                Given.iStartMyApp();

                //Actions
                When.naPaginaHome.euApertoOBotaoDeRacas();
                When.naPaginaDaListaDeRacas.euApertoParaCarregarMaisItensDaListaDeRacas();

                // Assertions
                Then.naPaginaDaListaDeRacas.aListaDeveApresentar10Racas();

                // Cleanup
                Then.iTeardownMyApp();
            }
        );
        opaTest(
            "Deve filtrar de acordo com o nome da raça inserida no search field",
            function (Given, When, Then) {
                // Arrangements
                Given.iStartMyApp();

                //Actions
                When.naPaginaHome.euApertoOBotaoDeRacas();
                When.naPaginaDaListaDeRacas.euDigitoONomeDeUmaRacaNoSearchField();

                // Assertions
                Then.naPaginaDaListaDeRacas.aListaDeveApresentarApenas1Raca();

                // Cleanup
                Then.iTeardownMyApp();
            }
        );
        opaTest(
            "Deve apresentar todas as raças após pressionar em reset",
            function (Given, When, Then) {
                // Arrangements
                Given.iStartMyApp();

                //Actions
                When.naPaginaHome.euApertoOBotaoDeRacas();
                When.naPaginaDaListaDeRacas.euDigitoONomeDeUmaRacaNoSearchField();
                When.naPaginaDaListaDeRacas.euPressionoBotaoReset();

                // Assertions
                Then.naPaginaDaListaDeRacas.aListaDeveApresentar5Racas();

                // Cleanup
                Then.iTeardownMyApp();
            }
        );
    }
);
