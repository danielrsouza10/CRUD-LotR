sap.ui.define(
  [
    "../common/BaseController",
    "ui5/o_senhor_dos_aneis/App/Raca/RacaService",
    "sap/ui/model/json/JSONModel",
    "ui5/o_senhor_dos_aneis/model/formatter",
    "ui5/o_senhor_dos_aneis/App/common/Dialogs",
  ],
  function (BaseController, RacaService, JSONModel, formatter, Dialogs) {
    "use strict";
    const ID_INPUT_NOME = "inputNome",
      ID_RADIO_BTN_EXTINTAOUNAO = "radioBtnExtintaOuNao",
      MODELO_RACA = "raca";
    return BaseController.extend("ui5.o_senhor_dos_aneis.App.Raca.CriarRaca", {
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
        this._atualizarTextoDaPaginaCriar();
      },

      aoCoincidirRotaEditar: function (oEvent) {
        this.filtros = {};
        this.raca = {};
        this.errosDeValidacao = {};
        this.modoEditar = true;
        this._limparInputs();
        this._carregarDadosDaRacaSelecionada(oEvent);
        this._atualizarTextoDaPaginaEditar();
      },

      aoMudarNome: function (oEvent) {
        this.exibirEspera(async () => {
          this._aoMudarInput(oEvent, this._validarNome.bind(this));
        });
      },

      aoCriarRaca: async function (oEvent) {
        this.exibirEspera(async () => {
          this._pegarValoresDaRacaNaTela();
          if (!this.modoEditar) {
            if (this._validarNovaRaca(this.raca)) {
              try {
                const racaCriada = await RacaService.adicionarRaca(this.raca);
                const chaveI18NMensagem = "mensagemDeBoxDeSucessoDeCriacao",
                  chaveI18NTitulo = "tituloDeBoxDeSucesso",
                  mensagem = this.obterTextoI18N(chaveI18NMensagem),
                  titulo = this.obterTextoI18N(chaveI18NTitulo);
                Dialogs.criarDialogoDeSucesso(mensagem, titulo, this);
                this._limparInputs();
                this.onNavToListaDeRacas();
              } catch (erros) {
                this._exibirErros(erros);
              }
            }
            return;
          }
          if (this._validarNovaRaca(this.raca)) {
            try {
              const racaEditada = await RacaService.editarRaca(this.raca);
              const chaveI18NMensagem = "mensagemDeBoxDeSucessoDeEdicao",
                chaveI18NTitulo = "tituloDeBoxDeSucesso",
                mensagem = this.obterTextoI18N(chaveI18NMensagem),
                titulo = this.obterTextoI18N(chaveI18NTitulo);
              Dialogs.criarDialogoDeSucesso(mensagem, titulo, this);
              this._limparInputs();
              this.onNavToListaDeRacas();
            } catch (erros) {
              this._exibirErros(erros);
            }
          }
        });
      },

      onNavToListaDeRacas: function () {
        const rotaListaDeRacas = "listaDeRacas";
        this.onNavTo(rotaListaDeRacas);
      },

      _carregarDadosDaRacaSelecionada: async function (oEvent) {
        const argumentos = "arguments";
        if (oEvent.getParameter(argumentos).id) {
          try {
            const idRaca = oEvent.getParameter(argumentos).id;
            const raca = await RacaService.obterRaca(idRaca);
            const modelo = new JSONModel(raca);

            this.modelo(MODELO_RACA, modelo);
          } catch (erros) {
            this._exibirErros(erros);
          }
        }
      },

      _atualizarTextoDaPaginaCriar: function () {
        this._atualizarTituloDaPaginaCriar();
        this._atualizarLabelDoBotaoAdicionar();
      },

      _atualizarTextoDaPaginaEditar: function () {
        this._atualizarTituloDaPaginaEditar();
        this._atualizarLabelDoBotaoEditar();
      },

      _atualizarTituloDaPaginaCriar: function () {
        const idPaginaCriacao = "paginaCriarRaca";
        const chaveI18N = "TituloPaginaCriarRaca";
        this.byId(idPaginaCriacao).setTitle(this.obterTextoI18N(chaveI18N));
      },

      _atualizarTituloDaPaginaEditar: function () {
        const idPaginaCriacao = "paginaCriarRaca";
        const chaveI18N = "TituloPaginaEditarRaca";
        this.byId(idPaginaCriacao).setTitle(this.obterTextoI18N(chaveI18N));
      },

      _atualizarLabelDoBotaoAdicionar: function () {
        const idBotaoAdicionar = "criarRacaBtn";
        const chaveI18N = "BotaoAdicionar";
        this.byId(idBotaoAdicionar).setText(this.obterTextoI18N(chaveI18N));
      },

      _atualizarLabelDoBotaoEditar: function () {
        const idBotaoAdicionar = "criarRacaBtn";
        const chaveI18N = "BotaoEditar";
        this.byId(idBotaoAdicionar).setText(this.obterTextoI18N(chaveI18N));
      },

      _aoMudarInput: function (oEvent, funcaoDeValidacao) {
        const objeto = oEvent.getSource(),
          nomeInserido = objeto.getValue(),
          valueStateSucesso = "Success",
          valueStateErro = "Error";
        let valueState = funcaoDeValidacao(nomeInserido)
          ? valueStateSucesso
          : valueStateErro;
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

      _pegarValoresDaRacaNaTela: function () {
        const nomeDoModelo = "raca";
        const modelo = this.modelo(nomeDoModelo);

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

        const modelo = new JSONModel({
          nome: stringVazia,
          localizacaoGeografica: stringVazia,
          habilidadeRacial: stringVazia,
        });
        this.modelo(MODELO_RACA, modelo);

        this.byId(ID_INPUT_NOME).setValueState(valueStatePadrao);
        this.byId(ID_RADIO_BTN_EXTINTAOUNAO).setSelectedIndex(condicaoInicial);
      },
    });
  }
);
