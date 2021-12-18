using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using OnboardingSoftware.Core;
using OnboardingSoftware.Core.Services;
using OnboardingSoftware.Data;
using OnboardingSoftware.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using OnboardingSoftware.Core.Models.Auth.MyMusic.Core.Models.Auth;
using Microsoft.AspNetCore.Identity;
using OnboardingSoftware.Api.Settings;
using OnboardingSoftware.Api.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace OnboardingSoftware.Api
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

            var jwtSettings = Configuration.GetSection("Jwt").Get<JwtSettings>();
            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));
            services.AddAuth(jwtSettings);

            services.AddControllers(opt =>
            {
                var policy = new AuthorizationPolicyBuilder("Bearer").RequireAuthenticatedUser().Build();
                opt.Filters.Add(new AuthorizeFilter(policy));
            }).AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnboardingSoftware.Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });
                var security =
                    new OpenApiSecurityRequirement
                    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                },
                UnresolvedReference = true
            },
            new List<string>()
        }
                    };
                c.AddSecurityRequirement(security);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAplikantService, AplikantService>();
            services.AddTransient<IPosaoService, PosaoService>();
            services.AddTransient<ITestService, TestService>();
            services.AddTransient<IPitanjeService, PitanjeService>();
            services.AddTransient<IOdgovorService, OdgovorService>();

            services.AddDbContext<OnboardingSoftwareDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("OnboardingSoftware.Data")));

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = true;
                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
                //options.Lockout.MaxFailedAccessAttempts = 5;
            }).AddEntityFrameworkStores<OnboardingSoftwareDbContext>().AddDefaultTokenProviders();


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnboardingSoftware.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuth();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
