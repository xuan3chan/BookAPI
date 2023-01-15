using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Bookman.Model;

namespace Bookman.Data
{
    public class BookmanContext : DbContext
    {
        public BookmanContext (DbContextOptions<BookmanContext> options)
            : base(options)
        {
        }

        public DbSet<Bookman.Model.BookModel> Book { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("data source = SCOPIAN\\SQLEXPRESS;initial catalog=bookdata ;" +
                "integrated security = True; MultipleActiveResultSets = True; App = EntityFramework");
        }
    }
}
