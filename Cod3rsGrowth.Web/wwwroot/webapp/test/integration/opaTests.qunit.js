/* global QUnit */
QUnit.config.autostart = false;

sap.ui.require(
  ["sap/ui/core/Core", "ui5/o_senhor_dos_aneis/test/integration/AllJourneys"],
  async function (Core) {
    "use strict";

    await Core.ready();

    QUnit.start();
  }
);
