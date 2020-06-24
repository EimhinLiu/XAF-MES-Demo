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
    [XafDisplayName("点检详情")]
    public class SpotCheckDetails : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public SpotCheckDetails(Session session)
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
        private string _Project;
        private string _Method;
        private Image _Picture;
        private SpotCheckStatu _SpotCheckStatus;

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
        public string Project
        {
            get { return _Project; }
            set { SetPropertyValue<string>(nameof(Project), ref _Project, value); }
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

        public enum SpotCheckStatu { 正常, 异常 }
        [XafDisplayName("点检状态")]
        public SpotCheckStatu SpotCheckStatus
        {
            get { return _SpotCheckStatus; }
            set { SetPropertyValue<SpotCheckStatu>(nameof(SpotCheckStatus), ref _SpotCheckStatus, value); }
        }

        private EquipmentSpotCheckList _EquipmentSpotCheckList;
        [Association("EquipmentSpotCheckList-SpotCheckDetails")]
        public EquipmentSpotCheckList EquipmentSpotCheckList
        {
            get { return _EquipmentSpotCheckList; }
            set { SetPropertyValue<EquipmentSpotCheckList>(nameof(EquipmentSpotCheckList), ref _EquipmentSpotCheckList, value); }
        }
    }
}