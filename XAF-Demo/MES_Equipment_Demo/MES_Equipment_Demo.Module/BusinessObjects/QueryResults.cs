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
    [XafDisplayName("查询结果")]
    public class QueryResults : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public QueryResults(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private DateTime _Date;
        private string _EquipmentNo;
        private string _EquipmentName;
        private string _EquipmentType;
        private EquipmentCategory _EquipmentCategorys;
        private string _Manufacturer;
        private DepartmentSetting _DepartmentSettings;
        private string _InstallationPlace;
        private int _WorkingHour;
        private Status _EquipmentStatus;
        private bool _SpotCheck;
        private bool _Maintain;
        private bool _CNCEquipment;
        private bool _VirtualEquipment;
        private DateTime _ActivationDate;
        private string _Comment;
        private SpotCheckStatu _SpotCheckStatus;

        [XafDisplayName("日期")]
        public DateTime Date
        {
            get { return _Date; }
            set { SetPropertyValue<DateTime>(nameof(Date), ref _Date, value); }
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

        [XafDisplayName("设备类别")]
        public EquipmentCategory EquipmentCategorys
        {
            get { return _EquipmentCategorys; }
            set { SetPropertyValue<EquipmentCategory>(nameof(EquipmentCategorys), ref _EquipmentCategorys, value); }
        }

        [XafDisplayName("生产厂家")]
        public string Manufacturer
        {
            get { return _Manufacturer; }
            set { SetPropertyValue<string>(nameof(Manufacturer), ref _Manufacturer, value); }
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

        [XafDisplayName("工时折算系数")]
        public int WorkingHour
        {
            get { return _WorkingHour; }
            set { SetPropertyValue<int>(nameof(WorkingHour), ref _WorkingHour, value); }
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

        [XafDisplayName("启用日期")]
        public DateTime ActivationDate
        {
            get { return _ActivationDate; }
            set { SetPropertyValue<DateTime>(nameof(ActivationDate), ref _ActivationDate, value); }
        }

        [XafDisplayName("备注")]
        public string Comment
        {
            get { return _Comment; }
            set { SetPropertyValue<string>(nameof(Comment), ref _Comment, value); }
        }

        public enum SpotCheckStatu { 正常, 异常 }
        [XafDisplayName("点检状态")]
        public SpotCheckStatu SpotCheckStatus
        {
            get { return _SpotCheckStatus; }
            set { SetPropertyValue<SpotCheckStatu>(nameof(SpotCheckStatus), ref _SpotCheckStatus, value); }
        }

        private EquipmentSpotCheckQuery _EquipmentSpotCheckQuery;
        [Association("EquipmentSpotCheckQuery-QueryResults")]
        public EquipmentSpotCheckQuery EquipmentSpotCheckQuery
        {
            get { return _EquipmentSpotCheckQuery; }
            set { SetPropertyValue<EquipmentSpotCheckQuery>(nameof(EquipmentSpotCheckQuery), ref _EquipmentSpotCheckQuery, value); }
        }
    }
}