sap.ui.define(
  ["sap/ui/test/opaQunit", "../pages/CriarPersonagem"],
  function (opaTest) {
    "use strict";

    QUnit.module("Criar Personagens");

    opaTest(
      "Deve retornar um erro ao adicionar um personagem com o nome já cadastrado",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "#/personagem/criarPersonagem",
        });

        //Actions
        When.naPaginaDeCriarPersonagem.euDigitoUmNomeValidoNoInputField(
          "Aragorn"
        );
        When.naPaginaDeCriarPersonagem.euSelecionoUmaRacaNaCombobo("4");
        When.naPaginaDeCriarPersonagem.euSelecionoUmaProfissaoNaCombobo("7");
        When.naPaginaDeCriarPersonagem.euDigitoUmaIdadeValidaNoInputField("98");
        When.naPaginaDeCriarPersonagem.euDigitoUmaAlturaValidaNoInputField(
          "1,97"
        );
        When.naPaginaDeCriarPersonagem.euSelecionoCondicaoMorto();
        When.naPaginaDeCriarPersonagem.euPressionoOBotaoAdicionar();

        // Assertions
        Then.naPaginaDeCriarPersonagem.deveAparecerUmaMessageBoxDeErro();
      }
    );
    opaTest(
      "Deve retornar um erro ao adicionar um personagem com o nome menor que 3 caracteres",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "#/personagem/criarPersonagem",
        });

        //Actions
        When.naPaginaDeCriarPersonagem.euDigitoUmNomeValidoNoInputField("Ar");
        When.naPaginaDeCriarPersonagem.euSelecionoUmaRacaNaCombobo("4");
        When.naPaginaDeCriarPersonagem.euSelecionoUmaProfissaoNaCombobo("7");
        When.naPaginaDeCriarPersonagem.euDigitoUmaIdadeValidaNoInputField("98");
        When.naPaginaDeCriarPersonagem.euDigitoUmaAlturaValidaNoInputField(
          "1,97"
        );
        When.naPaginaDeCriarPersonagem.euSelecionoCondicaoMorto();
        When.naPaginaDeCriarPersonagem.euPressionoOBotaoAdicionar();

        // Assertions
        Then.naPaginaDeCriarPersonagem.deveAparecerUmaMessageBoxDeErro();
      }
    );
    opaTest(
      "Deve retornar um erro ao adicionar um personagem com o nome com caracteres invalidos",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "#/personagem/criarPersonagem",
        });

        //Actions
        When.naPaginaDeCriarPersonagem.euDigitoUmNomeValidoNoInputField(
          "****"
        );
        When.naPaginaDeCriarPersonagem.euSelecionoUmaRacaNaCombobo("4");
        When.naPaginaDeCriarPersonagem.euSelecionoUmaProfissaoNaCombobo("7");
        When.naPaginaDeCriarPersonagem.euDigitoUmaIdadeValidaNoInputField("98");
        When.naPaginaDeCriarPersonagem.euDigitoUmaAlturaValidaNoInputField(
          "1,97"
        );
        When.naPaginaDeCriarPersonagem.euSelecionoCondicaoMorto();
        When.naPaginaDeCriarPersonagem.euPressionoOBotaoAdicionar();

        // Assertions
        Then.naPaginaDeCriarPersonagem.deveAparecerUmaMessageBoxDeErro();
      }
    );
    opaTest(
      "Deve filtrar de acordo com o nome do personagem inserido no search field",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDeCriarPersonagem.euDigitoONomeDeUmPersonagemNoSearchField(
          "Aragorn"
        );

        // Assertions
        Then.naPaginaDeCriarPersonagem.aListaDeveApresentarApenas1Personagem();
      }
    );
    opaTest(
      "Deve apresentar todos os personagens após pressionar em reset",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDeCriarPersonagem.euPressionoBotaoReset();

        // Assertions
        Then.naPaginaDeCriarPersonagem.aListaDeveApresentar5Personagens();
      }
    );
    opaTest(
      "Deve apresentar somente um personagem ao filtrar por nome e profissao",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDeCriarPersonagem.euDigitoONomeDeUmPersonagemNoSearchField(
          "Aragorn"
        );
        When.naPaginaDeCriarPersonagem.euPressionoBotaoFiltro();
        When.naPaginaDeCriarPersonagem.euSelecionoUmaProfissao();
        When.naPaginaDeCriarPersonagem.euPressionoBotaoOk();

        // Assertions
        Then.naPaginaDeCriarPersonagem.aListaDeveApresentarApenas1Personagem();
      }
    );
    opaTest(
      "Deve apresentar uma lista vazia ao filtrar por nome e raça",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDeCriarPersonagem.euPressionoBotaoFiltro();
        When.naPaginaDeCriarPersonagem.euSelecionoUmaRaca();
        When.naPaginaDeCriarPersonagem.euPressionoBotaoOk();

        // Assertions
        Then.naPaginaDeCriarPersonagem.aListaDeveEstarVazia();
      }
    );
    opaTest(
      "Deve resetar a lista e filtrar por data",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDeCriarPersonagem.euPressionoBotaoReset();
        When.naPaginaDeCriarPersonagem.euPressionoBotaoFiltro();
        When.naPaginaDeCriarPersonagem.euSelecionoUmaDataInicial("2012-05-05");
        When.naPaginaDeCriarPersonagem.euSelecionoUmaDataFinal("2013-05-05");
        When.naPaginaDeCriarPersonagem.euPressionoBotaoOk();

        // Assertions
        Then.naPaginaDeCriarPersonagem.aListaDeveApresentarApenas1Personagem();
      }
    );
    opaTest(
      "Deve resetar a lista e filtrar por vivo",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDeCriarPersonagem.euPressionoBotaoReset();
        When.naPaginaDeCriarPersonagem.euPressionoBotaoFiltro();
        When.naPaginaDeCriarPersonagem.euDouCheckEmVivo();
        When.naPaginaDeCriarPersonagem.euPressionoBotaoOk();

        // Assertions
        Then.naPaginaDeCriarPersonagem.aListaDeveApresentar5Personagens();
      }
    );
    opaTest(
      "Deve resetar a lista e filtrar por morto",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDeCriarPersonagem.euPressionoBotaoReset();
        When.naPaginaDeCriarPersonagem.euPressionoBotaoFiltro();
        When.naPaginaDeCriarPersonagem.euDouCheckEmMorto();
        When.naPaginaDeCriarPersonagem.euPressionoBotaoOk();

        // Assertions
        Then.naPaginaDeCriarPersonagem.aListaDeveApresentar5Personagens();
      }
    );
    opaTest(
      "Deve navegar de volta para a página Home",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDeCriarPersonagem.euPressionoBotaoVoltar();

        // Assertions
        Then.naPaginaHome
          .oTituloDaPaginaHomeDeveraSer()
          .and.aUrlDaPaginaHomeDeveraSer();

        // Cleanup
        Then.iTeardownMyApp();
      }
    );
  }
);
