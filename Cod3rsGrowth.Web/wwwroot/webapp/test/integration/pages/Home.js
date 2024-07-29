sap.ui.define(
  [
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/AggregationLengthEquals",
    "sap/ui/test/matchers/I18NText",
    "sap/ui/test/matchers/BindingPath",
    "sap/ui/test/actions/Press",
  ],
  function (Opa5, AggregationLengthEquals, I18NText, BindingPath, Press) {
    "use strict";

    var nomeView = "Home",
      buttonId = "personagensListBtn";

    Opa5.createPageObjects({
      onTheHomePage: {
        actions: {
          iPressOnCharactersButton: function () {
            return this.waitFor({
              id: buttonId,
              viewName: nomeView,
              matchers: new BindingPath({
                path: "/personagens",
              }),
              actions: new Press(),
              errorMessage: "No path page was found.",
            });
          },
        },
        // assertions: {
        //   theHomePageShouldHaveAButton: function () {
        //     return this.waitFor({
        //       id: buttonId,
        //       viewName: nomeView,
        //       success: function () {
        //         Opa5.assert.ok(true, "The view has a button of characters");
        //       },
        //       errorMessage: "Cannot find a button of characters.",
        //     });
        //   },

        //   theListShouldHaveAllEntries: function () {
        //     return this.waitFor({
        //       id: buttonId,
        //       viewName: nomeView,
        //       matchers: new AggregationLengthEquals({
        //         name: "items",
        //         length: 15,
        //       }),
        //       success: function () {
        //         Opa5.assert.ok(true, "The list has 15 items");
        //       },
        //       errorMessage: "The list does not contain all items.",
        //     });
        //   },

        //   theTitleShouldDisplayTheTotalAmountOfItems: function () {
        //     return this.waitFor({
        //       id: "tableHeader",
        //       viewName: nomeView,
        //       matchers: new I18NText({
        //         key: "worklistTableTitleCount",
        //         propertyName: "text",
        //         parameters: [23],
        //       }),
        //       success: function () {
        //         Opa5.assert.ok(true, "The table header has 23 items");
        //       },
        //       errorMessage:
        //         "The table header does not contain the number of items: 23",
        //     });
        //   },
        // },
      },
    });
  }
);
