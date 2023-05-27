using ASPNETLabCourse.Database;
using ASPNETLabCourse.Interfaces;
using ASPNETLabCourse.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ASPNETLabCourse
{
    public class Startup
    {
        private IConfigurationRoot _confString;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("dbsetting.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string conn = _confString.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContent>(options => options.UseMySql(conn, ServerVersion.AutoDetect(conn)));
            services.AddControllersWithViews();
            services.AddTransient<IShoesCategory, CategoryRepository>();
            services.AddTransient<IAllShoes, ShoesRepository>();
            services.AddMvc(mvcOptions => {
                mvcOptions.EnableEndpointRouting = false;
             });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("/Shoes/List");
                }
                else
                {
                    await next();
                }
            });
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDbContent content = scope.ServiceProvider.GetRequiredService<AppDbContent>();
                //content.Database.Migrate();
                DbObjects.Initial(content);
            }
        }
    }
}