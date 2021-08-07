using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortalApi.ViewModel
{
    public class Register
    {
        public Guid RegisterId { get; set; }
        public string RegType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string EmailId { get; set; }
        public string PersonalNumber { get; set; }
        public string UserName { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CityId { get; set; }
        public string Password { get; set; }
        public string DataOfBirth { get; set; }
        public string Gender { get; set; }
        public string PinCode { get; set; }
        public string Address { get; set; }
        public string Url { get; set; }
    }

}
