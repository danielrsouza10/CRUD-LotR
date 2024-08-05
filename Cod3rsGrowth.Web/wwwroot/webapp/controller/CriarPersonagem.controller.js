sap.ui.define(["../controller/BaseController"], function (BaseController) {
  "use strict";

  return BaseController.extend(
    "ui5.o_senhor_dos_aneis.controller.CriarPersonagem",
    {
      //         onInit: function () {
      //           this.filtros = {};
      //           const rota = "racas";
      //           this.vincularRota(rota, this.aoCoincidirRota);
      //         },
      //         aoCoincidirRota: function () {
      //           this.loadRacas();
      //         },
      //         loadRacas: async function () {
      //           this.getRouter().navTo(
      //             ROTA_RACAS,
      //             Object.keys(this.filtros).length === LISTA_VAZIA
      //               ? {}
      //               : { "?query": this.filtros }
      //           );
      //           const racas = await RacaService.obterTodos(this.filtros);
      //           const modelo = new JSONModel(racas);
      //           const modeloRaca = "racas";
      //           this.getView().setModel(modelo, modeloRaca);
      //         },
    }
  );
});
