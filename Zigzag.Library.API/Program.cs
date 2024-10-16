using Serilog;
using Zigzag.Library.API.Extns;
using Zigzag.Library.API.Infra.Logging;
using Zigzag.Library.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddZigzagServices();
builder.Services.AddZigzagAuthorization(builder.Configuration);

// Initialize Logging
ZigzagApiLog.Initialize();
var logger = ZigzagApiLog.CreateLogger<Program>();
var loggerFactory =  ZigzagApiLog.GetFactoryInstance();


builder.Host.UseSerilog();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();


app.UseMiddleware<LogContextMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
