﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace 期中專題
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MedSysEntities : DbContext
    {
        public MedSysEntities()
            : base("name=MedSysEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BlogCategory> BlogCategories { get; set; }
        public virtual DbSet<BlogManagement> BlogManagements { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Corporation> Corporations { get; set; }
        public virtual DbSet<EmployeeClass> EmployeeClasses { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<HealthReport> HealthReports { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderPay> OrderPays { get; set; }
        public virtual DbSet<OrderShip> OrderShips { get; set; }
        public virtual DbSet<OrderState> OrderStates { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<PlanRef> PlanRefs { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductsCategory> ProductsCategories { get; set; }
        public virtual DbSet<ProductsClassification> ProductsClassifications { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ReportDetail> ReportDetails { get; set; }
        public virtual DbSet<Reserve> Reserves { get; set; }
        public virtual DbSet<ReservedSub> ReservedSubs { get; set; }
        public virtual DbSet<subProjectBridge> subProjectBridges { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ItemRangeWord> ItemRangeWords { get; set; }
    }
}
