sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "sap/ui/model/Filter",
    "sap/ui/model/FilterOperator",
    "../model/formatter",
  ],
  function (Controller, JSONModel, Filter, FilterOperator, formatter) {
    "use strict";
    let filtro = [];
    let filtroNome = "";
    let filtroRaca = "";
    let filtroProfissao = "";
    let filtroDataInicial = "";
    let filtroDataFinal = "";

    return Controller.extend("ui5.o_senhor_dos_aneis.controller.List", {
      formatter: formatter,
      onInit() {
        this.loadPersonagens();
        this.loadRacas();
      },
      loadPersonagens() {
        const stringUrl = "https://localhost:7244/api/Personagem/personagens";
        fetch(stringUrl)
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
      },
      loadRacas() {
        const stringUrl = "https://localhost:7244/api/Raca/racas";
        fetch(stringUrl)
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
      onFiltrarPersonagens(evento) {
        filtroNome = evento.getParameter("query");
        this.aplicarFiltro();
      },
      async onOpenDialogoDeFiltro() {
        // create dialog lazily
        this.oDialog ??= await this.loadFragment({
          name: "ui5.o_senhor_dos_aneis.view.FilterDialog",
        });

        this.oDialog.open();
        this.limparFiltro();
      },
      onCloseDialogoDeFiltro() {
        this.aplicarFiltro();
        this.limparFiltro();
        this.byId("filterDialog").close();
      },
      onChangeComboBoxRacas(evento) {
        const itemSelecionado = evento.getParameter("selectedItem");
        if (itemSelecionado) {
          filtroRaca = itemSelecionado.getText();
        }
      },
      onChangeComboBoxProfissoes(evento) {
        const itemSelecionado = evento.getParameter("selectedItem");
        if (itemSelecionado && itemSelecionado.getText() != "Nenhum") {
          filtroProfissao = itemSelecionado.getText();
        } else {
          filtroProfissao = "";
        }
      },
      onReset() {
        filtro = [];
        const listaDePersonagens = this.getView().byId("listaDePersonagens");
        const binding = listaDePersonagens.getBinding("items");
        binding.filter(filtro);
      },
      aplicarFiltro() {
        if (filtroNome) {
          filtro.push(new Filter("nome", FilterOperator.Contains, filtroNome));
        }
        if (filtroRaca) {
          filtro.push(new Filter("raca", FilterOperator.Contains, filtroRaca));
        }
        if (filtroProfissao) {
          filtro.push(
            new Filter("profissao", FilterOperator.Contains, filtroProfissao)
          );
        }
        const listaDePersonagens = this.getView().byId("listaDePersonagens");
        const binding = listaDePersonagens.getBinding("items");
        binding.filter(filtro);
      },
      limparFiltro() {
        filtro = [];
      },
    });
  }
);
