using Microsoft.EntityFrameworkCore;
using portfolio.Models;

namespace portfolio.dbcontext
{
    public class dbcontextf: DbContext
    {                       

        public dbcontextf(DbContextOptions<dbcontextf> options) : base(options) {
        
       
        }
            public DbSet<submitmodel> contactFormSubmissions { get; set; }
    }
}
