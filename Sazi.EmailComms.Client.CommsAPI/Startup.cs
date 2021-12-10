using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Sazi.EmailComms.Core.DomainServices;
using Sazi.EmailComms.Core.Model;
using Sazi.EmailComms.Core.Repository;
using Sazi.EmailComms.Infrastructure.Data;
using Sazi.EmailComms.Services;
using Sazi.EmailComms.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sazi.EmailComms.Client.CommsAPI
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
           
            services.AddControllers();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddDbContext<CommsDBContext>(e => { e.UseSqlServer(Configuration.GetConnectionString("Default")); });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", Configuration["AppSettings:Scope"]);
                });
            });
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddJwtBearer(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = Configuration["AppSettings:IdentityProviderUrl"];

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sazi.EmailComms.Client.CommsAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sazi.EmailComms.Client.CommsAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
