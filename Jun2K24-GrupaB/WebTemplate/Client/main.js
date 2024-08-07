import { Sala } from "./Sala.js";
var glavni = document.createElement("div");
glavni.className = "Glavni";
document.body.appendChild(glavni);

var levo = document.createElement("div");
levo.className = "LeviDeo";
glavni.appendChild(levo);

var desno = document.createElement("div");
desno.className = "Desno";
glavni.appendChild(desno);

crtajLevo(levo);
crtajDesno(desno);

function crtajDesno(host) {
  var s;
  var d;
  fetch("https://localhost:7080/Ispit/PocetniPrikaz").then((s) => {
    s.json().then((sale) => {
      sale.forEach((sala) => {
        s = new Sala(sala.id, sala.kapacitet, sala.adresa, sala.cena, "?");
        d = document.createElement("div");
        host.appendChild(d);
        s.crtaj(d);
      });
    });
  });
}

function crtajLevo(host) {
  var gore = document.createElement("div");
  gore.className = "Gore";
  host.appendChild(gore);

  var red = document.createElement("div");
  red.className = "Red";
  gore.appendChild(red);

  var l = document.createElement("label");
  l.innerHTML = "Cena:";
  red.appendChild(l);

  var inpc = document.createElement("input");
  inpc.className = "nesto";
  inpc.type = "number";
  red.appendChild(inpc);

  red = document.createElement("div");
  red.className = "Red";
  gore.appendChild(red);

  l = document.createElement("label");
  l.innerHTML = "Kapacitet:";
  red.appendChild(l);

  var inpk = document.createElement("input");
  inpk.className = "nesto";
  inpk.type = "number";
  red.appendChild(inpk);

  red = document.createElement("div");
  red.className = "Red";
  gore.appendChild(red);

  l = document.createElement("label");
  l.innerHTML = "Slobodna:";
  red.appendChild(l);

  var cb = document.createElement("input");
  cb.type = "checkbox";
  cb.className = "cb";
  red.appendChild(cb);

  red = document.createElement("div");
  red.className = "Red";
  gore.appendChild(red);

  l = document.createElement("label");
  l.innerHTML = "Datum:";
  red.appendChild(l);

  var inpd = document.createElement("input");
  inpd.className = "Datum";
  inpd.type = "date";
  red.appendChild(inpd);

  var btnFiltriraj = document.createElement("button");
  btnFiltriraj.innerHTML = "Filtriraj";
  btnFiltriraj.onclick = (ev) =>
    Filtriraj(inpc.value, inpk.value, cb.checked, inpd.value);
  gore.appendChild(btnFiltriraj);

  var dole = document.createElement("div");
  dole.className = "Dole";
  host.appendChild(dole);

  red = document.createElement("div");
  red.className = "Red";
  dole.appendChild(red);

  l = document.createElement("label");
  l.innerHTML = "Ime i prezime:";
  red.appendChild(l);

  var inpi = document.createElement("input");
  inpi.className = "Ime";
  inpi.type = "text";
  red.appendChild(inpi);

  red = document.createElement("div");
  red.className = "Red";
  dole.appendChild(red);

  l = document.createElement("label");
  l.innerHTML = "JMBG:";
  red.appendChild(l);

  var inpj = document.createElement("input");
  inpj.className = "JMBG";
  inpj.type = "number";
  red.appendChild(inpj);
}

function Filtriraj(cena, kapacitet, slobodna, datum) {
  if (!datum) {
    datum = "2023-06-05";
  }
  if (!cena) {
    cena = 0;
  }
  if (!kapacitet) {
    kapacitet = 0;
  }
  if (datum == "2023-06-05" && cena == 0 && kapacitet == 0) {
    return;
  }
  fetch(
    "https://localhost:7080/Ispit/Filtriraj/" +
      cena +
      "/" +
      kapacitet +
      "/" +
      slobodna +
      "/" +
      datum
  ).then((s) => {
    console.log(s);
    var sala;
    s.json().then((p) => {
      console.log(p);
      var desno = document.querySelector(".Desno");
      var rod = desno.parentNode;
      rod.removeChild(desno);
      desno = document.createElement("div");
      desno.className = "Desno";
      rod.appendChild(desno);
      var d;
      p.forEach((sa) => {
        sala = new Sala(
          sa.id,
          sa.kapacitet,
          sa.adresa,
          sa.cena,
          sa.iznajmljena
        );
        d = document.createElement("div");
        desno.appendChild(d);
        sala.crtaj(d);
      });
    });
  });
}
