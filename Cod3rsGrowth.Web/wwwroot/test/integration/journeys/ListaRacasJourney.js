sap.ui.define(
  [
    "sap/ui/test/opaQunit",
    "../pages/Home",
    "../pages/ListaRacas",
    "../pages/DetalhesRaca",
  ],
  function (opaTest) {
    "use strict";

    QUnit.module("Lista de Raças");

    opaTest(
      "Deve ser possível carregar mais itens da lista de raças",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "racas",
        });

        //Actions
        When.naPaginaDaListaDeRacas.euApertoParaCarregarMaisItensDaListaDeRacas();

        // Assertions
        Then.naPaginaDaListaDeRacas.aListaDeveApresentar10Racas();
      }
    );
    opaTest(
      "Deve filtrar de acordo com o nome da raça inserida no search field",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDaListaDeRacas.euPressionoBotaoReset();
        When.naPaginaDaListaDeRacas.euDigitoONomeDeUmaRacaNoSearchField("Elfo");

        // Assertions
        Then.naPaginaDaListaDeRacas.aListaDeveApresentarApenas1Raca();
      }
    );
    opaTest(
      "Deve apresentar todas as raças após pressionar em reset",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDaListaDeRacas.euPressionoBotaoReset();

        // Assertions
        Then.naPaginaDaListaDeRacas.aListaDeveApresentar5Racas();
      }
    );
    opaTest(
      "Deve apresentar uma lista vazia quando busco por uma raça inexistente",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDaListaDeRacas.euPressionoBotaoReset();
        When.naPaginaDaListaDeRacas.euDigitoONomeDeUmaRacaNoSearchField(
          "Humanoide"
        );

        // Assertions
        Then.naPaginaDaListaDeRacas.aListaDeveEstarVazia();

        // Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve selecionar uma raça e navegar até a página de detalhes",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "racas",
        });
        //Actions
        When.naPaginaDaListaDeRacas.euSelecionoUmaRacaNaLista("Humano");

        // Assertions
        Then.naPaginaDeDetalhesDaRaca.oTituloDaPaginaDetalhesDaRacaDeveraSer();
        Then.naPaginaDeDetalhesDaRaca.aUrlDaPaginaDeDetalhesDaRacaDeveraSer(1);
        Then.naPaginaDeDetalhesDaRaca.oNomeNosDetalhesDaRacaDeveraSer("Humano");

        // Cleanup
        Then.iTeardownMyApp();
      }
    );
  }
);
