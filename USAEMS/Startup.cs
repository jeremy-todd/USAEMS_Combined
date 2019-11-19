using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using USAEMS.Infrastructure.Data;
using USAEMS.Core.Models;
using USAEMS.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;

namespace USAEMS
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
            //services.AddDbContext<AppDbContext>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            //Usr SQL database if in Azure, otherwise use SQLite
            /*if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
                services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("USAEMSDbConnection")));
            else*/
                services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source = ../USAEMS.Infrastructure/usaems.db"));

            services.BuildServiceProvider().GetService<AppDbContext>().Database.Migrate();

            //Add Identity services
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            //Add JWT support
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IIncidentRepository, IncidentRepository>();
            services.AddScoped<IIncidentService, IncidentService>();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseMvc();

            //create admin user if it doesn't already exist
            //SeedAdminUser(userManager, roleManager);
        }

        private void SeedAdminUser(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //create a SuperAdmin role if it doesn't alreadt exist
            //SuperAdmin can do anything, see anything, and see all users
            if (roleManager.FindByNameAsync("SuperAdmin").Result == null)
            {
                var superAdminRole = new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin".ToUpper()
                };
                var result = roleManager.CreateAsync(superAdminRole).Result;
            }

            //create an Admin role if it doesn't already exist
            //Admin can do anything, see anything, but only see users that have the same EmployerId as them
            if (roleManager.FindByNameAsync("Admin").Result == null)
            {
                var adminRole = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                };
                var result = roleManager.CreateAsync(adminRole).Result;
            }

            //create a Supervisor role if it doesn't already exist
            //Supervisor can manage users with the same EmployerId as them
            if (roleManager.FindByNameAsync("Supervisor").Result == null)
            {
                var supervisorRole = new IdentityRole
                {
                    Name = "Supervisor",
                    NormalizedName = "Supervisor".ToUpper()
                };
                var result = roleManager.CreateAsync(supervisorRole).Result;
            }

            //create a IncidentSubmit role if it doesn't already exist
            //IncidentSubmit can create, edit, and submit incident reports
            if (roleManager.FindByNameAsync("IncidentSubmit").Result == null)
            {
                var incidentSubmitRole = new IdentityRole
                {
                    Name = "IncidentSubmit",
                    NormalizedName = "IncidentSubmit".ToUpper()
                };
                var result = roleManager.CreateAsync(incidentSubmitRole).Result;
            }

            //create a NotifySubmit role if it doesn't already exist
            //NotifySubmit can create and send notifications
            if (roleManager.FindByNameAsync("NotifySubmit").Result == null)
            {
                var notifySubmitRole = new IdentityRole
                {
                    Name = "NotifySubmit",
                    NormalizedName = "NotifySubmit".ToUpper()
                };
                var result = roleManager.CreateAsync(notifySubmitRole).Result;
            }

            //create a StudentManager role if it doesn't already exist
            //StudentManager can submit student manager checklists
            if (roleManager.FindByNameAsync("StudentManager").Result == null)
            {
                var studentManagerRole = new IdentityRole
                {
                    Name = "StudentManager",
                    NormalizedName = "StudentManager".ToUpper()
                };
                var result = roleManager.CreateAsync(studentManagerRole).Result;
            }

            //create a StudentManagerAdmin role if it doesn't already exist
            //StudentManagerAdmin can make users StudentManager and remove StudentManager from users
            if (roleManager.FindByNameAsync("StudentManagerAdmin").Result == null)
            {
                var studentManagerAdminRole = new IdentityRole
                {
                    Name = "StudentManagerAdmin",
                    NormalizedName = "StudentManagerAdmin".ToUpper()
                };
                var result = roleManager.CreateAsync(studentManagerAdminRole).Result;
            }

            //create a Student role if it doesn't already exist
            //TODO: define what Student role can do
            if (roleManager.FindByNameAsync("Student").Result == null)
            {
                var studentRole = new IdentityRole
                {
                    Name = "Student",
                    NormalizedName = "Student".ToUpper()
                };
                var result = roleManager.CreateAsync(studentRole).Result;
            }

            //create a SuperAdmin user if it doesn't already exist
            if (userManager.FindByNameAsync("superadmin").Result == null)
            {
                AppUser user = new AppUser
                {
                    UserName = "superadmin@usaems.net",
                    Email = "superadmin@usaems.net"
                };

                //add the SuperAdmin user to the SuperAdmin role
                IdentityResult result = userManager.CreateAsync(user, "SuperAdminUSAEMS1234!").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "SuperAdmin").Wait();
                }
            }

            //create an IncidentSubmit user if it doesn't already exist
            if (userManager.FindByNameAsync("incidentsubmit").Result == null)
            {
                AppUser user = new AppUser
                {
                    UserName = "incidents@usaems.net",
                    Email = "incidents@usaems.net"
                };

                //add the IncidentSubmit user to the IncidentSubmit role
                IdentityResult result = userManager.CreateAsync(user, "IncidentSubmit1234!").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "IncidentSubmit").Wait();
                }
            }
        }
    }
}