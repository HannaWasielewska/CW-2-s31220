namespace APBD_1;

public class KontenerPlyn : Kontener, IHazardNotifier
{
    public bool CzyBezpieczne { get; }

    public KontenerPlyn(double max, double masaPustegoKontenera, double wysokosc, double glebokosc, bool czyBezpieczne)
        : base("L", max, masaPustegoKontenera, wysokosc, glebokosc)
    {
        CzyBezpieczne = czyBezpieczne;
    }

    public override void Zaladuj(double massKg)
    {
        double capacity = CzyBezpieczne ? MaxKg * 0.5 : MaxKg * 0.9;
        if (massKg > capacity)
        {
            NotifyHazard($"Overfill na : {numerSeryjny}");
            throw new OverfillException("Nie można załadować, przekroczona pojemność!");
        }
        ObecneKg = massKg;
    }

    public override void Rozladuj() {
        ObecneKg = 0;
    }

    public void NotifyHazard(string message) => Console.WriteLine($"[HAZARD] {message}");
}
