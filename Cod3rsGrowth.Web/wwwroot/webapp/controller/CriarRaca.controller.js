sap.ui.define(
  [
    "../controller/BaseController",
    "ui5/o_senhor_dos_aneis/services/RacaService",
    "sap/ui/model/json/JSONModel",
    "sap/m/MessageBox",
  ],
  function (BaseController, RacaService, JSONModel, MessageBox) {
    "use strict";
    const ID_INPUT_NOME = "inputNome",
      ID_INPUT_LOCALIZACAO = "inputLocalizacaoGeografica",
      ID_INPUT_HABILIDADE = "inputHabilidadeRacial",
      ID_RADIO_BTN_EXTINTAOUNAO = "radioBtnExtintaOuNao";
    return BaseController.extend(
      "ui5.o_senhor_dos_aneis.controller.CriarRaca",
      {
        onInit: function () {
          const rotaCriacao = "criarRaca";
          const rotaEdicao = "editarRaca";
          this.vincularRota(rotaCriacao, this.aoCoincidirRota);
          this.vincularRota(rotaEdicao, this.aoCoincidirRota);
        },

        aoCoincidirRota: function (oEvent) {
          this.filtros = {};
          this.raca = {};
          this.errosDeValidacao = {};
          this._limparInputs();
          this._carregarModeloDaRaca(oEvent);
        },

        aoMudarNome: function (oEvent) {
          this._aoMudarInput(oEvent, this._validarNome.bind(this));
        },

        aoCriarRaca: async function (oEvent) {
          this._pegarValoresDaRacaNaTela();

          if (this._validarNovaRaca(this.raca)) {
            try {
              const racaCriada = await RacaService.adicionarRaca(this.raca);
              const mensagemDeSucesso = "Raça adicionada com sucesso!";
              MessageBox.show(mensagemDeSucesso, {
                icon: sap.m.MessageBox.Icon.SUCCESS,
                title: "Sucesso",
                dependentOn: this.getView(),
              });
              this._limparInputs();
              const tempoParaVisualizarMensagem = 2000;
              setTimeout(() => this.onNavBack(), tempoParaVisualizarMensagem);
            } catch (erros) {
              this._exibirErros(erros);
            }
          }
        },

        onNavToListaDeRacas: function () {
          const rotaListaDeRacas = "listaDeRacas";
          this.onNavTo(rotaListaDeRacas);
        },

        _carregarModeloDaRaca: async function (oEvent) {
          if (oEvent.getParameter("arguments").id) {
            try {
              console.log(this.getView().getModel());
              const idRaca = oEvent.getParameter("arguments").id;
              const raca = await RacaService.obterRaca(idRaca);
              console.log(oEvent.getParameter("arguments").id);
              const modelo = new JSONModel(raca);
              const modeloRaca = "raca";

              this.getView().setModel(modelo, modeloRaca);
            } catch (erros) {
              console.log("Não foi possível obter a raça");
            }
          }
        },

        _carregarDadosDaRacaNaTela: function () {},

        _aoMudarInput: function (oEvent, funcaoDeValidacao) {
          const objeto = oEvent.getSource();
          const nomeInserido = objeto.getValue();
          let valueState = funcaoDeValidacao(nomeInserido)
            ? "Success"
            : "Error";
          objeto.setValueState(valueState);
        },

        _validarNovaRaca: function (personagem) {
          let racaValida = false;
          const nomeInseridoInput = this._validarNome(personagem.nome);
          if (nomeInseridoInput) {
            racaValida = true;
            return racaValida;
          }
          this._exibirErros(this.errosDeValidacao);
          return racaValida;
        },

        _validarNome: function (nomeInserido) {
          let nomeValido = false;
          const contemCaracteresEspeciais =
            this._verificarCaracteresEspeciais(nomeInserido);
          const tamanhoDaString = this._verificarTamanhoString(nomeInserido);
          if (!contemCaracteresEspeciais && tamanhoDaString) {
            nomeValido = true;
            return nomeValido;
          }
          return nomeValido;
        },

        _verificarCaracteresEspeciais: function (str) {
          const regex = /[^a-zA-Z]/;
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

        _exibirErros: function (erros) {
          const espacoEntreErros = ".\n";
          if (erros.status) {
            let mensagemDeErro = Object.values(erros.extensions.erros).join(
              espacoEntreErros
            );
            const tituloErro = erros.title;
            const detalhesDoErro = erros.detail;
            MessageBox.error(mensagemDeErro, {
              title: tituloErro,
              details: detalhesDoErro,
              contentWidth: "400px",
              dependentOn: this.getView(),
            });
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
            const tituloErro = "Erro ao criar raça";
            const detailsErro =
              "Corrija os campos acima para prosseguir com a criação da raça";
            MessageBox.error(mensagemDeErro, {
              title: tituloErro,
              details: detailsErro,
              contentWidth: "300px",
              dependentOn: this.getView(),
            });
          }
        },

        _pegarValoresDaRacaNaTela: function () {
          this.raca.nome = this.byId(ID_INPUT_NOME).getValue();
          this.raca.localizacaoGeografica =
            this.byId(ID_INPUT_LOCALIZACAO).getValue();
          this.raca.habilidadeRacial =
            this.byId(ID_INPUT_HABILIDADE).getValue();

          const condicaoExtinta = 0;
          this.raca.estaExtinta =
            this.byId(ID_RADIO_BTN_EXTINTAOUNAO).getSelectedIndex() ==
            condicaoExtinta
              ? true
              : false;
        },

        _limparInputs: function () {
          const stringVazia = "";
          const condicaoInicial = 0;
          const valueStatePadrao = "None";

          this.byId(ID_INPUT_NOME).setValue(stringVazia);
          this.byId(ID_INPUT_NOME).setValueState(valueStatePadrao);

          this.byId(ID_INPUT_HABILIDADE).setValue(stringVazia);
          this.byId(ID_INPUT_HABILIDADE).setValueState(valueStatePadrao);

          this.byId(ID_INPUT_LOCALIZACAO).setValue(stringVazia);
          this.byId(ID_INPUT_LOCALIZACAO).setValueState(valueStatePadrao);

          this.byId(ID_RADIO_BTN_EXTINTAOUNAO).setSelectedIndex(
            condicaoInicial
          );
        },
      }
    );
  }
);
