using DevExpress.Xpo;
using System;
using System.Linq;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp;

namespace XafDisableEnableFunctionality.Module.BusinessObjects
{



    //HACK licensing tutorial from devexpress
    //https://docs.devexpress.com/eXpressAppFramework/112916/ui-construction/views/ways-to-show-a-view/how-to-implement-a-singleton-business-object-and-show-its-detail-view


    [RuleObjectExists("AnotherSingletonExists", DefaultContexts.Save, "True", InvertResult = true,
        CustomMessageTemplate = "Another Lincense already exists.")]
    [RuleCriteria("CannotDeleteSingleton", DefaultContexts.Delete, "False",
        CustomMessageTemplate = "Cannot delete Lincense.")]
    public class License : BaseObject
    {
        public License(Session session) : base(session) { }

        FileData licenseFile;

        public FileData LicenseFile
        {
            get => licenseFile;
            set => SetPropertyValue(nameof(LicenseFile), ref licenseFile, value);
        }
      
    }
}
