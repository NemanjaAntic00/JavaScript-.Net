using WebTemplateModels;

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

    [HttpPost]
    [Route("DodajSalu/{redovi}/{sedista}")]
    public async Task<ActionResult> DodajS(int redovi, int sedista)
    {
        try
        {
            var sala = new Sala
            {
                BrRedova = redovi,
                BrSedista = sedista
            };
            Context.Sale.Add(sala);
            await Context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Route("DodajProjekciju/{naziv}/{sala}/{cena}/{sifra}/{vreme}")]
    public async Task<ActionResult> DodajP(string naziv, int sala, int cena, int sifra, DateTime vreme)
    {
        try
        {
            var salaa = await Context.Sale.FindAsync(sala);
            var projekcija = new Projekcija
            {
                Naziv = naziv,
                Sala = salaa,
                Cena = cena,
                Sifra = sifra,
                Vreme = vreme
            };
            Context.Projekcije.Add(projekcija);
            await Context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpPost]
    [Route("DodajKartu/{projekcija}/{red}/{sediste}")]
    public async Task<ActionResult> DodajP(int projekcija, int red, int sediste)
    {
        try
        {
            var projekcijaa = await Context.Projekcije.FindAsync(projekcija);
            int cenaa = 0;
            if (red > 1)
            {
                cenaa = (projekcijaa.Cena / 100) * (100 - (red - 1) * 3);
            }
            if (red == 1)
            {
                cenaa = projekcijaa.Cena;
            }
            var karta = new Karta
            {
                Cena = cenaa,
                Red = red,
                Sediste = sediste,
                Projekcija = projekcijaa
            };
            Context.Karte.Add(karta);
            await Context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("Projekcije")]
    public async Task<ActionResult> Pojekcje()
    {
        try
        {
            return Ok(await Context.Projekcije.Include(p => p.Sala).Select(
                p => new
                {
                    id = p.ID,
                    naziv = p.Naziv,
                    sifra = p.Sifra,
                    vreme = p.Vreme,
                    sala = p.Sala.Naziv
                }
            ).ToListAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("Karte/{projekcija}")]
    public async Task<ActionResult> Karte(int projekcija)
    {
        try
        {
            var projekcijaa = await Context.Projekcije.FindAsync(projekcija);
            return Ok(await Context.Karte.Where(p => p.Projekcija == projekcijaa).Select(
                p => new
                {
                    id = p.ID,
                    red = p.Red,
                    sediste = p.Sediste,
                }
            ).ToListAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


}
