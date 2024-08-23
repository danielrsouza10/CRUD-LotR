sap.ui.define(
  ["sap/ui/opaQunit", "../pages/DetalhesRaca", "../pages/ListaRacas"],
  function (opaTest) {
    "use strict";

    QUnit.module("Detalhes da Raça");

    opaTest(
      "Deve carregar a página corretamente",
      function (Given, When, Then) {
        //Arrangements
        Given.iStartMyApp({
          hash: "racas",
        });

        //Actions
        When.naPaginaDaListaDeRacas.euSelecionoUmaRacaNaLista();

        //Assertions
        Then.naPaginaDeDetalhesDaRaca.aTelaFoiCarregadaCorretamente();
        Then.naPaginaDeDetalhesDaRaca.oTituloDaPaginaDetalhesDaRacaDeveraSer();
        Then.naPaginaDeDetalhesDaRaca.oIdDaRacaNoDetalheCorrespondeAoIdDaRota();

        //Cleanup
        Then.iTeardownMyApp();
      }
    ),
      opaTest(
        "Deve carregar a página de notFound quando o ID da raça não existir",
        function (Given, When, Then) {
          //Arrangements
          Given.iStartMyApp({
            hash: "raca/0",
          });

          //Assertions
          Then.naPaginaDeNotFound.oTituloDaPaginaNotFoundDeveraSer();

          //Cleanup
          Then.iTeardownMyApp();
        }
      );
  }
);
