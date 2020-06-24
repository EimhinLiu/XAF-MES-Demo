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
using System.Drawing;
using DevExpress.Xpo.Metadata;

namespace MES_Equipment_Demo.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("明细")]
    public class SchemeDetails : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public SchemeDetails(Session session)
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
        private Image _Picture;

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

        [XafDisplayName("照片")]
        [ValueConverter(typeof(ImageValueConverter))]
        public Image Picture
        {
            get { return _Picture; }
            set { SetPropertyValue<Image>(nameof(Picture), ref _Picture, value); }
        }

        private EquipmentSpotCheckScheme _EquipmentSpotCheckScheme;
        [Association("EquipmentSpotCheckScheme-SchemeDetails")]
        public EquipmentSpotCheckScheme EquipmentSpotCheckScheme
        {
            get { return _EquipmentSpotCheckScheme; }
            set { SetPropertyValue<EquipmentSpotCheckScheme>(nameof(EquipmentSpotCheckScheme), ref _EquipmentSpotCheckScheme, value); }
        }

        private EquipmentMaintenancePlan _EquipmentMaintenancePlan;
        [Association("EquipmentMaintenancePlan-SchemeDetails")]
        public EquipmentMaintenancePlan EquipmentMaintenancePlan
        {
            get { return _EquipmentMaintenancePlan; }
            set { SetPropertyValue<EquipmentMaintenancePlan>(nameof(EquipmentMaintenancePlan), ref _EquipmentMaintenancePlan, value); }
        }
    }
}