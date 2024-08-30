sap.ui.define(
  [
    "sap/ui/test/opaQunit",
    "../pages/NotFound",
    "../pages/DetalhesRaca",
    "../pages/ListaRacas",
    "../pages/EditarRaca",
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
        Then.naPaginaDeDetalhesDaRaca
          .oTituloDaPaginaDetalhesDaRacaDeveraSer()
          .and.aUrlDaPaginaDeDetalhesDaRacaDeveraSer(1)
          .and.oIdNosDetalhesDaRacaDeveraSer("1")
          .and.oNomeNosDetalhesDaRacaDeveraSer("Humano")
          .and.aLocalizacaoGeograficaNosDetalhesDaRacaDeveraSer("???")
          .and.aHabilidadeRacialNosDetalhesDaRacaDeveraSer("???")
          .and.oEstaExtintaNosDetalhesDaRacaDeveraSer("Não")
          .and.aFormatacaoDoEstaExtintaDeveraSer("Success");

        //Cleanup
        Then.iTeardownMyApp();
      }
    );
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
    );
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
    opaTest(
      "Deve navegar até a página de edição da raça",
      function (Given, When, Then) {
        //Arrangements
        Given.iStartMyApp({
          hash: "raca/1",
        });

        //Actions
        When.naPaginaDeDetalhesDaRaca.euPressionoBotaoEditar();

        //Assertions
        Then.naPaginaDeEditarRaca
          .aTelaDeEdicaoFoiCarregadaCorretamente()
          .and.oBotaoEditarTemONomeCorreto()
          .and.osInputDeNomeDeveEstarPreenchido("Humano");

        //Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve pressionar o botao excluir para remover um registro pai com filhos",
      function (Given, When, Then) {
        //Arrangements
        Given.iStartMyApp({
          hash: "raca/1",
        });

        //Actions
        When.naPaginaDeDetalhesDaRaca.euPressionoBotaoRemover();

        //Assertions
        Then.naPaginaDeDetalhesDaRaca.deveAparecerUmaMessageBoxDeConfirmacao();
      }
    );
    opaTest(
      "Deve pressionar para confirmar a exclusao do registro pai com filhos e retornar um erro",
      function (Given, When, Then) {
        //Actions
        When.naPaginaDeDetalhesDaRaca.euPressionoSimParaConfirmarAEsclusao();

        //Assertions
        Then.naPaginaDeDetalhesDaRaca.deveAparecerUmaMessageBoxDeErroDeRegistroDeDependentes();

        //Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest("Deve existir uma lista na pagina", function (Given, When, Then) {
      //Arrangements
      Given.iStartMyApp({
        hash: "raca/10",
      });

      //Assertions
      Then.naPaginaDeDetalhesDaRaca.deveExistirUmaListaNaPagina();

      //Cleanup
      Then.iTeardownMyApp();
    });
    opaTest(
      "Deve conter uma lista dos registros filhos associados ao registro pai atual",
      function (Given, When, Then) {
        //Arrangements
        Given.iStartMyApp({
          hash: "raca/2",
        });

        //Assertions
        Then.naPaginaDeDetalhesDaRaca
          .deveExistirUmaListaNaPagina()
          .and.deveConterUmaListaComRegistrosFilhosNaPagina();

        //Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve pressionar o botao adicionar registro filho e carregar o modal de criação",
      function (Given, When, Then) {
        //Arrangements
        Given.iStartMyApp({
          hash: "raca/2",
        });

        //Actions
        When.naPaginaDeDetalhesDaRaca.euPressionoOBotaoAdicionarPersonagem();

        //Assertions
        Then.naPaginaDeDetalhesDaRaca.deveAparecerOModalDeCriacaoDePersonagem();

        //Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve tentar criar um personagem com nome ja existente e retornar um erro do servidor",
      function (Given, When, Then) {
        //Arrangements
        Given.iStartMyApp({
          hash: "raca/2",
        });
        //Actions
        When.naPaginaDeDetalhesDaRaca
          .euPressionoOBotaoAdicionarPersonagem()
          .and.euDigitoUmNomeNoInputField("Aragorn")
          .and.euSelecionoUmaProfissao("7")
          .and.euDigitoUmaIdadeNoInputField("98")
          .and.euDigitoUmaAlturaNoInputField("1.97")
          .and.euSelecionoCondicaoMorto()
          .and.euPressionoOBotaoAdicionar();

        //Assertions
        Then.naPaginaDeDetalhesDaRaca.deveAparecerUmaMessageBoxDeErroVindoDoServidor();

        //Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve tentar criar um personagem com nome invalido e retornar um erro de validação",
      function (Given, When, Then) {
        //Arrangements
        Given.iStartMyApp({
          hash: "raca/3",
        });
        //Actions
        When.naPaginaDeDetalhesDaRaca
          .euPressionoOBotaoAdicionarPersonagem()
          .and.euDigitoUmNomeNoInputField("Gi")
          .and.euSelecionoUmaProfissao("5")
          .and.euDigitoUmaIdadeNoInputField("1000")
          .and.euDigitoUmaAlturaNoInputField("1.97")
          .and.euSelecionoCondicaoMorto()
          .and.euSelecionoCondicaoVivo()
          .and.euPressionoOBotaoAdicionar();

        //Assertions
        Then.naPaginaDeDetalhesDaRaca.deveAparecerUmaMessageBoxDeErro();

        //Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve tentar criar um personagem com todos os inputs invalidos e retornar um erro de validação",
      function (Given, When, Then) {
        //Arrangements
        Given.iStartMyApp({
          hash: "raca/5",
        });
        //Actions
        When.naPaginaDeDetalhesDaRaca
          .euPressionoOBotaoAdicionarPersonagem()
          .and.euDigitoUmNomeNoInputField("O*")
          .and.euSelecionoUmaProfissao("5")
          .and.euDigitoUmaIdadeNoInputField("-990")
          .and.euDigitoUmaAlturaNoInputField("-1.97")
          .and.euSelecionoCondicaoMorto()
          .and.euSelecionoCondicaoVivo()
          .and.euPressionoOBotaoAdicionar();

        //Assertions
        Then.naPaginaDeDetalhesDaRaca.deveAparecerUmaMessageBoxDeErro();

        //Cleanup
        Then.iTeardownMyApp();
      }
    );
    opaTest(
      "Deve retornar a pagina de detalhes da raça quando pressiono o botao cancelar",
      function (Given, When, Then) {
        //Arrangements
        Given.iStartMyApp({
          hash: "raca/9",
        });
        //Actions
        When.naPaginaDeDetalhesDaRaca
          .euPressionoOBotaoAdicionarPersonagem()
          .and.euPressionoOBotaoCancelar();

        // Assertions
        Then.naPaginaDeDetalhesDaRaca.oTituloDaPaginaDetalhesDaRacaDeveraSer();
        // Cleanup
        Then.iTeardownMyApp();
      }
    );
  }
);
