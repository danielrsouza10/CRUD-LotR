sap.ui.define(
  [
    "sap/ui/test/opaQunit",
    "../pages/CriarRaca",
    "../pages/ListaRacas",
    "../pages/Home",
  ],
  function (opaTest) {
    "use strict";

    QUnit.module("Criar Raça");

    opaTest(
      "Deve retornar um erro ao adicionar um raça com o nome já cadastrado",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "raca/criarRaca",
        });

        //Actions
        When.naPaginaDeCriarRaca.euDigitoUmNomeNoInputField("Humano");
        When.naPaginaDeCriarRaca.euDigitoUmaLocalizacaoGeograficaNoInputField(
          "???"
        );
        When.naPaginaDeCriarRaca.euDigitoUmaHabilidadeRacialNoInputField("???");
        When.naPaginaDeCriarRaca.euSelecionoCondicaoNaoExtinta();
        When.naPaginaDeCriarRaca.euPressionoOBotaoAdicionar();

        // Assertions
        Then.naPaginaDeCriarRaca.deveAparecerUmaMessageBoxDeErroVindoDoServidor();
        // Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve retornar um erro ao adicionar um raça sem preencher nenhum input field",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "raca/criarRaca",
        });
        //Actions
        When.naPaginaDeCriarRaca.euPressionoOBotaoAdicionar();

        // Assertions
        Then.naPaginaDeCriarRaca.deveAparecerUmaMessageBoxDeErro();
        // Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve retornar um erro ao adicionar um raça com o nome menor que 3 caracteres",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "raca/criarRaca",
        });
        //Actions
        When.naPaginaDeCriarRaca.euDigitoUmNomeNoInputField("Al");
        When.naPaginaDeCriarRaca.euDigitoUmaLocalizacaoGeograficaNoInputField(
          "???"
        );
        When.naPaginaDeCriarRaca.euDigitoUmaHabilidadeRacialNoInputField("???");
        When.naPaginaDeCriarRaca.euSelecionoCondicaoNaoExtinta();
        When.naPaginaDeCriarRaca.euPressionoOBotaoAdicionar();

        // Assertions
        Then.naPaginaDeCriarRaca.deveAparecerUmaMessageBoxDeErro();
        // Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve retornar um erro ao adicionar um raça com o nome com caracteres invalidos",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "raca/criarRaca",
        });
        //Actions
        When.naPaginaDeCriarRaca.euDigitoUmNomeNoInputField("****");
        When.naPaginaDeCriarRaca.euDigitoUmaLocalizacaoGeograficaNoInputField(
          "???"
        );
        When.naPaginaDeCriarRaca.euDigitoUmaHabilidadeRacialNoInputField("???");
        When.naPaginaDeCriarRaca.euSelecionoCondicaoNaoExtinta();
        When.naPaginaDeCriarRaca.euSelecionoCondicaoExinta();
        When.naPaginaDeCriarRaca.euPressionoOBotaoAdicionar();

        // Assertions
        Then.naPaginaDeCriarRaca.deveAparecerUmaMessageBoxDeErro();
        // Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve retornar a pagina de listagem de raças quando pressiono o botao cancelar",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "raca/criarRaca",
        });
        //Actions
        When.naPaginaDeCriarRaca.euPressionoOBotaoCancelar();

        // Assertions
        Then.naPaginaDaListaDeRacas
          .oTituloDaPaginaDeRacasDeveraSer()
          .and.aUrlDaPaginaDeRacasDeveraSer();
        // Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve retornar a pagina anterior quando pressiono o botao de voltar",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "raca/criarRaca",
        });
        //Actions
        When.naPaginaDeCriarRaca.euPressionoBotaoVoltar();

        // Assertions
        Then.naPaginaDaListaDeRacas
          .oTituloDaPaginaDeRacasDeveraSer()
          .and.aUrlDaPaginaDeRacasDeveraSer();
        // Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve retornar um erro ao adicionar um raça com poucos caracteres e caracteres inválidos",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "raca/criarRaca",
        });
        //Actions
        When.naPaginaDeCriarRaca.euDigitoUmNomeNoInputField("D*");
        When.naPaginaDeCriarRaca.euDigitoUmaLocalizacaoGeograficaNoInputField(
          "???"
        );
        When.naPaginaDeCriarRaca.euDigitoUmaHabilidadeRacialNoInputField("???");
        When.naPaginaDeCriarRaca.euSelecionoCondicaoNaoExtinta();
        When.naPaginaDeCriarRaca.euPressionoOBotaoAdicionar();

        // Assertions
        Then.naPaginaDeCriarRaca.deveAparecerUmaMessageBoxDeErro();

        // Cleanup
        Then.iTeardownMyApp();
      }
    );
  }
);
