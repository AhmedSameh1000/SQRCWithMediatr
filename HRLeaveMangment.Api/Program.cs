using HRLeaveMangment.Application;
using HRLeaveMangment.Application.Models;
using HRLeaveMangment.Infrastructure;
using HRLeaveMangment.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("Stripe"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .ConfigurePersistenceServices(builder.Configuration)
    .ConfigureInfrastructureServices(builder.Configuration)
    .ConfigureApplicationServices();
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