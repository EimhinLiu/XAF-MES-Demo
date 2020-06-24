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
    [XafDisplayName("设备类别")]
    [DefaultProperty("Type")]
    public class EquipmentCategory : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public EquipmentCategory(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private string _Type;
        private int _No;

        [XafDisplayName("类别")]
        [RuleRequiredField]
        public string Type
        {
            get { return _Type; }
            set { SetPropertyValue<string>(nameof(Type), ref _Type, value); }
        }

        [XafDisplayName("排序序号")]
        public int No
        {
            get { return _No; }
            set { SetPropertyValue<int>(nameof(No), ref _No, value); }
        }
    }
}