using System;
using Api.CrossCutting.DependencyInjection;
using Api.CrossCutting.Mappings;
using Api.Domain.Models;
using Api.Domain.Security;
using AutoMapper;
using Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {

            Configuration = configuration;
            Environment = environment;

            //Project Settings
            Settings.ConnectionString = Configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            Settings.Migration = Configuration.GetValue<string>("Migrations:Migration");
            Settings.Issuer = Configuration.GetValue<string>("TokenConfigurations:Issuer");
            Settings.Audience = Configuration.GetValue<string>("TokenConfigurations:Audience");
            Settings.Seconds = Configuration.GetValue<string>("TokenConfigurations:Seconds");

            if (Environment.IsEnvironment("Testing"))
            {
                Settings.ConnectionString = "Persist Security Info=True;Server=localhost;Port=3306;Database=testedb_integration;Uid=root;Password=WendreoFernandes!";
                Settings.Migration = "Aplicar";
                Settings.Issuer = "Issuer";
                Settings.Audience = "ExemploAudience";
                Settings.Seconds = "288000";
            }
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            ConfigureService.ConfigureDependencyService(services);
            ConfigureRepository.ConfigureDependencyRepository(services);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = Settings.Audience;
                paramsValidation.ValidIssuer = Settings.Issuer;

                // Valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = true;

                // Verifica se um token recebido ainda é válido
                paramsValidation.ValidateLifetime = true;

                // Tempo de tolerância para a expiração de um token (utilizado
                // caso haja problemas de sincronismo de horário entre diferentes
                // computadores envolvidos no processo de comunicação)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
            .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
            .RequireAuthenticatedUser().Build());
            });

            services.AddControllers();

            services.AddSwaggerGen(gen =>
              {
                  gen.SwaggerDoc("v1", new OpenApiInfo
                  {
                      Title = ".NET Core Api",
                      Version = "v1",
                      Description = "DDD arch",
                      TermsOfService = new Uri("https://github.com/wendreof/dotnet-ddd"),
                      Contact = new OpenApiContact
                      {
                          Name = "@wendreof",
                          Email = "wendreolf@gmail.com",
                          Url = new Uri("https://github.com/wendreof/dotnet-ddd"),
                      },
                      License = new OpenApiLicense
                      {
                          Name = "MIT",
                          Url = new Uri("https://github.com/wendreof/dotnet-ddd"),
                      }
                  });

                  gen.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                  {
                      Description = "Type the JWT Bearer Token this way: Bearer {your entire JWT Token (without de brackets)}",
                      Name = "Authorization",
                      In = ParameterLocation.Header,
                      Type = SecuritySchemeType.ApiKey,
                      Scheme = "Bearer"
                  });

                  gen.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
            {
              new OpenApiSecurityScheme
              {
                Reference = new OpenApiReference
                {
                  Type = ReferenceType.SecurityScheme,
                  Id = "Bearer"
                }
              },
              new string[] {}
            }
                });
              });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(ui =>
            {
                ui.SwaggerEndpoint("/swagger/v1/swagger.json", ".NET Core with DDD");
                ui.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (Settings.Migration.ToLower() == "aplicar")
            {
                try
                {
                    using var service = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
                    var context = service.ServiceProvider.GetService<MyContext>();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("=/ Migration error: " + ex.Message);
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
