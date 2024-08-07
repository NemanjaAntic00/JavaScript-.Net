import { Tura } from "./Tura.js";

var glavni = document.createElement("div");
glavni.className = "Glavni";
document.body.appendChild(glavni);

var leviDeo = document.createElement("div");
leviDeo.className = "LeviDeo";
glavni.appendChild(leviDeo);

crtajLevo(leviDeo);

var DesniDeo = document.createElement("div");
DesniDeo.className = "DesniDeo";
glavni.appendChild(DesniDeo);

crtajDesno(DesniDeo);

function crtajDesno(host) {
  var d = document.createElement("div");
  host.appendChild(d);
  fetch("https://localhost:7080/Ispit/Ture").then((s) => {
    s.json().then((ture) => {
      var pom = [];
      ture.forEach((tura) => {
        tura.znamenitosti.forEach((znamenitost) => {
          pom.push(znamenitost.naziv);
        });
        var t = new Tura(tura.id, tura.cena, tura.slobodno, pom);
        t.crtaj(d);
        pom = [];
      });
    });
  });
}

function crtajLevo(host) {
  var gore = document.createElement("div");
  gore.className = "Gore";
  host.appendChild(gore);

  crtajGore(gore);

  var dole = document.createElement("div");
  dole.className = "Dole";
  host.appendChild(dole);

  crtajDole(dole);
}
function crtajDole(host) {
  var red = document.createElement("div");
  red.className = "Red";
  host.appendChild(red);

  var l = document.createElement("label");
  l.innerHTML = "Ime znamenitosti:";
  red.appendChild(l);

  var inpi = document.createElement("input");
  inpi.className = "inputciki";
  inpi.type = "text";
  red.appendChild(inpi);

  var red = document.createElement("div");
  red.className = "Red";
  host.appendChild(red);

  var l = document.createElement("label");
  l.innerHTML = "Cena:";
  red.appendChild(l);

  var inpc = document.createElement("input");
  inpc.className = "inputciki";
  inpc.type = "number";
  red.appendChild(inpc);

  var btnDodaj = document.createElement("button");
  btnDodaj.innerHTML = "Dodaj znamenitost";
  btnDodaj.onclick = (ev) => Dodaj(inpi.value, inpc.value);
  host.appendChild(btnDodaj);
}

function Dodaj(ime, cena) {
  fetch("https://localhost:7080/Ispit/DodajZnamenitost/" + ime + "/" + cena, {
    method: "POST",
  }).then((s) => {
    if (s.status == 200) {
      var opcije = document.querySelector(".Opcije");
      var par = opcije.parentNode;
      par.removeChild(opcije);
      opcije = document.createElement("div");
      opcije.className = "Opcije";
      par.appendChild(opcije);
      crtajZnamenitosti(opcije);
    }
  });
}

function crtajGore(host) {
  var red = document.createElement("div");
  red.className = "Red";
  host.appendChild(red);

  var l = document.createElement("label");
  l.innerHTML = "Ime i prezime:";
  red.appendChild(l);

  var inpi = document.createElement("input");
  inpi.className = "inputciki";
  inpi.type = "text";
  red.appendChild(inpi);

  red = document.createElement("div");
  red.className = "Red";
  host.appendChild(red);

  l = document.createElement("label");
  l.innerHTML = "Broj licne karte:";
  red.appendChild(l);

  var inpl = document.createElement("input");
  inpl.className = "inputciki";
  inpl.type = "number";
  red.appendChild(inpl);

  var d = document.createElement("div");
  host.appendChild(d);
  red = document.createElement("div");
  red.className = "Opcije";
  d.appendChild(red);

  crtajZnamenitosti(red);

  var btnZapocni = document.createElement("button");
  btnZapocni.innerHTML = "Zapocni turu";
  btnZapocni.onclick = (ev) => Zapocni(inpi.value, inpl.value);
  host.appendChild(btnZapocni);
}
function Zapocni(imeip, licna) {
  var opcije = document.querySelector(".Opcije");
  var selected = opcije.querySelectorAll("input[type='checkbox']:checked");
  var ip = imeip.split(" ");

  var znamenitosti = "";
  selected.forEach((element) => {
    znamenitosti = znamenitosti + element.value + "$";
  });

  fetch(
    "https://localhost:7080/Ispit/DodajTuru/" +
      ip[0] +
      "/" +
      ip[1] +
      "/" +
      licna +
      "/" +
      znamenitosti,
    {
      method: "POST",
    }
  ).then((s) => {
    if (s.status == 200) {
      var desno = document.querySelector(".DesniDeo");
      var rod = desno.parentNode;
      rod.removeChild(desno);
      desno = document.createElement("div");
      desno.className = "DesniDeo";
      rod.appendChild(desno);
      crtajDesno(desno);
    }
  });
}

function crtajZnamenitosti(host) {
  fetch("https://localhost:7080/Ispit/Znamenitosti").then((s) => {
    var l = document.createElement("label");
    l.innerHTML = "Znamenitosti:";
    host.appendChild(l);
    var cbb = document.createElement("div");
    cbb.className = "cbboxovi";
    host.appendChild(cbb);
    var cbDiv;
    var cb;
    s.json().then((znamenitosti) => {
      znamenitosti.forEach((znamenitost) => {
        cbDiv = document.createElement("div");
        cbDiv.className = "cbdiv";
        cbb.appendChild(cbDiv);
        cb = document.createElement("input");
        cb.type = "checkbox";
        cb.value = znamenitost.id;
        cbDiv.appendChild(cb);

        l = document.createElement("label");
        l.innerHTML = znamenitost.naziv;
        cbDiv.appendChild(l);
      });
    });
  });
}
