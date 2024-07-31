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
            }
        );
        opaTest(
            "Deve filtrar de acordo com o nome da raça inserida no search field",
            function (Given, When, Then) {
                //Actions
                When.naPaginaDaListaDeRacas.euPressionoBotaoReset();
                When.naPaginaDaListaDeRacas.euDigitoONomeDeUmaRacaNoSearchField("Elfo");

                // Assertions
                Then.naPaginaDaListaDeRacas.aListaDeveApresentarApenas1Raca();
            }
        );
        opaTest(
            "Deve apresentar todas as raças após pressionar em reset",
            function (Given, When, Then) {
                //Actions
                When.naPaginaDaListaDeRacas.euPressionoBotaoReset();

                // Assertions
                Then.naPaginaDaListaDeRacas.aListaDeveApresentar5Racas();
            }
        );
        opaTest(
            "Deve apresentar uma lista vazia quando busco por uma raça inexistente",
            function (Given, When, Then) {

                //Actions
                When.naPaginaDaListaDeRacas.euPressionoBotaoReset();
                When.naPaginaDaListaDeRacas.euDigitoONomeDeUmaRacaNoSearchField("Humanoide");


                // Assertions
                Then.naPaginaDaListaDeRacas.aListaDeveEstarVazia();

                // Cleanup
                Then.iTeardownMyApp();
            }
        );
    }
);
