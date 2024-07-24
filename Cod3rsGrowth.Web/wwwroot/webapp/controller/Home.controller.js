sap.ui.define(["../controller/BaseController"], function (BaseController) {
  "use strict";
  return BaseController.extend("ui5.o_senhor_dos_aneis.controller.Home", {
    onDisplayNotFound: function () {
      //display the "notFound" target without changing the hash
      this.getOwnerComponent().getRouter().getTargets().display("notFound", {
        fromTarget: "home",
      });
    },
  });
});
