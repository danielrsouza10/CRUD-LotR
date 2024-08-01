sap.ui.define(
  [
    "../controller/BaseController",
    "sap/ui/model/json/JSONModel",
    "ui5/o_senhor_dos_aneis/model/formatter",
    "ui5/o_senhor_dos_aneis/services/RacaService",
  ],
  (BaseController, JSONModel, formatter, RacaService) => {
    "use strict";

    return BaseController.extend(
      "ui5.o_senhor_dos_aneis.controller.ListaRacas",
      {
        formatter: formatter,

        onInit: function () {
          this.filtros = {};
          this.loadRacas();
        },

        loadRacas: async function () {
          const racas = await RacaService.obterTodos(this.filtros);
          const modelo = new JSONModel(racas);

          this.getView().setModel(modelo, "racas");

          this.getRouter().navTo(
            "racas",
            Object.keys(this.filtros).length === 0
              ? {}
              : { "?query": this.filtros }
          );
        },

        aoFiltrarRacas: function (oEvent) {
          const filtroRaca = oEvent.getParameter("query");
          if (filtroRaca) {
            this.filtros.nomeDaRaca = filtroRaca;
          } else {
            delete this.filtros.nomeDaRaca;
          }
          this.loadRacas();
        },

        aoChecarExtinta: function (oEvent) {
          var filtroExtinta = oEvent.getParameter("selected");
          if (filtroExtinta) {
            this.filtros.estaExtinta = true;
          }
          this.loadRacas();
        },

        aoResetarFiltros: function () {
          this.filtros = {};
          this.byId("searchFieldRacas").setValue("");
          this.loadRacas();
        },
      }
    );
  }
);
