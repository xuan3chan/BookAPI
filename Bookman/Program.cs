using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bookman.Data;
using Bookman.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookmanContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookmanContext") ?? throw new InvalidOperationException("Connection string 'BookmanContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options=>options.AddDefaultPolicy(policy=>policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddAutoMapper(typeof(Program));
//life cycle DI:AddSingleton(),Addtransient(),AddScoped();
builder.Services.AddScoped<IBook, Book>();
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
