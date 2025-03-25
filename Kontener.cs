namespace APBD_1;

public abstract class Kontener
{
        private static int counter = 1;
        public string numerSeryjny { get; }
        public double MaxKg { get; }
        public double ObecneKg { get; protected set; }
        public double MasaPustegoKontenera { get; }
        public double Wysokosc { get; }
        public double Glebokosc { get; }

        protected Kontener(string typ, double maxKg, double masaPustegoKontenera, double wysokosc, double glebokosc)
        {
            numerSeryjny = $"KON-{typ}-{counter++}";
            MaxKg = maxKg;
            MasaPustegoKontenera = masaPustegoKontenera;
            Wysokosc = wysokosc;
            Glebokosc = glebokosc;
        }

        public abstract void Zaladuj(double massKg);
        public abstract void Rozladuj();

}