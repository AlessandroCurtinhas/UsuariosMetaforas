using MetaforasUserID.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaforasUserID.Infra.Contexts
{
    public class DbPostgresContext : DbContext
    {
      //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      //{
      //    optionsBuilder.UseNpgsql(@"User ID = AplicacaoAPI; Password = Admin@123456; Host = localhost; Port = 7777; Database = MetaforasUserAPI; Pooling = true;");

      //}
        public DbPostgresContext(DbContextOptions<DbPostgresContext> options)
              : base(options) { }

        public DbSet<Usuario>? Usuario { get; set; }
        public DbSet<Historico>? Historico { get; set; }
    }
}
