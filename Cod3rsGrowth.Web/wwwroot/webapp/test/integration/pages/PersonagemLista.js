sap.ui.define(
  [
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/AggregationLengthEquals",
    "sap/ui/test/matchers/I18NText",
    "sap/ui/test/matchers/Properties",
    "sap/ui/test/actions/Press",
  ],
  function (Opa5, AggregationLengthEquals, I18NText, Properties, Press) {
    "use strict";

    var nomeView = "PersonagemLista",
      listaId = "listaDePersonagens";

    Opa5.createPageObjects({
      onThePersonagemListaPage: {
        actions: {
          iPressOnMoreData: function () {
            // Press action hits the "more" trigger on a list
            return this.waitFor({
              id: listaId,
              viewName: nomeView,
              actions: new Press(),
              errorMessage: "The list does not have a trigger.",
            });
          },
        },
        assertions: {
          theTitleShouldDisplayTheName: function (sName) {
            return this.waitFor({
              success: function () {
                return this.waitFor({
                  id: "listaDePersonagensPage",
                  viewName: sViewName,
                  matchers: new Properties({
                    title: sName,
                  }),
                  success: function (oPage) {
                    Opa5.assert.ok(true, "was on the remembered detail page");
                  },
                  errorMessage: "The Post " + sName + " is not shown",
                });
              },
            });
          },
          theListShouldHavePagination: function () {
            return this.waitFor({
              id: listaId,
              viewName: nomeView,
              matchers: new AggregationLengthEquals({
                name: "items",
                length: 10,
              }),
              success: function () {
                Opa5.assert.ok(true, "The list has 10 items on the first page");
              },
              errorMessage: "The list does not contain all items.",
            });
          },

          theListShouldHaveAllEntries: function () {
            return this.waitFor({
              id: listaId,
              viewName: nomeView,
              matchers: new AggregationLengthEquals({
                name: "items",
                length: 15,
              }),
              success: function () {
                Opa5.assert.ok(true, "The list has 15 items");
              },
              errorMessage: "The list does not contain all items.",
            });
          },

          theTitleShouldDisplayTheTotalAmountOfItems: function () {
            return this.waitFor({
              id: "tableHeader",
              viewName: nomeView,
              matchers: new I18NText({
                key: "worklistTableTitleCount",
                propertyName: "text",
                parameters: [23],
              }),
              success: function () {
                Opa5.assert.ok(true, "The table header has 23 items");
              },
              errorMessage:
                "The table header does not contain the number of items: 23",
            });
          },
        },
      },
    });
  }
);
