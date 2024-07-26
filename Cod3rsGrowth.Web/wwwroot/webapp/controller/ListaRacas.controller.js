sap.ui.define(
  [
    "../controller/BaseController",
    "sap/ui/model/json/JSONModel",
    "ui5/o_senhor_dos_aneis/model/formatter",
  ],
  function (BaseController, JSONModel, formatter) {
    "use strict";
    const stringBaseUrlRacas = "https://localhost:7244/api/Raca/racas";
    let filtroNomeDaRaca = "";
    let filtroEstaExtinta = "";

    return BaseController.extend(
      "ui5.o_senhor_dos_aneis.controller.ListaRacas",
      {
        formatter: formatter,

        onInit() {
          this.loadRacas();
        },
        loadRacas() {
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
        construirUrlComParametros() {
          let url = stringBaseUrlRacas;
          let urlPadrao = "https://localhost:7244//webapp/index.html#/racas";
          let parametros = [];

          if (filtroNomeDaRaca) {
            parametros.push(
              `NomeDaRaca=${encodeURIComponent(filtroNomeDaRaca)}`
            );
          }
          if (filtroEstaExtinta) {
            parametros.push(
              `EstaExtinta=${encodeURIComponent(filtroEstaExtinta)}`
            );
          }
          if (parametros.length > 0) {
            url += "?" + parametros.join("&");
            urlPadrao += "?" + parametros.join("&");
          }
          window.history.replaceState(null, null, urlPadrao);
          return url;
        },
        onFiltrarRacas(evento) {
          filtroNomeDaRaca = evento.getParameter("query");
          this.loadRacas();
        },
        onReset() {
          filtroNomeDaRaca = "";
          filtroEstaExtinta = "";
          this.getView().byId("searchFieldRacas").setValue("");
          this.loadRacas();
        },
      }
    );
  }
);
