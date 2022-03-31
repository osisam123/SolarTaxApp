using System;
using System.Collections.Generic;

namespace SolarTaxApp.Shared.Models
{
    public partial class UserTb
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
