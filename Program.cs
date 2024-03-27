using Microsoft.EntityFrameworkCore;
using Trainingym.Bussines;
using Trainingym.Bussines.Interface;
using Trainingym.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<TrainingymContext>(options => 
options.UseSqlServer(connectionString)
);
builder.Services.AddScoped<IMember, MemberBussines>();
builder.Services.AddScoped<IProduct, ProductBussines>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
