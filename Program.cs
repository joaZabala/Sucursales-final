using Microsoft.EntityFrameworkCore;
using repasoFinal2daMesa.data;
using repasoFinal2daMesa.Mapper;
using repasoFinal2daMesa.repositories;
using repasoFinal2daMesa.services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//AGREGAR LA DEPENDCIA DEL CONTEXTDB PARA LA CONEXION
builder.Services.AddDbContext<ContextDb>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion"));
});

//SE AGREGA LOS SERVICES
builder.Services.AddScoped<SucursalesService>();


builder.Services.AddScoped<SucursalesRepository>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
