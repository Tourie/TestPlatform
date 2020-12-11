using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestPlatform.Infrastructure.Data;
using TestPlatform.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using TestPlatform.Services.Interfaces;
using TestPlatform.Services.ModelServices;
using Microsoft.AspNetCore.Identity;
using TestPlatform.Core;
using TestPlatform.WEB.Hubs;

namespace TestPlatform
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
            services.AddMvc();
            services.AddControllersWithViews();

            //connect to db
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connection));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            services.AddSignalR(hubOptions =>
            {
                hubOptions.EnableDetailedErrors = true;
                //hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(1);
            });

            services.AddAuthentication().AddGoogle(options =>
            {
                IConfigurationSection googleAuthNSection =
                Configuration.GetSection("Authentication:Google");

                options.ClientId = "147370545374-lprqjjo2r0u2d7eaqfncdssg5aai7dba.apps.googleusercontent.com";
                options.ClientSecret = "ljDqHr5Y_O-1s0PYRGrP86G-";
            });

            services.AddTransient(serviceProvider => Configuration);
            services.AddSingleton<EmailService>();
            services.AddScoped(typeof(IRepository<>), typeof(GenRepository<>));
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ITestService, TestService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<ITestResultService, TestResultService>();
            services.AddTransient<ICommentService, CommentService>();
        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {/*
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();*/
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHsts();
            }
            else
            {
                app.UseExceptionHandler("/Exception");
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/Error/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "admin",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

                endpoints.MapHub<CommentsHub>("/comments");
            });
        }
    }
}