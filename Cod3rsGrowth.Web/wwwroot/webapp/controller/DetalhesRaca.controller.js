sap.ui.define(
  [
    "../common/BaseController",
    "ui5/o_senhor_dos_aneis/services/RacaService",
    "ui5/o_senhor_dos_aneis/services/PersonagemService",
    "sap/ui/model/json/JSONModel",
    "ui5/o_senhor_dos_aneis/model/formatter",
  ],

  function (
    BaseController,
    RacaService,
    PersonagemService,
    JSONModel,
    formatter
  ) {
    "use strict";
    const ID_INPUT_NOME = "inputNome",
      ID_RADIO_BTN_VIVOOUMORTO = "radioBtnVivoMorto",
      ID_COMBOBOX_PROFISSAO = "profissaoComboBox",
      ID_MODAL_CRIAR_PERSONAGEM = "modalCriarPersonagem",
      MODELO_PERSONAGENS = "personagens",
      MODELO_PERSONAGEM = "personagem",
      MODELO_RACA = "raca";

    return BaseController.extend(
      "ui5.o_senhor_dos_aneis.controller.DetalhesRaca",
      {
        formatter: formatter,

        onInit: function () {
          const rota = "detalhesRaca";
          this.vincularRota(rota, this.aoCoincidirRota);
        },

        aoCoincidirRota: function (oEvent) {
          this.filtros = {};
          this.personagem = {};
          this.errosDeValidacao = {};
          this._carregarDados(oEvent);
          this._mostrarBotoesDeEditarERemoverPersonagem(false);
        },

        aoClicarBtnEditarRaca: function () {
          this.exibirEspera(async () => {
            const modelo = "raca",
              rotaEditarRaca = "editarRaca",
              idRacaSelecionada = this.modelo(modelo).getData().id;
            this.onNavTo(rotaEditarRaca, { id: idRacaSelecionada });
          });
        },

        aoClicarBtnRemoverRaca: async function () {
          const chaveI18NMensagem = "mensagemDeBoxDeConfirmacaoDeExclusao",
            chaveI18NTitulo = "tituloDeBoxDeAdvertencia",
            mensagem = this.obterTextoI18N(chaveI18NMensagem),
            titulo = this.obterTextoI18N(chaveI18NTitulo);
          const confirmacao = await this.criarDialogoDeAviso(titulo, mensagem);
          if (confirmacao) {
            this.exibirEspera(async () => {
              const idRaca = this.modelo(MODELO_RACA).getData().id;
              try {
                await RacaService.removerRaca(idRaca);
                const chaveI18NMensagem = "mensagemDeBoxDeSucessoDeRemocao",
                  chaveI18NTitulo = "tituloDeBoxDeSucesso",
                  mensagem = this.obterTextoI18N(chaveI18NMensagem),
                  titulo = this.obterTextoI18N(chaveI18NTitulo);
                this.criarDialogoDeSucesso(mensagem, titulo);
                const tempoParaVisualizarMensagem = 2000;
                const rota = "listaDeRacas";
                setTimeout(
                  () => this.onNavTo(rota),
                  tempoParaVisualizarMensagem
                );
              } catch (erros) {
                this._exibirErros(erros);
              }
            });
          }
        },

        aoClicarBtnAdicionarPersonagem: function (oEvent) {
          this.exibirEspera(async () => {
            this._carregarModalDeCriacao();
            this._carregarModeloDeNovoPersonagem();
          });
        },

        aoClicarBtnEditarPersonagem: function () {
          this.exibirEspera(async () => {
            this._carregarModalDeCriacao();
          });
        },

        aoClicarBtnRemoverPersonagem: async function () {
          const chaveI18NMensagem = "mensagemDeBoxDeConfirmacaoDeExclusao",
            chaveI18NTitulo = "tituloDeBoxDeAdvertencia",
            mensagem = this.obterTextoI18N(chaveI18NMensagem),
            titulo = this.obterTextoI18N(chaveI18NTitulo);
          const confirmacao = await this.criarDialogoDeAviso(titulo, mensagem);
          if (confirmacao) {
            this.exibirEspera(async () => {
              const idPersonagem = this.modelo(MODELO_PERSONAGEM).getData().id;
              try {
                await PersonagemService.removerPersonagem(idPersonagem);
                const chaveI18NMensagem = "mensagemDeBoxDeSucessoDeRemocao",
                  chaveI18NTitulo = "tituloDeBoxDeSucesso",
                  mensagem = this.obterTextoI18N(chaveI18NMensagem),
                  titulo = this.obterTextoI18N(chaveI18NTitulo);
                this.criarDialogoDeSucesso(mensagem, titulo);
              } catch (erros) {
                this._exibirErros(erros);
              }
            });
          }
          await this._loadPersonagens();
        },

        aoSelecionarItemNaListaDePersonagem: function (oEvent) {
          this.exibirEspera(async () => {
            this._buscarDadosDoPersonagemSelecionadoNaLista(oEvent);
            this._mostrarBotoesDeEditarERemoverPersonagem(true);
          });
        },

        aoClicarBtnAdicionarNoModal: async function (oEvent) {
          this.exibirEspera(async () => {
            this._buscarDadosDoPersonagemNoModelo();
            if (this._validarNovoPersonagem(this.personagem)) {
              if (this.personagem.id) {
                try {
                  const personagemEditado =
                    await PersonagemService.editarPersonagem(this.personagem);
                  const chaveI18NMensagem = "mensagemDeBoxDeSucessoDeEdicao",
                    chaveI18NTitulo = "tituloDeBoxDeSucesso",
                    mensagem = this.obterTextoI18N(chaveI18NMensagem),
                    titulo = this.obterTextoI18N(chaveI18NTitulo);
                  this.criarDialogoDeSucesso(mensagem, titulo);
                  this._limparInputs(oEvent);
                  await this._loadPersonagens();
                  return this.byId(ID_MODAL_CRIAR_PERSONAGEM).close();
                } catch (erros) {
                  return this._exibirErros(erros);
                }
              }
              try {
                const personagemCriado =
                  await PersonagemService.adicionarPersonagem(this.personagem);
                const chaveI18NMensagem = "mensagemDeBoxDeSucessoDeCriacao",
                  chaveI18NTitulo = "tituloDeBoxDeSucesso",
                  mensagem = this.obterTextoI18N(chaveI18NMensagem),
                  titulo = this.obterTextoI18N(chaveI18NTitulo);
                this.criarDialogoDeSucesso(mensagem, titulo);
                this._limparInputs(oEvent);
                this.byId(ID_MODAL_CRIAR_PERSONAGEM).close();
              } catch (erros) {
                this._exibirErros(erros);
              }
            }
            await this._loadPersonagens();
          });
        },

        aoClicarBtnCancelarNoModal: async function (oEvent) {
          const chaveI18NMensagem = "mensagemDeBoxDeCancelamento",
            chaveI18NTitulo = "tituloDeBoxDeAdvertencia",
            mensagem = this.obterTextoI18N(chaveI18NMensagem),
            titulo = this.obterTextoI18N(chaveI18NTitulo);
          const confirmacao = await this.criarDialogoDeAviso(titulo, mensagem);
          if (confirmacao) {
            this.exibirEspera(async () => {
              this.byId(ID_MODAL_CRIAR_PERSONAGEM).close();
              this._limparInputs(oEvent);
              this._mostrarBotoesDeEditarERemoverPersonagem(false);
            });
          }
        },

        _carregarModalDeCriacao: async function () {
          const modeloTemId = this.modelo(MODELO_PERSONAGEM).getData().id;

          this.modalCriarPersonagem ??= await this.loadFragment({
            name: "ui5.o_senhor_dos_aneis.view.CriarPersonagensModal",
          });

          if (modeloTemId) {
            this._atualizarTextoDaModalEditar();
            this.modalCriarPersonagem.open();
            return this._buscarDadosDoPersonagemNoModelo();
          }
          this.modalCriarPersonagem.open();
          this._atualizarTextoDaPaginaCriar();
        },

        _buscarDadosDoPersonagemNoModelo: function () {
          const modelo = this.modelo(MODELO_PERSONAGEM);

          const dadosDoModelo = modelo.getData();
          const condicao = 0;
          const condicaoSelecionada =
            this.byId(ID_RADIO_BTN_VIVOOUMORTO).getSelectedIndex() == condicao
              ? true
              : false;
          const profissaoSelecionada = this.byId(
            ID_COMBOBOX_PROFISSAO
          ).getSelectedIndex();

          this.personagem = {
            nome: dadosDoModelo.nome,
            id: dadosDoModelo.id,
            idRaca: dadosDoModelo.idRaca,
            profissao: parseInt(profissaoSelecionada),
            altura: parseFloat(dadosDoModelo.altura),
            idade: parseInt(dadosDoModelo.idade),
            estaVivo: condicaoSelecionada,
          };
        },

        _buscarDadosDoPersonagemSelecionadoNaLista: function (dados) {
          const personagemSelecionado = dados
            .getSource()
            .getBindingContext("personagens")
            .getObject();

          this.personagem = {
            nome: personagemSelecionado.nome,
            id: personagemSelecionado.id,
            idRaca: personagemSelecionado.idRaca,
            altura: parseFloat(personagemSelecionado.altura),
            idade: parseInt(personagemSelecionado.idade),
          };

          this.modelo(MODELO_PERSONAGEM, new JSONModel(personagemSelecionado));
        },

        _carregarDados: async function (oEvent) {
          this._carregarDadosDaRaca(oEvent);
          this._carregarListaDePersonagens(oEvent);
          this._carregarModeloVazioDePersonagem(oEvent);
        },

        _carregarDadosDaRaca: async function (oEvent) {
          try {
            const idRaca = oEvent.getParameter("arguments").id;
            const raca = await RacaService.obterRaca(idRaca);
            const modelo = new JSONModel(raca);

            this.modelo(MODELO_RACA, modelo);
          } catch (erros) {
            const rotaNotFound = "notFound";
            this.onNavTo(rotaNotFound, this);
          }
        },

        _carregarListaDePersonagens: async function (oEvent) {
          try {
            const idRaca = oEvent.getParameter("arguments").id;
            const raca = await RacaService.obterRaca(idRaca);
            this.filtros.nomeDaRaca = raca.nome;
            const personagens = await PersonagemService.obterTodos(
              this.filtros
            );
            const modelo = new JSONModel(personagens);

            this.modelo(MODELO_PERSONAGENS, modelo);
          } catch (erros) {
            this._exibirErros(erros);
          }
        },

        _carregarModeloVazioDePersonagem: function (oEvent) {
          const stringVazia = "";
          const condicaoInicial = 0;

          const modelo = new JSONModel({
            nome: stringVazia,
            idRaca: oEvent.getParameter("arguments").id,
            profissao: stringVazia,
            altura: stringVazia,
            idade: stringVazia,
            estaVivo: condicaoInicial,
          });

          this.modelo(MODELO_PERSONAGEM, modelo);
        },

        _carregarModeloDeNovoPersonagem: function () {
          const stringVazia = "";
          const condicaoInicial = 0;

          const modeloRaca = this.modelo(MODELO_RACA);
          const idRaca = modeloRaca.getProperty("/id");

          const modelo = new JSONModel({
            nome: stringVazia,
            idRaca: idRaca,
            profissao: stringVazia,
            altura: stringVazia,
            idade: stringVazia,
            estaVivo: condicaoInicial,
          });

          this.modelo(MODELO_PERSONAGEM, modelo);
        },

        _limparInputs: function (oEvent) {
          const stringVazia = "";
          const profissaoInicial = 0;
          const condicaoInicial = 0;
          const valueStatePadrao = "None";

          const modeloRaca = this.modelo(MODELO_RACA);
          const idRaca = modeloRaca.getProperty("/id");

          const modelo = new JSONModel({
            nome: stringVazia,
            idRaca: idRaca,
            profissao: profissaoInicial,
            altura: stringVazia,
            idade: stringVazia,
            estaVivo: condicaoInicial,
          });
          this.modelo(MODELO_PERSONAGEM, modelo);

          this.byId(ID_INPUT_NOME).setValueState(valueStatePadrao);
          this.byId(ID_COMBOBOX_PROFISSAO).setSelectedIndex(profissaoInicial);
          this.byId(ID_RADIO_BTN_VIVOOUMORTO).setSelectedIndex(condicaoInicial);
        },
        _atualizarTextoDaPaginaCriar: function () {
          this._atualizarTituloDaModalCriar();
          this._atualizarLabelDoBotaoAdicionar();
        },

        _atualizarTextoDaModalEditar: function () {
          this._atualizarTituloDaModalEditar();
          this._atualizarLabelDoBotaoEditar();
        },

        _atualizarTituloDaModalCriar: function () {
          const idModalCriacao = "modalCriarPersonagem";
          const chaveI18N = "TituloModalCriarPersonagem";
          this.byId(idModalCriacao).setTitle(this.obterTextoI18N(chaveI18N));
        },

        _atualizarTituloDaModalEditar: function () {
          const idModalCriacao = "modalCriarPersonagem";
          const chaveI18N = "TituloModalEditarPersonagem";
          this.byId(idModalCriacao).setTitle(this.obterTextoI18N(chaveI18N));
        },

        _atualizarLabelDoBotaoAdicionar: function () {
          const idBotaoAdicionar = "criarPersonagemModalBtn";
          const chaveI18N = "BotaoAdicionar";
          this.byId(idBotaoAdicionar).setText(this.obterTextoI18N(chaveI18N));
        },

        _atualizarLabelDoBotaoEditar: function () {
          const idBotaoAdicionar = "criarPersonagemModalBtn";
          const chaveI18N = "BotaoEditar";
          this.byId(idBotaoAdicionar).setText(this.obterTextoI18N(chaveI18N));
        },
        _mostrarBotoesDeEditarERemoverPersonagem: function (visibilidade) {
          this.byId("removerPersonagemBtn").setVisible(visibilidade);
          this.byId("editarPersonagemBtn").setVisible(visibilidade);
        },
        _loadPersonagens: async function () {
          try {
            const idRaca = this.modelo(MODELO_RACA).getData().id;
            const raca = await RacaService.obterRaca(idRaca);
            this.filtros.nomeDaRaca = raca.nome;
            const personagens = await PersonagemService.obterTodos(
              this.filtros
            );

            const modeloPersonagens = new JSONModel(personagens);
            this.modelo(MODELO_PERSONAGENS, modeloPersonagens);
          } catch (erros) {
            this._exibirErros(erros);
          }
        },
      }
    );
  }
);
