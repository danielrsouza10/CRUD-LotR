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
  }
);
