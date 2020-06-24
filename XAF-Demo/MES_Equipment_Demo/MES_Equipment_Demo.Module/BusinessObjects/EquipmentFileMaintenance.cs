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
    // 更改名字为中文名
    [XafDisplayName("设备档案维护")]
    [DefaultProperty("EquipmentNum")]
    public class EquipmentFileMaintenance : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public EquipmentFileMaintenance(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private string _EquipmentNum;
        private string _EquipmentName;
        private string _EquipmentType;
        private EquipmentCategory _EquipmentCategorys;
        private EquipmentChildrenClass _EquipmentChildrenClasses;
        private int _WorkingHour;
        private DepartmentSetting _Department;
        private string _InstallationPlace;
        private string _Manufacturer;
        private DateTime _ActivationDate;
        private Status _EquipmentStatus;
        private bool _SpotCheck;
        private bool _Maintain;
        private bool _CNCEquipment;
        private bool _VirtualEquipment;
        private string _Comment;

        [XafDisplayName("设备编号")]
        // 必填项
        [RuleRequiredField]
        // 不可重复项
        [RuleUniqueValue]
        public string EquipmentNum
        {
            get { return _EquipmentNum; }
            set { SetPropertyValue<string>(nameof(EquipmentNum), ref _EquipmentNum, value); }
        }

        [XafDisplayName("设备名称")]
        [RuleRequiredField]
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
        [RuleRequiredField]
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
        [RuleRequiredField]
        public DepartmentSetting Department
        {
            get { return _Department; }
            set { SetPropertyValue<DepartmentSetting>(nameof(Department), ref _Department, value); }
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

        [XafDisplayName("是否点检")]
        [CaptionsForBoolValues("是", "否")]
        public bool SpotCheck
        {
            get { return _SpotCheck; }
            set { SetPropertyValue<bool>(nameof(SpotCheck), ref _SpotCheck, value); }
        }

        [XafDisplayName("是否保养")]
        [CaptionsForBoolValues("是", "否")]
        public bool Maintain
        {
            get { return _Maintain; }
            set { SetPropertyValue<bool>(nameof(Maintain), ref _Maintain, value); }
        }

        [XafDisplayName("是否数控设备")]
        [CaptionsForBoolValues("是", "否")]
        public bool CNCEquipment
        {
            get { return _CNCEquipment; }
            set { SetPropertyValue<bool>(nameof(CNCEquipment), ref _CNCEquipment, value); }
        }

        [XafDisplayName("是否虚拟设备")]
        [CaptionsForBoolValues("是", "否")]
        public bool VirtualEquipment
        {
            get { return _VirtualEquipment; }
            set { SetPropertyValue<bool>(nameof(VirtualEquipment), ref _VirtualEquipment, value); }
        }

        [XafDisplayName("备注"),Size(300)]
        public string Comment
        {
            get { return _Comment; }
            set { SetPropertyValue<string>(nameof(Comment), ref _Comment, value); }
        }

        [Association("EquipmentFileMaintenance-SystemUser")]
        public XPCollection<SystemUser> SystemUser
        {
            get { return GetCollection<SystemUser>(nameof(SystemUser)); }
        }
    }
}