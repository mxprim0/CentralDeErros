using CentralDeErros.Api.Models;
using CentralDeErros.Api.Services;
using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using CentralDeErros.Api.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeErros.Api
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
            services.AddMvcCore().AddJsonFormatters();

            services.AddDbContext<ErrorDbContext>();
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddScoped<IEnvironment, EnvironmentService>();
            services.AddScoped<IErrorOccurrence, ErrorOccurrenceService>();
            services.AddScoped<IError, ErrorService>();
            services.AddScoped<ILevel, LevelService>();
            services.AddScoped<ISituation, SituationService>();
            services.AddScoped<IUser, UserService>();
            services.AddDbContext<ErrorDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CentralDeErros")));

            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<Users>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidAudience = appSettings.ValidoEm,
                    ValidIssuer = appSettings.Emissor,
                    ClockSkew = TimeSpan.Zero,
                };
            });

            services.AddAuthorization(options => {options.AddPolicy("Bearer", new AuthorizationPolicyBuilder().AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build());});
            }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvcWithDefaultRoute();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();    
        }
    }
}
