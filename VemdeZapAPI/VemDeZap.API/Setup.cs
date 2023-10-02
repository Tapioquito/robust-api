using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Reflection;
using VemdeZap.Domain.Commands.User.UserAdd;
using VemdeZap.Domain.Interfaces.Repositories;
using VemDeZap.API.Security;

namespace VemDeZap.API
{
    public class Setup
    {
        public const string ISSUER = "c1f5f42";
        public const string AUDIENCE = "c6bbbb645024";



        public static void ConfigureAuthentication(IServiceCollection services)
        {
            //Configuração do Token:

            var signingConfigurations = new SigninConfiguration();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfiguration
            {
                Audience = AUDIENCE,
                Issuer = ISSUER,
                Seconds = int.Parse(TimeSpan.FromDays(1).TotalSeconds.ToString())
            };
            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.SigningCredentials.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                //Valida assinatura de um Token recebido:
                paramsValidation.ValidateIssuerSigningKey = true;

                //Verifica se um token recebido ainda é válido:
                paramsValidation.ValidateLifetime = true;

                //Tempo de tolerância para a expiração de um token( utilizado
                //caso haja problemas de sincronismo de horário entre diferentes
                //computadores envolvidos no processo de coumincação):
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });
            //Ativa o uso do tokenh como forma de autorizar o acesso
            //a recursos deste projeto
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            
            services.AddCors();
        }
        public static void ConfigureMeadiatR(IServiceCollection services)
        {
            services.AddMediatR(typeof(Program).GetTypeInfo().Assembly, typeof(UserAddRequest).GetTypeInfo().Assembly);
        }
        public static void ConfigureRepositories(IServiceCollection services)
        {


            // services.AddScoped<PortalContext, PortalContext>();
            //services.AddTransient<IUnitofWork, UnitofWork>();

            services.AddTransient<IRepositoryUser, RepositoryUser>();
        }
        public static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "VemDeZap.API", Version = "v1" }));
        }
        public static void ConfigureMVC(IServiceCollection services)
        {
            services.AddMvc(options =>
            { })
                           ;
        }
    }
}
