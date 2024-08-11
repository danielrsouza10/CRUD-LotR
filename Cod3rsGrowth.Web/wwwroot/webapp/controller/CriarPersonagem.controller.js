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

          if (this._validarNome(nomeInserido)) {
            this.personagem.nome = nomeInserido;
          }

          console.log(this.personagem);
        },
        aoMudarRacaNaComboBox: function (oEvent) {
          const objeto = oEvent.getSource();
          const racaSelecionada = objeto.getSelectedKey();
          this.personagem.idRaca = parseInt(racaSelecionada);
          console.log(this.personagem);
          return "";
        },
        aoMudarProfissaoNaComboBox: function (oEvent) {
          const objeto = oEvent.getSource();
          const profissaoSelecionada = objeto.getSelectedKey();
          this.personagem.profissao = parseInt(profissaoSelecionada);
          console.log(this.personagem);
          return "";
        },
        aoMudarIdade: function (oEvent) {
          const objeto = oEvent.getSource();
          const idadeInserida = objeto.getValue();
          if (this._validarIdade(idadeInserida)) {
            this.personagem.idade = parseInt(idadeInserida);
          }
          console.log(this.personagem);
          return "";
        },
        aoMudarAltura: function (oEvent) {
          const objeto = oEvent.getSource();
          const alturaInserida = objeto.getValue();
          if (this._validarAltura(alturaInserida)) {
            this.personagem.altura = parseInt(alturaInserida);
          }
          console.log(this.personagem);
          return "";
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
          try {
            const personagemCriado =
              await PersonagemService.adicionarPersonagem(this.personagem);
            MessageBox.show("Personagem adicionado com sucesso!");
          } catch (erros) {
            this._exibirErros(erros);
          }
        },

        // _validarInputUsuario: function (nomeInserido) {
        //   let erroValidacao = false;
        //   const nomeInseridoInput = nomeInserido.getValue();
        //   const alturaInseridaInput = nomeInserido.getValue(); //alterar quando implementar
        //   const idadeInseridaInput = nomeInserido.getValue(); //alterar quando implementar

        // let contemCaracteresEspeciais =
        //   this._verificarCaracteresEspeciais(nomeInseridoInput);
        // let tamanhoDaString = this._verificarTamanhoString(nomeInseridoInput);
        //   let verificarAltura = this._verificarInputAltura(alturaInseridaInput);
        //   let verificarIdade = this._verificarInputIdade(idadeInseridaInput);

        //   if (
        //     !contemCaracteresEspeciais &&
        //     tamanhoDaString &&
        //     verificarAltura &&
        //     verificarIdade
        //   ) {
        //     erroValidacao = true;
        //     return erroValidacao;
        //     let valueState = this._verificarTamanhoString(nomeInseridoInput)
        //       ? "Error"
        //       : "Success"; //valor visual do input do usuario no front
        //     nomeInserido.setValueState(valueState);
        //   }

        //   this._verificarCaracteresEspeciais(textoInput);

        //   try {
        //     binding.getType().validateValue(inputUsuario.getValue());
        // 	valueState = "Success";
        //   } catch (exception) {
        //     valueState = "Error";
        //     erroValidacao = true;
        //   }
        //   nomeInserido.setValueState(valueState);

        //   return erroValidacao;
        // },

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
          return regex.test(str);
        },

        _verificarTamanhoString: function (str) {
          const tamanhoMinimo = 3;
          return str.length >= tamanhoMinimo;
        },

        _validarIdade(idadeInserida) {
          const idadeMinima = 0;
          return idadeInserida >= idadeMinima;
        },

        _validarAltura(alturaInserida) {
          const alturaMinima = 0;
          return alturaInserida >= alturaMinima;
        },

        _exibirErros: function (erros) {
          const tituloMessageBox = "erros.errors";
          let mensagemDeErro = Object.values(erros).join(" ");
          console.log(erros);
          MessageBox.show(mensagemDeErro);
        },
      }
    );
  }
);
