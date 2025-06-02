using Scalar.AspNetCore;
using Serilog;

namespace MovieMate.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);
                // Configure Serilog
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .Enrich.FromLogContext()
                    .CreateLogger();
                builder.Host.UseSerilog();

                // Add services to the container.
                builder.Services.AddControllers();
                builder.Services.AddApplicationServices();

                // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
                builder.Services.AddOpenApi();

                var app = builder.Build();
                app.UseStaticFiles();

                //Add support to logging request with SERILOG
                app.UseSerilogRequestLogging();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    // -> /openapi/v1.json
                    app.MapOpenApi();
                    // -> /scalar/v1
                    app.MapScalarApiReference(options =>
                    {
                        options.Theme = ScalarTheme.BluePlanet;
                        options.EnabledClients = [ScalarClient.HttpClient, ScalarClient.Axios, ScalarClient.Fetch];
                    });
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();

                app.MapControllers();

                await app.RunAsync();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "An error occurred while starting the application.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }

}
