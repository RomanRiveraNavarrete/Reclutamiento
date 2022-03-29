using API_Equipo1.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
//Hola
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(r =>
{
    r.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API de Tacos",
        Description = "Diferentes sucursales de tacos"
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    r.IncludeXmlComments(xmlPath);
});

//conexion a BD
builder.Services.AddDbContext<ContextTacos>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.AddCors(options => options.AddPolicy("AlloWebApp",builder=>builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AlloWebApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
