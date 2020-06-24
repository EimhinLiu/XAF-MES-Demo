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
    [XafDisplayName("设备点检查询")]
    public class EquipmentSpotCheckQuery : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public EquipmentSpotCheckQuery(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private DateTime _StartTime;
        private DateTime _EndTime;

        [XafDisplayName("开始时间")]
        [RuleRequiredField]
        public DateTime StartTime
        {
            get { return _StartTime; }
            set { SetPropertyValue<DateTime>(nameof(StartTime), ref _StartTime, value); }
        }

        [XafDisplayName("结束时间")]
        [RuleRequiredField]
        public DateTime EndTime
        {
            get { return _EndTime; }
            set { SetPropertyValue<DateTime>(nameof(EndTime), ref _EndTime, value); }
        }

        [Association("EquipmentSpotCheckQuery-QueryResults")]
        public XPCollection<QueryResults> QueryResults
        {
            get { return GetCollection<QueryResults>(nameof(QueryResults)); }
        }

    }
}