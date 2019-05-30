using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garden.API.Data;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Garden.API
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
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                        sqlOptions.CommandTimeout(90);
                    });
                }, ServiceLifetime.Scoped
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(
                    IdentityServerAuthenticationDefaults.AuthenticationScheme,
                    jwtOptions =>
                    {
                        jwtOptions.Authority = Common.API.EndPoints.IdentityServerUrl;
                        jwtOptions.RequireHttpsMetadata = false;

                        // This previously was: options.ApiName = scopeName;
                        jwtOptions.Audience = "Garden.API";

                        // Option 1: if you want to turn off issuer validation
                        //jwtOptions.TokenValidationParameters.ValidateIssuer = false;

                        // Option 2: if you want to support multiple issuers
                        jwtOptions.TokenValidationParameters.ValidIssuers = new[]
                        {
                            Common.API.EndPoints.IdentityServerUrl,
                            Common.API.EndPoints.IdentityServerUrl.Replace("http", "https")
                        };
                    },
                    null
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
        }
    }
}
