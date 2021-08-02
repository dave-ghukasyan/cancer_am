using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CancerAM.Models
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => $"{FirstName} {LastName}"; }
        public string Password { get; set; }
        public bool IsSuperUser { get; set; }
        public string Username { get; set; }
    }
}
