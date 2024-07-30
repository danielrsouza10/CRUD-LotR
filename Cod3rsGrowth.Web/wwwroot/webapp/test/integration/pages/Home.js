sap.ui.define(
  [
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/AggregationLengthEquals",
    "sap/ui/test/matchers/I18NText",
    "sap/ui/test/actions/Press",
  ],
  function (Opa5, AggregationLengthEquals, I18NText, Press) {
    "use strict";

    var nomeView = "Home";

    Opa5.createPageObjects({
      naPaginaHome: {
        actions: {
          euApertoOBotaoDePersonagens: function () {
            return this.waitFor({
              id: "personagensListBtn",
              viewName: nomeView,
              actions: new Press(),
              errorMessage: "No path page was found.",
            });
          },
          euApertoOBotaoDeRacas: function () {
            return this.waitFor({
              id: "racasListBtn",
              viewName: nomeView,
              actions: new Press(),
              errorMessage: "No path page was found.",
            });
          },
        },
      },
    });
  }
);
