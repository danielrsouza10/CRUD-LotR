sap.ui.define([], () => {
  "use strict";

  return {
    descricaoDaProfissao(valorProfissao) {
      const pacoteDeRecursos = this.getOwnerComponent()
        .getModel("i18n")
        .getResourceBundle();
      switch (valorProfissao) {
        case 0:
          return pacoteDeRecursos.getText("profissao0");
        case 1:
          return pacoteDeRecursos.getText("profissao1");
        case 2:
          return pacoteDeRecursos.getText("profissao2");
        case 3:
          return pacoteDeRecursos.getText("profissao3");
        case 4:
          return pacoteDeRecursos.getText("profissao4");
        case 5:
          return pacoteDeRecursos.getText("profissao5");
        case 6:
          return pacoteDeRecursos.getText("profissao6");
        case 7:
          return pacoteDeRecursos.getText("profissao7");
        case 8:
          return pacoteDeRecursos.getText("profissao8");
        case 9:
          return pacoteDeRecursos.getText("profissao9");
        case 10:
          return pacoteDeRecursos.getText("profissao10");
        case 11:
          return pacoteDeRecursos.getText("profissao11");
        case 12:
          return pacoteDeRecursos.getText("profissao12");
        case 13:
          return pacoteDeRecursos.getText("profissao13");
        case 14:
          return pacoteDeRecursos.getText("profissao14");
        case 15:
          return pacoteDeRecursos.getText("profissao15");
        default:
          return valorProfissao;
      }
    },
    formatarBooleanVivoMorto(valorVivoOuMorto) {
      const pacoteDeRecursos = this.getOwnerComponent()
        .getModel("i18n")
        .getResourceBundle();
      switch (valorVivoOuMorto) {
        case true:
          return pacoteDeRecursos.getText("true");
        case false:
          return pacoteDeRecursos.getText("false");
      }
    },
  };
});
