using Model.BaseInfo;
using Caspian.Common;
using Model.AcceptingInfo;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class Context : MyContext
    {
        public DbSet<Province> Provinces { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<StudentCodeFormula> StudentCodeFormulas { get; set; }

        public DbSet<FormulToken> FormulTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
