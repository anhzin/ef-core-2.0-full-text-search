using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators;
using Microsoft.EntityFrameworkCore.Query.Sql;
using StudyEfCore.Generators;
using StudyEfCore.Models;
using StudyEfCore.Translators;

namespace StudyEfCore
{
    public class EfCoreContext : DbContext
    {
        public DbSet<Product> Product { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<FtsResult> Fts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=hungd\\HUNGD;Initial Catalog=FTS;Integrated Security=True;MultipleActiveResultSets=True")
                .ReplaceService<ICompositeMethodCallTranslator, FtsCompositeTranslator>()
                .ReplaceService<IQuerySqlGeneratorFactory, FtsQuerySqlGeneratorFactory>();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().ToTable("Products");
            base.OnModelCreating(modelBuilder);
        }

        public IQueryable<FtsResult> FullTextSearch()
        {
            return Fts.FromSql("SELECT [Key] as Id, [Rank] FROM Freetexttable(Product, Title, 'Product')");
        }
    }
}
