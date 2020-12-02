using System;
using System.Collections.Generic;
using System.Text;

namespace EStoreApp.Models
{
    public class clsUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
        public string Email { get; set; }
        public string CNIC { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Type { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

       
        public string ConfirmPassword { get; set; }

    }
}
