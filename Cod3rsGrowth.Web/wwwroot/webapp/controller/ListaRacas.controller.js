sap.ui.define(
  [
    "../controller/BaseController",
    "sap/ui/model/json/JSONModel",
    "ui5/o_senhor_dos_aneis/model/formatter",
  ],
  (BaseController, JSONModel, formatter) => {
    "use strict";

    const stringBaseUrlRacas = "https://localhost:7244/api/Raca/racas";

    return BaseController.extend(
      "ui5.o_senhor_dos_aneis.controller.ListaRacas",
      {
        formatter: formatter,

        onInit: function () {
          this.filtros = {};
          this.loadRacas();

          var oRouter = sap.ui.core.UIComponent.getRouterFor(this);
          var oRoute = oRouter.getRoute("racas");
          if (oRoute) {
            oRoute.attachPatternMatched(this._onRouteMatched, this);
          }
        },

        _onRouteMatched: function () {
          this.loadRacas();
        },

        loadRacas: function () {
          let url = this.construirUrlComParametros();

          fetch(url)
            .then((response) => {
              if (!response.ok) {
                throw new Error("Sem resposta: " + response.statusText);
              }
              return response.json();
            })
            .then((dados) => {
              const objetoModelo = new JSONModel(dados);
              this.getView().setModel(objetoModelo, "racas");
            })
            .catch((error) => {
              console.error("Houve um problema de fetch", error);
            });
        },

        aoFiltrarRacas: function (oEvent) {
          var nomeDaRaca = oEvent.getParameter("query");
          this.filtros.nomeDaRaca = nomeDaRaca
            ? encodeURIComponent(nomeDaRaca)
            : "";
          this.loadRacas();
        },

        aoChecarExtinta: function (oEvent) {
          var estaExtinta = oEvent.getParameter("selected");
          this.filtros.estaExtinta = estaExtinta ? "true" : "";
          this.loadRacas();
        },

        aoResetarFiltros: function () {
          this.filtros = {};
          this.byId("searchFieldRacas").setValue("");
          this.loadRacas();
        },

        construirUrlComParametros: function () {
          let url = stringBaseUrlRacas;
          let parametros = [];

          if (this.filtros.nomeDaRaca)
            parametros.push(`NomeDaRaca=${this.filtros.nomeDaRaca}`);
          if (this.filtros.estaExtinta)
            parametros.push(`EstaExtinta=${this.filtros.estaExtinta}`);

          if (parametros.length > 0) {
            url += "?" + parametros.join("&");
          }

          return url;
        },
      }
    );
  }
);
