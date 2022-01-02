using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Poetry.Administrator.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Contact")]
    [DefaultProperty(nameof(Name))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    // [Persistent("DatabaseTableName")]
    public class Concurs : LinkObject
    {
        public Concurs(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue(nameof(PersistentProperty), ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod()
        //{
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}

        [XafDisplayName("Название"), ToolTip("Название конкурса")]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Name
        {
            get => base.Name;
            set => base.Name = value;
        }


        private Guid _owner;
        [XafDisplayName("Ведущий"), ToolTip("Ведущий конкурса")]
        [Index(2)]
        public Guid Owner
        {
            get { return _owner; }
            set => SetPropertyValue(nameof(Owner), ref _owner, value);
        }

        private Group _group;
        [XafDisplayName("Группа"), ToolTip("Конкурс в группе")]
        [Index(3)]
        public Group Group
        {
            get { return _group; }
            set => SetPropertyValue(nameof(Group), ref _group, value);
        }


    }
}