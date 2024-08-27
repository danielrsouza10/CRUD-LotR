sap.ui.define(
  [
    "../controller/BaseController",
    "ui5/o_senhor_dos_aneis/services/RacaService",
    "sap/ui/model/json/JSONModel",
    "sap/m/MessageBox",
      "ui5/o_senhor_dos_aneis/model/formatter",
  ],
  function (BaseController, RacaService, JSONModel, MessageBox, formatter) {
    "use strict";
    const ID_INPUT_NOME = "inputNome",
      ID_INPUT_LOCALIZACAO = "inputLocalizacaoGeografica",
      ID_INPUT_HABILIDADE = "inputHabilidadeRacial",
      ID_RADIO_BTN_EXTINTAOUNAO = "radioBtnExtintaOuNao";
    return BaseController.extend(
      "ui5.o_senhor_dos_aneis.controller.CriarRaca",
      {
          formatter: formatter,

        onInit: function () {
          const rotaCriacao = "criarRaca";
          const rotaEdicao = "editarRaca";
          this.vincularRota(rotaCriacao, this.aoCoincidirRotaCriar);
          this.vincularRota(rotaEdicao, this.aoCoincidirRotaEditar);
        },

        aoCoincidirRotaCriar: function (oEvent) {
          this.filtros = {};
          this.raca = {};
          this.errosDeValidacao = {};
          this.modoEditar = false;
          this._limparInputs();
          this._atualizarTextoDaPáginaCriar();
        },

        aoCoincidirRotaEditar: function (oEvent) {
          this.filtros = {};
          this.raca = {};
          this.errosDeValidacao = {};
          this.modoEditar = true;
          this._limparInputs();
          this._carregarDadosDaRacaSelecionada(oEvent);
          this._atualizarTextoDaPáginaEditar();
        },

        aoMudarNome: function (oEvent) {
          this._aoMudarInput(oEvent, this._validarNome.bind(this));
        },

        aoCriarRaca: async function (oEvent) {
          this._pegarValoresDaRacaNaTela();
          const sucessoMessageBox = (mensagem, titulo) => {
            console.log("Exibindo MessageBox:", mensagem); // Verifica se esta linha é executada
            MessageBox.show(mensagem, {
              icon: sap.m.MessageBox.Icon.SUCCESS,
              title: titulo,
              dependentOn: this.getView(),
            });
          };
          if (!this.modoEditar) {
            if (this._validarNovaRaca(this.raca)) {
              try {
                const racaCriada = await RacaService.adicionarRaca(this.raca);
                const mensagemDeSucesso = "Raça adicionada com sucesso!";
                const tituloDaMessageBox = "Sucesso";
                sucessoMessageBox(mensagemDeSucesso, tituloDaMessageBox);
                this._limparInputs();
                const tempoParaVisualizarMensagem = 2000;
                setTimeout(() => this.onNavBack(), tempoParaVisualizarMensagem);
              } catch (erros) {
                this._exibirErros(erros);
              }
            }
          } else {
            if (this._validarNovaRaca(this.raca)) {
              try {
                const racaEditada = await RacaService.editarRaca(this.raca);
                const mensagemDeSucesso = "Raça editada com sucesso!";
                const tituloDaMessageBox = "Sucesso";
                sucessoMessageBox(mensagemDeSucesso, tituloDaMessageBox);
                this._limparInputs();
                const tempoParaVisualizarMensagem = 2000;
                setTimeout(() => this.onNavBack(), tempoParaVisualizarMensagem);
              } catch (erros) {
                this._exibirErros(erros);
              }
            }
          }
        },

        onNavToListaDeRacas: function () {
          const rotaListaDeRacas = "listaDeRacas";
          this.onNavTo(rotaListaDeRacas);
        },

        _carregarDadosDaRacaSelecionada: async function (oEvent) {
          if (oEvent.getParameter("arguments").id) {
            try {
              const idRaca = oEvent.getParameter("arguments").id;
              const raca = await RacaService.obterRaca(idRaca);
              const modelo = new JSONModel(raca);
              const modeloRaca = "raca";

              this.getView().setModel(modelo, modeloRaca);
            } catch (erros) {
              this._exibirErros(erros);
            }
          }
        },

        _atualizarTextoDaPáginaCriar: function () {
          this._atualizarTituloDaPaginaCriar();
          this._atualizarLabelDoBotaoAdicionar();
        },

        _atualizarTextoDaPáginaEditar: function () {
          this._atualizarTituloDaPaginaEditar();
          this._atualizarLabelDoBotaoEditar();
        },

        _atualizarTituloDaPaginaCriar: function () {
          const idPaginaCriacao = "paginaCriarRaca";
          const oBundle = this.getView().getModel("i18n").getResourceBundle();
          const novoTitulo = oBundle.getText("TituloPaginaCriarRaca");
          this.byId(idPaginaCriacao).setTitle(novoTitulo);
        },

        _atualizarTituloDaPaginaEditar: function () {
          const idPaginaCriacao = "paginaCriarRaca";
          const oBundle = this.getView().getModel("i18n").getResourceBundle();
          const novoTitulo = oBundle.getText("TituloPaginaEditarRaca");
          this.byId(idPaginaCriacao).setTitle(novoTitulo);
        },

        _atualizarLabelDoBotaoAdicionar: function () {
          const idBotaoAdicionar = "criarRacaBtn";
          const oBundle = this.getView().getModel("i18n").getResourceBundle();
          const novoLabel = oBundle.getText("BotaoAdicionar");
          this.byId(idBotaoAdicionar).setText(novoLabel);
        },

        _atualizarLabelDoBotaoEditar: function () {
          const idBotaoAdicionar = "criarRacaBtn";
          const oBundle = this.getView().getModel("i18n").getResourceBundle();
          const novoLabel = oBundle.getText("BotaoEditar");
          this.byId(idBotaoAdicionar).setText(novoLabel);
        },

        _aoMudarInput: function (oEvent, funcaoDeValidacao) {
          const objeto = oEvent.getSource();
          const nomeInserido = objeto.getValue();
          let valueState = funcaoDeValidacao(nomeInserido)
            ? "Success"
            : "Error";
          objeto.setValueState(valueState);
        },

        _validarNovaRaca: function (raca) {
          let racaValida = false;
          const nomeInseridoInput = this._validarNome(raca.nome);
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

        _pegarValoresDaRacaNaTela: function () {
          const modelo = this.getView().getModel("raca");

          const dadosDoModelo = modelo.getData();
          const condicaoExtinta = 0;
          const condicaoEstaExtintaNoModelo =
            this.byId(ID_RADIO_BTN_EXTINTAOUNAO).getSelectedIndex() ==
            condicaoExtinta
              ? true
              : false;

          this.raca = {
            id: dadosDoModelo.id,
            nome: dadosDoModelo.nome,
            localizacaoGeografica: dadosDoModelo.localizacaoGeografica,
            habilidadeRacial: dadosDoModelo.habilidadeRacial,
            estaExtinta: condicaoEstaExtintaNoModelo,
          };
        },

        _limparInputs: function () {
          const stringVazia = "";
          const condicaoInicial = 0;
          const valueStatePadrao = "None";

          const modeloRaca = "raca";
          const modelo = new JSONModel({
            nome: stringVazia,
            localizacaoGeografica: stringVazia,
            habilidadeRacial: stringVazia,
          });
          this.getView().setModel(modelo, modeloRaca);

          this.byId(ID_INPUT_NOME).setValueState(valueStatePadrao);
          this.byId(ID_RADIO_BTN_EXTINTAOUNAO).setSelectedIndex(
            condicaoInicial
          );
        },
      }
    );
  }
);
