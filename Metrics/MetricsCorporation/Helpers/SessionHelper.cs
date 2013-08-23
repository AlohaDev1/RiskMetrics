using System.Web;
using MetricsCorporation.Models;

namespace MetricsCorporation.Helpers
{
    public class SessionHelper
    {
        private static UserModel currentUser;

        public static bool LoggedIn
        {
            get
            {
                return CurrentUser != null;
            }
        }

        public static UserModel CurrentUser
        {
            get
            {
                return currentUser;
            }
            set
            {
                currentUser = value;
            }
        }

        public static void DropSession(HttpSessionStateBase session)
        {
            currentUser = null;
            session["company_id"] = null;
        }
    }
}