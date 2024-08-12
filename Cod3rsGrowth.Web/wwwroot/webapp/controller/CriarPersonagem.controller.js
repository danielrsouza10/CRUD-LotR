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
        },
        aoMudarIdade: function (oEvent) {
          const objeto = oEvent.getSource();
          const idadeInserida = objeto.getValue();
          let valueState = this._validarIdade(idadeInserida)
            ? "Success"
            : "Error";
          objeto.setValueState(valueState);
        },
        aoMudarAltura: function (oEvent) {
          const objeto = oEvent.getSource();
          const alturaInserida = objeto.getValue();
          let valueState = this._validarAltura(alturaInserida)
            ? "Success"
            : "Error";
          objeto.setValueState(valueState);
        },

        aoCriarPersonagem: async function (oEvent) {
          this.personagem.nome = this.byId("inputNome").getValue();
          this.personagem.idRaca = parseInt(
            this.byId("comboBoxRacas").getSelectedKey()
          );
          this.personagem.profissao = parseInt(
            this.byId("comboBoxProfissoes").getSelectedIndex()
          );
          this.personagem.idade = parseInt(this.byId("inputIdade").getValue());
          this.personagem.altura = parseFloat(
            this.byId("inputAltura").getValue()
          );
          const condicaoVivo = 0;
          this.personagem.estaVivo =
            this.byId("radioBtnVivoMorto").getSelectedIndex() == condicaoVivo
              ? true
              : false;
          console.log(this.personagem);

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
              const tempoParaVisualizarMensagem = 3000;
              setTimeout(() => this.onNavBack(), tempoParaVisualizarMensagem);
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
              "O nome não pode conter números, espaços ou caracteres especiais";
            const tituloErro = "Nome Inválido";
            MessageBox.error(mensagemDeErro, {
              title: tituloErro,
              contentWidth: "35%",
              dependentOn: this.getView(),
            });
            return nomeValido;
          }
          const tamanhoDaString = this._verificarTamanhoString(nomeInserido);
          if (!tamanhoDaString) {
            const mensagemDeErro = "O nome precisa ter pelo menos 3 caracteres";
            const tituloErro = "Nome Inválido";
            MessageBox.error(mensagemDeErro, {
              title: tituloErro,
              contentWidth: "35%",
              dependentOn: this.getView(),
            });
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
          if (str !== null) {
            return str.length >= tamanhoMinimo;
          }
          return false;
        },

        _validarIdade(idadeInserida) {
          const idadeMinima = 0;
          let idadeValida = false;
          if (idadeInserida < idadeMinima) {
            const mensagemDeErro = "O valor precisa ser maior do que zero";
            const tituloErro = "Idade inválida";
            MessageBox.error(mensagemDeErro, {
              title: tituloErro,
              contentWidth: "35%",
              dependentOn: this.getView(),
            });
            return idadeValida;
          }
          idadeValida = true;
          return idadeValida;
        },

        _validarAltura(alturaInserida) {
          const alturaMinima = 0;
          let alturaValida = false;
          if (alturaInserida < alturaMinima) {
            const mensagemDeErro = "O valor precisa ser maior do que zero";
            const tituloErro = "Altura inválida";
            MessageBox.error(mensagemDeErro, {
              title: tituloErro,
              contentWidth: "35%",
              dependentOn: this.getView(),
            });
            return alturaValida;
          }
          alturaValida = true;
          return alturaValida;
        },

        _exibirErros: function (erros) {
          console.log(erros);
          let mensagemDeErro = Object.values(erros.extensions.erros).join(" ");
          const tituloErro = erros.title;
          const detalhesDoErro = erros.details;
          MessageBox.error(mensagemDeErro, {
            title: tituloErro,
            details: detalhesDoErro,
            contentWidth: "35%",
            dependentOn: this.getView(),
          });
        },
        _limparInputs: function () {
          const stringVazia = "";
          const chaveRacaInicial = 1;
          const indexProfissaoInicial = 0;
          const condicaoInicial = 0;

          this.byId("inputNome").setValue(stringVazia);
          this.byId("comboBoxRacas").setSelectedKey(chaveRacaInicial);
          this.byId("comboBoxProfissoes").setSelectedIndex(
            indexProfissaoInicial
          );
          this.byId("inputIdade").setValue(stringVazia);
          this.byId("inputAltura").setValue(stringVazia);
          this.byId("radioBtnVivoMorto").setSelectedIndex(condicaoInicial);
        },
      }
    );
  }
);
