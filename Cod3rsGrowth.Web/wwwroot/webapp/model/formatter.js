sap.ui.define([], () => {
  "use strict";

  const MODELO_I18N = "i18n";

  return {
    formatarBooleanVivoMorto(valorEstaExtinta) {
      const vivoMortoVerdadeiro = "trueVivoMorto";
      const vivoMortoFalso = "falseVivoMorto";
      const pacoteDeRecursos = this.getOwnerComponent()
        .getModel(MODELO_I18N)
        .getResourceBundle();
      switch (valorEstaExtinta) {
        case true:
          return pacoteDeRecursos.getText(vivoMortoVerdadeiro);
        case false:
          return pacoteDeRecursos.getText(vivoMortoFalso);
      }
    },
    formatarBooleanEstaExtinta(valorVivoOuMorto) {
      const estaExtintaVerdadeiro = "trueEstaExtinta";
      const estaExtintaFalso = "falseEstaExtinta";
      const pacoteDeRecursos = this.getOwnerComponent()
        .getModel(MODELO_I18N)
        .getResourceBundle();
      switch (valorVivoOuMorto) {
        case true:
          return pacoteDeRecursos.getText(estaExtintaVerdadeiro);
        case false:
          return pacoteDeRecursos.getText(estaExtintaFalso);
      }
    },
    formatarCorVivoMorto(valorVivoOuMorto) {
      const corVerdadeira = "trueColor";
      const corFalsa = "falseColor";
      const pacoteDeRecursos = this.getOwnerComponent()
        .getModel(MODELO_I18N)
        .getResourceBundle();
      switch (valorVivoOuMorto) {
        case true:
          return pacoteDeRecursos.getText(corVerdadeira);
        case false:
          return pacoteDeRecursos.getText(corFalsa);
      }
    },
    formatarDataDeCadastro(valorDaData) {
      const stringBarra = "/";
      const stringDataLocalPtBr = "pt-BR";
      const padStart = 2;
      const stringZero = "0";
      const ajusteMesJaneiro = 1; //+1 pois no getMonth Janeiro começa com zero.
      let dataFormatada = new Date(valorDaData);
      dataFormatada.toLocaleDateString(stringDataLocalPtBr);
      let dia = dataFormatada
        .getDate()
        .toString()
        .padStart(padStart, stringZero);
      let mes = (dataFormatada.getMonth() + ajusteMesJaneiro)
        .toString()
        .padStart(padStart, stringZero);
      let ano = dataFormatada.getFullYear();
      return dia + stringBarra + mes + stringBarra + ano;
    },
    formatarIconeListagem(raca) {
      switch (raca) {
        case "Humano":
          return "icons/icons8-humano-48.png";
        case "Elfo":
          return "icons/icons8-legolas-48.png";
        case "Ent":
          return "icons/icons8-ent-48.png";
        case "Anão":
          return "icons/icons8-anão-64.png";
        case "Dragão":
          return "icons/icons8-dragão-48.png";
        case "Maiar":
          return "icons/icons8-gandalf-48.png";
        case "Orc":
          return "icons/icons8-orc-48.png";
        case "Hobbit":
          return "icons/icons8-frodo-48.png";
        case "Troll":
          return "icons/icons8-troll-48.png";
        case "Ex-Hobbit":
          return "icons/icons8-gollum-48.png";
        default:
          return "icons/icons8-o-um-anel-48.png";
      }
    },
    formatarStatusExtintoNaLista(extinto) {
      if (!extinto) {
        return "Success";
      }
      return "Error";
    },
    formatarStatusCondicaoNaLista(vivo) {
      if (!vivo) {
        return "Error";
      }
      return "Success";
    },
    formatarCondicaoExtintaInicial(extinto){
      if(extinto){
        return 0;
      }
      return 1;
    }
  };
});
