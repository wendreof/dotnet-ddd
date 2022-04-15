using System;
using Api.CrossCutting.DependencyInjection;
using Api.Domain.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace application
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
      ConfigureService.ConfigureDependencyService(services);
      ConfigureRepository.ConfigureDependencyRepository(services);

      var signingConfigurations = new SigningConfigurations();
      services.AddSingleton(signingConfigurations);

      var tokenConfigurations = new TokenConfigurations();
      new ConfigureFromConfigurationOptions<TokenConfigurations>(Configuration.GetSection("TokenConfigurations"))
      .Configure(tokenConfigurations);

      services.AddSingleton(tokenConfigurations);

      services.AddAuthentication(authOptions =>
      {
        authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(bearerOptions =>
      {
        var paramsValidation = bearerOptions.TokenValidationParameters;
        paramsValidation.IssuerSigningKey = signingConfigurations.Key;
        paramsValidation.ValidAudience = tokenConfigurations.Audience;
        paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

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
        ui.RoutePrefix = String.Empty;
      });

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
