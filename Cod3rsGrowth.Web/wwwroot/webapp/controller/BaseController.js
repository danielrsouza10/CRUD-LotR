sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History",
    "sap/ui/core/UIComponent",
      "sap/m/MessageBox",
  ],
  function (Controller, History, UIComponent, MessageBox) {
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
          _exibirErros: function (erros) {
              const espacoEntreErros = ".\n";
              if (erros.status) {
                  let mensagemDeErro = Object.values(erros.extensions.erros).join(
                      espacoEntreErros
                  );
                  const tituloErro = erros.title;
                  const detalhesDoErro = erros.detail;
                  MessageBox.error(mensagemDeErro, {
                      title: tituloErro,
                      details: detalhesDoErro,
                      contentWidth: "400px",
                      dependentOn: this.getView(),
                  });
              }
              if (
                  this.errosDeValidacao.caracteresEspeciais ||
                  this.errosDeValidacao.tamanhoDaString ||
                  this.errosDeValidacao.idadeMinima ||
                  this.errosDeValidacao.alturaMinima
              ) {
                  let mensagemDeErro = Object.values(this.errosDeValidacao).join(
                      espacoEntreErros
                  );
                  const tituloErro = "Erro ao criar raça";
                  const detailsErro =
                      "Corrija os campos acima para prosseguir com a criação da raça";
                  MessageBox.error(mensagemDeErro, {
                      title: tituloErro,
                      details: detailsErro,
                      contentWidth: "300px",
                      dependentOn: this.getView(),
                  });
              }
          },
      }
    );
  }
);
