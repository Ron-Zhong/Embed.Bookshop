using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Embed.Bookshop.Entities;

namespace Embed.Bookshop
{
    public partial class DBContext : DbContext
    {
        #region Contstructors
        protected string ConnectionString { get; init; }
        public DBContext()
        {
        }
        public DBContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        #endregion

        #region DbSets
        public DbSet<Order> Orders { get; set; }
        public DbSet<Bookstore> Bookstores { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        #endregion

        #region EntityFrameworkCore
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connStr = "Server=tcp:embeddb.database.windows.net,1433;Initial Catalog=bookshop;Persist Security Info=False;User ID=embedadm;Password=Iloveembed99!!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                optionsBuilder.UseSqlServer(connStr, builder => builder.EnableRetryOnFailure());
            }

#if DEBUG
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
#endif
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
        #endregion
    }
}
