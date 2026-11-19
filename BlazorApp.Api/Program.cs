// Program.cs - sets up services and request pipeline for BlazorApp.Api
using BlazorApp.Api.Bus;
using BlazorApp.Api.Commands;
using BlazorApp.Api.Handlers;
using BlazorApp.Api.MappingProfiles;
using BlazorApp.Api.Queries;
using BlazorApp.Web.Data;
using BlazorApp.Web.Data.Models;
using LiteBus;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add framework services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(NimsProfile));
builder.Services.AddSingleton<ILiteBus, SimpleLiteBus>();

// Register MongoDB + ApplicationDbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
var databaseName = builder.Configuration["MongoDB:DatabaseName"] ?? "Incidents";
builder.Services.AddSingleton<IMongoClient>(_ => new MongoClient(connectionString));
builder.Services.AddSingleton<IMongoDatabase>(sp =>
    sp.GetRequiredService<IMongoClient>().GetDatabase(databaseName));
builder.Services.AddSingleton<ApplicationDbContext>();

// Allow the Blazor Web frontend to call this API
builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorWebPolicy", policy =>
        policy.WithOrigins("https://localhost:7016", "http://localhost:5065")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// Register CQRS handlers
builder.Services.AddTransient<IQueryHandler<GetAllNimsQuery, List<ApplicationNims>>, GetAllNimsQueryHandler>();
builder.Services.AddTransient<IQueryHandler<GetNimsByIdQuery, ApplicationNims?>, GetNimsByIdQueryHandler>();
builder.Services.AddTransient<ICommandHandler<CreateNimsCommand>, CreateNimsCommandHandler>();
builder.Services.AddTransient<ICommandHandler<UpdateNimsCommand>, UpdateNimsCommandHandler>();
builder.Services.AddTransient<ICommandHandler<DeleteNimsCommand>, DeleteNimsCommandHandler>();

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
