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
    [XafDisplayName("设备保养计划")]
    public class EquipmentMaintenanceSchedule : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public EquipmentMaintenanceSchedule(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private string _ListNo;
        private string _Equipment;
        private string _EquipmentNo;
        private string _EquipmentName;
        private string _EquipmentType;
        private EquipmentStatu _EquipmentStatus;
        private Statu _Status;
        private string _Manufacturer;
        private EquipmentChildrenClass _EquipmentChildrenClasses;
        private DepartmentSetting _DepartmentSettings;
        private bool _CNCEquipment;
        private string _remarks;
        private bool _SpotCheck;
        private string _InstallationPlace;
        private DateTime _StartTime;
        private MaintenanceLevel _MaintenanceLevels;
        private MaintenanceCycle _MaintenanceCycles;
        private EquipmentCategory _EquipmentCategorys;
        private string _Schedule_Time;
        private EquipmentMaintenancePlan _EquipmentMaintenancePlans;

        [XafDisplayName("单据编号")]
        public string ListNo
        {
            get { return _ListNo; }
            set { SetPropertyValue<string>(nameof(ListNo), ref _ListNo, value); }
        }

        [XafDisplayName("设备")]
        [RuleRequiredField]
        public string Equipment
        {
            get { return _Equipment; }
            set { SetPropertyValue<string>(nameof(Equipment), ref _Equipment, value); }
        }

        [XafDisplayName("设备编号")]
        public string EquipmentNo
        {
            get { return _EquipmentNo; }
            set { SetPropertyValue<string>(nameof(EquipmentNo), ref _EquipmentNo, value); }
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

        public enum Statu { 正常,异常 }
        [XafDisplayName("状态")]
        public Statu Status
        {
            get { return _Status; }
            set { SetPropertyValue<Statu>(nameof(Status), ref _Status, value); }
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

        [XafDisplayName("所属部门")]
        public DepartmentSetting DepartmentSettings
        {
            get { return _DepartmentSettings; }
            set { SetPropertyValue<DepartmentSetting>(nameof(DepartmentSettings), ref _DepartmentSettings, value); }
        }

        [XafDisplayName("是否数控设备")]
        [CaptionsForBoolValues("是", "否")]
        public bool CNCEquipment
        {
            get { return _CNCEquipment; }
            set { SetPropertyValue<bool>(nameof(CNCEquipment), ref _CNCEquipment, value); }
        }

        [XafDisplayName("备注")]
        public string remarks
        {
            get { return _remarks; }
            set { SetPropertyValue<string>(nameof(remarks), ref _remarks, value); }
        }

        [XafDisplayName("是否点检")]
        [CaptionsForBoolValues("是", "否")]
        public bool SpotCheck
        {
            get { return _SpotCheck; }
            set { SetPropertyValue<bool>(nameof(SpotCheck), ref _SpotCheck, value); }
        }

        [XafDisplayName("安装地点")]
        public string InstallationPlace
        {
            get { return _InstallationPlace; }
            set { SetPropertyValue<string>(nameof(InstallationPlace), ref _InstallationPlace, value); }
        }

        [XafDisplayName("启用日期")]
        public DateTime StartTime
        {
            get { return _StartTime; }
            set { SetPropertyValue<DateTime>(nameof(StartTime), ref _StartTime, value); }
        }

        public enum MaintenanceLevel { 一级, 二级, 三级, 四级, 五级 }
        [XafDisplayName("保养级别")]
        public MaintenanceLevel MaintenanceLevels
        {
            get { return _MaintenanceLevels; }
            set { SetPropertyValue<MaintenanceLevel>(nameof(MaintenanceLevels), ref _MaintenanceLevels, value); }
        }

        public enum MaintenanceCycle { 每周保养, 月度保养, 季度保养, 年度保养 }
        [XafDisplayName("保养周期")]
        public MaintenanceCycle MaintenanceCycles
        {
            get { return _MaintenanceCycles; }
            set { SetPropertyValue<MaintenanceCycle>(nameof(MaintenanceCycles), ref _MaintenanceCycles, value); }
        }

        [XafDisplayName("设备类别")]
        public EquipmentCategory EquipmentCategorys
        {
            get { return _EquipmentCategorys; }
            set { SetPropertyValue<EquipmentCategory>(nameof(EquipmentCategorys), ref _EquipmentCategorys, value); }
        }

        [XafDisplayName("计划日期")]
        public string Schedule_Time
        {
            get { return _Schedule_Time; }
            set { SetPropertyValue<string>(nameof(Schedule_Time), ref _Schedule_Time, value); }
        }

        [XafDisplayName("保养方案")]
        [RuleRequiredField]
        public EquipmentMaintenancePlan EquipmentMaintenancePlans
        {
            get { return _EquipmentMaintenancePlans; }
            set { SetPropertyValue<EquipmentMaintenancePlan>(nameof(EquipmentMaintenancePlans), ref _EquipmentMaintenancePlans, value); }
        }

        [Association("EquipmentMaintenanceSchedule-ScheduleDetails")]
        public XPCollection<ScheduleDetails> ScheduleDetails
        {
            get { return GetCollection<ScheduleDetails>(nameof(ScheduleDetails)); }
        }
    }
}