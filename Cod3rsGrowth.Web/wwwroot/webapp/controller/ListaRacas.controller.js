sap.ui.define(
  [
    "../controller/BaseController",
    "sap/ui/model/json/JSONModel",
    "ui5/o_senhor_dos_aneis/model/formatter",
    "ui5/o_senhor_dos_aneis/services/RacaService",
  ],
  (BaseController, JSONModel, formatter, RacaService) => {
    "use strict";

    const ROTA_RACAS = "listaDeRacas";
    const LISTA_VAZIA = 0;

    return BaseController.extend(
      "ui5.o_senhor_dos_aneis.controller.ListaRacas",
      {
        formatter: formatter,

        onInit: function () {
          this.filtros = {};
          const rota = "listaDeRacas";
          this.vincularRota(rota, this.aoCoincidirRota);
        },

        aoCoincidirRota: function () {
          this.loadRacas();
        },

        loadRacas: async function () {
          this.getRouter().navTo(
            ROTA_RACAS,
            Object.keys(this.filtros).length === LISTA_VAZIA
              ? {}
              : { "?query": this.filtros },
            true
          );

          const racas = await RacaService.obterTodos(this.filtros);
          const modelo = new JSONModel(racas);
          const modeloRaca = "racas";

          this.getView().setModel(modelo, modeloRaca);
        },
        aoSelecionarRacaNaLista: function (oEvent) {
          const idRacaSelecionada = oEvent
            .getSource()
            .getBindingContext("racas")
            .getProperty("id");
          const rotaDetalhesRaca = "detalhesRaca";
          this.onNavTo(rotaDetalhesRaca, { id: idRacaSelecionada });
        },

        aoFiltrarRacas: function (oEvent) {
          const filtroRaca = oEvent.getParameter("query");
          if (filtroRaca) {
            this.filtros.nomeDaRaca = filtroRaca;
          } else {
            delete this.filtros.nomeDaRaca;
          }
          this.loadRacas();
        },

        aoChecarExtinta: function (oEvent) {
          var filtroExtinta = oEvent.getParameter("selected");
          if (filtroExtinta) {
            this.filtros.estaExtinta = true;
            return this.loadRacas();
          }
          delete this.filtros.estaExtinta;
          return this.loadRacas();
        },

        aoResetarFiltros: function () {
          const stringVazia = "",
            idBarraDePesquisa = "searchFieldRacas",
            idCheckBoxExtinta = "checkBoxExtinta";

          this.filtros = {};
          this.byId(idBarraDePesquisa).setValue(stringVazia);
          this.byId(idCheckBoxExtinta).setSelected(false);
          this.loadRacas();
        },
        onNavToCriarRaca: function () {
          const rotaCriarRaca = "criarRaca";
          this.onNavTo(rotaCriarRaca);
        },
      }
    );
  }
);
