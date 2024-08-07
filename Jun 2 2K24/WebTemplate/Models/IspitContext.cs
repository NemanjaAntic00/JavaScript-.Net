namespace WebTemplate.Models;

public class IspitContext : DbContext
{
    // DbSet kolekcije!
    public DbSet<Tura> Ture { get; set; }
    public DbSet<Korisnik> Korisnici { get; set; }
    public DbSet<Znamenitost> Znamenitosti { get; set; }
    public DbSet<KorisnikTura> KorisnikTure { get; set; }
    public DbSet<ZnamenitostTura> ZnamenitostTure { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Korisnik>()
            .HasMany(k => k.Ture)
            .WithMany(t => t.Korisnici)
            .UsingEntity<KorisnikTura>(
                m => m.HasOne(kt => kt.Tura)
                    .WithMany()
                    .HasForeignKey(kt => kt.TuraID),

                m => m.HasOne(kt => kt.Korisnik)
                    .WithMany()
                    .HasForeignKey(kt => kt.KorisnikID),
                m => m.HasKey(kt => new { kt.KorisnikID, kt.TuraID })

            );


        modelBuilder.Entity<Znamenitost>()
            .HasMany(k => k.Ture)
            .WithMany(t => t.Znamenitosti)
            .UsingEntity<ZnamenitostTura>(
                m => m.HasOne(kt => kt.Tura)
                    .WithMany()
                    .HasForeignKey(kt => kt.Turaid),

                m => m.HasOne(kt => kt.Znamenitost)
                    .WithMany()
                    .HasForeignKey(kt => kt.ZnamenitostID),
                m => m.HasKey(kt => new { kt.ZnamenitostID, kt.Turaid })

            );
    }

    public IspitContext(DbContextOptions options) : base(options)
    {

    }
}
