export class Sto {
  constructor(id, cena, zaradaid, prodavnica) {
    (this.id = id),
      (this.cena = cena),
      (this.container = null),
      (this.brPriloga = 0),
      (this.zaradaid = zaradaid);
    this.prodavnica = prodavnica;
  }
  crtaj(host) {
    this.container = document.createElement("div");
    host.appendChild(this.container);
    var l = document.createElement("label");
    l.innerHTML = "Sto " + (this.id + 1);
    this.container.appendChild(l);

    var sendvicd = document.createElement("div");
    sendvicd.className = "SendvicD";
    this.container.appendChild(sendvicd);

    var sendvic = document.createElement("div");
    sendvic.className = "Sendvic";
    sendvicd.appendChild(sendvic);

    this.crtajSendvic(sendvic);

    var isporuci = document.createElement("button");
    isporuci.innerHTML = "Isporuci";
    isporuci.onclick = (ev) => this.Isporuci();
    this.container.appendChild(isporuci);
  }

  Isporuci() {
    if (this.brPriloga == 0) {
      alert("Ne moze samo leba!");
    } else {
      fetch(
        "https://localhost:7080/Ispit/DodajZaradu/" +
          this.zaradaid +
          "/" +
          this.cena,
        {
          method: "PUT",
        }
      ).then((s) => {
        if (s.status == 200) {
          s.json().then((p) => {
            var roditelj = this.container.parentNode;
            roditelj.removeChild(this.container);
            this.brPriloga = 0;
            this.cena = 0;
            this.crtaj(roditelj);
            this.prodavnica.Isporuci(p);
            console.log(p);
          });
        }
      });
    }
  }

  crtajCenu(host) {
    var cena = document.createElement("div");
    cena.className = "Cena";
    host.appendChild(cena);
    var l = document.createElement("label");
    l.innerHTML = this.cena;
    cena.appendChild(l);
  }

  crtajSendvic(host) {
    var cenad = document.createElement("div");
    cenad.className = "CenaDiv";
    host.appendChild(cenad);
    this.crtajCenu(cenad);

    var lepinja = document.createElement("div");
    lepinja.className = "Lepinja";
    host.appendChild(lepinja);

    var prilozid = document.createElement("div");
    prilozid.className = "PriloziD";
    host.appendChild(prilozid);

    var prilozi = document.createElement("div");
    prilozi.className = "Prilozi";
    prilozid.appendChild(prilozi);

    lepinja = document.createElement("div");
    lepinja.className = "Lepinja";
    host.appendChild(lepinja);
  }

  dodajPrilog(kolicina, cena, r, g, b) {
    var prilogd = this.container.querySelector(".Prilozi");
    for (let i = 0; i < kolicina; i++) {
      var prilog = document.createElement("div");
      prilog.className = "Prilog";
      prilog.style.backgroundColor = "rgb(" + r + "," + g + "," + b + ")";
      prilogd.appendChild(prilog);
    }
    this.brPriloga += Number(kolicina);
    console.log(this.brPriloga);

    this.cena += Number(cena);
    var cdiv = this.container.querySelector(".Cena");
    var rod = cdiv.parentNode;
    rod.removeChild(cdiv);
    this.crtajCenu(rod);
  }
}
