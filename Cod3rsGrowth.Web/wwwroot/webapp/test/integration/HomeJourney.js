sap.ui.define(
  ["sap/ui/test/opaQunit", "./pages/Home", "./pages/PersonagemLista"],
  function (opaTest) {
    "use strict";

    QUnit.module("Home");

    opaTest(
      "Should see a button that show characters",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp();

        //Actions
        When.onTheHomePage.iPressOnCharactersButton();

        // Assertions
        Then.onThePersonagensListaPage.theTitleShouldDisplayTheName(
          "Personagens"
        );
      }
    );

    // opaTest("Should see the characters page when a user clicks on the characters button", function (Given, When, Then) {
    //   //Actions
    //   When.onTheHomePage.iPressOnCharactersButton();

    //   // Assertions
    //   Then.onThePersonagemListaPage.theListShouldHaveAllEntries();

    //   // Cleanup
    //   Then.iTeardownMyApp();
    // });
  }
);
