﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppStore.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DIU_App_StoreEntities : DbContext
    {
        public DIU_App_StoreEntities()
            : base("name=DIU_App_StoreEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tbl_AssignCourse> Tbl_AssignCourse { get; set; }
        public virtual DbSet<Tbl_Course> Tbl_Course { get; set; }
        public virtual DbSet<Tbl_File> Tbl_File { get; set; }
        public virtual DbSet<Tbl_Level> Tbl_Level { get; set; }
        public virtual DbSet<Tbl_Project> Tbl_Project { get; set; }
        public virtual DbSet<Tbl_Semester> Tbl_Semester { get; set; }
        public virtual DbSet<Tbl_Student> Tbl_Student { get; set; }
        public virtual DbSet<Tbl_Teacher> Tbl_Teacher { get; set; }
        public virtual DbSet<tbl_UserInfo> tbl_UserInfo { get; set; }
        public virtual DbSet<Tbl_Level_CourseModels> Tbl_LevelCourse { get; set; }
    }
}
