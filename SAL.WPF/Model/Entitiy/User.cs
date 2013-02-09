using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAL.Model.Entitiy
{
    public class User
    {
        public string UID { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string UserType_CD { get; set; }
        public string status_flg { get; set; }
        public string ROLES { get; set; }
    }
}