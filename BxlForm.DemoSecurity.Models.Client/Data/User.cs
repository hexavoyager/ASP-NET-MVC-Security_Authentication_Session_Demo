using System;
using System.Collections.Generic;
using System.Text;

namespace BxlForm.DemoSecurity.Models.Client.Data
{
    public class User
    {
        public int Id { get; private set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        internal string Passwd { get; private set; }
        public bool IsAdmin { get; private set; }

        public User(string lastName, string firstName, string email, string passwd)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Passwd = passwd;
        }

        internal User(int id, string lastName, string firstName, string email, bool isAdmin)
            : this(lastName, firstName, email, null)
        {
            Id = id;
            IsAdmin = isAdmin;
        }
    }
}
