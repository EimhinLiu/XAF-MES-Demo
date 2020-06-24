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
    [XafDisplayName("设备点检方案")]
    [DefaultProperty("SchemeName")]
    public class EquipmentSpotCheckScheme : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public EquipmentSpotCheckScheme(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private string _SchemeName;
        private EquipmentCategory _EquipmentCategorys;
        private SchemeStatu _SchemeStatus;

        [XafDisplayName("方案名称")]
        [RuleRequiredField]
        public string SchemeName
        {
            get { return _SchemeName; }
            set { SetPropertyValue<string>(nameof(SchemeName), ref _SchemeName, value); }
        }

        [XafDisplayName("设备类别")]
        [RuleRequiredField]
        public EquipmentCategory EquipmentCategorys
        {
            get { return _EquipmentCategorys; }
            set { SetPropertyValue<EquipmentCategory>(nameof(EquipmentCategorys), ref _EquipmentCategorys, value); }
        }

        public enum SchemeStatu { 有效, 编制 }
        [XafDisplayName("方案状态")]
        public SchemeStatu SchemeStatus
        {
            get { return _SchemeStatus; }
            set { SetPropertyValue<SchemeStatu>(nameof(SchemeStatus), ref _SchemeStatus, value); }
        }

        [Association("EquipmentSpotCheckScheme-SchemeDetails")]
        public XPCollection<SchemeDetails> SchemeDetails
        {
            get { return GetCollection<SchemeDetails>(nameof(SchemeDetails)); }
        }
    }
}