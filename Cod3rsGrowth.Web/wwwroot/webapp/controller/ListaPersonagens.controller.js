sap.ui.define(
  [
    "ui5/o_senhor_dos_aneis/controller/BaseController",
    "sap/ui/model/json/JSONModel",
    "ui5/o_senhor_dos_aneis/model/formatter",
  ],
  function (BaseController, JSONModel, formatter) {
    "use strict";

    let filtroNome = "";
    let filtroRaca = "";
    let filtroProfissao = "";
    let filtroDataInicial = "";
    let filtroDataFinal = "";
    let filtroVivo = "";
    let filtroMorto = "";

    return BaseController.extend(
      "ui5.o_senhor_dos_aneis.controller.ListaPersonagens",
      {
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
          let url = "https://localhost:7244/api/Personagem/personagens";
          let urlPadrao =
            "https://localhost:7244//webapp/index.html#/personagens";
          let parametros = [];
          let query = "";

          if (filtroNome) {
            parametros.push(
              `NomeDoPersonagem=${encodeURIComponent(filtroNome)}`
            );
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
          if (filtroVivo) {
            parametros.push(`EstaVivo=${encodeURIComponent(filtroVivo)}`);
            filtroVivo = "";
          }
          // if (!filtroVivo) {
          //   parametros.push(`EstaVivo=${encodeURIComponent(!filtroVivo)}`);
          //   filtroVivo = "";
          // }
          if (parametros.length > 0) {
            query += "?" + parametros.join("&");
            url += "?" + parametros.join("&");
            urlPadrao += "?" + parametros.join("&");
          }
          this.getRouter().navTo(
            "personagens",
            parametros.length == 0 ? {} : { "?query": query }
          );
          
          window.history.replaceState(null, null, urlPadrao);

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
        },
        onDataFinalSelecionada(evento) {
          filtroDataFinal = evento
            .getSource()
            .getProperty("dateValue")
            .toISOString();
        },
        onCheckVivoBox(evento) {
          filtroVivo = evento.getParameter("selected");
        },
        // onCheckMortoBox(evento) {
        //   filtroMorto = !evento.getParameter("selected");
        //   console.log(filtroMorto);
        // },
        onReset() {
          filtroNome = "";
          filtroRaca = "";
          filtroProfissao = "";
          filtroDataInicial = "";
          filtroDataFinal = "";
          filtroVivo = "";
          filtroMorto = "";
          this.getView().byId("searchFieldPersonagens").setValue("");
          this.loadPersonagens();
        },
        async onOpenDialogoDeFiltro() {
          // create dialog lazily
          this.oDialog ??= await this.loadFragment({
            name: "ui5.o_senhor_dos_aneis.view.FilterPersonagensDialog",
          });

          this.oDialog.open();
        },
        onCloseDialogoDeFiltro() {
          this.loadPersonagens();
          this.byId("filterDialog").close();
        },
      }
    );
  }
);
