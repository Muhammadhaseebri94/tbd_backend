using Entities.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Context
{
    public class ApplicationDbContext:IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        { 
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CallStatus> CallStatuses { get; set; }
        public DbSet<DialSheet> DialSheets { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<Addendum> Addendums { get; set; }
        public DbSet<CallHistory> CallHistories { get; set; }
        public DbSet<DialSheetCompany> DialSheetCompanies { get; set; }
        public DbSet<DialSheetAgent> DialSheetAgents { get; set; }
        public DbSet<RemarksOption> RemarksOptions { get; set; }
        public DbSet<EmployeeMonthlyRemarks> EmployeeMonthlyRemarks { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CallStatus>().HasData(
                new CallStatus {Id=1, Status = "Call Back" },
                new CallStatus { Id = 2, Status = "Not Available" },
                new CallStatus { Id = 3, Status = "Interested" },
                new CallStatus { Id = 4, Status = "Voice Mail" },
                new CallStatus { Id = 5, Status = "Do Not Call" },
                new CallStatus { Id = 6, Status = "Purchased" }
                );
            builder.Entity<ProjectType>().HasData(
                new ProjectType { Id = 1, ProjectTypeName = "TOD" },
                new ProjectType { Id = 2, ProjectTypeName = "Normal" }
                );
            builder.Entity<IdentityRole>().HasData(
               new IdentityRole { Name="Super Admin",NormalizedName= "SUPER ADMIN"},
               new IdentityRole { Name="Data Manager",NormalizedName="DATA MANAGER"},
               new IdentityRole { Name="HR Manager",NormalizedName="HR MANAGER"},
               new IdentityRole { Name="Data Entry",NormalizedName="DATA ENTRY"},
               new IdentityRole { Name="Project Manager",NormalizedName="PROJECT MANAGER"},
               new IdentityRole { Name="QTO Estimator MEP",NormalizedName="QTO ESTIMATOR MEP"},
               new IdentityRole { Name = "QTO Estimator CIVIL",NormalizedName="QTO ESTIMATOR CIVIL"},
               new IdentityRole { Name = "QTO Estimator BOTH",NormalizedName="QTO ESTIMATOR BOTH"},
               new IdentityRole { Name = "QTO Estimator QC",NormalizedName="QTO ESTIMATOR QC"},
               new IdentityRole { Name = "Cost Estimator MEP",NormalizedName="COST ESTIMATOR MEP"},
               new IdentityRole { Name = "Cost Estimator CIVIL",NormalizedName="COST ESTIMATOR  CIVIL"},
               new IdentityRole { Name = "Cost Estimator BOTH",NormalizedName="COST ESTIMATOR BOTH"},
               new IdentityRole { Name="Sales Leader",NormalizedName="SALES LEADER"},
               new IdentityRole { Name = "Sales Agent TBD",NormalizedName="SALES AGENT TBD"},
               new IdentityRole { Name = "Sales Agent SUBBIDDING",NormalizedName="SALES AGENT SUBBIDDING"},
               new IdentityRole { Name = "Sales Agent BUILDCROFTTRADING",NormalizedName="SALES AGENT BUILDCROFTTRADING"}
               );
            builder.Entity<RemarksOption>().HasData(
               new RemarksOption { Id = 1, OptionValue = "Exceeds Expectations"},
               new RemarksOption { Id = 2, OptionValue = "Meets Expectations"},
               new RemarksOption { Id = 3, OptionValue = "Needs Improvement"},
               new RemarksOption { Id = 4, OptionValue = "Satisfactory Performance"},
               new RemarksOption { Id = 5, OptionValue = "Below Expectations"}
               );
            builder.Entity<MenuItem>().HasData(
              new MenuItem { Id = 1, Name = "Dashboard",Parent=false,ParentName=null, Route= "/dashboard", Icon= "dashboard" },
              new MenuItem { Id = 2, Name = "Projects List", Parent = false, ParentName = null, Route = "/projects-list", Icon = "engineering" },
              new MenuItem { Id = 3, Name = "Users List", Parent = false, ParentName = null, Route = "/users-list", Icon = "people" },
              new MenuItem {Id = 4, Name = "Companies List", Parent = false, ParentName = null, Route = "/companies-list", Icon = "business" },
              new MenuItem {Id = 5, Name = "Table List", Parent = false, ParentName = null, Route = "/table-list", Icon = "content_paste" }
              );

        }
    }
}
