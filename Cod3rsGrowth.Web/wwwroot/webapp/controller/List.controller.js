sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "sap/ui/model/Filter",
    "sap/ui/model/FilterOperator",
  ],
  function (Controller, JSONModel, Filter, FilterOperator) {
    "use strict";
    return Controller.extend("ui5.o_senhor_dos_aneis.controller.List", {
      onInit() {
        const oViewModel = new JSONModel({
          unidadeMedida: "m",
        });
        this.getView().setModel(oViewModel, "view");
        console.log("entrou")
        this.loadPersonagens();
      },
      async loadPersonagens() {
        const stringUrl = "https://localhost:7244/api/Personagem/personagens";
console.log("entrou")
        try {
          const response = await fetch(stringUrl);
          if (!response.ok) {
            throw new Error("Sem resposta" + response.statusText);
          }
          const dados = await response.json();
          const objetoModelo = new JSONModel(dados);
          this.getView().setModel(objetoModelo);
        } catch (error) {
          console.error("Houve um problema de fetch", error);
        }
      },
      onFiltrarPersonagens(evento) {
        const ARRAY_DE_FILTRO = [];
        const STRING_QUERY = evento.getParameter("query");
        if (STRING_QUERY) {
          ARRAY_DE_FILTRO.push(
            new Filter("Nome", FilterOperator.Contains, STRING_QUERY)
          );
        }

        const LISTA_DE_PERSONAGENS = this.byId("listaDePersonagens");
        const BINDING = LISTA_DE_PERSONAGENS.getBinding("items");
        BINDING.filter(ARRAY_DE_FILTRO);
      },
    });
  }
);
