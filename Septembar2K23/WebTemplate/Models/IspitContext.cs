namespace WebTemplate.Models;

public class IspitContext : DbContext
{
    // DbSet kolekcije!
    public DbSet<Prodavnica> Prodavnice { get; set; }
    public DbSet<Sastojak> Sastojci { get; set; }
    public DbSet<Zarada> Zarade { get; set; }

    public IspitContext(DbContextOptions options) : base(options)
    {

    }
}
