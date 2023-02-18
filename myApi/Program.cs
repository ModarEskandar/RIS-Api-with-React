using Microsoft.EntityFrameworkCore;
using Data;
using Data.Models;
using Microsoft.OpenApi.Models;
using Configurations;
using Data.IRepository;
using Data.Repositories;
using myApi;
using Serilog;
using Services;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File(
    path: Environment.CurrentDirectory.ToString() + "\\Logs\\log-.txt",
    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3} {Message:lj} {NewLine} {Exception}]",
    rollingInterval: RollingInterval.Day,
    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information
    ).CreateLogger();
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
builder.Services.AddAuthorization();
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder =>
    {
        builder.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:3000", "https://appname.azurestaticapps.net");
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(typeof(MapperInitializer));
builder.Services.AddDbContext<RISDbContext>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOptions =>
{
    swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP.Net React", Version = "v1" });
});
// builder.Services.AddDbContext<PatientsDbContext>(options=>options.UseOracle(
//     builder.Configuration.GetConnectionString("DefaultConnection")
// ));
builder.Services.ConfigureIdentity();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(SwaggerUIOptions =>
{
    SwaggerUIOptions.DocumentTitle = "ASP.Net REact.";
    SwaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Web Api Serving Simple Patient Model");
    SwaggerUIOptions.RoutePrefix = string.Empty;
});
app.ConfigureExceptionHandler();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseCors("CORSPolicy");

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    // endpoints.MapControllerRoute(
    //     name: "default",
    //     pattern: "{controller=Home}/{action=Index}/{id?}"
    // );
    endpoints.MapControllers();
});
app.MapGet("/get-all-patients", async () => await PatientsRepository.GetPatientsAsync())
.WithTags("Patients Endpoints");
app.MapGet("/get-patient-by-id/{patientId}", async (int patientId) =>
{
    Patient patient = await PatientsRepository.GetPatientByIdAsync(patientId);
    return (patient != null) ? Results.Ok(patient) : Results.BadRequest();
}).WithTags("Patients Endpoints");
app.MapPost("/create-patient", async (Patient patient) =>
{
    bool patientCreatedSuccessfully = await PatientsRepository.CreatePatientAsync(patient);
    return (patientCreatedSuccessfully) ? Results.Ok("Patient Created Successfully") : Results.BadRequest();
}).WithTags("Patients Endpoints");
app.MapPut("/update-patient", async (Patient patient) =>
{
    bool patientUpdatedSuccessfully = await PatientsRepository.UpdatePatientAsync(patient);
    return (patientUpdatedSuccessfully) ? Results.Ok("Patient Updated Successfully") : Results.BadRequest();
}).WithTags("Patients Endpoints");
app.MapDelete("/delete-patient/{patientId}", async (int patientId) =>
{
    bool patientDeletedSuccessfully = await PatientsRepository.DeletePatientAsync(patientId);
    return (patientDeletedSuccessfully) ? Results.Ok("Patient Deleted Successfully") : Results.BadRequest("not");
}).WithTags("Patients Endpoints");

try
{
    Log.Information("Application Is Starting");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application Failed to Start");
}
finally
{
    Log.CloseAndFlush();
}