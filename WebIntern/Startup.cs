using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebIntern.Models;
using WebIntern.Services;

namespace WebIntern
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<NhanVienService>();
            services.AddDbContext<EmpManagerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectEmpManager")));
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

