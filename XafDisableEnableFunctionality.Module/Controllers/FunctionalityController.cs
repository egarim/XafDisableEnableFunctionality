using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Core;
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
using System.IO;
using System.Linq;
using System.Text;
using XafDisableEnableFunctionality.Module.BusinessObjects;

namespace XafDisableEnableFunctionality.Module.Controllers
{
    public static class Extensions
    {

        public static void EnableDisable(this ActionList Actions,string Reason,bool Enable)
        {
            foreach (ActionBase actionBase in Actions)
            {
                actionBase.Enabled[Reason]=Enable;
            }
        }
        public static byte[] GetLicenseObject(this IObjectSpace ObjectSpace)
        {
            License license = ObjectSpace.GetObjectsQuery<License>().FirstOrDefault();
            if (license != null)
            {
                MemoryStream stream = new MemoryStream();
                license.LicenseFile.SaveToStream(stream);
                return stream.ToArray();
            }
            return new byte[0];
        }

    }
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class FunctionalityController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public FunctionalityController()
        {
            InitializeComponent();
           
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            var Licensie = this.ObjectSpace.GetLicenseObject();
            if (Licensie.Length >0)
            {
                EnableDisableFunctionality("Licensing", true);
            }
            else
            {
                EnableDisableFunctionality("Licensing", false);
            }
          
            // Perform various tasks depending on the target View.
        }

        private void EnableDisableFunctionality(string reason, bool enable)
        {
            this.Frame.GetController<ModificationsController>()?.Actions.EnableDisable(reason, enable);
            this.Frame.GetController<NewObjectViewController>()?.Actions.EnableDisable(reason, enable);
            this.Frame.GetController<DeleteObjectsViewController>()?.Actions.EnableDisable(reason, enable);
            this.Frame.GetController<LinkUnlinkController>()?.Actions.EnableDisable(reason, enable);
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
