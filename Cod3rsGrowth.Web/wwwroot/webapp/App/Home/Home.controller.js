sap.ui.define(["../common/BaseController"], function (BaseController) {
  "use strict";

  const ROTA_PERSONAGENS = "listaDePersonagens";
  const ROTA_RACAS = "listaDeRacas";

  return BaseController.extend(
    "ui5.o_senhor_dos_aneis.controller.App.Home.Home",
    {
      onNavToPersonagens() {
        this.onNavTo(ROTA_PERSONAGENS, this);
      },
      onNavToRacas: function () {
        this.onNavTo(ROTA_RACAS, this);
      },
    }
  );
});
