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

    return BaseController.extend(
      "ui5.o_senhor_dos_aneis.controller.ListaPersonagens",
      {
        formatter: formatter,

        onInit: function () {
          this.filtros = {};
          this.loadPersonagens();
          this.loadRacas();
        },

        loadPersonagens: async function () {
          const personagens = await PersonagemService.obterTodos(this.filtros);
          const modelo = new JSONModel(personagens);

          this.getView().setModel(modelo, "personagens");

          this.getRouter().navTo(
            "personagens",
            Object.keys(this.filtros).length === 0
              ? {}
              : { "?query": this.filtros }
          );
        },

        loadRacas: async function () {
          const racas = await RacaService.obterTodos(this.filtros);
          const modelo = new JSONModel(racas);

          this.getView().setModel(modelo, "racas");

          this.getRouter().navTo(
            "racas",
            Object.keys(this.filtros).length === 0
              ? {}
              : { "?query": this.filtros }
          );
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
          this.filtros = {};
          this.byId("searchFieldPersonagens").setValue("");
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
