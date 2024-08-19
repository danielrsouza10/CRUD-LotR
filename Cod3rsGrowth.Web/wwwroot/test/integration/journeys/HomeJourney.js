sap.ui.define(
  [
    "sap/ui/test/opaQunit",
    "../pages/Home",
    "../pages/PersonagemLista",
    "../pages/RacaLista",
    "../pages/NotFound",
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
      }
    );
    opaTest("Deve navegar até a página de raças", function (Given, When, Then) {
      //Actions
      When.naPaginaDaListaDePersonagens.euPressionoBotaoVoltar();
      When.naPaginaHome.euApertoOBotaoDeRacas();

      // Assertions
      Then.naPaginaDaListaDeRacas
        .oTituloDaPaginaDeRacasDeveraSer()
        .and.aUrlDaPaginaDeRacasDeveraSer();
    });
    opaTest(
      "Deve navegar até a página de notFound",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDaListaDeRacas.euPressionoBotaoVoltar();
        When.naPaginaHome.euNavegoParaUmaPaginaInexistente();

        // Assertions
        Then.naPaginaDeNotFound.oTituloDaPaginaNotFoundDeveraSer();
      }
    );
    opaTest(
      "Na página de notFound devera navegar de volta para Home",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDeNotFound.euPressionoBotaoVoltar();

        // Assertions
        Then.naPaginaHome.oTituloDaPaginaHomeDeveraSer();

        // Cleanup
        Then.iTeardownMyApp();
      }
    );
  }
);
