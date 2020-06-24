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
    [XafDisplayName("设备保养监控")]
    public class EquipmentMaintenanceMonitor : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public EquipmentMaintenanceMonitor(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private string _EquipmentNo;
        private string _EquipmentName;
        private string _EquipmentType;
        private EquipmentCategory _EquipmentCategorys;
        private EquipmentChildrenClass _EquipmentChildrenClasses;
        private int _WorkingHour;
        private DepartmentSetting _DepartmentSettings;
        private string _InstallationPlace;
        private string _Manufacturer;
        private DateTime _ActivationDate;
        private Status _EquipmentStatus;
        private bool _CNCEquipment;
        private bool _SpotCheck;
        private string _Cycle;
        private int _GeneratMaintenancePlan;
        private int _GeneratedMaintenancePlan;
        private int _MaintenanceTimes;
        private bool _Maintained;
        private bool _Generated;
        private string _Comment;

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

        [XafDisplayName("设备类别")]
        public EquipmentCategory EquipmentCategorys
        {
            get { return _EquipmentCategorys; }
            set { SetPropertyValue<EquipmentCategory>(nameof(EquipmentCategorys), ref _EquipmentCategorys, value); }
        }

        [XafDisplayName("设备子类")]
        public EquipmentChildrenClass EquipmentChildrenClasses
        {
            get { return _EquipmentChildrenClasses; }
            set { SetPropertyValue<EquipmentChildrenClass>(nameof(EquipmentChildrenClasses), ref _EquipmentChildrenClasses, value); }
        }

        [XafDisplayName("工时折算系数")]
        public int WorkingHour
        {
            get { return _WorkingHour; }
            set { SetPropertyValue<int>(nameof(WorkingHour), ref _WorkingHour, value); }
        }

        [XafDisplayName("所属部门")]
        public DepartmentSetting DepartmentSettings
        {
            get { return _DepartmentSettings; }
            set { SetPropertyValue<DepartmentSetting>(nameof(DepartmentSettings), ref _DepartmentSettings, value); }
        }

        [XafDisplayName("安装地点")]
        public string InstallationPlace
        {
            get { return _InstallationPlace; }
            set { SetPropertyValue<string>(nameof(InstallationPlace), ref _InstallationPlace, value); }
        }

        [XafDisplayName("生产厂家")]
        public string Manufacturer
        {
            get { return _Manufacturer; }
            set { SetPropertyValue<string>(nameof(Manufacturer), ref _Manufacturer, value); }
        }

        [XafDisplayName("启用日期")]
        public DateTime ActivationDate
        {
            get { return _ActivationDate; }
            set { SetPropertyValue<DateTime>(nameof(ActivationDate), ref _ActivationDate, value); }
        }

        public enum Status { 良好, 报修, 闲置, 封存, 报废, 故障 }
        [XafDisplayName("设备状态")]
        public Status EquipmentStatus
        {
            get { return _EquipmentStatus; }
            set { SetPropertyValue<Status>(nameof(EquipmentStatus), ref _EquipmentStatus, value); }
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

        [XafDisplayName("周期")]
        public string Cycle
        {
            get { return _Cycle; }
            set { SetPropertyValue<string>(nameof(Cycle), ref _Cycle, value); }
        }

        [XafDisplayName("应生成保养计划")]
        public int GeneratMaintenancePlan
        {
            get { return _GeneratMaintenancePlan; }
            set { SetPropertyValue<int>(nameof(GeneratMaintenancePlan), ref _GeneratMaintenancePlan, value); }
        }

        [XafDisplayName("已生成保养计划")]
        public int GeneratedMaintenancePlan
        {
            get { return _GeneratedMaintenancePlan; }
            set { SetPropertyValue<int>(nameof(GeneratedMaintenancePlan), ref _GeneratedMaintenancePlan, value); }
        }

        [XafDisplayName("已保养次数")]
        public int MaintenanceTimes
        {
            get { return _MaintenanceTimes; }
            set { SetPropertyValue<int>(nameof(MaintenanceTimes), ref _MaintenanceTimes, value); }
        }

        [XafDisplayName("已保养")]
        public bool Maintained
        {
            get { return _Maintained; }
            set { SetPropertyValue<bool>(nameof(Maintained), ref _Maintained, value); }
        }

        [XafDisplayName("已生成")]
        public bool Generated
        {
            get { return _Generated; }
            set { SetPropertyValue<bool>(nameof(Generated), ref _Generated, value); }
        }

        [XafDisplayName("备注"),Size(300)]
        public string Comment
        {
            get { return _Comment; }
            set { SetPropertyValue<string>(nameof(Comment), ref _Comment, value); }
        }

        [Association("EquipmentMaintenanceMonitor-SystemUser")]
        public XPCollection<SystemUser> SystemUser
        {
            get { return GetCollection<SystemUser>(nameof(SystemUser)); }
        }
    }
}