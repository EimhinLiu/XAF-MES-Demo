using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using System.Linq;

namespace MES_Equipment_Demo.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("部门设置")]
    [DefaultProperty("OrganizationName")]
    public class DepartmentSetting : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public DepartmentSetting(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private string _OrganizationName;
        private string _OrganizationCodeName;
        private string _ShortName;

        [XafDisplayName("组织名称")]
        [RuleRequiredField]
        public string OrganizationName
        {
            get { return _OrganizationName; }
            set { SetPropertyValue<string>(nameof(OrganizationName), ref _OrganizationName, value); }
        }

        [XafDisplayName("组织代码")]
        public string OrganizationCodeName
        {
            get { return _OrganizationCodeName; }
            set { SetPropertyValue<string>(nameof(OrganizationCodeName), ref _OrganizationCodeName, value); }
        }

        [XafDisplayName("简称")]
        public string ShortName
        {
            get { return _ShortName; }
            set { SetPropertyValue<string>(nameof(ShortName), ref _ShortName, value); }
        }
    }
}