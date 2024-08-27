sap.ui.define(
  [
    "../controller/BaseController",
    "ui5/o_senhor_dos_aneis/services/RacaService",
    "sap/ui/model/json/JSONModel",
    "ui5/o_senhor_dos_aneis/model/formatter",
  ],

  function (BaseController, RacaService, JSONModel, formatter) {
    "use strict";
    return BaseController.extend(
      "ui5.o_senhor_dos_aneis.controller.DetalhesRaca",
      {
        formatter: formatter,

        onInit: function () {
          const rota = "detalhesRaca";
          this.vincularRota(rota, this.aoCoincidirRota);
        },
        aoCoincidirRota: function (oEvent) {
          this._carregarModeloDaRaca(oEvent);
        },
        onNavToEditarRaca: function () {
          const modelo = "raca",
            rotaEditarRaca = "editarRaca",
            idRacaSelecionada = this.getView().getModel(modelo).getData().id;
          this.onNavTo(rotaEditarRaca, { id: idRacaSelecionada });
        },
          aoPressionarOBotaoRemover: function (){
            if(_desejaExcluirEsseRegistro()){
                const idRaca = this.getView().getModel(modelo).getData().id;
                try{
                RacaService.removerRaca(idRaca);
                }catch(erros){
                    _exibirErros(erros);
                }
            }
          },
        _carregarModeloDaRaca: async function (oEvent) {
          try {
            const idRaca = oEvent.getParameter("arguments").id;
            const raca = await RacaService.obterRaca(idRaca);
            const modelo = new JSONModel(raca);
            const modeloRaca = "raca";

            this.getView().setModel(modelo, modeloRaca);
          } catch (erros) {
            const rotaNotFound = "notFound";
            this.onNavTo(rotaNotFound, this);
          }
        },
      }
    );
  }
);
