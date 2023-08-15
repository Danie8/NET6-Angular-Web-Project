using Microsoft.EntityFrameworkCore;
using NET6_Angular_Web_Project.Data;
using NET6_Angular_Web_Project;
using Microsoft.Extensions.Configuration;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

Log4netConfiguration.Configure(); // M�todo que configura log4net desde 'log4net.config'

// Ruta correcta al archivo 'NET6ANGULARAPPLICATION.ini'
string iniFilePath = @"C:\NET6ANGULARAPPLICATION\NET6ANGULARAPPLICATION.ini";

// Carga las variables desde el archivo 'NET6ANGULARAPPLICATION.ini'
var configBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddIniFile(iniFilePath);
var config = configBuilder.Build();

// Agrega la configuraci�n al constructor de la aplicaci�n
builder.Configuration.AddConfiguration(config);

// Utiliza la cadena de conexi�n desde el archivo 'NET6ANGULARAPPLICATION.ini'
var connectionString = config["Database:ConnectionString"];
if (connectionString == null)
{
    throw new Exception($"No se pudo leer la cadena de conexi�n desde el archivo '{iniFilePath}'.");
}

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Agrega la cadena de conexi�n de la base de datos y el DbContext al contenedor de inyecci�n de dependencias
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Use the CORS policy
app.UseCors("EnableCORS");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});

app.MapFallbackToFile("index.html");

app.Run();
