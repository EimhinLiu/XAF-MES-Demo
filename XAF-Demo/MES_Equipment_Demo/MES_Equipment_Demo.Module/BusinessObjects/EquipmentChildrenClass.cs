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
    [XafDisplayName("设备子类")]
    [DefaultProperty("ChildrenClass")]
    public class EquipmentChildrenClass : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public EquipmentChildrenClass(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private string _ChildrenClass;
        private string _Creater;
        private DateTime _CreateTime;
        private int _No;

        [XafDisplayName("子类")]
        [RuleRequiredField]
        public string ChildrenClass
        {
            get { return _ChildrenClass; }
            set { SetPropertyValue<string>(nameof(ChildrenClass), ref _ChildrenClass, value); }
        }

        [XafDisplayName("创建人")]
        public string Creater
        {
            get { return _Creater; }
            set { SetPropertyValue<string>(nameof(Creater), ref _Creater, value); }
        }

        [XafDisplayName("创建时间")]
        public DateTime CreateTime
        {
            get { return _CreateTime; }
            set { SetPropertyValue<DateTime>(nameof(CreateTime), ref _CreateTime, value); }
        }

        [XafDisplayName("排序序号")]
        public int No
        {
            get { return _No; }
            set { SetPropertyValue<int>(nameof(No), ref _No, value); }
        }
    }
}