using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using domain;


namespace infra.Data
  
{
    public class KpmContext : DbContext
    {
        public KpmContext(DbContextOptions<KpmContext> options)
        : base(options)
        {
        }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<domain.Function> Functions { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<DepartmentFunction> DepartmentFunctions { get; set; }
        public DbSet<domain.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(KpmContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
