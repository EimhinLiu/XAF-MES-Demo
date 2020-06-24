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
using DevExpress.Xpo.Metadata;
using System.Drawing;

namespace MES_Equipment_Demo.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("明细")]
    public class ScheduleDetails : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ScheduleDetails(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private int _No;
        private string _Benchmark;
        private string _project;
        private string _Method;
        private string _Comment;
        private Image _Picture;
        private MaintenanceStatu _MaintenanceStatus;

        [XafDisplayName("序号")]
        public int No
        {
            get { return _No; }
            set { SetPropertyValue<int>(nameof(No), ref _No, value); }
        }

        [XafDisplayName("基准")]
        [RuleRequiredField]
        public string Benchmark
        {
            get { return _Benchmark; }
            set { SetPropertyValue<string>(nameof(Benchmark), ref _Benchmark, value); }
        }

        [XafDisplayName("项目")]
        public string project
        {
            get { return _project; }
            set { SetPropertyValue<string>(nameof(project), ref _project, value); }
        }

        [XafDisplayName("方法")]
        public string Method
        {
            get { return _Method; }
            set { SetPropertyValue<string>(nameof(Method), ref _Method, value); }
        }

        [XafDisplayName("备注")]
        public string Comment
        {
            get { return _Comment; }
            set { SetPropertyValue<string>(nameof(Comment), ref _Comment, value); }
        }

        [XafDisplayName("照片")]
        [ValueConverter(typeof(ImageValueConverter))]
        public Image Picture
        {
            get { return _Picture; }
            set { SetPropertyValue<Image>(nameof(Picture), ref _Picture, value); }
        }

        public enum MaintenanceStatu { 正常,异常 }
        [XafDisplayName("保养状态")]
        public MaintenanceStatu MaintenanceStatus
        {
            get { return _MaintenanceStatus; }
            set { SetPropertyValue<MaintenanceStatu>(nameof(MaintenanceStatus), ref _MaintenanceStatus, value); }
        }

        private EquipmentMaintenanceSchedule _EquipmentMaintenanceSchedule;
        [Association("EquipmentMaintenanceSchedule-ScheduleDetails")]
        public EquipmentMaintenanceSchedule EquipmentMaintenanceSchedule
        {
            get { return _EquipmentMaintenanceSchedule; }
            set { SetPropertyValue<EquipmentMaintenanceSchedule>(nameof(EquipmentMaintenanceSchedule), ref _EquipmentMaintenanceSchedule, value); }
        }

        private EquipmentMaintenanceQuery _EquipmentMaintenanceQuery;
        [Association("EquipmentMaintenanceQuery-ScheduleDetails")]
        public EquipmentMaintenanceQuery EquipmentMaintenanceQuery
        {
            get { return _EquipmentMaintenanceQuery; }
            set { SetPropertyValue<EquipmentMaintenanceQuery>(nameof(EquipmentMaintenanceQuery), ref _EquipmentMaintenanceQuery, value); }
        }
    }
}