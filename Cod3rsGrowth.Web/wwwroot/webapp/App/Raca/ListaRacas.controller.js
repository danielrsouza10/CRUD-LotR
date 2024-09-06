sap.ui.define(
  [
    "../common/BaseController",
    "sap/ui/model/json/JSONModel",
    "ui5/o_senhor_dos_aneis/model/formatter",
    "ui5/o_senhor_dos_aneis/App/Raca/RacaService",
  ],
  (BaseController, JSONModel, formatter, RacaService) => {
    "use strict";

    const ROTA_RACAS = "listaDeRacas";
    const LISTA_VAZIA = 0;

    return BaseController.extend("ui5.o_senhor_dos_aneis.App.Raca.ListaRacas", {
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
        this.exibirEspera(async () => {
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

          this.modelo(modeloRaca, modelo);
        });
      },
      aoSelecionarRacaNaLista: function (oEvent) {
        this.exibirEspera(async () => {
          const rotaDetalhesRaca = "detalhesRaca",
            contexto = "racas",
            propriedade = "id",
            idRacaSelecionada = oEvent
              .getSource()
              .getBindingContext(contexto)
              .getProperty(propriedade);

          this.onNavTo(rotaDetalhesRaca, { id: idRacaSelecionada });
        });
      },

      aoFiltrarRacas: function (oEvent) {
        const parametro = "query";
        this.exibirEspera(async () => {
          const filtroRaca = oEvent.getParameter(parametro);
          if (filtroRaca) {
            this.filtros.nomeDaRaca = filtroRaca;
          } else {
            delete this.filtros.nomeDaRaca;
          }
          this.loadRacas();
        });
      },

      aoChecarExtinta: function (oEvent) {
        const parametro = "selected";
        this.exibirEspera(async () => {
          var filtroExtinta = oEvent.getParameter(parametro);
          if (filtroExtinta) {
            this.filtros.estaExtinta = true;
            return this.loadRacas();
          }
          delete this.filtros.estaExtinta;
          return this.loadRacas();
        });
      },

      aoResetarFiltros: function () {
        this.exibirEspera(async () => {
          const stringVazia = "",
            idBarraDePesquisa = "searchFieldRacas",
            idCheckBoxExtinta = "checkBoxExtinta";

          this.filtros = {};
          this.byId(idBarraDePesquisa).setValue(stringVazia);
          this.byId(idCheckBoxExtinta).setSelected(false);
          this.loadRacas();
        });
      },
      onNavToCriarRaca: function () {
        const rotaCriarRaca = "criarRaca";
        const parametros = "criarNovaRaca";
        this.onNavTo(rotaCriarRaca, parametros);
      },
    });
  }
);
