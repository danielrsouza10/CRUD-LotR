sap.ui.define(
  [
    "sap/ui/test/opaQunit",
    "../pages/NotFound",
    "../pages/DetalhesRaca",
    "../pages/ListaRacas",
    "../pages/Home",
  ],
  function (opaTest) {
    "use strict";

    QUnit.module("Detalhes da Raça");

    opaTest(
      "Deve carregar a página da raça de id 1 corretamente",
      function (Given, When, Then) {
        //Arrangements
        Given.iStartMyApp({
          hash: "raca/1",
        });

        //Assertions
        Then.naPaginaDeDetalhesDaRaca.oTituloDaPaginaDetalhesDaRacaDeveraSer();
        Then.naPaginaDeDetalhesDaRaca.aUrlDaPaginaDeDetalhesDaRacaDeveraSer(1);

        //Cleanup
        Then.iTeardownMyApp();
      }
    ),
      opaTest(
        "Deve carregar a página de notFound quando o ID da raça não existir",
        function (Given, When, Then) {
          //Arrangements;
          Given.iStartMyApp({
            hash: "raca/0",
          });

          //Assertions;
          Then.naPaginaDeNotFound.oTituloDaPaginaNotFoundDeveraSer();

          //Cleanup;
          Then.iTeardownMyApp();
        }
      ),
      opaTest(
        "Deve navegar para a págima home ao pressionar o botão voltar",
        function (Given, When, Then) {
          //Arrangements
          Given.iStartMyApp({
            hash: "raca/1",
          });

          //Actions
          When.naPaginaDeDetalhesDaRaca.euPressionoBotaoVoltar();

          //Assertions
          Then.naPaginaHome
            .oTituloDaPaginaHomeDeveraSer()
            .and.aUrlDaPaginaHomeDeveraSer();

          //Cleanup
          Then.iTeardownMyApp();
        }
      );
  }
);
