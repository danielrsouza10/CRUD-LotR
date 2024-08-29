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
    const ID_RADIO_BTN_VIVOOUMORTO = "radioBtnVivoMorto";
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
          this.personagem = {};
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
        aoAdicionarPersonagem: async function () {
          this.modalCriarPersonagem ??= await this.loadFragment({
            name: "ui5.o_senhor_dos_aneis.view.CriarPersonagensModal",
          });

          this.modalCriarPersonagem.open();
        },
        aoFecharModalCriarPersonagem: function (oEvent) {
          this._carregarModeloDePersonagens(oEvent);
          this._pegarValoresDoPersonagemNoModalNaTela();
          this.byId("modalCriarPersonagem").close();
        },
        aoFecharModalCancelarCriarPersonagem: function (oEvent) {
          this._carregarModeloDePersonagens(oEvent);
          this.byId("modalCriarPersonagem").close();
        },

        _pegarValoresDoPersonagemNoModalNaTela: function () {
          const modeloPersonagem = "personagem";
          const modelo = new JSONModel();
          this.getView().setModel(modelo, modeloPersonagem);

          const dadosDoModelo = modelo.getData();
          const condicao = 0;
          const condicaoNoModelo =
            this.byId(ID_RADIO_BTN_VIVOOUMORTO).getSelectedIndex() == condicao
              ? true
              : false;
          //pegar valor da profissao
          //pegar valor do id da raça
          console.log(dadosDoModelo);
          this.personagem = {
            nome: dadosDoModelo.nome,
            idRaca: dadosDoModelo.id,
            altura: dadosDoModelo.altura,
            idade: dadosDoModelo.idade,
            estaVivo: condicaoNoModelo,
          };
          console.log(this.personagem);
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
