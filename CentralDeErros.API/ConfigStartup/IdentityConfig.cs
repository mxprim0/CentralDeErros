using Microsoft.Extensions.DependencyInjection;
using CentralDeErros.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System;

namespace CentralDeErros.API.ConfigStartup
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<SigningConfigurations, SigningConfigurations>();

            // JWT
            // acesso à seção do arq appsetiings
            var tokenSettingsSection = configuration.GetSection("AppSettings");

            // config com parametros
            services.Configure<TokenSettings>(tokenSettingsSection);
            // cast para objeto
            var appSettings = tokenSettingsSection.Get<TokenSettings>();

            // chave gerada 
            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenSettings();
            new ConfigureFromConfigurationOptions<TokenSettings>(tokenSettingsSection).Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);

            // config autenticação e Bearer
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
                    IssuerSigningKey = signingConfigurations.Key,
                    ValidAudience = appSettings.ValidoEm,
                    ValidIssuer = appSettings.Emissor,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            return services;
        }
    }
}
