using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XafDisableEnableFunctionality.Module.BusinessObjects;

namespace XafDisableEnableFunctionality.Module.Controllers
{
    //HACK how to show a singleton https://docs.devexpress.com/eXpressAppFramework/112916/ui-construction/views/ways-to-show-a-view/how-to-implement-a-singleton-business-object-and-show-its-detail-view
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppWindowControllertopic.aspx.
    public partial class LicensingController : WindowController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public LicensingController()
        {
            InitializeComponent();


            // Target required Windows (via the TargetXXX properties) and create their Actions.
            this.TargetWindowType = WindowType.Main;
            PopupWindowShowAction showSingletonAction =
                new PopupWindowShowAction(this, "Licensing", PredefinedCategory.View);
            showSingletonAction.CustomizePopupWindowParams += showSingletonAction_CustomizePopupWindowParams;
          


        }

  

      
        private void showSingletonAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(License));
            DetailView detailView = Application.CreateDetailView(objectSpace, objectSpace.GetObjects<License>()[0]);
            detailView.ViewEditMode = ViewEditMode.Edit;
            e.DialogController.SaveOnAccept=true;
            e.View = detailView;

        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target Window.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
