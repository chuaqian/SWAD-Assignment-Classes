using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWADAssgClasses
{
    public class User
    {
        public string userId { get; set; }
        public string fullName { get; set; }
        public string contactDetails { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool isVerified { get; set; }

        public User(string userId, string fullName, string contactDetails, string email, string password, bool isVerified)
        {
            this.userId = userId;
            this.fullName = fullName;
            this.contactDetails = contactDetails;
            this.email = email;
            this.password = password;
            this.isVerified = isVerified;
        }
    }
}
