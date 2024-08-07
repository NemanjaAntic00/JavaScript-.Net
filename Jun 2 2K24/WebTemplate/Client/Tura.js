export class Tura {
  constructor(id, cena, slobodno, znamenitosti) {
    (this.id = id),
      (this.cena = cena),
      (this.slobodno = slobodno),
      (this.znamenitosti = znamenitosti),
      (this.container = null);
  }
  crtaj(host) {
    this.container = document.createElement("div");
    this.container.className = "Tura";
    host.appendChild(this.container);

    if (this.slobodno == 0) {
      this.container.style.backgroundColor =
        "rgb(" + 255 + "," + 130 + "," + 120 + ")";
    } else {
      this.container.style.backgroundColor =
        "rgb(" + 135 + "," + 206 + "," + 235 + ")";
    }

    var red = document.createElement("div");
    red.className = "red";
    this.container.appendChild(red);

    var l = document.createElement("label");
    l.innerHTML = "Preostalo Mesta:";
    l.className = "l1";
    red.appendChild(l);

    l = document.createElement("label");
    l.innerHTML = this.slobodno;
    red.appendChild(l);

    red = document.createElement("div");
    red.className = "red";
    this.container.appendChild(red);

    l = document.createElement("label");
    l.innerHTML = "Cena:";
    l.className = "l1";
    red.appendChild(l);

    l = document.createElement("label");
    l.innerHTML = this.cena;
    red.appendChild(l);

    red = document.createElement("div");
    red.className = "red";
    this.container.appendChild(red);

    l = document.createElement("label");
    l.innerHTML = "Znamenitosti:";
    l.className = "l1";
    red.appendChild(l);

    var znam = document.createElement("div");
    znam.className = "Znam";
    red.appendChild(znam);

    this.znamenitosti.forEach((element) => {
      l = document.createElement("label");
      l.innerHTML = element;
      znam.appendChild(l);
    });
  }
}
