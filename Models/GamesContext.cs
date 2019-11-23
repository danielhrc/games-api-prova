using Microsoft.EntityFrameworkCore;
namespace GamesAPI.Models
{
public class GamesContext : DbContext
{
public GamesContext(DbContextOptions<GamesContext> options)
: base(options)
{
}
public DbSet<GamesItem> GamesItems { get; set; }
}
}