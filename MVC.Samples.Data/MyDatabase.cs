﻿using MVC.Samples.Data.Models;
using MVC.Samples.Data.Models.Ravi;
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
}
