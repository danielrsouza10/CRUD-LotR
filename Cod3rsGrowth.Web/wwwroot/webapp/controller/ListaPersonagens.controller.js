sap.ui.define(
  [
    "ui5/o_senhor_dos_aneis/controller/BaseController",
    "sap/ui/model/json/JSONModel",
    "sap/ui/model/Sorter",
    "ui5/o_senhor_dos_aneis/model/formatter",
    "ui5/o_senhor_dos_aneis/services/PersonagemService",
    "ui5/o_senhor_dos_aneis/services/RacaService",
  ],
  (
    BaseController,
    JSONModel,
    Sorter,
    formatter,
    PersonagemService,
    RacaService
  ) => {
    "use strict";

    const ROTA_PERSONAGENS = "listaDePersonagens";
    const LISTA_VAZIA = 0;

    return BaseController.extend(
      "ui5.o_senhor_dos_aneis.controller.ListaPersonagens",
      {
        formatter: formatter,

        onInit: function () {
          this.filtros = {};
          const rota = "listaDePersonagens";
          this.vincularRota(rota, this.aoCoincidirRota);
        },

        aoCoincidirRota: function () {
          this.loadPersonagens();
          this.loadRacas();
        },

        loadPersonagens: async function () {
          this.getRouter().navTo(
            ROTA_PERSONAGENS,
            Object.keys(this.filtros).length === LISTA_VAZIA
              ? {}
              : { "?query": this.filtros }
          );

          const personagens = await PersonagemService.obterTodos(this.filtros);
          const modelo = new JSONModel(personagens);
          const modeloPersonagem = "personagens";

          this.getView().setModel(modelo, modeloPersonagem);
        },

        loadRacas: async function () {
          const racas = await RacaService.obterTodos(this.filtros);
          const modelo = new JSONModel(racas);
          const modeloRaca = "racas";

          this.getView().setModel(modelo, modeloRaca);
        },

        aoFiltrarPersonagens: function (oEvent) {
          const filtroNome = oEvent.getParameter("query");

          if (filtroNome) {
            this.filtros.nomeDoPersonagem = filtroNome;
          } else {
            delete this.filtros.nomeDoPersonagem;
          }
          this.loadPersonagens();
        },

        aoMudarRacaNaComboBox: function (oEvent) {
          const filtroRaca = oEvent.getParameter("selectedItem").getText();
          if (filtroRaca) {
            this.filtros.nomeDaRaca = filtroRaca;
          } else {
            delete this.filtros.nomeDaRaca;
          }
          this.loadPersonagens();
        },

        aoMudarProfissaoNaComboBox: function (oEvent) {
          const filtroProfissao = oEvent.getParameter("selectedItem").getText();
          if (filtroProfissao) {
            this.filtros.profissao = filtroProfissao;
          } else {
            delete this.filtros.profissao;
          }
          this.loadPersonagens();
        },

        aoSelecionarDataInicial: function (oEvent) {
          const filtroDataInicial = oEvent
            .getSource()
            .getProperty("dateValue")
            .toISOString();
          if (filtroDataInicial) {
            this.filtros.dataInicial = filtroDataInicial;
          } else {
            delete this.filtros.dataInicial;
          }
          this.loadPersonagens();
        },

        aoSelecionarDataFinal: function (oEvent) {
          const filtroDataFinal = oEvent
            .getSource()
            .getProperty("dateValue")
            .toISOString();
          if (filtroDataFinal) {
            this.filtros.dataFinal = filtroDataFinal;
          } else {
            delete this.filtros.dataFinal;
          }
          this.loadPersonagens();
        },

        aoChecarVivo: function (oEvent) {
          const filtroVivo = oEvent.getParameter("selected");
          if (filtroVivo) {
            this.filtros.estaVivo = true;
          }
          this.loadPersonagens();
        },

        aoChecarMorto: function (oEvent) {
          const filtroMorto = oEvent.getParameter("selected");
          if (filtroMorto) {
            this.filtros.estaVivo = false;
          }
          this.loadPersonagens();
        },

        aoResetarFiltros: function () {
          const stringVazia = "";
          this.filtros = {};
          this.byId("searchFieldPersonagens").setValue(stringVazia);
          this.loadPersonagens();
        },

        async aoAbrirDialogoDeFiltro() {
          this.oDialog ??= await this.loadFragment({
            name: "ui5.o_senhor_dos_aneis.view.FilterPersonagensDialog",
          });

          this.oDialog.open();
        },

        aoFecharDialogoDeFiltro: function () {
          this.loadPersonagens();
          this.byId("filterDialog").close();
        },

        aoOrganizar: function () {
          var lista = this.byId("listaDePersonagens");
          var binding = lista.getBinding("items");
          var sorter = new Sorter("nome");
          binding.sort(sorter);
        },

        aoAgrupar: function () {
          var lista = this.byId("listaDePersonagens");
          var binding = lista.getBinding("items");
          var sorter = new Sorter("raca", false, function (contexto) {
            var raca = contexto.getProperty("raca");
            return {
              key: raca,
              text: raca,
            };
          });
          binding.sort(sorter);
        },
      }
    );
  }
);
