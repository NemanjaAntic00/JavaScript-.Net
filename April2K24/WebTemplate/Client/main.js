import { Projekcija } from "./Projekcija.js";

var glavni = document.createElement("div");
glavni.className = "Glavni";
document.body.appendChild(glavni);

fetch("https://localhost:7080/Ispit/Projekcije").then((s) => {
  var p;
  var d;
  s.json().then((p) => {
    p = new Projekcija(p.naziv, p.vreme, p.sala);
    d = document.createElement("div");
    d.className = "Projekcija";
    glavni.appendChild(d);
    p.crtaj(d);
  });
});
