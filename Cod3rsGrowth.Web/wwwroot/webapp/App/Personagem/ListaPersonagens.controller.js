sap.ui.define(
  [
    "ui5/o_senhor_dos_aneis/App/common/BaseController",
    "sap/ui/model/json/JSONModel",
    "sap/ui/model/Sorter",
    "ui5/o_senhor_dos_aneis/model/formatter",
    "ui5/o_senhor_dos_aneis/App/Personagem/PersonagemService",
    "ui5/o_senhor_dos_aneis/App/Raca/RacaService",
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
      "ui5.o_senhor_dos_aneis.App.Personagem.ListaPersonagens",
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
          this.exibirEspera(async () => {
            this.getRouter().navTo(
              ROTA_PERSONAGENS,
              Object.keys(this.filtros).length === LISTA_VAZIA
                ? {}
                : { "?query": this.filtros },
              true
            );

            const personagens = await PersonagemService.obterTodos(
              this.filtros
            );
            const modelo = new JSONModel(personagens);
            const modeloPersonagem = "personagens";

            this.modelo(modeloPersonagem, modelo);
          });
        },

        loadRacas: async function () {
          this.exibirEspera(async () => {
            const racas = await RacaService.obterTodos(this.filtros);
            const modelo = new JSONModel(racas);
            const modeloRaca = "racas";

            this.modelo(modeloRaca, modelo);
          });
        },

        aoFiltrarPersonagens: function (oEvent) {
          this.exibirEspera(async () => {
            const filtroNomeDoPersonagem = oEvent.getParameter("query");

            if (filtroNomeDoPersonagem) {
              this.filtros.nomeDoPersonagem = filtroNomeDoPersonagem;
            } else {
              delete this.filtros.nomeDoPersonagem;
            }
            this.loadPersonagens();
          });
        },

        aoMudarRacaNaComboBox: function (oEvent) {
          this.exibirEspera(async () => {
            const filtroRaca = oEvent.getParameter("selectedItem").getText();
            if (filtroRaca) {
              this.filtros.nomeDaRaca = filtroRaca;
            } else {
              delete this.filtros.nomeDaRaca;
            }
            this.loadPersonagens();
          });
        },

        aoMudarProfissaoNaComboBox: function (oEvent) {
          this.exibirEspera(async () => {
            const filtroProfissao = oEvent
              .getParameter("selectedItem")
              .getText();
            if (filtroProfissao) {
              this.filtros.profissao = filtroProfissao;
            } else {
              delete this.filtros.profissao;
            }
            this.loadPersonagens();
          });
        },

        aoSelecionarDataInicial: function (oEvent) {
          this.exibirEspera(async () => {
            const filtroDataInicial = oEvent
              .getSource()
              .getProperty("dateValue")
              .toISOString();
            if (filtroDataInicial) {
              this.filtros.dataInicial = filtroDataInicial;
              debugger;
            } else {
              delete this.filtros.dataInicial;
            }
            this.loadPersonagens();
          });
        },

        aoSelecionarDataFinal: function (oEvent) {
          this.exibirEspera(async () => {
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
          });
        },

        aoChecarVivo: function (oEvent) {
          this.exibirEspera(async () => {
            const filtroVivo = oEvent.getParameter("selected");
            if (filtroVivo) {
              this.filtros.estaVivo = true;
            }
            this.loadPersonagens();
          });
        },

        aoChecarMorto: function (oEvent) {
          this.exibirEspera(async () => {
            const filtroMorto = oEvent.getParameter("selected");
            if (filtroMorto) {
              this.filtros.estaVivo = false;
            }
            this.loadPersonagens();
          });
        },

        aoResetarFiltros: function () {
          this.exibirEspera(async () => {
            const stringVazia = "",
              idSearchField = "searchFieldPersonagens";
            this.filtros = {};
            this.byId(idSearchField).setValue(stringVazia);
            this.loadPersonagens();
          });
        },

        async aoAbrirDialogoDeFiltro() {
          this.exibirEspera(async () => {
            this.oDialog ??= await this.loadFragment({
              name: "ui5.o_senhor_dos_aneis.App.Personagem.FilterPersonagensDialog",
            });

            this.oDialog.open();
          });
        },

        aoFecharDialogoDeFiltro: function () {
          const idFilterDialog = "filterDialog";
          this.exibirEspera(async () => {
            debugger;
            this.loadPersonagens();
            this.byId(idFilterDialog).close();
          });
        },

        aoOrganizar: function () {
          const idListaDePersonagens = "listaDePersonagens",
            propriedade = "items",
            propriedadeOrdenada = "nome";
          this.exibirEspera(async () => {
            var lista = this.byId(idListaDePersonagens);
            var binding = lista.getBinding(propriedade);
            var sorter = new Sorter(propriedadeOrdenada);
            binding.sort(sorter);
          });
        },

        aoAgrupar: function () {
          const idListaDePersonagens = "listaDePersonagens",
            propriedade = "items",
            propriedadeOrdenada = "raca";
          this.exibirEspera(async () => {
            var lista = this.byId(idListaDePersonagens);
            var binding = lista.getBinding(propriedade);
            var sorter = new Sorter(propriedadeOrdenada, false, function (
              contexto
            ) {
              var raca = contexto.getProperty(propriedadeOrdenada);
              return {
                key: raca,
                text: raca,
              };
            });
            binding.sort(sorter);
          });
        },
        onNavToCriarPersonagem: function () {
          const rotaCriarPersonagem = "criarPersonagem";
          this.onNavTo(rotaCriarPersonagem);
        },
      }
    );
  }
);
