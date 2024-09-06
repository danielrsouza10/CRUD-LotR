sap.ui.define(["sap/m/MessageBox"], function (MessageBox) {
  "use strict";
  this.errosDeValidacao = {};

  return {
    criarDialogoDeAviso: function (titulo, mensagem, controlador) {
      return new Promise((resolve, reject) => {
        MessageBox.warning(mensagem, {
          title: titulo,
          actions: [MessageBox.Action.YES, MessageBox.Action.NO],
          emphasizedAction: "YES",
          onClose: function (acao) {
            if (acao === "YES") {
              resolve(true);
            } else {
              resolve(false);
            }
          },
          dependentOn: controlador.getView(),
        });
      });
    },
    criarDialogoDeSucesso: function (mensagem, titulo, controlador) {
      MessageBox.show(mensagem, {
        icon: sap.m.MessageBox.Icon.SUCCESS,
        title: titulo,
        dependentOn: controlador.getView(),
      });
    },
    criarDialogoDeErro: function (
      titulo,
      detalhes,
      mensagemDeErro,
      controlador
    ) {
      MessageBox.error(mensagemDeErro, {
        title: titulo,
        details: detalhes,
        contentWidth: "400px",
        dependentOn: controlador.getView(),
      });
    },
  };
});
