using Microsoft.EntityFrameworkCore;
using BusinessLogic.Implement;
using BusinessLogic.Interface;
using WorkUnit.Implement;
using WorkUnit.Interface;
using Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<DataIRContext>(item => item.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IFactoryLogic, FactoryLogic>();
builder.Services.AddScoped<IFactoryAbstractRepository, FactoryAbstractRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());//mapper
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "FrontendUI",
        builder =>
        {
            builder.WithOrigins("*")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseDefaultFiles();
    app.UseStaticFiles();
}

app.UseCors("FrontendUI");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
