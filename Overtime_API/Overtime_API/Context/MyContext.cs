using Microsoft.EntityFrameworkCore;
using Overtime_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime_API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Limitation> Limitations { get; set; }
        public DbSet<OvertimeApplication> OvertimeApplications { get; set; }
        public DbSet<OvertimeData> OvertimeDatas { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountRole>()
                .HasKey(ar => new { ar.AccountNIK, ar.RoleID });

            modelBuilder.Entity<AccountRole>()
                .HasOne(ar => ar.Role)
                .WithMany(r => r.AccountRole)
                .HasForeignKey(ar => ar.RoleID);

            modelBuilder.Entity<AccountRole>()
                .HasOne(ar => ar.Account)
                .WithMany(a => a.AccountRoles)
                .HasForeignKey(ar => ar.AccountNIK);

            modelBuilder.Entity<Employee>()
                .HasOne(employee => employee.Account)
                .WithOne(account => account.Employee)
                .HasForeignKey<Account>(account => account.NIK);

<<<<<<< Updated upstream
            modelBuilder.Entity<Employee>()
                .HasOne(employee => employee.ParentEmployee)
                .WithMany(employees => employees.ChildEmployee)
                .HasForeignKey(employee => employee.NIKManager);

=======
>>>>>>> Stashed changes
            modelBuilder.Entity<Employee>()
               .HasOne(employee => employee.Position)
               .WithMany(position => position.Employees)
               .HasForeignKey(employee => employee.PositionID);

            modelBuilder.Entity<Employee>()
               .HasOne(employee => employee.Client)
               .WithMany(client => client.Employees)
               .HasForeignKey(employee => employee.ClientID);

            modelBuilder.Entity<Employee>()
               .HasOne(employee => employee.Department)
               .WithMany(department => department.Employees)
               .HasForeignKey(employee => employee.DepartmentID);

            modelBuilder.Entity<Employee>()
               .HasOne(employee => employee.OvertimeData)
               .WithOne(od => od.Employee)
               .HasForeignKey<OvertimeData>(od => od.NIK);

            modelBuilder.Entity<OvertimeApplication>()
               .HasOne(oa => oa.OvertimeData)
               .WithMany(od => od.OvertimeApplication)
               .HasForeignKey(oa => oa.OvertimeID);

            modelBuilder.Entity<Limitation>()
               .HasOne(limitation => limitation.OvertimeApplication)
               .WithMany(oa => oa.Limitations)
               .HasForeignKey(limitation => limitation.OvertimeApplicationID);

            modelBuilder.Entity<Activity>()
               .HasOne(activity => activity.OvertimeApplication)
               .WithMany(oa => oa.Activities)
               .HasForeignKey(activity => activity.OvertimeApplicationID);

        }
        

    }
}
