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

    return BaseController.extend(
      "ui5.o_senhor_dos_aneis.controller.CriarPersonagem",
      {
        onInit: function () {
          this.filtros = {};
          this.personagem = {};
          const rota = "criarPersonagem";
          this.vincularRota(rota, this.aoCoincidirRota);
        },

        aoCoincidirRota: function () {
          this.loadRacas();
        },
        loadRacas: async function () {
          const racas = await RacaService.obterTodos(this.filtros);
          const modelo = new JSONModel(racas);
          const modeloRaca = "racas";

          this.getView().setModel(modelo, modeloRaca);
        },
        aoMudarNome: function (oEvent) {
          const objeto = oEvent.getSource();
          const nomeInserido = objeto.getValue();
          let valueState = this._validarNome(nomeInserido)
            ? "Success"
            : "Error";
          objeto.setValueState(valueState);
          this.personagem.nome = nomeInserido;

          console.log(this.personagem);
        },
        aoMudarRacaNaComboBox: function (oEvent) {
          const objeto = oEvent.getSource();
          const racaSelecionada = objeto.getSelectedKey();
          this.personagem.idRaca = parseInt(racaSelecionada);
          console.log(this.personagem);
        },
        aoMudarProfissaoNaComboBox: function (oEvent) {
          const objeto = oEvent.getSource();
          const profissaoSelecionada = objeto.getSelectedKey();
          this.personagem.profissao = parseInt(profissaoSelecionada);
          console.log(this.personagem);
        },
        aoMudarIdade: function (oEvent) {
          const objeto = oEvent.getSource();
          const idadeInserida = objeto.getValue();
          let valueState = this._validarIdade(idadeInserida)
            ? "Success"
            : "Error";
          objeto.setValueState(valueState);
          this.personagem.idade = parseInt(idadeInserida);
          console.log(this.personagem);
        },
        aoMudarAltura: function (oEvent) {
          const objeto = oEvent.getSource();
          const alturaInserida = objeto.getValue();
          let valueState = this._validarAltura(alturaInserida)
            ? "Success"
            : "Error";
          objeto.setValueState(valueState);
          this.personagem.altura = parseInt(alturaInserida);
          console.log(this.personagem);
        },
        aoSelecionarCondicao: function (oEvent) {
          const condicaoSelecionada = oEvent.getSource().getSelectedIndex();
          const condicaoVivo = 0;
          this.personagem.estaVivo =
            condicaoSelecionada == condicaoVivo ? true : false;
          console.log(this.personagem);
        },

        aoCriarPersonagem: async function (oEvent) {
          if (this.personagem.idRaca == null) {
            this.personagem.idRaca = 1;
          }
          if (this.personagem.profissao == null) {
            this.personagem.profissao = 1;
          }
          if (this.personagem.estaVivo == null) {
            this.personagem.estaVivo = true;
          }
          if (this._validarNovoPersonagem(this.personagem)) {
            try {
              const personagemCriado =
                await PersonagemService.adicionarPersonagem(this.personagem);
            } catch (erros) {
              this._exibirErros(erros);
            }
          }
        },

        _validarNovoPersonagem: function (personagem) {
          let personagemValido = false;
          const nomeInseridoInput = this._validarNome(personagem.nome);
          if (!nomeInseridoInput) {
            return personagemValido;
          }
          const idadeInseridaInput = this._validarIdade(personagem.idade);
          if (!idadeInseridaInput) {
            return personagemValido;
          }
          const alturaInseridaInput = this._validarAltura(personagem.altura);
          if (!alturaInseridaInput) {
            return personagemValido;
          }
          personagemValido = true;
          return personagemValido;
        },

        _validarNome: function (nomeInserido) {
          let nomeValido = false;
          const contemCaracteresEspeciais =
            this._verificarCaracteresEspeciais(nomeInserido);
          if (contemCaracteresEspeciais) {
            const mensagemDeErro =
              "O nome não deve conter números ou caracteres especiais";
            MessageBox.error(mensagemDeErro);
            return nomeValido;
          }
          const tamanhoDaString = this._verificarTamanhoString(nomeInserido);
          if (!tamanhoDaString) {
            const mensagemDeErro = "O nome precisa ter pelo menos 3 caracteres";
            MessageBox.error(mensagemDeErro);
            return nomeValido;
          }
          nomeValido = true;
          return nomeValido;
        },

        _verificarCaracteresEspeciais: function (str) {
          const regex = /[^a-zA-Z]/;
          return regex.test(str);
        },

        _verificarTamanhoString: function (str) {
          const tamanhoMinimo = 3;
          return str.length >= tamanhoMinimo;
        },

        _validarIdade(idadeInserida) {
          const idadeMinima = 0;
          let idadeValida = false;
          if (idadeInserida < idadeMinima) {
            const mensagemDeErro = "Idade inválida";
            MessageBox.error(mensagemDeErro);
            return idadeValida;
          }
          idadeValida = true;
          return idadeValida;
        },

        _validarAltura(alturaInserida) {
          const alturaMinima = 0;
          let alturaValida = false;
          if (alturaInserida < alturaMinima) {
            const mensagemDeErro = "Altura inválida";
            MessageBox.error(mensagemDeErro);
            return alturaValida;
          }
          alturaValida = true;
          return alturaValida;
        },

        _exibirErros: function (erros) {
          const tituloMessageBox = "erros.errors";
          let mensagemDeErro = Object.values(erros).join(" ");
          console.log(erros);
          MessageBox.error(mensagemDeErro);
        },
      }
    );
  }
);
