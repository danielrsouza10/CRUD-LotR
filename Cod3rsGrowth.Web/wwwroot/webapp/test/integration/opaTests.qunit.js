/* global QUnit */
QUnit.config.autostart = false;

sap.ui.require(
  [
    "sap/ui/core/Core",
    "sap/ui/test/Opa5",
    "ui5/o_senhor_dos_aneis/test/integration/AllJourneys",
  ],
  async function (Core, Opa5) {
    "use strict";

    await Core.ready();

    QUnit.start();
  }
);
