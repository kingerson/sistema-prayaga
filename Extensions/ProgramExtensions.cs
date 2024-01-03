using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.OpenApi.Models;
using SistemaPrayaga.Application;
using SistemaPrayaga.Infrastructure;


namespace SistemaPrayaga
{
    [ExcludeFromCodeCoverage]
    public static class ProgramExtensions
    {
        public static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder builder)
        {
            #region Serialisation

                _ = builder.Services.Configure<JsonOptions>(opt =>
                {
                    opt.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    opt.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    opt.SerializerOptions.PropertyNameCaseInsensitive = true;
                    opt.SerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString;
                    opt.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    opt.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                });

            #endregion Serialisation

            #region Swagger

                var ti = CultureInfo.CurrentCulture.TextInfo;

                _ = builder.Services.AddControllers().AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.WriteIndented = true;
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString;

                });

                _ = builder.Services.AddEndpointsApiExplorer();
                _ = builder.Services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1",
                        new OpenApiInfo
                        {
                            Version = "v1",
                            Title = $"API Sistema Prayaga - {ti.ToTitleCase(builder.Environment.EnvironmentName)} ",
                            Description = "Sistema Prayaga - Gestion de Prayaga.",
                            Contact = new OpenApiContact
                            {
                                Name = "Gerson Navarro",
                                Email = "g.navarrope@gmail.com",
                                Url = new Uri("https://github.com/kingerson")
                            }
                        });

                    options.DocInclusionPredicate((name, api) => true);
                });

            #endregion Swagger

            #region Project Dependencies
            _ = builder.Services.AddHttpContextAccessor();

            _ = builder.Services.AddApplication(builder.Configuration);
            _ = builder.Services.AddInfrastructure(builder.Configuration);
            
            #endregion

            _ = builder.Services.AddHttpClient();

            _ = builder.Services.AddCors();
            return builder;
        }

        public static WebApplication ConfigureApplication(this WebApplication app)
        {

            #region Swagger

                _ = app.UseSwagger();
                _ = app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"Sistema Prayaga - V1"));

            #endregion Swagger

            #region Security

            _ = app.UseHsts();

            #endregion Security

            _ = app.UseRouting();
            _ = app.UseAuthorization();
            _ = app.UseHttpsRedirection();
            _ = app.MapControllers();

            _ = app.UseCors(builder => builder.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                                    );

            return app;
        }
    }
}