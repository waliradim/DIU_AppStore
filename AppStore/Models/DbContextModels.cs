using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AppStore.Models;
using System.Data.Entity.Infrastructure;

namespace AppStore.Models
{

    public class DbContextModels:DbContext
    {
        public DbContextModels()
            : base("name=DbContext")
        {
        }
        public virtual DbSet<UserRegInfoModel> UserRegInfoModels { get; set; }
        public virtual DbSet<AdminModels> AdminModelses { get; set; }
    }
}