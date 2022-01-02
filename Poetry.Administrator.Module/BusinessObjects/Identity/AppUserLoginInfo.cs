using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace Poetry.Administrator.Module.BusinessObjects
{
    [DeferredDeletion(false)]
    [Persistent(nameof(AppUserLoginInfo))]
    public class AppUserLoginInfo : BaseObject, ISecurityUserLoginInfo
    {
        private string loginProviderName;
        private AppUser user;
        private string providerUserKey;
        public AppUserLoginInfo(Session session) : base(session) { }

        [Indexed("ProviderUserKey", Unique = true)]
        [Appearance("PasswordProvider", Enabled = false, Criteria = "!(IsNewObject(this)) and LoginProviderName == '" + SecurityDefaults.PasswordAuthentication + "'", Context = "DetailView")]
        public string LoginProviderName
        {
            get { return loginProviderName; }
            set { SetPropertyValue(nameof(LoginProviderName), ref loginProviderName, value); }
        }

        [Appearance("PasswordProviderUserKey", Enabled = false, Criteria = "!(IsNewObject(this)) and LoginProviderName == '" + SecurityDefaults.PasswordAuthentication + "'", Context = "DetailView")]
        public string ProviderUserKey
        {
            get { return providerUserKey; }
            set { SetPropertyValue(nameof(ProviderUserKey), ref providerUserKey, value); }
        }

        [Association("User-LoginInfo")]
        public AppUser User
        {
            get { return user; }
            set { SetPropertyValue(nameof(User), ref user, value); }
        }


        object ISecurityUserLoginInfo.User => User;
    }
}
