using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Treinamentos.Persistencia;

namespace Treinamentos.View
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = CreateHostBuilder(args).Build();
      using(var scope = host.Services.CreateScope())
      {
        var servicos = scope.ServiceProvider;
        try
        {
          var context = servicos.GetRequiredService<TreinamentosContext>();
          context.Database.Migrate(); 
        }
        catch (Exception ex)
        {

          var logger = servicos.GetRequiredService<ILogger<Program>>();
          logger.LogError(ex, "Problemas ao criar o banco de dados.");
        }
      }
      host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
