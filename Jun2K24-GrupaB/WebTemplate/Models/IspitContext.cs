namespace WebTemplate.Models;

public class IspitContext : DbContext
{
    // DbSet kolekcije!
    public DbSet<Sala> Sale { get; set; }
    public DbSet<Korisnik> Korisnici { get; set; }
    public DbSet<Evidencija> Evidencije { get; set; }
    public IspitContext(DbContextOptions options) : base(options)
    {

    }
}
