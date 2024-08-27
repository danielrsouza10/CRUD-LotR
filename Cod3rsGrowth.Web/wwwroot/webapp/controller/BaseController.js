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
                vincularRota: function (rota, aoCoincidirRota) {
                    var oRouter = sap.ui.core.UIComponent.getRouterFor(this);
                    var oRoute = oRouter.getRoute(rota);
                    if (oRoute) {
                        oRoute.attachPatternMatched(aoCoincidirRota, this);
                    }
                },

                getRouter: function () {
                    return UIComponent.getRouterFor(this);
                },

                onNavBack: function () {
                    var historico, hashAnterior, hashAtual, hashNotFound;

                    historico = History.getInstance();
                    hashAnterior = historico.getPreviousHash();
                    hashAtual = historico._oHashChanger._oRouterHashChanger.hash;
                    hashNotFound = "notFound";

                    if (
                        hashAnterior !== undefined &&
                        hashAnterior !== hashNotFound &&
                        hashAtual !== hashNotFound
                    ) {
                        window.history.go(-1);
                    } else {
                        this.getRouter().navTo("appHome", {});
                    }
                },
                onNavTo: function (rota, parametros) {
                    this.getRouter().navTo(rota, parametros);
                },
                obterTextoI18N: function (chave) {
                    const oBundle = this.getView().getModel("i18n").getResourceBundle();
                    return oBundle.getText(chave);
                },
            }
        );
    }
);
