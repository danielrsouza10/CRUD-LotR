sap.ui.define(
  [
    "sap/ui/test/opaQunit",
    "../pages/EditarRaca",
    "../pages/ListaRacas",
    "../pages/Home",
  ],
  function (opaTest) {
    "use strict";

    QUnit.module("Editar Raça");

    opaTest(
      "Deve retornar um erro ao editar um raça com o nome já cadastrado em outra raça",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "raca/editarRaca/1",
        });

        //Actions
        When.naPaginaDeEditarRaca.aTelaFoiCarregadaCorretamente();
        When.naPaginaDeEditarRaca.euDigitoUmNomeNoInputField("Elfo");
        When.naPaginaDeEditarRaca.euDigitoUmaLocalizacaoGeograficaNoInputField(
          "???"
        );
        When.naPaginaDeEditarRaca.euDigitoUmaHabilidadeRacialNoInputField(
          "???"
        );
        When.naPaginaDeEditarRaca.euSelecionoCondicaoNaoExtinta();
        When.naPaginaDeEditarRaca.euPressionoOBotaoEditar();

        // Assertions
        Then.naPaginaDeEditarRaca.deveAparecerUmaMessageBoxDeErroVindoDoServidor();
        // Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve retornar um erro ao editar um raça sem preencher nenhum input field",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "raca/editarRaca/1",
        });
        //Actions
        When.naPaginaDeEditarRaca.aTelaFoiCarregadaCorretamente();
        When.naPaginaDeEditarRaca.euDigitoUmNomeNoInputField("");
        When.naPaginaDeEditarRaca.euDigitoUmaLocalizacaoGeograficaNoInputField(
          ""
        );
        When.naPaginaDeEditarRaca.euDigitoUmaHabilidadeRacialNoInputField("");
        When.naPaginaDeEditarRaca.euPressionoOBotaoEditar();

        // Assertions
        Then.naPaginaDeEditarRaca.deveAparecerUmaMessageBoxDeErro();
        // Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve retornar um erro ao editar um raça com o nome menor que 3 caracteres",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "raca/editarRaca/1",
        });
        //Actions
        When.naPaginaDeEditarRaca.aTelaFoiCarregadaCorretamente();
        When.naPaginaDeEditarRaca.euDigitoUmNomeNoInputField("Al");
        When.naPaginaDeEditarRaca.euDigitoUmaLocalizacaoGeograficaNoInputField(
          "???"
        );
        When.naPaginaDeEditarRaca.euDigitoUmaHabilidadeRacialNoInputField(
          "???"
        );
        When.naPaginaDeEditarRaca.euSelecionoCondicaoNaoExtinta();
        When.naPaginaDeEditarRaca.euPressionoOBotaoEditar();

        // Assertions
        Then.naPaginaDeEditarRaca.deveAparecerUmaMessageBoxDeErro();
        // Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve retornar um erro ao editar um raça com o nome com caracteres invalidos",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "raca/editarRaca/1",
        });
        //Actions
        When.naPaginaDeEditarRaca.aTelaFoiCarregadaCorretamente();
        When.naPaginaDeEditarRaca.euDigitoUmNomeNoInputField("****");
        When.naPaginaDeEditarRaca.euDigitoUmaLocalizacaoGeograficaNoInputField(
          "???"
        );
        When.naPaginaDeEditarRaca.euDigitoUmaHabilidadeRacialNoInputField(
          "???"
        );
        When.naPaginaDeEditarRaca.euSelecionoCondicaoNaoExtinta();
        When.naPaginaDeEditarRaca.euSelecionoCondicaoExinta();
        When.naPaginaDeEditarRaca.euPressionoOBotaoEditar();

        // Assertions
        Then.naPaginaDeEditarRaca.deveAparecerUmaMessageBoxDeErro();
        // Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve retornar a pagina de listagem de raças quando pressiono o botao cancelar",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "raca/editarRaca/1",
        });
        //Actions
        When.naPaginaDeEditarRaca.aTelaFoiCarregadaCorretamente();
        When.naPaginaDeEditarRaca.euPressionoOBotaoCancelar();

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
          hash: "raca/editarRaca/1",
        });
        //Actions
        When.naPaginaDeEditarRaca.aTelaFoiCarregadaCorretamente();
        When.naPaginaDeEditarRaca.euPressionoBotaoVoltar();

        // Assertions
        Then.naPaginaDaListaDeRacas
          .oTituloDaPaginaDeRacasDeveraSer()
          .and.aUrlDaPaginaDeRacasDeveraSer();
        // Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve retornar um erro ao editar um raça com poucos caracteres e caracteres inválidos",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "raca/editarRaca/1",
        });
        //Actions
        When.naPaginaDeEditarRaca.aTelaFoiCarregadaCorretamente();
        When.naPaginaDeEditarRaca.euDigitoUmNomeNoInputField("D*");
        When.naPaginaDeEditarRaca.euDigitoUmaLocalizacaoGeograficaNoInputField(
          "???"
        );
        When.naPaginaDeEditarRaca.euDigitoUmaHabilidadeRacialNoInputField(
          "???"
        );
        When.naPaginaDeEditarRaca.euSelecionoCondicaoNaoExtinta();
        When.naPaginaDeEditarRaca.euPressionoOBotaoEditar();

        // Assertions
        Then.naPaginaDeEditarRaca.deveAparecerUmaMessageBoxDeErro();

        // Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve retornar uma mensagem de sucesso ao editar um raça com o nome com caracteres validos",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "raca/editarRaca/10",
        });
        //Actions
        When.naPaginaDeEditarRaca.aTelaFoiCarregadaCorretamente();
        When.naPaginaDeEditarRaca.euDigitoUmNomeNoInputField("Dragaos");
        When.naPaginaDeEditarRaca.euSelecionoCondicaoNaoExtinta();
        When.naPaginaDeEditarRaca.euSelecionoCondicaoExinta();
        When.naPaginaDeEditarRaca.euPressionoOBotaoEditar();

        // Assertions
        Then.naPaginaDeEditarRaca.deveAparecerUmaMessageBoxDeSucesso();
        // Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve retornar uma mensagem de sucesso ao editar um raça com o nome anterior dela",
      function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
          hash: "raca/editarRaca/10",
        });
        //Actions
        When.naPaginaDeEditarRaca.aTelaFoiCarregadaCorretamente();
        When.naPaginaDeEditarRaca.euDigitoUmNomeNoInputField("Dragão");
        When.naPaginaDeEditarRaca.euPressionoOBotaoEditar();

        // Assertions
        Then.naPaginaDeEditarRaca.deveAparecerUmaMessageBoxDeSucesso();
        // Cleanup
        Then.iTeardownMyApp();
      }
    );
  }
);
