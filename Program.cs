using Portfolio.Models;
using Portfolio.Repositories;
using Portfolio.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<Academics>, AcademicsRepository>();
builder.Services.AddScoped<IService<Academics>, AcademicsService>();

builder.Services.AddScoped<IRepository<Experience>, ExperienceRepository>();
builder.Services.AddScoped<IService<Experience>, ExperienceService>();

builder.Services.AddScoped<IRepository<Skills>, SkillsRepository>();
builder.Services.AddScoped<IService<Skills>, SkillsService>();

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("AllowReactApp");

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
