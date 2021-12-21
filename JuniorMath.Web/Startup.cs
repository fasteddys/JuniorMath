﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JuniorMath.Infrastructure.Data;
using JuniorMath.Infrastructure.Identity;
using JuniorMath.ApplicationCore.Interfaces.Repository;
using JuniorMath.Infrastructure.Data.Repository.Base;
using JuniorMath.Infrastructure.Services.Email;
using JuniorMath.ApplicationCore.Domain.User;
using JuniorMath.ApplicationCore.Interfaces.Services.Users;
using JuniorMath.ApplicationCore.Services.Users;
using JuniorMath.ApplicationCore.Interfaces.Services.Utiliites;
using JuniorMath.ApplicationCore.Services.Utiliites;
using JuniorMath.ApplicationCore.Interfaces.Base;
using JuniorMath.Infrastructure.Configuration.Sms;
using JuniorMath.Infrastructure.Services.SMS;
using JuniorMath.Infrastructure.Configuration.Identity;
using JuniorMath.Infrastructure.Configuration.Email;
using JuniorMath.RazorClassLib.Services;
using JuniorMath.Web.Interfaces;
using JuniorMath.Web.Services;
using JuniorMath.Infrastructure.Configuration.SiteSettings;
using JuniorMath.ApplicationCore.Interfaces.Services.ExaminationPaper;
using JuniorMath.ApplicationCore.Services.ExaminationPaper;

namespace JuniorMath.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<JuniorMathContext>(options =>
           options.UseSqlServer(
               Configuration.GetConnectionString("DefaultConnection")
               , b => b.MigrationsAssembly("JuniorMath.Infrastructure")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")
                    , b => b.MigrationsAssembly("JuniorMath.Infrastructure")));


            // Get Identity Default Options
            IConfigurationSection identityDefaultOptionsConfigurationSection = Configuration.GetSection("IdentityDefaultOptions");

            services.Configure<IdentityDefaultOptions>(identityDefaultOptionsConfigurationSection);

            var identityDefaultOptions = identityDefaultOptionsConfigurationSection.Get<IdentityDefaultOptions>();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                  .AddEntityFrameworkStores<ApplicationDbContext>()
                  .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(24);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Set configuration options
            SetConfigurationOptions(services);

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddTransient<IEmailSender, EmailSender>();

            ConfigureThirdPartyService(services);
            ConfigureApplicatiojnService(services);
            ConfigureWebService(services);

            // Add DI for Dotnetdesk
            services.AddTransient<INetcoreService, NetcoreService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddSessionStateTempDataProvider();
            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromHours(24);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
            //services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<UserHandler>();
            services.AddSingleton<WebUserHandler>();

            services.AddTransient<ISmsSender, TwilioAuthMessageSender>();;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            // IMPORTANT: This session call MUST go before UseMvc()
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void SetConfigurationOptions(IServiceCollection services)
        {
            services.Configure<SiteSettingsOptions>(Configuration.GetSection("SiteSettingsOptions"));
            services.Configure<SmtpOptions>(Configuration.GetSection("SmtpOptions"));
            services.Configure<SMSoptions>(Configuration.GetSection("TwilioAccountDetails"));
            services.Configure<SendGridOptions>(Configuration.GetSection("SendGridOptions"));
        }

        private void ConfigureThirdPartyService(IServiceCollection services)
        {
        }

        private void ConfigureWebService(IServiceCollection services)
        {
            //services.AddScoped<IRazorViewToStringRenderer, RazorViewToStringRenderer>();
        }

        private void ConfigureApplicatiojnService(IServiceCollection services)
        {
            services.AddScoped<IUtilityService, UtilityService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IExamService, ExamService>();
        }
    }
}
