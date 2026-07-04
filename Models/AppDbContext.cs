using Microsoft.EntityFrameworkCore;

namespace AppMvcTeste.Models;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Produto> Produtos { get; set; }
}