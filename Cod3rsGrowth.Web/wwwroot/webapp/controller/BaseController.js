sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History",
    "sap/ui/core/UIComponent",
  ],
  function (Controller, History, UIComponent) {
    "use strict";

    return Controller.extend(
      "ui5.o_senhor_dos_aneis.controller.BaseController",
      {
        getRouter: function () {
          return UIComponent.getRouterFor(this);
        },

        onNavBack: function () {
          var historico, hashAnterior;

          historico = History.getInstance();
          hashAnterior = historico.getPreviousHash();

          if (hashAnterior !== undefined) {
            window.history.go(-1);
          } else {
            this.getRouter().navTo("home", {}, true);
          }
        },
      }
    );
  }
);
