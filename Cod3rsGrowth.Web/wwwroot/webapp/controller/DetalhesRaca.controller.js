sap.ui.define(
  [
    "../controller/BaseController",
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
          this._carregarModelos(oEvent);
          this._mostrarBotoesEditarERemover(false);
        },
        aoClicarBtnEditarRaca: function () {
          const modelo = "raca",
            rotaEditarRaca = "editarRaca",
            idRacaSelecionada = this.getView().getModel(modelo).getData().id;
          this.onNavTo(rotaEditarRaca, { id: idRacaSelecionada });
        },
        aoClicarBtnRemoverRaca: async function () {
          const tituloDoDialogo = "Excluir registro",
            mensagemDoDialogo = "Deseja confirmar a exclusão desse registro?";
          const confirmacao = await this.criarDialogoDeAviso(
            tituloDoDialogo,
            mensagemDoDialogo
          );
          if (confirmacao) {
            const idRaca = this.getView().getModel(MODELO_RACA).getData().id;
            try {
              await RacaService.removerRaca(idRaca);
              const mensagemDeSucesso = "Raça removida com sucesso!";
              const tituloDaMessageBox = "Sucesso";
              this.criarDialogoDeSucesso(mensagemDeSucesso, tituloDaMessageBox);
            } catch (erros) {
              this._exibirErros(erros);
            }
          }
        },
        aoClicarBtnAdicionarPersonagem: function (oEvent) {
          this._carregarModalDeCriacao();
        },

        aoClicarBtnEditarPersonagem: function (oEvent) {
          this._mostrarBotoesEditarERemover(false);
          this._buscarDadosDoPersonagemSelecionado(oEvent);
          this._carregarModalDeCriacao();
        },

        aoPressionarAdicionarNoModal: async function (oEvent) {
          this._pegarDadosDoPersonagemNoModelo();
          if (this._validarNovoPersonagem(this.personagem)) {
            if (this.personagem.id) {
              try {
                const personagemEditado =
                  await PersonagemService.editarPersonagem(this.personagem);
                const mensagemDeSucesso = "Personagem editado com sucesso!";
                const tituloDaMessageBox = "Sucesso";
                this.criarDialogoDeSucesso(
                  mensagemDeSucesso,
                  tituloDaMessageBox
                );
                this._limparInputs(oEvent);
                return this.byId(ID_MODAL_CRIAR_PERSONAGEM).close();
              } catch (erros) {
                return this._exibirErros(erros);
              }
            }
            try {
              const personagemCriado =
                await PersonagemService.adicionarPersonagem(this.personagem);
              const mensagemDeSucesso = "Personagem adicionado com sucesso!";
              const tituloDaMessageBox = "Sucesso";
              this.criarDialogoDeSucesso(mensagemDeSucesso, tituloDaMessageBox);
              this._limparInputs(oEvent);
              this.byId(ID_MODAL_CRIAR_PERSONAGEM).close();
            } catch (erros) {
              this._exibirErros(erros);
            }
          }
        },

        aoPressionarCancelarNoModal: function (oEvent) {
          this.byId(ID_MODAL_CRIAR_PERSONAGEM).close();
          this._limparInputs(oEvent);
        },

        _carregarModalDeCriacao: async function () {
          this.modalCriarPersonagem ??= await this.loadFragment({
            name: "ui5.o_senhor_dos_aneis.view.CriarPersonagensModal",
          });

          this.modalCriarPersonagem.open();
          this._pegarDadosDoPersonagemNoModelo();
        },

        _pegarDadosDoPersonagemNoModelo: function () {
          const modelo = this.getView().getModel(MODELO_PERSONAGEM);

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

        _buscarDadosDoPersonagemSelecionado: function (dados) {
          const idPersonagemSelecionado = dados
            .getSource()
            .getBindingContext("personagens")
            .getProperty("id");

          const personagemSelecionado = dados
            .getSource()
            .getBindingContext("personagens")
            .getObject();

          console.log(personagemSelecionado);

          this.getView().setModel(
            new JSONModel(personagemSelecionado),
            MODELO_PERSONAGEM
          );

          return idPersonagemSelecionado;
        },

        _mostrarBotoesEditarERemover: function (valor) {
          this.byId("editarPersonagemBtn").setVisible(valor);
          this.byId("removerPersonagemBtn").setVisible(valor);
        },

        _carregarModelos: async function (oEvent) {
          this._carregarModeloDaRaca(oEvent);
          this._carregarModeloDePersonagens(oEvent);
          this._carregarModeloDeNovoPersonagem(oEvent);
        },

        _carregarModeloDaRaca: async function (oEvent) {
          try {
            const idRaca = oEvent.getParameter("arguments").id;
            const raca = await RacaService.obterRaca(idRaca);
            const modelo = new JSONModel(raca);

            this.getView().setModel(modelo, MODELO_RACA);
          } catch (erros) {
            const rotaNotFound = "notFound";
            this.onNavTo(rotaNotFound, this);
          }
        },
        _carregarModeloDePersonagens: async function (oEvent) {
          try {
            const idRaca = oEvent.getParameter("arguments").id;
            const raca = await RacaService.obterRaca(idRaca);
            this.filtros.nomeDaRaca = raca.nome;
            const personagens = await PersonagemService.obterTodos(
              this.filtros
            );
            const modelo = new JSONModel(personagens);

            this.getView().setModel(modelo, MODELO_PERSONAGENS);
          } catch (erros) {
            this._exibirErros(erros);
          }
        },
        _carregarModeloPersonagemSelecionado: async function (oEvent) {
          try {
            const idPersonagemSelecionado = oEvent.getParameter("arguments").id;
          } catch (erros) {
            this._exibirErros(erros);
          }
        },
        _carregarModeloDeNovoPersonagem: function (oEvent) {
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

          this.getView().setModel(modelo, MODELO_PERSONAGEM);
        },
        _limparInputs: function (oEvent) {
          const stringVazia = "";
          const profissaoInicial = 0;
          const condicaoInicial = 0;
          const valueStatePadrao = "None";

          const modeloRaca = this.getView().getModel(MODELO_RACA);
          const idRaca = modeloRaca.getProperty("/id");

          const modelo = new JSONModel({
            nome: stringVazia,
            idRaca: idRaca,
            profissao: profissaoInicial,
            altura: stringVazia,
            idade: stringVazia,
            estaVivo: condicaoInicial,
          });
          this.getView().setModel(modelo, MODELO_PERSONAGEM);

          this.byId(ID_INPUT_NOME).setValueState(valueStatePadrao);
          this.byId(ID_COMBOBOX_PROFISSAO).setSelectedIndex(profissaoInicial);
          this.byId(ID_RADIO_BTN_VIVOOUMORTO).setSelectedIndex(condicaoInicial);
        },
      }
    );
  }
);
