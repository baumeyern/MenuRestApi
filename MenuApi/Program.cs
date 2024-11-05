using FluentAssertions.Common;
using MenuApi.DbContexts;
using MenuApi.DbContexts.Interfaces;
using MenuApi.Services;
using MenuApi.Services.Interfaces;
using MenuApi.Repositories;
using MenuApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Register services and repositories
builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddTransient<IMenuItemService, MenuItemService>();

//Register db context
builder.Services.AddDbContext<IMenuContext, MenuContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Add database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<IMenuContext>();
    if (!context.Database.CanConnect())
    {
        throw new NotSupportedException("Can't connect to database");
    }
}

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