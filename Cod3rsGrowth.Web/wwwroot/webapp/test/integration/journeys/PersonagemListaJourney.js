sap.ui.define(
  ["sap/ui/test/opaQunit", "../pages/Home", "../pages/PersonagemLista"],
  function (opaTest) {
    "use strict";

    QUnit.module("Personagens");

    opaTest(
      "Deve ser possível carregar mais itens da lista de personagens",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp();

        //Actions
        When.naPaginaHome.euApertoOBotaoDePersonagens();
        When.naPaginaDaListaDePersonagens.euApertoParaCarregarMaisItensDaListaDePersonagens();

        // Assertions
        Then.naPaginaDaListaDePersonagens.aListaDeveApresentar10Personagens();
      }
    );
    opaTest(
      "Deve filtrar de acordo com o nome do personagem inserido no search field",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDaListaDePersonagens.euDigitoONomeDeUmPersonagemNoSearchField(
          "Aragorn"
        );

        // Assertions
        Then.naPaginaDaListaDePersonagens.aListaDeveApresentarApenas1Personagem();
      }
    );
    opaTest(
      "Deve apresentar todos os personagens após pressionar em reset",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDaListaDePersonagens.euPressionoBotaoReset();

        // Assertions
        Then.naPaginaDaListaDePersonagens.aListaDeveApresentar5Personagens();
      }
    );
    opaTest(
      "Deve apresentar somente um personagem ao filtrar por nome e profissao",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDaListaDePersonagens.euDigitoONomeDeUmPersonagemNoSearchField(
          "Aragorn"
        );
        When.naPaginaDaListaDePersonagens.euPressionoBotaoFiltro();
        When.naPaginaDaListaDePersonagens.euSelecionoUmaProfissao();
        When.naPaginaDaListaDePersonagens.euPressionoBotaoOk();

        // Assertions
        Then.naPaginaDaListaDePersonagens.aListaDeveApresentarApenas1Personagem();
      }
    );
    opaTest(
      "Deve apresentar uma lista vazia ao filtrar por nome e raça",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDaListaDePersonagens.euPressionoBotaoFiltro();
        When.naPaginaDaListaDePersonagens.euSelecionoUmaRaca();
        When.naPaginaDaListaDePersonagens.euPressionoBotaoOk();

        // Assertions
        Then.naPaginaDaListaDePersonagens.aListaDeveEstarVazia();
      }
    );
    opaTest(
      "Deve resetar a lista e filtrar por data",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDaListaDePersonagens.euPressionoBotaoReset();
        When.naPaginaDaListaDePersonagens.euPressionoBotaoFiltro();
        When.naPaginaDaListaDePersonagens.euSelecionoUmaDataInicial(
          "2012-05-05"
        );
        When.naPaginaDaListaDePersonagens.euSelecionoUmaDataFinal("2013-05-05");
        When.naPaginaDaListaDePersonagens.euPressionoBotaoOk();

        // Assertions
        Then.naPaginaDaListaDePersonagens.aListaDeveApresentarApenas1Personagem();
      }
    );
    opaTest(
      "Deve resetar a lista e filtrar por vivo",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDaListaDePersonagens.euPressionoBotaoReset();
        When.naPaginaDaListaDePersonagens.euPressionoBotaoFiltro();
        When.naPaginaDaListaDePersonagens.euDouCheckEmVivo();
        When.naPaginaDaListaDePersonagens.euPressionoBotaoOk();

        // Assertions
        Then.naPaginaDaListaDePersonagens.aListaDeveApresentar5Personagens();
      }
    );
    opaTest(
      "Deve resetar a lista e filtrar por morto",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDaListaDePersonagens.euPressionoBotaoReset();
        When.naPaginaDaListaDePersonagens.euPressionoBotaoFiltro();
        When.naPaginaDaListaDePersonagens.euDouCheckEmMorto();
        When.naPaginaDaListaDePersonagens.euPressionoBotaoOk();

        // Assertions
        Then.naPaginaDaListaDePersonagens.aListaDeveApresentar5Personagens();
      }
    );
    opaTest(
      "Deve navegar de volta para a página Home",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDaListaDePersonagens.euPressionoBotaoVoltar();

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
