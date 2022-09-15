using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCarlosCajasAPI.Models;

namespace TestCarlosCajasAPI.Data
{
    public class EnterpriseDbContext : DbContext
    {
        public EnterpriseDbContext(DbContextOptions<EnterpriseDbContext>options):base(options)
        {

        }
        public DbSet<EnterpriseModel> enterpriseModels { get; set; }
        public DbSet<DepartmentModel> departmentModels { get; set; }
        public DbSet<EmployeeModel> employeeModels { get; set; }
        public DbSet<Department_EmployeeModel> department_EmloyeeModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnterpriseModel>().ToTable("tbl_enterprises");
            modelBuilder.Entity<DepartmentModel>().ToTable("tbl_departments");
            modelBuilder.Entity<EmployeeModel>().ToTable("tbl_employees");
            modelBuilder.Entity<Department_EmployeeModel>().ToTable("tbl_departments_employees");

        }

    }
}
