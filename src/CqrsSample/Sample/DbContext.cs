using System;
using System.Collections.Generic;

namespace CqrsSample.Sample
{
    public class DbContext
    {
        public List<User> Users { get; } = new List<User>();
    }

    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}