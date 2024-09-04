sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History",
    "sap/ui/core/UIComponent",
    "sap/m/MessageBox",
  ],
  function (Controller, History, UIComponent, MessageBox) {
    "use strict";
    this.errosDeValidacao = {};

    return Controller.extend(
      "ui5.o_senhor_dos_aneis.controller.BaseController",
      {
        vincularRota: function (rota, aoCoincidirRota) {
          var oRouter = sap.ui.core.UIComponent.getRouterFor(this);
          var oRoute = oRouter.getRoute(rota);
          if (oRoute) {
            oRoute.attachPatternMatched(aoCoincidirRota, this);
          }
        },

        getRouter: function () {
          return UIComponent.getRouterFor(this);
        },

        onNavBack: function () {
          var historico, hashAnterior, hashAtual, hashNotFound;

          historico = History.getInstance();
          hashAnterior = historico.getPreviousHash();
          hashAtual = historico._oHashChanger._oRouterHashChanger.hash;
          hashNotFound = "notFound";

          if (
            hashAnterior !== undefined &&
            hashAnterior !== hashNotFound &&
            hashAtual !== hashNotFound
          ) {
            window.history.go(-1);
          } else {
            this.getRouter().navTo("appHome", {});
          }
        },

        onNavTo: function (rota, parametros) {
          this.getRouter().navTo(rota, parametros);
        },

        obterTextoI18N: function (chave) {
          const oBundle = this.getView().getModel("i18n").getResourceBundle();
          return oBundle.getText(chave);
        },

        aoMudarNome: function (oEvent) {
          this._aoMudarInput(oEvent, this._validarNome.bind(this));
        },

        aoMudarIdade: function (oEvent) {
          this._aoMudarInput(oEvent, this._validarIdade.bind(this));
        },

        aoMudarAltura: function (oEvent) {
          this._aoMudarInput(oEvent, this._validarAltura.bind(this));
        },

        _aoMudarInput: function (oEvent, funcaoDeValidacao) {
          const objeto = oEvent.getSource();
          const nomeInserido = objeto.getValue();
          const valueStateSucesso = "Success";
          const valueStateErro = "Error";
          let valueState = funcaoDeValidacao(nomeInserido)
            ? valueStateSucesso
            : valueStateErro;
          objeto.setValueState(valueState);
        },

        _validarNovoPersonagem: function (personagem) {
          const nomeInseridoInput = this._validarNome(personagem.nome);
          const idadeInseridaInput = this._validarIdade(personagem.idade);
          const alturaInseridaInput = this._validarAltura(personagem.altura);
          if (nomeInseridoInput && idadeInseridaInput && alturaInseridaInput) {
            return true;
          }
          this._exibirErros(this.errosDeValidacao);
          return false;
        },

        _validarNome: function (nomeInserido) {
          const contemCaracteresEspeciais =
            this._verificarCaracteresEspeciais(nomeInserido);
          const tamanhoDaString = this._verificarTamanhoString(nomeInserido);
          if (!contemCaracteresEspeciais && tamanhoDaString) {
            return true;
          }
          return false;
        },

        _verificarCaracteresEspeciais: function (str) {
          const regex = /[^a-zA-ZÀ-ÖØ-öø-ÿ\s]/;
          if (regex.test(str)) {
            const mensagemDeErro =
              "O nome não pode conter números, espaços ou caracteres especiais";
            this.errosDeValidacao.caracteresEspeciais = mensagemDeErro;
            return regex.test(str);
          }
          delete this.errosDeValidacao.caracteresEspeciais;
          return regex.test(str);
        },

        _verificarTamanhoString: function (str) {
          const tamanhoMinimo = 3;
          if (str.length < tamanhoMinimo) {
            const mensagemDeErro = "O nome precisa ter pelo menos 3 caracteres";
            this.errosDeValidacao.tamanhoDaString = mensagemDeErro;
            return str.length >= tamanhoMinimo;
          }
          delete this.errosDeValidacao.tamanhoDaString;
          return str.length >= tamanhoMinimo;
        },

        _validarIdade(idadeInserida) {
          const idadeMinima = 0;
          if (idadeInserida < idadeMinima) {
            const mensagemDeErro =
              "O valor da idade precisa ser maior do que zero";
            this.errosDeValidacao.idadeMinima = mensagemDeErro;
            return false;
          }
          delete this.errosDeValidacao.idadeMinima;
          return true;
        },

        _validarAltura(alturaInserida) {
          const alturaMinima = 0;
          if (alturaInserida < alturaMinima) {
            const mensagemDeErro =
              "O valor da altura precisa ser maior do que zero";
            this.errosDeValidacao.alturaMinima = mensagemDeErro;
            return false;
          }
          delete this.errosDeValidacao.alturaMinima;
          return true;
        },

        _exibirErros: function (erros) {
          const espacoEntreErros = ".\n";

          if (erros.status == "500") {
            const mensagemDeErro = Object.values(erros.extensions).join(
              espacoEntreErros
            );
            return this.criarDialogoDeErro(
              erros.title,
              mensagemDeErro,
              erros.detail
            );
          }
          if (erros.status) {
            const mensagemDeErro = Object.values(erros.extensions.erros).join(
              espacoEntreErros
            );
            return this.criarDialogoDeErro(
              erros.title,
              erros.detail,
              mensagemDeErro
            );
          }
          if (
            this.errosDeValidacao.caracteresEspeciais ||
            this.errosDeValidacao.tamanhoDaString ||
            this.errosDeValidacao.idadeMinima ||
            this.errosDeValidacao.alturaMinima
          ) {
            let mensagemDeErro = Object.values(this.errosDeValidacao).join(
              espacoEntreErros
            );
            const tituloErro = "Erro ao criar registro";
            const detalhesDoErro =
              "Corrija os campos acima para prosseguir com a criação do registro";
            return this.criarDialogoDeErro(
              tituloErro,
              detalhesDoErro,
              mensagemDeErro
            );
          }
        },
        criarDialogoDeAviso: function (titulo, mensagem) {
          return new Promise((resolve, reject) => {
            MessageBox.warning(mensagem, {
              title: titulo,
              actions: [MessageBox.Action.YES, MessageBox.Action.NO],
              emphasizedAction: "YES",
              onClose: function (acao) {
                if (acao === "YES") {
                  resolve(true);
                } else {
                  resolve(false);
                }
              },
              dependentOn: this.getView(),
            });
          });
        },
        criarDialogoDeSucesso: function (mensagem, titulo) {
          MessageBox.show(mensagem, {
            icon: sap.m.MessageBox.Icon.SUCCESS,
            title: titulo,
            dependentOn: this.getView(),
          });
        },
        criarDialogoDeErro: function (titulo, detalhes, mensagemDeErro) {
          MessageBox.error(mensagemDeErro, {
            title: titulo,
            details: detalhes,
            contentWidth: "400px",
            dependentOn: this.getView(),
          });
        },
      }
    );
  }
);
