export class Sala {
  constructor(id, kapacitet, adresa, cena, iznajmljena) {
    (this.id = id),
      (this.kapacitet = kapacitet),
      (this.adresa = adresa),
      (this.cena = cena),
      (this.iznajmljena = iznajmljena),
      (this.container = null);
  }

  crtaj(host) {
    this.container = document.createElement("div");
    this.container.className = "Sala";
    host.appendChild(this.container);

    if (this.iznajmljena == true || this.iznajmljena == "?") {
      this.container.style.backgroundColor =
        "rgb(" + 255 + "," + 0 + "," + 0 + ")";
    } else {
      this.container.style.backgroundColor =
        "rgb(" + 0 + "," + 255 + "," + 0 + ")";
    }

    var red = document.createElement("div");
    red.className = "red";
    this.container.appendChild(red);

    var l1 = document.createElement("label");
    l1.className = "l1";
    l1.innerHTML = "Kapacitet:";
    red.appendChild(l1);

    var l2 = document.createElement("label");
    l2.className = "l2";
    l2.innerHTML = this.kapacitet;
    red.appendChild(l2);

    red = document.createElement("div");
    red.className = "red";
    this.container.appendChild(red);

    l1 = document.createElement("label");
    l1.className = "l1";
    l1.innerHTML = "Adresa:";
    red.appendChild(l1);

    l2 = document.createElement("label");
    l2.className = "l2";
    l2.innerHTML = this.adresa;
    red.appendChild(l2);

    red = document.createElement("div");
    red.className = "red";
    this.container.appendChild(red);

    l1 = document.createElement("label");
    l1.className = "l1";
    l1.innerHTML = "Cena:";
    red.appendChild(l1);

    l2 = document.createElement("label");
    l2.className = "l2";
    l2.innerHTML = this.cena;
    red.appendChild(l2);

    red = document.createElement("div");
    red.className = "red";
    this.container.appendChild(red);

    l1 = document.createElement("label");
    l1.className = "l1";
    l1.innerHTML = "Iznajmljen:";
    red.appendChild(l1);

    l2 = document.createElement("label");
    l2.className = "l2";
    l2.innerHTML = this.iznajmljena;
    red.appendChild(l2);

    var btnIznajmi = document.createElement("button");
    btnIznajmi.innerHTML = "Iznajmi";
    btnIznajmi.onclick = (ev) => this.Iznajmi(this.id);
    this.container.appendChild(btnIznajmi);
    if (this.iznajmljena == true || this.iznajmljena == "?") {
      btnIznajmi.disabled = true;
    }
  }

  Iznajmi(id) {
    var imeip = document.querySelector(".Ime").value;
    if (!imeip) {
      alert("Morate uneti ime i prezime!");
      return;
    }

    var razdvojeno = imeip.split(" ");

    var jmbg = document.querySelector(".JMBG").value;

    if (!jmbg) {
      alert("Morate uneti JMBG!");
      return;
    }

    var dat = document.querySelector(".Datum").value;

    console.log(dat);

    fetch(
      "https://localhost:7080/Ispit/IznajmiSalu/" +
        razdvojeno[0] +
        "/" +
        razdvojeno[1] +
        "/" +
        jmbg +
        "/" +
        dat +
        "/" +
        this.id,
      {
        method: "POST",
      }
    ).then((s) => {
      if (s.status == 200) {
        this.iznajmljena = true;
        var rod = this.container.parentNode;
        rod.removeChild(this.container);
        this.crtaj(rod);
      }
    });
  }
}
