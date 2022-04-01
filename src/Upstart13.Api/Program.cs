using MediatR;
using Upstart13.Api.Controllers;
using Upstart13.Api.Filters;
using Upstart13.Application.AutoMapper;
using Upstart13.Application.Notifications;
using Upstart13.Infrastructure;
using Upstart13.Infrastructure.ExternalCommunication.Common;
using Upstart13.Infrastructure.ExternalCommunication.CommunicationService;
using Upstart13.Infrastructure.ExternalCommunication.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ApiExceptionFilter));
    options.Filters.Add(typeof(NotificationFilter));
});
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddMediatR(typeof(BaseApiController));
builder.Services.AddMediatR(typeof(AutoMapperProfile));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.Configure<ExternalUrls>(
    builder.Configuration.GetSection("ExternalUrls"));
builder.Services.AddScoped<NotificationContext>();
builder.Services.AddScoped<ISendRequest, SendRequest>();
builder.Services.AddScoped<IWeatherService, WeatherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthorization();

app.MapControllers();

app.Run();
