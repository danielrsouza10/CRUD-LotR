sap.ui.define(["sap/ui/test/opaQunit", "./pages/App"], (opaTest) => {
  "use strict";

  QUnit.module("Navigation");

  opaTest("Should open the Message Toast", (Given, When, Then) => {
    // Arrangements
    Given.iStartMyUIComponent({
      componentConfig: {
        name: "ui5.o_senhor_dos_aneis",
      },
    });

    //Actions
    When.onTheAppPage.iPressSearchButton();

    // Assertions
    Then.onTheAppPage.iShouldSeeTheSearchMessageToast();

    // Cleanup
    Then.iTeardownMyApp();
  });
});
