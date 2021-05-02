using Bookshelf.ACore.Abstract;
using Bookshelf.ACore.Concrete;
using Bookshelf.Business.Abstract;
using Bookshelf.Business.Concrete;
using Bookshelf.DataAccess.Abstract;
using Bookshelf.DataAccess.Concrete;
using Bookshelf.WebUI.Services.Abstract;
using Bookshelf.WebUI.Services.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IUserSessionService, UserSessionService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IUserDal, UserDal>();
            services.AddScoped<IBookshelfDal, BookshelfDal>();
            services.AddScoped<IBookshelfService, BookshelfService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccessRoleService, AccessRoleService>();
            services.AddScoped<IAccessRoleDal, AccessRoleDal>();
            services.AddScoped<IBookDal, BookDal>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookPageService, BookPageService>();
            services.AddScoped<IBookPageDal, BookPageDal>();


            services.AddSession();
            services.AddDistributedMemoryCache();

            services.AddMvc(option=>option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSession();


            app.UseMvc(routes => {
                routes.MapRoute("default","{controller=Home}/{action=Index}/{ID?}");
            });
            //app.UseMvcWithDefaultRoute();
        }
    }
}
