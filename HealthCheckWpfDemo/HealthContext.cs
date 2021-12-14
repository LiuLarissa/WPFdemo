using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace HealthCheckWpfDemo
{
    public class HealthContext :DbContext
    {
        private readonly string connectionString = "Server=localhost;uid=root;pwd=xxxx;port=3306;Database=d_healthcheck;charset=utf8";
        public DbSet<BloodItem> bloodItems { get; set; }
        public DbSet<CancerItem> cancerItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BloodItem>()
                .HasMany(b => b.details)
                .WithOne()
                .HasForeignKey(i => i.bloodItemId);

            builder.Entity<CancerItem>()
                .HasMany(c => c.treatments)
                .WithOne()
                .HasForeignKey(i => i.cancerItemid);
        }

        
    }
}
