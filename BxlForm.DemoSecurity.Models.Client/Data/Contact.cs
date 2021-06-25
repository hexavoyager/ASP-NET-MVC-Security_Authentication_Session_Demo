using System;
using System.Collections.Generic;
using System.Text;

namespace BxlForm.DemoSecurity.Models.Client.Data
{
    public class Contact
    {
        public int Id { get; private set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int CategoryId { get; set; }
        internal int UserId { get; private set; }

        public Contact(string lastName, string firstName, string email, int categoryId, int userId)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            CategoryId = categoryId;
            UserId = userId;
        }

        internal Contact(int id, string lastName, string firstName, string email, int categoryId, int userId)
            : this (lastName, firstName, email, categoryId, userId)
        {
            Id = id;
        }
    }
}
