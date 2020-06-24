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
    [XafDisplayName("系统用户")]
    public class SystemUser : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public SystemUser(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private string _Name;
        private string _AccountNum;
        private string _CardNum;
        private string _Position;
        private PositionCategory _PositionCategorys;
        private DepartmentSetting _DepartmentSettings;
        private string _PhoneNum;
        private bool _gender;

        [XafDisplayName("姓名")]
        [RuleRequiredField]
        public string Name
        {
            get { return _Name; }
            set { SetPropertyValue<string>(nameof(Name), ref _Name, value); }
        }

        [XafDisplayName("账号")]
        [RuleRequiredField]
        public string AccountNum
        {
            get { return _AccountNum; }
            set { SetPropertyValue<string>(nameof(AccountNum), ref _AccountNum, value); }
        }

        [XafDisplayName("卡号")]
        public string CardNum
        {
            get { return _CardNum; }
            set { SetPropertyValue<string>(nameof(CardNum), ref _CardNum, value); }
        }

        [XafDisplayName("职务")]
        public string Position
        {
            get { return _Position; }
            set { SetPropertyValue<string>(nameof(Position), ref _Position, value); }
        }

        public enum PositionCategory { 经营层,中层,主管,销售人员,售后服务人员,基本生产工人,辅产工人,管理人员,技术人员,维修人员 }
        [XafDisplayName("岗位类别 ")]
        public PositionCategory PositionCategorys
        {
            get { return _PositionCategorys; }
            set { SetPropertyValue<PositionCategory>(nameof(PositionCategorys), ref _PositionCategorys, value); }
        }

        [XafDisplayName("部门 ")]
        [RuleRequiredField]
        public DepartmentSetting DepartmentSettings
        {
            get { return _DepartmentSettings; }
            set { SetPropertyValue<DepartmentSetting>(nameof(DepartmentSettings), ref _DepartmentSettings, value); }
        }

        [XafDisplayName("手机号码 ")]
        public string PhoneNum
        {
            get { return _PhoneNum; }
            set { SetPropertyValue<string>(nameof(PhoneNum), ref _PhoneNum, value); }
        }

        [XafDisplayName("性别 ")]
        [CaptionsForBoolValues("男", "女")]
        public bool gender
        {
            get { return _gender; }
            set { SetPropertyValue<bool>(nameof(gender), ref _gender, value); }
        }

        private EquipmentFileMaintenance _EquipmentFileMaintenance;
        [Association("EquipmentFileMaintenance-SystemUser")]
        public EquipmentFileMaintenance EquipmentFileMaintenance
        {
            get { return _EquipmentFileMaintenance; }
            set { SetPropertyValue<EquipmentFileMaintenance>(nameof(EquipmentFileMaintenance), ref _EquipmentFileMaintenance, value); }
        }

        private EquipmentMaintenanceMonitor _EquipmentMaintenanceMonitor;
        [Association("EquipmentMaintenanceMonitor-SystemUser")]
        public EquipmentMaintenanceMonitor EquipmentMaintenanceMonitor
        {
            get { return _EquipmentMaintenanceMonitor; }
            set { SetPropertyValue<EquipmentMaintenanceMonitor>(nameof(EquipmentMaintenanceMonitor), ref _EquipmentMaintenanceMonitor, value); }
        }
    }
}