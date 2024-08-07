export class Prodavnica {
  constructor(id, stolovi, naziv, sastojci, pazar) {
    (this.id = id),
      (this.stolovi = stolovi),
      (this.naziv = naziv),
      (this.sastojci = sastojci),
      (this.container = null),
      (this.pazar = pazar);
  }

  Isporuci(cena) {
    var d = this.container.querySelector(".Libela");
    var rod = d.parentNode;
    rod.removeChild(d);
    this.pazar = Number(cena);
    this.crtajNaziv(rod);
  }

  crtaj(host) {
    this.container = document.createElement("div");
    this.container.className = "Prodavnica";
    host.appendChild(this.container);

    var naziv = document.createElement("div");
    naziv.className = "Naziv";
    this.container.appendChild(naziv);

    this.crtajNaziv(naziv);

    var dole = document.createElement("div");
    dole.className = "Dole";
    this.container.appendChild(dole);

    this.crtajDole(dole);
  }

  crtajDole(host) {
    var dodaj = document.createElement("div");
    dodaj.className = "Dodaj";
    host.appendChild(dodaj);

    this.crtajDodaj(dodaj);

    var stolovi = document.createElement("Stolovi");
    stolovi.className = "Stolovi";
    host.appendChild(stolovi);

    this.crtajStolovi(stolovi);
  }

  crtajStolovi(host) {
    var astal;

    this.stolovi.forEach((sto) => {
      astal = document.createElement("div");
      astal.className = "Sto";
      host.appendChild(astal);
      sto.crtaj(astal);
    });
  }

  crtajDodaj(host) {
    var red = document.createElement("div");
    red.className = "Red";
    host.appendChild(red);

    var l = document.createElement("label");
    l.className = "lsto";
    l.innerHTML = "Sto";
    red.appendChild(l);

    var se1 = document.createElement("select");
    var op;
    this.stolovi.forEach((sto) => {
      op = document.createElement("option");
      op.innerHTML = sto.id + 1;
      op.value = sto.id + 1;
      se1.appendChild(op);
    });
    red.appendChild(se1);

    var red = document.createElement("div");
    red.className = "Red";
    host.appendChild(red);

    var l = document.createElement("label");
    l.innerHTML = "Sastojak";
    red.appendChild(l);

    var se2 = document.createElement("select");
    var op;
    this.sastojci.forEach((sastojak) => {
      op = document.createElement("option");
      op.innerHTML = sastojak.naziv;
      op.value = sastojak.id;
      se2.appendChild(op);
    });
    red.appendChild(se2);

    var red = document.createElement("div");
    red.className = "Red";
    host.appendChild(red);

    var l = document.createElement("label");
    l.innerHTML = "Kolicina";
    red.appendChild(l);

    var inp = document.createElement("input");
    inp.type = "number";
    red.appendChild(inp);

    var btnDodaj = document.createElement("button");
    btnDodaj.innerHTML = "Dodaj";
    btnDodaj.onclick = (ev) => this.Dodaj(se1.value, se2.value, inp.value);
    host.appendChild(btnDodaj);
  }

  Dodaj(stol, sastojakid, kolicina) {
    fetch(
      "https://localhost:7080/Ispit/ImaDovoljnoSastojka/" +
        sastojakid +
        "/" +
        kolicina
    ).then((s) => {
      if (s.status == 200 || s.status == 201) {
        var cena;
        var r;
        var g;
        var b;
        this.sastojci.forEach((sastojak) => {
          if (sastojak.id == sastojakid) {
            cena = sastojak.cena;
            r = sastojak.r;
            g = sastojak.g;
            b = sastojak.b;
          }
        });
        this.stolovi.forEach((sto) => {
          if (sto.id == stol - 1) {
            if (sto.brPriloga + Number(kolicina) <= 4) {
              sto.dodajPrilog(kolicina, cena * kolicina, r, g, b);
            } else {
              alert("Bajo maks 4 priloga");
            }
          }
        });
      } else {
        if (s.status == 400) {
          alert("Nema vise toj na stanje Bajo!");
        }
      }
    });
  }

  crtajNaziv(host) {
    var d = document.createElement("div");
    d.className = "Libela";
    host.appendChild(d);
    var l = document.createElement("h1");
    l.innerHTML = this.naziv + " - " + this.pazar + " din";
    d.appendChild(l);
  }
}
