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

    [Route("DodajSalu/{kapacitet}/{adresa}/{cena}")]
    [HttpPost]
    public async Task<ActionResult> DodajS(int kapacitet, string adresa, int cena)
    {
        try
        {
            var s = new Sala
            {
                Kapacitet = kapacitet,
                Adresa = adresa,
                Cena = cena
            };
            Context.Sale.Add(s);
            await Context.SaveChangesAsync();
            return Ok("Sala je uspesno dodata!");

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("PocetniPrikaz")]
    [HttpGet]
    public async Task<ActionResult> Prikaz()
    {
        try
        {
            return Ok(await Context.Sale.Select(p => new
            {
                id = p.ID,
                cena = p.Cena,
                kapacitet = p.Kapacitet,
                adresa = p.Adresa
            }).ToListAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("IznajmiSalu/{ime}/{prezime}/{jmbg}/{datum}/{id}")]
    [HttpPost]
    public async Task<ActionResult> Iznajmi(string ime, string prezime, int jmbg, DateTime datum, int id)
    {
        try
        {
            var k = new Korisnik
            {
                Ime = ime,
                Prezime = prezime,
                JMBG = jmbg
            };

            Context.Korisnici.Add(k);
            await Context.SaveChangesAsync();

            var s = await Context.Sale.FindAsync(id);
            var e = new Evidencija
            {
                Datum = datum,
                Korisnik = k,
                Sala = s,
                Iznajmljena = true
            };

            Context.Evidencije.Add(e);
            await Context.SaveChangesAsync();

            return Ok();


        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("Filtriraj/{cena}/{kapacitet}/{slobodna}/{datum}")]
    [HttpGet]
    public async Task<ActionResult> Filtriraj(int cena, int kapacitet, bool slobodna, DateTime datum)
    {
        try
        {
            DateTime dt = new DateTime(2023, 6, 5);
            if (datum == dt)
            {
                if (kapacitet == 0)
                {
                    return Ok(await Context.Sale.Where(p => p.Cena <= cena)
                    .Select(p => new
                    {
                        id = p.ID,
                        kapacitet = p.Kapacitet,
                        adresa = p.Adresa,
                        cena = p.Cena,
                        iznajmljena = "?"
                    })
                    .ToListAsync());
                }
                else if (cena == 0)
                {
                    return Ok(await Context.Sale.Where(p => p.Kapacitet <= kapacitet)
                    .Select(p => new
                    {
                        id = p.ID,
                        kapacitet = p.Kapacitet,
                        adresa = p.Adresa,
                        cena = p.Cena,
                        iznajmljena = "?"
                    }).ToListAsync());
                }
                else
                {
                    return Ok(await Context.Sale.Where(p => p.Cena <= cena && p.Kapacitet <= kapacitet)
                    .Select(p => new
                    {
                        id = p.ID,
                        kapacitet = p.Kapacitet,
                        adresa = p.Adresa,
                        cena = p.Cena,
                        iznajmljena = "?"
                    }).ToListAsync());
                }
            }

            if (slobodna == false)
            {
                if (kapacitet == 0 && cena == 0)
                {
                    var ret = await Context.Sale.Include(p => p.Evidencije)
                     .Select(p => new
                     {
                         id = p.ID,
                         kapacitet = p.Kapacitet,
                         adresa = p.Adresa,
                         cena = p.Cena,
                         iznajmljena = (p.Evidencije.Where(s => s.Datum == datum).FirstOrDefault() == null) ? false : true
                     })
                     .ToListAsync();
                    return Ok(ret);

                }
                if (kapacitet == 0)
                {
                    var ret = await Context.Sale.Include(p => p.Evidencije)
                        .Where(p => p.Cena <= cena)
                     .Select(p => new
                     {
                         id = p.ID,
                         kapacitet = p.Kapacitet,
                         adresa = p.Adresa,
                         cena = p.Cena,
                         iznajmljena = (p.Evidencije.Where(s => s.Datum == datum).FirstOrDefault() == null) ? false : true
                     })
                     .ToListAsync();
                    return Ok(ret);
                }
                else if (cena == 0)
                {
                    var ret = await Context.Sale.Include(p => p.Evidencije)
                        .Where(p => p.Kapacitet <= kapacitet)
                     .Select(p => new
                     {
                         id = p.ID,
                         kapacitet = p.Kapacitet,
                         adresa = p.Adresa,
                         cena = p.Cena,
                         iznajmljena = (p.Evidencije.Where(s => s.Datum == datum).FirstOrDefault() == null) ? false : true
                     })
                     .ToListAsync();
                    return Ok(ret);
                }
                else
                {
                    var ret = await Context.Sale.Include(p => p.Evidencije)
                        .Where(p => p.Kapacitet <= kapacitet && p.Cena <= cena)
                     .Select(p => new
                     {
                         id = p.ID,
                         kapacitet = p.Kapacitet,
                         adresa = p.Adresa,
                         cena = p.Cena,
                         iznajmljena = (p.Evidencije.Where(s => s.Datum == datum).FirstOrDefault() == null) ? false : true
                     })
                     .ToListAsync();
                    return Ok(ret);
                }
            }
            else
            {
                if (kapacitet == 0 && cena == 0)
                {
                    var pom = await Context.Sale.Include(p => p.Evidencije)
                        .Where(p => p.Evidencije.Any(s => s.Datum == datum))
                        .ToListAsync();
                    var ret = await Context.Sale.Where(p => !pom.Contains(p))
                        .Select(p => new
                        {
                            id = p.ID,
                            kapacitet = p.Kapacitet,
                            adresa = p.Adresa,
                            cena = p.Cena,
                            iznajmljena = false
                        })
                        .ToListAsync();
                    return Ok(ret);
                }

                if (kapacitet == 0)
                {
                    var pom = await Context.Sale.Include(p => p.Evidencije)
                        .Where(p => p.Evidencije.Any(s => s.Datum == datum))
                        .ToListAsync();
                    var ret = await Context.Sale.Where(p => !pom.Contains(p) && p.Cena <= cena)
                        .Select(p => new
                        {
                            id = p.ID,
                            kapacitet = p.Kapacitet,
                            adresa = p.Adresa,
                            cena = p.Cena,
                            iznajmljena = false
                        })
                        .ToListAsync();
                    return Ok(ret);
                }
                else if (cena == 0)
                {
                    var pom = await Context.Sale.Include(p => p.Evidencije)
                        .Where(p => p.Evidencije.Any(s => s.Datum == datum))
                        .ToListAsync();
                    var ret = await Context.Sale.Where(p => !pom.Contains(p) && p.Kapacitet <= kapacitet)
                        .Select(p => new
                        {
                            id = p.ID,
                            kapacitet = p.Kapacitet,
                            adresa = p.Adresa,
                            cena = p.Cena,
                            iznajmljena = false
                        })
                        .ToListAsync();
                    return Ok(ret);
                }
                else
                {
                    var pom = await Context.Sale.Include(p => p.Evidencije)
                        .Where(p => p.Evidencije.Any(s => s.Datum == datum))
                        .ToListAsync();
                    var ret = await Context.Sale.Where(p => !pom.Contains(p) && p.Cena <= cena && p.Kapacitet <= kapacitet)
                        .Select(p => new
                        {
                            id = p.ID,
                            kapacitet = p.Kapacitet,
                            adresa = p.Adresa,
                            cena = p.Cena,
                            iznajmljena = false
                        })
                        .ToListAsync();
                    return Ok(ret);
                }
            }

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
