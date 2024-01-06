using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using WebChatSignalR.BL.Hubs;
using WebChatSignalR.DAL.DbModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var migrationsAssembly = typeof(DefaultDbContext).Assembly.ToString();
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnectionString");
IdentityModelEventSource.ShowPII = true;
builder.Services.AddDbContext<DefaultDbContext>(options =>
    options.UseSqlServer(connectionString,
        b => b.MigrationsAssembly(migrationsAssembly)));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

var app = builder.Build(); 


app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();