using api.middleware;
using AutoMapper;
using core.interfaces;
using inftastructer;
using inftastructer.Repository.Services;
using StackExchange.Redis;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InfrastructureConfiguration(builder.Configuration);
builder.Configuration.AddUserSecrets<Program>();
builder.Services.AddScoped<ICustomerBasketService, CustomerBasketService>();
// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddScoped<core.interfaces.ICustomerBasketService, inftastructer.Repository.Services.CustomerBasketService>();
builder.Services.AddMemoryCache();


// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
        policy.WithOrigins("http://localhost:5239") 
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials());
});

builder.Services.AddScoped<core.interfaces.IBasketRepository, inftastructer.Repository.CustomerBasketRepository>();
builder.Services.AddSingleton<StackExchange.Redis.IConnectionMultiplexer>(sp =>
    ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")));

        var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ExceptionsMiddleware>();

app.MapControllers();

app.Run();

