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
    [XafDisplayName("设备维修查询")]
    public class EquipmentRepairQuery : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public EquipmentRepairQuery(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private string _ListNo;
        private ListStatu _ListStatus;
        private EquipmentFileMaintenance _EquipmentFileMaintenances;
        private string _EquipmentNo;
        private EquipmentCategory _EquipmentCategorys;
        private string _EquipmentName;
        private string _EquipmentType;
        private EquipmentStatu _EquipmentStatus;
        private string _Manufacturer;
        private EquipmentChildrenClass _EquipmentChildrenClasses;
        private bool _CNCEquipment;
        private bool _SpotCheck;
        private DepartmentSetting _DepartmentSettings;
        private string _FaultDescription;
        private RepairSource _RepairSources;
        private SystemUser _SystemUsers1;
        private DateTime _ApplicationTime;
        private SystemUser _SystemUsers2;
        private DateTime _MaintenanceTime;
        private string _MaintenanceContent;
        private decimal _MaintenanceCosts;
        private string _remarks;

        [XafDisplayName("单据编号")]
        public string ListNo
        {
            get { return _ListNo; }
            set { SetPropertyValue<string>(nameof(ListNo), ref _ListNo, value); }
        }

        public enum ListStatu { 有效, 编制 }
        [XafDisplayName("单据状态")]
        public ListStatu ListStatus
        {
            get { return _ListStatus; }
            set { SetPropertyValue<ListStatu>(nameof(ListStatus), ref _ListStatus, value); }
        }

        [XafDisplayName("设备")]
        [RuleRequiredField]
        public EquipmentFileMaintenance EquipmentFileMaintenances
        {
            get { return _EquipmentFileMaintenances; }
            set { SetPropertyValue<EquipmentFileMaintenance>(nameof(EquipmentFileMaintenances), ref _EquipmentFileMaintenances, value); }
        }

        [XafDisplayName("设备编号")]
        public string EquipmentNo
        {
            get { return _EquipmentNo; }
            set { SetPropertyValue<string>(nameof(EquipmentNo), ref _EquipmentNo, value); }
        }

        [XafDisplayName("设备类别")]
        public EquipmentCategory EquipmentCategorys
        {
            get { return _EquipmentCategorys; }
            set { SetPropertyValue<EquipmentCategory>(nameof(EquipmentCategorys), ref _EquipmentCategorys, value); }
        }

        [XafDisplayName("设备名称")]
        public string EquipmentName
        {
            get { return _EquipmentName; }
            set { SetPropertyValue<string>(nameof(EquipmentName), ref _EquipmentName, value); }
        }

        [XafDisplayName("设备型号")]
        public string EquipmentType
        {
            get { return _EquipmentType; }
            set { SetPropertyValue<string>(nameof(EquipmentType), ref _EquipmentType, value); }
        }

        public enum EquipmentStatu { 有效, 编制 }
        [XafDisplayName("设备状态")]
        public EquipmentStatu EquipmentStatus
        {
            get { return _EquipmentStatus; }
            set { SetPropertyValue<EquipmentStatu>(nameof(EquipmentStatus), ref _EquipmentStatus, value); }
        }

        [XafDisplayName("生产厂家")]
        public string Manufacturer
        {
            get { return _Manufacturer; }
            set { SetPropertyValue<string>(nameof(Manufacturer), ref _Manufacturer, value); }
        }

        [XafDisplayName("设备子类")]
        public EquipmentChildrenClass EquipmentChildrenClasses
        {
            get { return _EquipmentChildrenClasses; }
            set { SetPropertyValue<EquipmentChildrenClass>(nameof(EquipmentChildrenClasses), ref _EquipmentChildrenClasses, value); }
        }

        [XafDisplayName("是否数控设备")]
        [CaptionsForBoolValues("是", "否")]
        public bool CNCEquipment
        {
            get { return _CNCEquipment; }
            set { SetPropertyValue<bool>(nameof(CNCEquipment), ref _CNCEquipment, value); }
        }

        [XafDisplayName("是否点检")]
        [CaptionsForBoolValues("是", "否")]
        public bool SpotCheck
        {
            get { return _SpotCheck; }
            set { SetPropertyValue<bool>(nameof(SpotCheck), ref _SpotCheck, value); }
        }

        [XafDisplayName("所属部门")]
        public DepartmentSetting DepartmentSettings
        {
            get { return _DepartmentSettings; }
            set { SetPropertyValue<DepartmentSetting>(nameof(DepartmentSettings), ref _DepartmentSettings, value); }
        }

        [XafDisplayName("故障描述"), Size(300)]
        [RuleRequiredField]
        public string FaultDescription
        {
            get { return _FaultDescription; }
            set { SetPropertyValue<string>(nameof(FaultDescription), ref _FaultDescription, value); }
        }

        public enum RepairSource { 手工录入, 安灯报修, 点检异常, 保养异常 }
        [XafDisplayName("维修来源")]
        public RepairSource RepairSources
        {
            get { return _RepairSources; }
            set { SetPropertyValue<RepairSource>(nameof(RepairSources), ref _RepairSources, value); }
        }

        [XafDisplayName("申请人")]
        [RuleRequiredField]
        public SystemUser SystemUsers1
        {
            get { return _SystemUsers1; }
            set { SetPropertyValue<SystemUser>(nameof(SystemUsers1), ref _SystemUsers1, value); }
        }

        [XafDisplayName("申请时间")]
        public DateTime ApplicationTime
        {
            get { return _ApplicationTime; }
            set { SetPropertyValue<DateTime>(nameof(ApplicationTime), ref _ApplicationTime, value); }
        }

        [XafDisplayName("维修人员")]
        [RuleRequiredField]
        public SystemUser SystemUsers2
        {
            get { return _SystemUsers2; }
            set { SetPropertyValue<SystemUser>(nameof(SystemUsers2), ref _SystemUsers2, value); }
        }

        [XafDisplayName("维修时间")]
        public DateTime MaintenanceTime
        {
            get { return _MaintenanceTime; }
            set { SetPropertyValue<DateTime>(nameof(MaintenanceTime), ref _MaintenanceTime, value); }
        }

        [XafDisplayName("维修内容"), Size(300)]
        public string MaintenanceContent
        {
            get { return _MaintenanceContent; }
            set { SetPropertyValue<string>(nameof(MaintenanceContent), ref _MaintenanceContent, value); }
        }

        [XafDisplayName("维修费用")]
        public decimal MaintenanceCosts
        {
            get { return _MaintenanceCosts; }
            set { SetPropertyValue<decimal>(nameof(MaintenanceCosts), ref _MaintenanceCosts, value); }
        }

        [XafDisplayName("备注")]
        public string remarks
        {
            get { return _remarks; }
            set { SetPropertyValue<string>(nameof(remarks), ref _remarks, value); }
        }
    }
}