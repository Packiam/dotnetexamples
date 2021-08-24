using MVC.Samples.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Samples.Data
{
    public class MyDatabase : DbContext
    {
        public DbSet<UserRegistration> userRegistrations { get; set; }

        public MyDatabase() { }
        public MyDatabase(string connectionString) : base(connectionString) { }
    }

    public class MyNewDatabase : DbContext
    {
        public DbSet<UserRegistration> userRegistrations { get; set; }

        public MyNewDatabase() { }
        public MyNewDatabase(string connectionString) : base(connectionString) { }
    }
}
