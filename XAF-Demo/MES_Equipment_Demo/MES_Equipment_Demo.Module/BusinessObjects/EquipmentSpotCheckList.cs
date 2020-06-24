using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace MES_Equipment_Demo.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("设备点检单")]
    public class EquipmentSpotCheckList : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public EquipmentSpotCheckList(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private string _ListNo;
        private DateTime _SpotCheckTime;
        private string _Equipment;
        private DateTime _StartTime;
        private ListStatu _ListStatus;
        private EquipmentSpotCheckScheme _EquipmentSpotCheckSchemes;
        private string _EquipmentNo;
        private string _EquipmentName;
        private string _EquipmentType;
        private string _InstallationPlace;
        private string _Manufacturer;
        private string _remarks1;
        private EquipmentStatu _EquipmentStatus;
        private string _Creater;
        private EquipmentChildrenClass _EquipmentChildrenClasses;
        private bool _CNCEquipment;
        private bool _SpotCheck;
        private DepartmentSetting _DepartmentSettings;
        private EquipmentCategory _EquipmentCategorys;
        private string _remarks2;

        [XafDisplayName("单据编号")]
        public string ListNo
        {
            get { return _ListNo; }
            set { SetPropertyValue<string>(nameof(ListNo), ref _ListNo, value); }
        }

        [XafDisplayName("点检日期")]
        public DateTime SpotCheckTime
        {
            get { return _SpotCheckTime; }
            set { SetPropertyValue<DateTime>(nameof(SpotCheckTime), ref _SpotCheckTime, value); }
        }

        [XafDisplayName("设备")]
        [RuleRequiredField]
        public string Equipment
        {
            get { return _Equipment; }
            set { SetPropertyValue<string>(nameof(Equipment), ref _Equipment, value); }
        }

        [XafDisplayName("启用日期")]
        public DateTime StartTime
        {
            get { return _StartTime; }
            set { SetPropertyValue<DateTime>(nameof(StartTime), ref _StartTime, value); }
        }

        public enum ListStatu { 有效, 编制 }
        [XafDisplayName("单据状态")]
        public ListStatu ListStatus
        {
            get { return _ListStatus; }
            set { SetPropertyValue<ListStatu>(nameof(ListStatus), ref _ListStatus, value); }
        }

        [XafDisplayName("点检方案")]
        public EquipmentSpotCheckScheme EquipmentSpotCheckSchemes
        {
            get { return _EquipmentSpotCheckSchemes; }
            set { SetPropertyValue<EquipmentSpotCheckScheme>(nameof(EquipmentSpotCheckSchemes), ref _EquipmentSpotCheckSchemes, value); }
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

        [XafDisplayName("备注1")]
        public string remarks1
        {
            get { return _remarks1; }
            set { SetPropertyValue<string>(nameof(remarks1), ref _remarks1, value); }
        }

        public enum EquipmentStatu { 有效, 编制 }
        [XafDisplayName("设备状态")]
        public EquipmentStatu EquipmentStatus
        {
            get { return _EquipmentStatus; }
            set { SetPropertyValue<EquipmentStatu>(nameof(EquipmentStatus), ref _EquipmentStatus, value); }
        }

        [XafDisplayName("创建人")]
        public string Creater
        {
            get { return _Creater; }
            set { SetPropertyValue<string>(nameof(Creater), ref _Creater, value); }
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

        [XafDisplayName("设备类别")]
        public EquipmentCategory EquipmentCategorys
        {
            get { return _EquipmentCategorys; }
            set { SetPropertyValue<EquipmentCategory>(nameof(EquipmentCategorys), ref _EquipmentCategorys, value); }
        }

        [XafDisplayName("备注2")]
        public string remarks2
        {
            get { return _remarks2; }
            set { SetPropertyValue<string>(nameof(remarks2), ref _remarks2, value); }
        }

        [Association("EquipmentSpotCheckList-SpotCheckDetails")]
        public XPCollection<SpotCheckDetails> SpotCheckDetails
        {
            get { return GetCollection<SpotCheckDetails>(nameof(SpotCheckDetails)); }
        }
    }
}