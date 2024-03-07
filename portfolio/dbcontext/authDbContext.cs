using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace portfolio.dbcontext
{
    public class authDbContext:IdentityDbContext
    {
        public authDbContext(DbContextOptions<authDbContext> options)
             : base(options)
        {
        }
    }
}
