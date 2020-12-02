using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EStoreApp.Models
{
    public class clsAccount
    {
        public int AccountId { get; set; }
        public string TokenId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public bool? Status { get; set; }
        public string Email { get; set; }
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
        public string CompnayName { get; set; }
        public string UrduName { get; set; }
        public int? ReferenceAccountId { get; set; }

        public string ReferenceName { get; set; }
        public string State { get; set; }

        public int? CityId { get; set; }
        public string CityName { get; set; }

        public string PostalCode { get; set; }
        public string Address { get; set; }
       
        public string Type { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? DocumentId { get; set; }
        public string ImagePath { get; set; }
        public string StatusString { get; set; }
        public DateTime? CreatedDate { get; set; }
        public String CreatedByString { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedByString { get; set; }

    }
}