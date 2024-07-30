sap.ui.define(
  [
    "sap/ui/test/opaQunit",
    "../pages/Home",
    "../pages/PersonagemLista",
    "../pages/RacaLista",
  ],
  function (opaTest) {
    "use strict";

    QUnit.module("Home");

    opaTest(
      "Deve navegar até a pagina de personagens",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp();

        //Actions
        When.naPaginaHome.euApertoOBotaoDePersonagens();

        // Assertions
        Then.naPaginaDaListaDePersonagens
          .oTituloDaPaginaDePersonagensDeveraSer()
          .and.aUrlDaPaginaDePersonagensDeveraSer();

        // Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest("Deve navegar até a pagina de raças", function (Given, When, Then) {
      // Arrangements
      Given.iStartMyApp();

      //Actions
      When.naPaginaHome.euApertoOBotaoDeRacas();

      // Assertions
      Then.naPaginaDaListaDeRacas
        .oTituloDaPaginaDeRacasDeveraSer()
        .and.aUrlDaPaginaDeRacasDeveraSer();

      // Cleanup
      Then.iTeardownMyApp();
    });
  }
);
