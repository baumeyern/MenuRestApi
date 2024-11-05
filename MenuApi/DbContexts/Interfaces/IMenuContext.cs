using MenuApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MenuApi.DbContexts.Interfaces;

public interface IMenuContext
{
    DbSet<MenuItem> MenuItems { get; set; }
    DatabaseFacade Database { get; }
    int SaveChanges();
}