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
  };
});
