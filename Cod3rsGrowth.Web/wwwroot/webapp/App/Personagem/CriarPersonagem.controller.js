sap.ui.define(
  [
    "../common/BaseController",
    "sap/ui/model/json/JSONModel",
    "ui5/o_senhor_dos_aneis/App/Raca/RacaService",
    "ui5/o_senhor_dos_aneis/App/Personagem/PersonagemService",
    "ui5/o_senhor_dos_aneis/App/common/Dialogs",
  ],
  function (
    BaseController,
    JSONModel,
    RacaService,
    PersonagemService,
    Dialogs
  ) {
    "use strict";
    const ID_INPUT_NOME = "inputNome",
      ID_COMBOBOX_RACAS = "comboBoxRacas",
      ID_COMBOBOX_PROFISSOES = "comboBoxProfissoes",
      ID_INPUT_IDADE = "inputIdade",
      ID_INPUT_ALTURA = "inputAltura",
      ID_RADIO_BTN_VIVOMORTO = "radioBtnVivoMorto";
    return BaseController.extend(
      "ui5.o_senhor_dos_aneis.App.Personagem.CriarPersonagem",
      {
        onInit: function () {
          const rota = "criarPersonagem";
          this.vincularRota(rota, this.aoCoincidirRota);
        },

        aoCoincidirRota: function () {
          this.filtros = {};
          this.personagem = {};
          this.errosDeValidacao = {};
          this.loadRacas();
          this._limparInputs();
        },

        loadRacas: async function () {
          this.exibirEspera(async () => {
            const racas = await RacaService.obterTodos(this.filtros);
            const modelo = new JSONModel(racas);
            const modeloRaca = "racas";

            this.modelo(modeloRaca, modelo);
          });
        },

        aoCriarPersonagem: async function () {
          this.exibirEspera(async () => {
            this._pegarValoresDoPersonagemNaTela();

            if (this._validarNovoPersonagem(this.personagem)) {
              try {
                const personagemCriado =
                  await PersonagemService.adicionarPersonagem(this.personagem);
                const chaveI18NMensagem = "mensagemDeBoxDeSucessoDeCriacao",
                  chaveI18NTitulo = "tituloDeBoxDeSucesso",
                  mensagem = this.obterTextoI18N(chaveI18NMensagem),
                  titulo = this.obterTextoI18N(chaveI18NTitulo);
                Dialogs.criarDialogoDeSucesso(mensagem, titulo, this);
                this._limparInputs();
                const tempoParaVisualizarMensagem = 2000;
                setTimeout(() => this.onNavBack(), tempoParaVisualizarMensagem);
              } catch (erros) {
                this._exibirErros(erros);
              }
            }
          });
        },

        onNavToListaDePersonagens: function () {
          const rotaListaDePersonagens = "listaDePersonagens";
          this.onNavTo(rotaListaDePersonagens);
        },

        _pegarValoresDoPersonagemNaTela: function () {
          this.personagem.nome = this.byId(ID_INPUT_NOME).getValue();
          this.personagem.idRaca = parseInt(
            this.byId(ID_COMBOBOX_RACAS).getSelectedKey()
          );
          this.personagem.profissao = parseInt(
            this.byId(ID_COMBOBOX_PROFISSOES).getSelectedIndex()
          );
          this.personagem.idade = parseInt(
            this.byId(ID_INPUT_IDADE).getValue()
          );
          this.personagem.altura = parseFloat(
            this.byId(ID_INPUT_ALTURA).getValue()
          );
          const condicaoVivo = 0;
          this.personagem.estaVivo =
            this.byId(ID_RADIO_BTN_VIVOMORTO).getSelectedIndex() == condicaoVivo
              ? true
              : false;
        },

        _limparInputs: function () {
          const stringVazia = "";
          const chaveRacaInicial = 1;
          const indexProfissaoInicial = 0;
          const condicaoInicial = 0;
          const valueStatePadrao = "None";

          this.byId(ID_INPUT_NOME).setValue(stringVazia);
          this.byId(ID_INPUT_NOME).setValueState(valueStatePadrao);

          this.byId(ID_COMBOBOX_RACAS).setSelectedKey(chaveRacaInicial);

          this.byId(ID_COMBOBOX_PROFISSOES).setSelectedIndex(
            indexProfissaoInicial
          );

          this.byId(ID_INPUT_IDADE).setValue(stringVazia);
          this.byId(ID_INPUT_IDADE).setValueState(valueStatePadrao);

          this.byId(ID_INPUT_ALTURA).setValue(stringVazia);
          this.byId(ID_INPUT_ALTURA).setValueState(valueStatePadrao);

          this.byId(ID_RADIO_BTN_VIVOMORTO).setSelectedIndex(condicaoInicial);
        },
      }
    );
  }
);
