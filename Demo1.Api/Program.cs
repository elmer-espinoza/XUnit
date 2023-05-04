using Demo1.Api.Data;
using Demo1.Api.Services;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<MyWorldDbContext>(options =>
//{
//	options.UseSqlServer(builder.Configuration.GetConnectionString("MyWorldDbConnection"));
//});

builder.Services.AddDbContext<MyWorldDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MyConn")));

//builder.Services.AddDbContext<MyWorldDbContext>(opt => opt.UseSqlServer("Server = (local); Database = Facturacion; User Id = sa; Password = poison; TrustServerCertificate = True"));

builder.Services.AddScoped<ITodoService, TodoService>();

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
