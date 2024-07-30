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
  }
);
