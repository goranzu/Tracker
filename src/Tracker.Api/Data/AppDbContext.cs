using Microsoft.EntityFrameworkCore;
using Tracker.Api.Data.Entities;

namespace Tracker.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Exercise> Exercises => Set<Exercise>();
}