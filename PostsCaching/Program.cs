using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PostsCaching.Database;
using PostsCaching.Models.Dtos;
using PostsCaching.Repositories;
using PostsCaching.Services;
using PostsCaching.Utils.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddDbContext<PostsDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("pgsConnectionString"))
    )
    .AddScoped<IPostsService, PostsService>()
    .AddScoped<IPostsRepository, PostsRepository>()
    .AddScoped<IValidator<PostDto>, PostDtoValidator>()
    .AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

// Ensuring database exists and up to date
using (IServiceScope serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    PostsDbContext context = serviceScope.ServiceProvider.GetRequiredService<PostsDbContext>();

    context.Database.Migrate();
}

app.MapControllers();

app.Run();
