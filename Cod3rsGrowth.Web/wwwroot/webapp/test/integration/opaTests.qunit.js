QUnit.config.autostart = false;

sap.ui.require(["sap/ui/core/Core"], async (Core) => {
  "use strict";

  await Core.ready();

  sap.ui.require(
    [
      //   "ui5/o_senhor_dos_aneis/localService/mockserver",
      "ui5/o_senhor_dos_aneis/test/integration/NavigationJourney",
    ],
    () => {
      // initialize the mock server
      //   mockserver.init();
      QUnit.start();
    }
  );
});
