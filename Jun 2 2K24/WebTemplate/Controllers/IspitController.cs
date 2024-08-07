namespace WebTemplate.Controllers;

[ApiController]
[Route("[controller]")]
public class IspitController : ControllerBase
{
    public IspitContext Context { get; set; }

    public IspitController(IspitContext context)
    {
        Context = context;
    }
    [Route("DodajZnamenitost/{naziv}/{cena}")]
    [HttpPost]
    public async Task<ActionResult> DodajZ(string naziv, int cena)
    {
        try
        {
            var znamenitost = new Znamenitost
            {
                Naziv = naziv,
                Cena = cena
            };
            Context.Znamenitosti.Add(znamenitost);
            await Context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("Znamenitosti")]
    [HttpGet]
    public async Task<ActionResult> Znamenitosti()
    {
        try
        {
            return Ok(await Context.Znamenitosti.Select(z => new
            {
                id = z.ID,
                naziv = z.Naziv,
                cena = z.Cena
            }).ToListAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("DodajTuru/{ime}/{prezime}/{licna}/{znamenitosti}")]
    [HttpPost]
    public async Task<ActionResult> Upisi(string ime, string prezime, int licna, string znamenitosti)
    {
        try
        {
            var znamenitostiIDs = znamenitosti.Split('$')
                .Where(x => int.TryParse(x, out _))
                .Select(int.Parse)
                .ToList();


            var znamenitostii = Context.Znamenitosti.Where(z => znamenitostiIDs.Contains(z.ID));

            var tureSaZnamenitostima = await Context.Ture
                .Include(t => t.Znamenitosti)
                .Where(t => t.Znamenitosti.Any(z => znamenitostiIDs.Contains(z.ID)))
                .ToListAsync();
            var tura = tureSaZnamenitostima.FirstOrDefault(t =>
                 t.Znamenitosti.Select(z => z.ID).OrderBy(id => id).SequenceEqual(znamenitostiIDs.OrderBy(id => id)));


            if (tura != null)
            {
                if (tura.PreostaloMesta == 0)
                {
                    return StatusCode(201, "Sto to brate moj");
                }
                tura.PreostaloMesta -= 1;
                Context.Ture.Update(tura);
                await Context.SaveChangesAsync();
            }
            if (tura == null)
            {
                var cena = 0;
                foreach (var znamenitost in znamenitostii)
                {
                    cena += znamenitost.Cena;
                }
                tura = new Tura
                {
                    Cena = cena,
                    PreostaloMesta = 5
                };
                Context.Ture.Add(tura);
                await Context.SaveChangesAsync();

                foreach (var znamenitost in znamenitostii)
                {
                    var zt = new ZnamenitostTura
                    {
                        ZnamenitostID = znamenitost.ID,
                        Turaid = tura.ID
                    };
                    Context.ZnamenitostTure.Add(zt);

                }
                await Context.SaveChangesAsync();
            }

            var korisnik = new Korisnik
            {
                Ime = ime,
                Prezime = prezime,
                Licna = licna
            };
            Context.Korisnici.Add(korisnik);
            await Context.SaveChangesAsync();

            var kt = new KorisnikTura
            {
                KorisnikID = korisnik.ID,
                TuraID = tura.ID
            };
            Context.KorisnikTure.Add(kt);
            await Context.SaveChangesAsync();

            return Ok(tura);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Route("Ture")]
    [HttpGet]
    public async Task<ActionResult> Ture()
    {
        try
        {
            return Ok(await Context.Ture
                .Include(p => p.Znamenitosti)
                .Select(p => new
                {
                    id = p.ID,
                    cena = p.Cena,
                    slobodno = p.PreostaloMesta,
                    znamenitosti = p.Znamenitosti.Select(z => new
                    {
                        id = z.ID,
                        naziv = z.Naziv,
                        cena = z.Cena
                    })
                }).ToListAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


}
