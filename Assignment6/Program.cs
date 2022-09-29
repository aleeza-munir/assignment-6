using Assignment6.Models;
//using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Assignment6.Services.Characters;
using Assignment6.Services.Movies;
using Assignment6.Services.Franchises;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<CharacterService>();
builder.Services.AddTransient<MovieService>();
builder.Services.AddTransient<FranchiseService>();
builder.Services.AddDbContext<MovieCharactersDBContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MovieCharacterDb"));
});
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo //Fix this later, add some more documentations
    {
        Version = "v1",
        Title = "Movie Character Franchise API",
        Description = "Assignment 6 API"
    });
    opt.IncludeXmlComments(xmlPath);
});

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