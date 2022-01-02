using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace Poetry.Administrator.Module.BusinessObjects
{
    [MapInheritance(MapInheritanceType.ParentTable)]
    [DefaultProperty(nameof(UserName))]
    public class AppUser : PermissionPolicyUser, IObjectSpaceLink, ISecurityUserWithLoginInfo
    {
        public AppUser(Session session) : base(session) { }

        [Browsable(false)]
        [Aggregated, Association("User-LoginInfo")]
        public XPCollection<AppUserLoginInfo> LoginInfo
        {
            get { return GetCollection<AppUserLoginInfo>(nameof(LoginInfo)); }
        }

        IEnumerable<ISecurityUserLoginInfo> IOAuthSecurityUser.UserLogins => LoginInfo.OfType<ISecurityUserLoginInfo>();

        IObjectSpace IObjectSpaceLink.ObjectSpace { get; set; }

        ISecurityUserLoginInfo ISecurityUserWithLoginInfo.CreateUserLoginInfo(string loginProviderName, string providerUserKey)
        {
            AppUserLoginInfo result = ((IObjectSpaceLink)this).ObjectSpace.CreateObject<AppUserLoginInfo>();
            result.LoginProviderName = loginProviderName;
            result.ProviderUserKey = providerUserKey;
            result.User = this;
            return result;
        }

        private string _name;
        [XafDisplayName("Имя"), ToolTip("Имя на ОК")]
        [Index(0)]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Name
        {
            get { return _name; }
            set => SetPropertyValue(nameof(Name), ref _name, value);
        }

        private string _okId;
        [XafDisplayName("Id на ОК"), ToolTip("Id на ОК")]
        [Index(1)]
        [RuleRequiredField(DefaultContexts.Save)]
        public string OkID
        {
            get { return _okId; }
            set => SetPropertyValue(nameof(OkID), ref _okId, value);
        }
    }
}
