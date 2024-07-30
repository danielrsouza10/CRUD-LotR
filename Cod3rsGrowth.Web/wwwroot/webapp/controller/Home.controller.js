sap.ui.define(["../controller/BaseController"], function (BaseController) {
  "use strict";
  return BaseController.extend("ui5.o_senhor_dos_aneis.controller.Home", {
    onNavToPersonagens() {
      this.getRouter().navTo("listaDePersonagens");
    },
    onNavToRacas: function () {
      this.getRouter().navTo("listaDeRacas");
    },
  });
});
