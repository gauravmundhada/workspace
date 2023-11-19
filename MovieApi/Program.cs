using Microsoft.EntityFrameworkCore;
using MovieAppapi.Models;
 
var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
 
builder.Services.AddControllers();
 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var connectionString = builder.Configuration.GetConnectionString("mycon");
builder.Services.AddDbContext<MovieContext>(options => options.UseSqlServer(connectionString));
 
 
 
builder.Services.AddCors(
    option =>
    {
        option.AddDefaultPolicy(builder =>
        {
            builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
        });
    });
 
 
 
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
app.UseRouting();
app.UseCors();
 
app.UseAuthorization();
 
app.MapControllers();
 
app.Run();