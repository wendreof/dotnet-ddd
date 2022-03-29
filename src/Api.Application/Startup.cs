using System;
using Api.CrossCutting.DependencyInjection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

      app.UseWelcomePage();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
