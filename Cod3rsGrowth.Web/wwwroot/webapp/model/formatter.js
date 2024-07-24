sap.ui.define([], () => {
  "use strict";

  return {
    formatarBooleanVivoMorto(valorEstaExtinta) {
      const pacoteDeRecursos = this.getOwnerComponent()
        .getModel("i18n")
        .getResourceBundle();
      switch (valorEstaExtinta) {
        case true:
          return pacoteDeRecursos.getText("trueVivoMorto");
        case false:
          return pacoteDeRecursos.getText("falseVivoMorto");
      }
    },
    formatarBooleanEstaExtinta(valorVivoOuMorto) {
      const pacoteDeRecursos = this.getOwnerComponent()
        .getModel("i18n")
        .getResourceBundle();
      switch (valorVivoOuMorto) {
        case true:
          return pacoteDeRecursos.getText("trueEstaExtinta");
        case false:
          return pacoteDeRecursos.getText("falseEstaExtinta");
      }
    },
    formatarCorVivoMorto(valorVivoOuMorto) {
      const pacoteDeRecursos = this.getOwnerComponent()
        .getModel("i18n")
        .getResourceBundle();
      switch (valorVivoOuMorto) {
        case true:
          return pacoteDeRecursos.getText("trueColor");
        case false:
          return pacoteDeRecursos.getText("falseColor");
      }
    },
    formatarDataDeCadastro(valorDaData) {
      let dataFormatada = new Date(valorDaData);
      dataFormatada.toLocaleDateString("pt-BR");
      let dia = dataFormatada.getDate().toString().padStart(2, "0");
      let mes = (dataFormatada.getMonth() + 1).toString().padStart(2, "0"); //+1 pois no getMonth Janeiro começa com zero.
      let ano = dataFormatada.getFullYear();
      return dia + "/" + mes + "/" + ano;
    },
  };
});
