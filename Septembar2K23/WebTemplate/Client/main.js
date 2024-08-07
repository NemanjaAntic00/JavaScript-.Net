import { Sastojak } from "./Sastojak.js";
import { Prodavnica } from "./Prodavnica.js";
import { Sto } from "./Sto.js";

var glavni = document.createElement("div");
glavni.className = "GlavniKontejner";
document.body.appendChild(glavni);

var listaSastojaka = [];
var listaStolova = [];
var p;
fetch("https://localhost:7080/Ispit/Prikaz").then((s) => {
  s.json().then((prodavnice) => {
    prodavnice.forEach((prodavnica) => {
      prodavnica.sastojci.forEach((sastojak) => {
        var s = new Sastojak(
          sastojak.id,
          sastojak.naziv,
          sastojak.cena,
          sastojak.kolicina
        );
        listaSastojaka.push(s);
      });
      for (let i = 0; i < prodavnica.mesta; i++) {
        var st = new Sto(i, 0, prodavnica.id, 0);
        listaStolova.push(st);
      }
      console.log(listaSastojaka);
      p = new Prodavnica(
        prodavnica.id,
        listaStolova,
        prodavnica.prodavnica,
        listaSastojaka,
        prodavnica.pazar
      );
      p.stolovi.forEach((element) => {
        element.prodavnica = p;
      });
      console.log(p);
      p.crtaj(glavni);
      listaSastojaka = [];
      listaStolova = [];
    });
  });
});
