using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace Poetry.Administrator.Module.BusinessObjects
{
    public abstract class BaseObject : XPCustomObject
    {
        public BaseObject(Session session)
            : base(session)
        {
            _id = -1;
            _name = string.Empty;
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        int _id;
        [VisibleInListView(false)]
        public int Id
        {
            get => _id;
            set => SetPropertyValue(nameof(Id), ref _id, value);
        }

        private string _name;
        [XafDisplayName("Название"), ToolTip("Название")]
        [Index(0)]
        [Persistent("Name"), RuleRequiredField(DefaultContexts.Save)]
        public string Name
        {
            get => _name;
            set => SetPropertyValue(nameof(Name), ref _name, value);
        }

    }

    public class LinkObject : BaseObject
    {
        public LinkObject(Session session) : base(session)
        {
            _link = string.Empty;
        }

        private string _link;
        [XafDisplayName("HTTP связь"), ToolTip("HTTP связь с OK.RU")]
        [Index(1)]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Link
        {
            get => _link;
            set => SetPropertyValue(nameof(Link), ref _link, value);
        }
    }
}