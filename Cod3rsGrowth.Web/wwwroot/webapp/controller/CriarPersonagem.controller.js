sap.ui.define(
  [
    "../controller/BaseController",
    "sap/ui/model/json/JSONModel",
    "ui5/o_senhor_dos_aneis/services/RacaService",
    "ui5/o_senhor_dos_aneis/services/PersonagemService",
    "sap/m/MessageBox",
  ],
  function (
    BaseController,
    JSONModel,
    RacaService,
    PersonagemService,
    MessageBox
  ) {
    "use strict";
    const ID_INPUT_NOME = "inputNome",
      ID_COMBOBOX_RACAS = "comboBoxRacas",
      ID_COMBOBOX_PROFISSOES = "comboBoxProfissoes",
      ID_INPUT_IDADE = "inputIdade",
      ID_INPUT_ALTURA = "inputAltura",
      ID_RADIO_BTN_VIVOMORTO = "radioBtnVivoMorto";
    return BaseController.extend(
      "ui5.o_senhor_dos_aneis.controller.CriarPersonagem",
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
          const racas = await RacaService.obterTodos(this.filtros);
          const modelo = new JSONModel(racas);
          const modeloRaca = "racas";

          this.getView().setModel(modelo, modeloRaca);
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

        aoCriarPersonagem: async function (oEvent) {
          this._pegarValoresDoPersonagemNaTela();

          if (this._validarNovoPersonagem(this.personagem)) {
            try {
              const personagemCriado =
                await PersonagemService.adicionarPersonagem(this.personagem);
              const mensagemDeSucesso = "Personagem adicionado com sucesso!";
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

        _aoMudarInput: function (oEvent, funcaoDeValidacao) {
          const objeto = oEvent.getSource();
          const nomeInserido = objeto.getValue();
          let valueState = funcaoDeValidacao(nomeInserido)
            ? "Success"
            : "Error";
          objeto.setValueState(valueState);
        },

        _validarNovoPersonagem: function (personagem) {
          let personagemValido = false;
          const nomeInseridoInput = this._validarNome(personagem.nome);
          const idadeInseridaInput = this._validarIdade(personagem.idade);
          const alturaInseridaInput = this._validarAltura(personagem.altura);
          if (nomeInseridoInput && idadeInseridaInput && alturaInseridaInput) {
            personagemValido = true;
            return personagemValido;
          }
          this._exibirErros(this.errosDeValidacao);
          return personagemValido;
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

        _validarIdade(idadeInserida) {
          const idadeMinima = 0;
          let idadeValida = false;
          if (idadeInserida < idadeMinima) {
            const mensagemDeErro =
              "O valor da idade precisa ser maior do que zero";
            this.errosDeValidacao.idadeMinima = mensagemDeErro;
            return idadeValida;
          }
          delete this.errosDeValidacao.idadeMinima;
          idadeValida = true;
          return idadeValida;
        },

        _validarAltura(alturaInserida) {
          const alturaMinima = 0;
          let alturaValida = false;
          if (alturaInserida < alturaMinima) {
            const mensagemDeErro =
              "O valor da altura precisa ser maior do que zero";
            this.errosDeValidacao.alturaMinima = mensagemDeErro;
            return alturaValida;
          }
          delete this.errosDeValidacao.alturaMinima;
          alturaValida = true;
          return alturaValida;
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
            const tituloErro = "Erro ao criar personagem";
            const detailsErro =
              "Corrija os campos acima para prosseguir com a criação do personagem";
            MessageBox.error(mensagemDeErro, {
              title: tituloErro,
              details: detailsErro,
              contentWidth: "300px",
              dependentOn: this.getView(),
            });
          }
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
