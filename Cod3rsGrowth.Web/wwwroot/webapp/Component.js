sap.ui.define(
  ["sap/ui/core/UIComponent", "sap/ui/model/resource/ResourceModel"],
  (UIComponent, ResourceModel) => {
    "use strict";

    return UIComponent.extend("ui5.o_senhor_dos_aneis.Component", {
      metadata: {
        interfaces: ["sap.ui.core.IAsyncContentCreation"],
        manifest: "json",
      },
      init() {
        // call the init function of the parent
        UIComponent.prototype.init.apply(this, arguments);

        // set i18n model on view
        const i18nModel = new ResourceModel({
          bundleName: "ui5.o_senhor_dos_aneis.i18n.i18n",
        });
        this.setModel(i18nModel, "i18n");

        // create the views based on the url/hash
        this.getRouter().initialize();
      },
    });
  }
);
