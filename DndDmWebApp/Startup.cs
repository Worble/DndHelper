using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using DndDmHelperData.UnitOfWork.Interface;
using DndDmHelperData.UnitOfWork;
using DndDmHelperData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Routing;

namespace DndDmWebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<DndDmHelperContext, DndDmHelperContext>();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromHours(1);
                options.Cookie.HttpOnly = true;
            });

            services.AddAuthentication(o =>
            {
                o.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                o.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.Cookie.Name = "AuthCookie";
                    options.AccessDeniedPath = "/forbidden";
                    options.LoginPath = "/login";
                    options.LogoutPath = "/logout";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                    options.SlidingExpiration = true;
                    options.Events = new CookieAuthenticationEvents
                    {
                        OnValidatePrincipal = Helper.ValidateAsync
                    };
                });

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                             .RequireAuthenticatedUser()
                             .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStatusCodePagesWithReExecute("/error/{0}");

            app.UseSession();

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                if (!serviceScope.ServiceProvider.GetService<DndDmHelperContext>().AllMigrationsApplied())
                {
                    serviceScope.ServiceProvider.GetService<DndDmHelperContext>().Database.Migrate();
                }
                serviceScope.ServiceProvider.GetService<DndDmHelperContext>().EnsureSeeded();
            }

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "notes",
                    template: "game/{gameID}/notes/{action}/{id?}",
                    defaults: new { controller = "Note", action = "Index" });

                routes.MapRoute(
                    name: "game_create_character",
                    template: "game/{gameID}/addcharacter/{action?}/{id?}",
                    defaults: new { controller = "Character" });

                routes.MapRoute(
                    name: "game_create",
                    template: "game/create",
                    defaults: new { controller = "Game", action = "Create" });

                routes.MapRoute(
                    name: "game_index",
                    template: "game",
                    defaults: new { controller = "Game", action = "Index" });

                routes.MapRoute(
                    name: "game",
                    template: "game/{id?}/{action?}",
                    defaults: new { controller = "Game" , action="Detail" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Game", action = "Index"},
                    constraints: new { controller = new NotEqual("Note") });
            });
        }
    }

    public class NotEqual : IRouteConstraint
    {
        private string _match = String.Empty;

        public NotEqual(string match)
        {
            _match = match;
        }

        public bool Match(HttpContext httpContext, IRouter route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return String.Compare(values[parameterName].ToString(), _match, true) != 0;
        }
    }
}

