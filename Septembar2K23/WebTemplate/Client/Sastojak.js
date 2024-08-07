export class Sastojak {
  constructor(id, naziv, cena, kolicina) {
    (this.id = id),
      (this.naziv = naziv),
      (this.cena = cena),
      (this.kolicina = kolicina),
      (this.r = Math.floor(Math.random() * 256)),
      (this.g = Math.floor(Math.random() * 256)),
      (this.b = Math.floor(Math.random() * 256));
  }
}
