using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace MES_Equipment_Demo.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("设备保养方案")]
    [DefaultProperty("PlanName")]
    public class EquipmentMaintenancePlan : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public EquipmentMaintenancePlan(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private string _PlanName;
        private EquipmentCategory _EquipmentCategorys;
        private MaintenanceCycle _MaintenanceCycles;
        private MaintenanceLevel _MaintenanceLevels;
        private SchemeStatu _SchemeStatus;

        [XafDisplayName("方案名称")]
        [RuleRequiredField]
        public string PlanName
        {
            get { return _PlanName; }
            set { SetPropertyValue<string>(nameof(PlanName), ref _PlanName, value); }
        }

        [XafDisplayName("设备类别")]
        [RuleRequiredField]
        public EquipmentCategory EquipmentCategorys
        {
            get { return _EquipmentCategorys; }
            set { SetPropertyValue<EquipmentCategory>(nameof(EquipmentCategorys), ref _EquipmentCategorys, value); }
        }

        public enum MaintenanceCycle { 每周保养,月度保养,季度保养,年度保养 }
        [XafDisplayName("保养周期")]
        public MaintenanceCycle MaintenanceCycles
        {
            get { return _MaintenanceCycles; }
            set { SetPropertyValue<MaintenanceCycle>(nameof(MaintenanceCycles), ref _MaintenanceCycles, value); }
        }

        public enum MaintenanceLevel { 一级,二级,三级,四级,五级 }
        [XafDisplayName("保养级别")]
        public MaintenanceLevel MaintenanceLevels
        {
            get { return _MaintenanceLevels; }
            set { SetPropertyValue<MaintenanceLevel>(nameof(MaintenanceLevels), ref _MaintenanceLevels, value); }
        }

        public enum SchemeStatu { 有效, 编制 }
        [XafDisplayName("方案状态")]
        public SchemeStatu SchemeStatus
        {
            get { return _SchemeStatus; }
            set { SetPropertyValue<SchemeStatu>(nameof(SchemeStatus), ref _SchemeStatus, value); }
        }

        [Association("EquipmentMaintenancePlan-SchemeDetails")]
        public XPCollection<SchemeDetails> SchemeDetails
        {
            get { return GetCollection<SchemeDetails>(nameof(SchemeDetails)); }
        }

    }
}