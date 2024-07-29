sap.ui.define(
  ["sap/ui/test/opaQunit", "./pages/PersonagemLista"],
  function (opaTest) {
    "use strict";

    QUnit.module("Personagens");

    opaTest("Should see the list with all posts", function (Given, When, Then) {
      // Arrangements
      Given.iStartMyApp();

      // Assertions
      Then.onThePersonagemListaPage
        .theListShouldHavePagination()
        .and.theTitleShouldDisplayTheTotalAmountOfItems();
    });

    opaTest("Should be able to load more items", function (Given, When, Then) {
      //Actions
      When.onThePersonagemListaPage.iPressOnMoreData();

      // Assertions
      Then.onThePersonagemListaPage.theListShouldHaveAllEntries();

      // Cleanup
      Then.iTeardownMyApp();
    });
  }
);
