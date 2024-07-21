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
    // const ARRAY_DE_FILTRO = [];
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
        const ARRAY_DE_FILTRO = [];
        const INPUT_SEARCH_BAR = evento.getParameter("query");
        if (INPUT_SEARCH_BAR) {
          ARRAY_DE_FILTRO.push(
            new Filter("nome", FilterOperator.Contains, INPUT_SEARCH_BAR)
          );
        }

        const LISTA_DE_PERSONAGENS = this.byId("listaDePersonagens");
        const BINDING = LISTA_DE_PERSONAGENS.getBinding("items");
        BINDING.filter(ARRAY_DE_FILTRO);
      },
      async onOpenFilterDialog() {
        // create dialog lazily
        this.oDialog ??= await this.loadFragment({
          name: "ui5.o_senhor_dos_aneis.view.FilterDialog",
        });

        this.oDialog.open();
      },
      onCloseFilterDialog(evento) {
        const ARRAY_DE_FILTRO = [];
        const SELECTED_RACA_COMBO_BOX =
          this.byId("comboBoxRacas").mProperties.selectedKey;
        console.log(SELECTED_RACA_COMBO_BOX);
        if (INPUT_SEARCH_BAR) {
          ARRAY_DE_FILTRO.push(
            new Filter("nome", FilterOperator.Contains, INPUT_SEARCH_BAR)
          );
        }

        const LISTA_DE_PERSONAGENS = this.byId("listaDePersonagens");
        const BINDING = LISTA_DE_PERSONAGENS.getBinding("items");
        BINDING.filter(ARRAY_DE_FILTRO);
        this.byId("filterDialog").close();
      },
      // onChangeComboBoxRacas(evento) {
      //   const ARRAY_DE_FILTRO = [];
      //   const STRING_QUERY = evento.mParameters.selectedItem.mProperties.text;
      //   if (STRING_QUERY) {
      //     ARRAY_DE_FILTRO.push(
      //       new Filter("raca", FilterOperator.Contains, STRING_QUERY)
      //     );
      //   }

      //   const LISTA_DE_PERSONAGENS = this.byId("listaDePersonagens");
      //   const BINDING = LISTA_DE_PERSONAGENS.getBinding("items");
      //   BINDING.filter(ARRAY_DE_FILTRO);
      // },
    });
  }
);
