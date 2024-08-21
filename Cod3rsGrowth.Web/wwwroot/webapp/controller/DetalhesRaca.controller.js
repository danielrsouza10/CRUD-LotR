sap.ui.define(
  [
    "../controller/BaseController",
    "ui5/o_senhor_dos_aneis/services/RacaService",
    "sap/ui/model/json/JSONModel",
    "sap/m/MessageBox",
  ],

  function (BaseController, RacaService, JSONModel, MessageBox) {
    "use strict";
    return BaseController.extend(
      "ui5.o_senhor_dos_aneis.controller.DetalhesRaca",
      {
        onInit: function () {
          const rota = "detalhesRaca";
          this.vincularRota(rota, this.aoCoincidirRota);
        },
        aoCoincidirRota: function (oEvent) {
          try {
            const idRaca = oEvent.getParameter("arguments").id;
            const raca = RacaService.obterRaca(idRaca);
            const modelo = new JSONModel(raca);
            const modeloRaca = "raca";

            this.getView().setModel(modelo, modeloRaca);
            console.log(modelo);
          } catch (erros) {
            const mensagemDeErro =
              "Não foi possivel carregar a raça selecionada";
            console.log(mensagemDeErro);
            MessageBox.show(mensagemDeErro, {
              icon: sap.m.MessageBox.Icon.ERROR,
              title: "Erro",
              dependentOn: this.getView(),
            });
            const tempoParaVisualizarMensagem = 2000;
            setTimeout(() => this.onNavBack(), tempoParaVisualizarMensagem);
          }
        },
      }
    );
  }
);
