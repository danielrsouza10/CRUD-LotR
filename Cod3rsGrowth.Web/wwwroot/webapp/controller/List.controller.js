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
    const stringBaseUrlPersonagens =
      "https://localhost:7244/api/Personagem/personagens";
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
      },
      loadRacas() {
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
      construirUrlComParametros() {
        let url = stringBaseUrlPersonagens;
        let parametros = [];

        if (filtroNome) {
          parametros.push(`NomeDoPersonagem=${encodeURIComponent(filtroNome)}`);
        }
        if (filtroRaca) {
          parametros.push(`NomeDaRaca=${encodeURIComponent(filtroRaca)}`);
        }
        if (filtroProfissao) {
          parametros.push(`Profissao=${encodeURIComponent(filtroProfissao)}`);
        }
        if (filtroDataInicial) {
          parametros.push(
            `DataInicial=${encodeURIComponent(filtroDataInicial)}`
          );
        }
        if (filtroDataFinal) {
          parametros.push(`DataFinal=${encodeURIComponent(filtroDataFinal)}`);
        }

        if (parametros.length > 0) {
          url += "?" + parametros.join("&");
        }
        window.history.replaceState(null, null, url);
        return url;
      },
      onFiltrarPersonagens(evento) {
        filtroNome = evento.getParameter("query");
        this.loadPersonagens();
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
      onDataInicialSelecionada(evento) {
        filtroDataInicial = evento
          .getSource()
          .getProperty("dateValue")
          .toISOString();
        console.log(filtroDataInicial);
      },
      onDataFinalSelecionada(evento) {
        filtroDataFinal = evento
          .getSource()
          .getProperty("dateValue")
          .toISOString();
        console.log(filtroDataFinal);
      },
      onReset() {
        filtroNome = "";
        filtroRaca = "";
        filtroProfissao = "";
        filtroDataInicial = "";
        filtroDataFinal = "";
        this.loadPersonagens();
      },
      async onOpenDialogoDeFiltro() {
        // create dialog lazily
        this.oDialog ??= await this.loadFragment({
          name: "ui5.o_senhor_dos_aneis.view.FilterDialog",
        });

        this.oDialog.open();
      },
      onCloseDialogoDeFiltro() {
        this.loadPersonagens();
        this.byId("filterDialog").close();
      },
    });
  }
);
