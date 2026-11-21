// Program.cs - sets up services and request pipeline for BlazorApp.Api
using BlazorApp.Application;
using BlazorApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add framework services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Clean Architecture services
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// Allow the Blazor Web frontend to call this API
builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorWebPolicy", policy =>
        policy.WithOrigins("https://localhost:7016", "http://localhost:5065")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

// Always enable Swagger (restrict to Dev only before going to production)
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlazorApp.Api v1"));

if (app.Environment.IsDevelopment())
{
    // Dev-only middleware can go here
}

app.UseHttpsRedirection();
app.UseCors("BlazorWebPolicy");
app.UseAuthorization();
app.MapControllers();

app.Run();
