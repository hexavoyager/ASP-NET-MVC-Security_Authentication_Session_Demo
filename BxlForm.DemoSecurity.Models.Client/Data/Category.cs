using System;
using System.Collections.Generic;
using System.Text;

namespace BxlForm.DemoSecurity.Models.Client.Data
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; set; }

        public Category(string name)
        {
            Name = name;
        }

        internal Category(int id, string name)
            : this(name)
        {
            Id = id;
        }
    }
}
