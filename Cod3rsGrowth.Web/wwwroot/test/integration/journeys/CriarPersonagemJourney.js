sap.ui.define(
  [
    "sap/ui/test/opaQunit",
    "../pages/CriarPersonagem",
    "../pages/ListaPersonagens",
    "../pages/Home",
  ],
  function (opaTest) {
    "use strict";

    QUnit.module("Criar Personagens");

    opaTest(
      "Deve retornar um erro ao adicionar um personagem com o nome já cadastrado",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "personagem/criarPersonagem",
        });

        //Actions
        When.naPaginaDeCriarPersonagem.aTelaFoiCarregadaCorretamente();
        When.naPaginaDeCriarPersonagem.euDigitoUmNomeNoInputField("Aragorn");
        When.naPaginaDeCriarPersonagem.euSelecionoUmaRaca("4");
        When.naPaginaDeCriarPersonagem.euSelecionoUmaProfissao("7");
        When.naPaginaDeCriarPersonagem.euDigitoUmaIdadeNoInputField("98");
        When.naPaginaDeCriarPersonagem.euDigitoUmaAlturaNoInputField("1.97");
        When.naPaginaDeCriarPersonagem.euSelecionoCondicaoMorto();
        When.naPaginaDeCriarPersonagem.euPressionoOBotaoAdicionar();

        // Assertions
        Then.naPaginaDeCriarPersonagem.deveAparecerUmaMessageBoxDeErroVindoDoServidor();
        // Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve retornar um erro ao adicionar um personagem sem preencher nenhum input field",
      function (Given, When, Then) {
        Given.iStartMyApp({
          hash: "personagem/criarPersonagem",
        });
        //Actions
        When.naPaginaDeCriarPersonagem.aTelaFoiCarregadaCorretamente();
        When.naPaginaDeCriarPersonagem.euPressionoOBotaoAdicionar();

        // Assertions
        Then.naPaginaDeCriarPersonagem.deveAparecerUmaMessageBoxDeErro();
      }
    );
    opaTest(
      "Deve retornar um erro ao adicionar um personagem com o nome menor que 3 caracteres",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDeCriarPersonagem.euPressionoBotaoFechar();
        When.naPaginaDeCriarPersonagem.aTelaFoiCarregadaCorretamente();
        When.naPaginaDeCriarPersonagem.euDigitoUmNomeNoInputField("Ar");
        When.naPaginaDeCriarPersonagem.euSelecionoUmaRaca("4");
        When.naPaginaDeCriarPersonagem.euSelecionoUmaProfissao("7");
        When.naPaginaDeCriarPersonagem.euDigitoUmaIdadeNoInputField("98");
        When.naPaginaDeCriarPersonagem.euDigitoUmaAlturaNoInputField("1.97");
        When.naPaginaDeCriarPersonagem.euSelecionoCondicaoMorto();
        When.naPaginaDeCriarPersonagem.euPressionoOBotaoAdicionar();

        // Assertions
        Then.naPaginaDeCriarPersonagem.deveAparecerUmaMessageBoxDeErro();
      }
    );
    opaTest(
      "Deve retornar um erro ao adicionar um personagem com o nome com caracteres invalidos",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDeCriarPersonagem.euPressionoBotaoFechar();
        When.naPaginaDeCriarPersonagem.aTelaFoiCarregadaCorretamente();
        When.naPaginaDeCriarPersonagem.euDigitoUmNomeNoInputField("****");
        When.naPaginaDeCriarPersonagem.euSelecionoUmaRaca("10");
        When.naPaginaDeCriarPersonagem.euSelecionoUmaProfissao("6");
        When.naPaginaDeCriarPersonagem.euDigitoUmaIdadeNoInputField("1000");
        When.naPaginaDeCriarPersonagem.euDigitoUmaAlturaNoInputField("0.69");
        When.naPaginaDeCriarPersonagem.euSelecionoCondicaoMorto();
        When.naPaginaDeCriarPersonagem.euSelecionoCondicaoVivo();
        When.naPaginaDeCriarPersonagem.euPressionoOBotaoAdicionar();

        // Assertions
        Then.naPaginaDeCriarPersonagem.deveAparecerUmaMessageBoxDeErro();
      }
    );
    opaTest(
      "Deve retornar um erro ao adicionar um personagem com o altura invalida",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDeCriarPersonagem.euPressionoBotaoFechar();
        When.naPaginaDeCriarPersonagem.aTelaFoiCarregadaCorretamente();
        When.naPaginaDeCriarPersonagem.euDigitoUmNomeNoInputField("****");
        When.naPaginaDeCriarPersonagem.euSelecionoUmaRaca("10");
        When.naPaginaDeCriarPersonagem.euSelecionoUmaProfissao("6");
        When.naPaginaDeCriarPersonagem.euDigitoUmaIdadeNoInputField("1000");
        When.naPaginaDeCriarPersonagem.euDigitoUmaAlturaNoInputField("-0.69");
        When.naPaginaDeCriarPersonagem.euSelecionoCondicaoMorto();
        When.naPaginaDeCriarPersonagem.euSelecionoCondicaoVivo();
        When.naPaginaDeCriarPersonagem.euPressionoOBotaoAdicionar();

        // Assertions
        Then.naPaginaDeCriarPersonagem.deveAparecerUmaMessageBoxDeErro();
      }
    );
    opaTest(
      "Deve retornar um erro ao adicionar um personagem com o idade invalida",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDeCriarPersonagem.euPressionoBotaoFechar();
        When.naPaginaDeCriarPersonagem.aTelaFoiCarregadaCorretamente();
        When.naPaginaDeCriarPersonagem.euDigitoUmNomeNoInputField("****");
        When.naPaginaDeCriarPersonagem.euSelecionoUmaRaca("10");
        When.naPaginaDeCriarPersonagem.euSelecionoUmaProfissao("6");
        When.naPaginaDeCriarPersonagem.euDigitoUmaIdadeNoInputField("-1000");
        When.naPaginaDeCriarPersonagem.euDigitoUmaAlturaNoInputField("0.69");
        When.naPaginaDeCriarPersonagem.euSelecionoCondicaoMorto();
        When.naPaginaDeCriarPersonagem.euSelecionoCondicaoVivo();
        When.naPaginaDeCriarPersonagem.euPressionoOBotaoAdicionar();

        // Assertions
        Then.naPaginaDeCriarPersonagem.deveAparecerUmaMessageBoxDeErro();
      }
    );
    opaTest(
      "Deve retornar a pagina de listagem de personagens quando pressiono o botao cancelar",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDeCriarPersonagem.euPressionoBotaoFechar();
        When.naPaginaDeCriarPersonagem.aTelaFoiCarregadaCorretamente();
        When.naPaginaDeCriarPersonagem.euPressionoOBotaoCancelar();

        // Assertions
        Then.naPaginaDaListaDePersonagens
          .oTituloDaPaginaDePersonagensDeveraSer()
          .and.aUrlDaPaginaDePersonagensDeveraSer();
        // Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve retornar a pagina anterior quando pressiono o botao de voltar",
      function (Given, When, Then) {
        Given.iStartMyApp({
          hash: "personagem/criarPersonagem",
        });
        //Actions
        When.naPaginaDeCriarPersonagem.aTelaFoiCarregadaCorretamente();
        When.naPaginaDeCriarPersonagem.euPressionoBotaoVoltar();

        // Assertions
        Then.naPaginaDaListaDePersonagens
          .oTituloDaPaginaDePersonagensDeveraSer()
          .and.aUrlDaPaginaDePersonagensDeveraSer();
        // Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve retornar um erro ao adicionar um personagem com todos os input fields invalidos",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "personagem/criarPersonagem",
        });
        //Actions
        When.naPaginaDeCriarPersonagem.aTelaFoiCarregadaCorretamente();
        When.naPaginaDeCriarPersonagem.euDigitoUmNomeNoInputField("D*");
        When.naPaginaDeCriarPersonagem.euSelecionoUmaRaca("10");
        When.naPaginaDeCriarPersonagem.euSelecionoUmaProfissao("6");
        When.naPaginaDeCriarPersonagem.euDigitoUmaIdadeNoInputField("-1000");
        When.naPaginaDeCriarPersonagem.euDigitoUmaAlturaNoInputField("-0.69");
        When.naPaginaDeCriarPersonagem.euSelecionoCondicaoMorto();
        When.naPaginaDeCriarPersonagem.euPressionoOBotaoAdicionar();

        // Assertions
        Then.naPaginaDeCriarPersonagem.deveAparecerUmaMessageBoxDeErro();

        // Cleanup
        Then.iTeardownMyApp();
      }
    );
  }
);
