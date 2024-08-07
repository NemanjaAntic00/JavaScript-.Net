export class Projekcija {
  constructor(naziv, vreme, sala) {
    this.naziv = naziv;
    this.vreme = vreme;
    this.sala = sala;
  }
  crtaj(host) {
    var kupi = document.createElement("div");
    kupi.className = "Kupi";
    host.appendChild(kupi);

    this.crtajKupi(kupi);
  }
  crtajKupi(host) {
    var l = document.createElement("label");
    l.innerHTML = "Kupi kartu";
    host.appendChild(l);

    var podaci = document.createElement("div");
    podaci.className = "Podaci";
    host.appendChild(podaci);

    var red = document.createElement("div");
    red.className = "Red";
    podaci.appendChild(red);
    l = document.createElement("label");
    l.innerHTML = "Red:";
    red.appendChild(l);
    var o = document.createElement("output");
    red.appendChild(o);
  }
}
