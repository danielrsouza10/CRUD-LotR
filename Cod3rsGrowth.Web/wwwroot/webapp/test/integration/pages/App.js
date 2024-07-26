sap.ui.define(
  ["sap/ui/test/Opa5", "sap/ui/test/actions/Press"],
  (Opa5, Press) => {
    "use strict";

    const sViewName = "ui5.o_senhor_dos_aneis.view.Home";

    Opa5.createPageObjects({
      onTheAppPage: {
        actions: {
          iPressSearchButton() {
            return this.waitFor({
              id: "personagensListBtn",
              viewName: sViewName,
              actions: new Press(),
              errorMessage: "Did not find the 'ShowPersonagensList' button on the Home view",
            });
          },
        },

        assertions: {
          iShouldSeeTheSearchMessageToast() {
            return this.waitFor({
              // Turn off autoWait
              autoWait: false,
              check: function () {
                // Locate the message toast using its class name in a jQuery function
                return Opa5.getJQuery()(".sapMMessageToast").length > 0;
              },
              success() {
                // we set the view busy, so we need to query the parent of the app
                Opa5.assert.ok(true, "The MessageToast was shown");
              },
              errorMessage: "Did not find the MessageToast control",
            });
          },
        },
      },
    });
  }
);
