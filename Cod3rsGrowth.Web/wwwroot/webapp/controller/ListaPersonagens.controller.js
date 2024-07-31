sap.ui.define(
    [
        "ui5/o_senhor_dos_aneis/controller/BaseController",
        "sap/ui/model/json/JSONModel",
        "ui5/o_senhor_dos_aneis/model/formatter",
    ],
    (BaseController, JSONModel, formatter) => {
        "use strict";

        return BaseController.extend(
            "ui5.o_senhor_dos_aneis.controller.ListaPersonagens",
            {
                formatter: formatter,

                onInit: function () {
                    this.filtros = {};
                    this.loadPersonagens();
                    this.loadRacas();

                    var oRouter = sap.ui.core.UIComponent.getRouterFor(this);
                    var oRoute = oRouter.getRoute("personagens");
                    if (oRoute) {
                        oRoute.attachPatternMatched(this._onRouteMatched, this);
                    }
                },

                _onRouteMatched: function () {
                    this.loadPersonagens();
                },

                loadPersonagens: function () {
                    let url = this.construirUrlComParametros();

                    fetch(url)
                        .then((response) => {
                            if (!response.ok) {
                                throw new Error("Sem resposta: " + response.statusText);
                            }
                            return response.json();
                        })
                        .then((dados) => {
                            const objetoModelo = new JSONModel(dados);
                            this.getView().setModel(objetoModelo, "personagens");
                        })
                        .catch((error) => {
                            console.error("Houve um problema de fetch", error);
                        });

                    const currentUrl = new URL(window.location.href);
                    const params = new URLSearchParams(currentUrl.search);

                    Object.keys(this.filtros).forEach((key) => {
                        if (this.filtros[key]) {
                            params.set(key, this.filtros[key]);
                        } else {
                            params.delete(key);
                        }
                    });

                    // const newUrl = `${currentUrl.pathname}?${params.toString()}`;
                    // window.history.replaceState(null, null, newUrl);
                },

                aoFiltrarPersonagens: function (oEvent) {
                    var nome = oEvent.getParameter("query");
                    this.filtros.nome = nome ? encodeURIComponent(nome) : "";
                    this.loadPersonagens();
                },

                aoMudarRacaNaComboBox: function (oEvent) {
                    var raca = oEvent.getParameter("selectedItem").getText();
                    this.filtros.raca = raca ? encodeURIComponent(raca) : "";
                    this.loadPersonagens();
                },

                aoMudarProfissaoNaComboBox: function (oEvent) {
                    var profissao = oEvent.getParameter("selectedItem").getText();
                    this.filtros.profissao =
                        profissao && profissao !== "Nenhum"
                            ? encodeURIComponent(profissao)
                            : "";
                    this.loadPersonagens();
                },

                aoSelecionarDataInicial: function (oEvent) {
                    var dataInicial = oEvent
                        .getSource()
                        .getProperty("dateValue")
                        .toISOString();
                    this.filtros.dataInicial = encodeURIComponent(dataInicial);
                    this.loadPersonagens();
                },

                aoSelecionarDataFinal: function (oEvent) {
                    var dataFinal = oEvent
                        .getSource()
                        .getProperty("dateValue")
                        .toISOString();
                    this.filtros.dataFinal = encodeURIComponent(dataFinal);
                    this.loadPersonagens();
                },

                aoChecarVivo: function (oEvent) {
                    var vivo = oEvent.getParameter("selected");
                    this.filtros.vivo = vivo ? "true" : "";
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

                loadRacas: function () {
                    const stringUrlRacas = "https://localhost:7244/api/Raca/racas";
                    fetch(stringUrlRacas)
                        .then((response) => {
                            if (!response.ok) {
                                throw new Error("Sem resposta: " + response.statusText);
                            }
                            return response.json();
                        })
                        .then((dados) => {
                            const objetoModelo = new JSONModel(dados);
                            this.getView().setModel(objetoModelo, "racas");
                        })
                        .catch((error) => {
                            console.error("Houve um problema de fetch", error);
                        });
                },

                construirUrlComParametros: function () {
                    let url = "https://localhost:7244/api/Personagem/personagens";
                    let parametros = [];

                    if (this.filtros.nome)
                        parametros.push(`NomeDoPersonagem=${this.filtros.nome}`);
                    if (this.filtros.raca)
                        parametros.push(`NomeDaRaca=${this.filtros.raca}`);
                    if (this.filtros.profissao)
                        parametros.push(`Profissao=${this.filtros.profissao}`);
                    if (this.filtros.dataInicial)
                        parametros.push(`DataInicial=${this.filtros.dataInicial}`);
                    if (this.filtros.dataFinal)
                        parametros.push(`DataFinal=${this.filtros.dataFinal}`);
                    if (this.filtros.vivo)
                        parametros.push(`EstaVivo=${this.filtros.vivo}`);

                    if (parametros.length > 0) {
                        url += "?" + parametros.join("&");
                    }

                    return url;
                },
            }
        );
    }
);
