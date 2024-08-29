sap.ui.define(
  [
    "../controller/BaseController",
    "ui5/o_senhor_dos_aneis/services/RacaService",
    "ui5/o_senhor_dos_aneis/services/PersonagemService",
    "sap/ui/model/json/JSONModel",
    "ui5/o_senhor_dos_aneis/model/formatter",
  ],

  function (
    BaseController,
    RacaService,
    PersonagemService,
    JSONModel,
    formatter
  ) {
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
          this.filtros = {};
          this._carregarModeloDaRaca(oEvent);
          this._carregarModeloDePersonagens(oEvent);
        },
        onNavToEditarRaca: function () {
          const modelo = "raca",
            rotaEditarRaca = "editarRaca",
            idRacaSelecionada = this.getView().getModel(modelo).getData().id;
          this.onNavTo(rotaEditarRaca, { id: idRacaSelecionada });
        },
        aoPressionarOBotaoRemover: async function () {
          const tituloDoDialogo = "Excluir registro",
            mensagemDoDialogo = "Deseja confirmar a exclusão desse registro?";
          const confirmacao = await this.criarDialogoDeAviso(
            tituloDoDialogo,
            mensagemDoDialogo
          );
          if (confirmacao) {
            const modelo = "raca";
            const idRaca = this.getView().getModel(modelo).getData().id;
            try {
              await RacaService.removerRaca(idRaca);
              const mensagemDeSucesso = "Raça removida com sucesso!";
              const tituloDaMessageBox = "Sucesso";
              this.criarDialogoDeSucesso(mensagemDeSucesso, tituloDaMessageBox);
            } catch (erros) {
              this._exibirErros(erros);
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
        _carregarModeloDePersonagens: async function (oEvent) {
          try {
            const idRaca = oEvent.getParameter("arguments").id;
            const raca = await RacaService.obterRaca(idRaca);
            this.filtros.nomeDaRaca = raca.nome;
            const personagens = await PersonagemService.obterTodos(
              this.filtros
            );
            const modelo = new JSONModel(personagens);
            const modeloPersonagens = "personagens";

            this.getView().setModel(modelo, modeloPersonagens);
          } catch (erros) {}
        },
      }
    );
  }
);
