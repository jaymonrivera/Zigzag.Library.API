using Microsoft.EntityFrameworkCore;
using Zigzag.Library.API.Model;

namespace Zigzag.Library.API.Infra.Data;

public class ZigzagDbContext : DbContext
{
    public ZigzagDbContext(DbContextOptions<ZigzagDbContext> options) : base(options) { }
    public DbSet<Book> Books { get; set; }

}
