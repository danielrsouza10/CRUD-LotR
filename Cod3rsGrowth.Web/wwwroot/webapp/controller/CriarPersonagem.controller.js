sap.ui.define(
  [
    "../controller/BaseController",
    "sap/ui/model/json/JSONModel",
    "ui5/o_senhor_dos_aneis/services/RacaService",
  ],
  function (BaseController, JSONModel, RacaService) {
    "use strict";

    return BaseController.extend(
      "ui5.o_senhor_dos_aneis.controller.CriarPersonagem",
      {
        onInit: function () {
          this.filtros = {};
          const rota = "criarPersonagem";
          this.vincularRota(rota, this.aoCoincidirRota);
        },

        aoCoincidirRota: function () {
          this.loadRacas();
        },

        _verificarCaracteresEspeciais: function (str) {
          const regex = /[^a-zA-Z0-9]/;
          return regex.test(str);
        },

        _verificarTamanhoString: function (str) {
          let tamanhoMinimo = 3;
          return str.length < tamanhoMinimo;
        },

        _validarInputUsuario: function (objetoInput) {
          let erroValidacao = false;
          let nomeInseridoInput = objetoInput.getValue();

          let contemCaracteresEspeciais =
            this._verificarCaracteresEspeciais(nomeInseridoInput);

          if (!contemCaracteresEspeciais) {
            let valueState = this._verificarTamanhoString(nomeInseridoInput)
              ? "Error"
              : "Success"; //valor visual do input do usuario no front
            objetoInput.setValueState(valueState);
          }

          //   this._verificarCaracteresEspeciais(textoInput);

          //   try {
          //     binding.getType().validateValue(inputUsuario.getValue());
          // 	valueState = "Success";
          //   } catch (exception) {
          //     valueState = "Error";
          //     erroValidacao = true;
          //   }
          //   objetoInput.setValueState(valueState);

          return erroValidacao;
        },

        loadRacas: async function () {
          const racas = await RacaService.obterTodos(this.filtros);
          const modelo = new JSONModel(racas);
          const modeloRaca = "racas";

          this.getView().setModel(modelo, modeloRaca);
        },
        aoMudarNome: function (oEvent) {
          const objetoInput = oEvent.getSource();
          this._validarInputUsuario(objetoInput);
          console.log(objetoInput);
        },
      }
    );
  }
);
