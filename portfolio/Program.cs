using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using portfolio.dbcontext;





namespace portfolio
{
    public class Program
    {
        /*private readonly IConfiguration Configuration;
        public Program(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigurServices( IServiceCollection service)
        {
            service.AddRazorPages();

            
            service.AddDbContext<authDbContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));
        
            service.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<authDbContext>();
            service.ConfigureApplicationCookie(config => {

                config.LoginPath = "/Login";
            });
        }*/

        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<authDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<authDbContext>();
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Adminpolicy", policy => policy.RequireRole("Admin"));
            });
            builder.Services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath ="/auth/login";
                
                
                });





            builder.Services.AddDbContext<dbcontextf>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("defaultconnection"))
            .LogTo(Console.WriteLine,LogLevel.Information));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=home}/{id?}");

            app.Run();
        }
    }
}