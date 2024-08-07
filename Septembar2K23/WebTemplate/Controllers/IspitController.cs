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

    [Route("DodajProdavnicu/{ime}")]
    [HttpGet]
    public async Task<ActionResult> DodajP(string ime)
    {
        try
        {
            var p = new Prodavnica
            {
                Naziv = ime
            };
            Context.Prodavnice.Add(p);
            await Context.SaveChangesAsync();
            return Ok($"Prodavnica {ime} je uspesno dodata!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [Route("DodajSastojak/{ime}/{kolicina}/{cena}/{zaradaid}")]
    [HttpGet]
    public async Task<ActionResult> DodajS(string ime, int kolicina, int cena, int zaradaid)
    {
        try
        {
            var z = await Context.Zarade.FindAsync(zaradaid);
            var s = new Sastojak
            {
                Naziv = ime,
                Cena = cena,
                Kolicina = kolicina,
                Zarade = z
            };
            Context.Sastojci.Add(s);
            await Context.SaveChangesAsync();
            return Ok($"Sastojak {ime} je uspesno dodat!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Route("ImaDovoljnoSastojka/{id}/{kolicina}")]
    [HttpGet]
    public async Task<ActionResult> Proveri(int id, int kolicina)
    {
        try
        {
            var s = await Context.Sastojci.FindAsync(id);
            if (s != null)
            {
                if (s.Kolicina < kolicina)
                {
                    return BadRequest();
                }
                if (s.Kolicina > kolicina)
                {
                    s.Kolicina -= kolicina;
                    await Context.SaveChangesAsync();
                    return Ok();
                }
                if (s.Kolicina == kolicina)
                {
                    s.Kolicina -= kolicina;
                    await Context.SaveChangesAsync();
                    return StatusCode(201);
                }
            }
            return StatusCode(202);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("DodajZaradu/{id}/{zarada}")]
    [HttpPut]
    public async Task<ActionResult> Dodajz(int id, int zarada)
    {
        try
        {
            var z = await Context.Zarade.FindAsync(id);
            if (z != null)
            {
                z.Pazar += zarada;
                await Context.SaveChangesAsync();
                return Ok(z.Pazar);
            }
            return BadRequest();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("Prikaz")]
    [HttpGet]
    public async Task<ActionResult> Prikaz()
    {
        try
        {
            return Ok(await Context.Zarade
                        .Include(p => p.Prodavnica)
                        .Include(p => p.Sastojci)
                        .Select(p => new
                        {
                            id = p.ID,
                            mesta = p.Mesta,
                            prodavnica = p.Prodavnica.Naziv,
                            pazar = p.Pazar,
                            sastojci = p.Sastojci.Select(s => new
                            {
                                id = s.ID,
                                naziv = s.Naziv,
                                cena = s.Cena,
                                kolicina = s.Kolicina
                            })

                        })
                        .ToListAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


}
