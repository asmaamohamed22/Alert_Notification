using Microsoft.EntityFrameworkCore;
using MANotification.Models;
using MANotification.Hubs;
using MANotification.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<INotificationRepository, NotificationRepository>();

builder.Services.AddCors();

builder.Services.AddSignalR();

// DB
var connectionString = builder.Configuration.GetConnectionString("MAConection");
builder.Services.AddDbContext<MAContext>(option => option.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors(x => x.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()
.AllowCredentials());

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<UserHub>("/notify");
});



app.MapControllers();

app.Run();
