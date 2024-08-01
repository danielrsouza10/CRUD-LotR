sap.ui.define(["../controller/BaseController"], function (BaseController) {
  "use strict";

  const ROTA_PERSONAGENS = "listaDePersonagens";
  const ROTA_RACAS = "listaDeRacas";
  
  return BaseController.extend("ui5.o_senhor_dos_aneis.controller.Home", {
    onNavToPersonagens() {
      this.getRouter().navTo(ROTA_PERSONAGENS);
    },
    onNavToRacas: function () {
      this.getRouter().navTo(ROTA_RACAS);
    },
  });
});
