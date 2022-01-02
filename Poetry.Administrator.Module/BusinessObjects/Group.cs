using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using System.Linq;

namespace Poetry.Administrator.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Contact")]
    [DefaultProperty(nameof(Name))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    // [Persistent("DatabaseTableName")]
    public class Group : LinkObject
    {
        public Group(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        [XafDisplayName("Группа"), ToolTip("Название группы")]
        public string Name
        {
            get => base.Name;
            set => base.Name = value;
        }

        private Guid _owner;
        [XafDisplayName("Администратор"), ToolTip("Администратор группы")]
        [Index(3)]
        public Guid Owner
        {
            get { return _owner; }
            set => SetPropertyValue(nameof(Owner), ref _owner, value);
        }

    }
}