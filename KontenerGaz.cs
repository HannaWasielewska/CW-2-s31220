namespace APBD_1;

public class KontenerGaz : Kontener, IHazardNotifier
{
    public double Cisnienie { get; }

    public KontenerGaz(double max, double masaPustegoKontenera, double wysokosc, double glebokosc, double cisnienie)
        : base("G", max, masaPustegoKontenera, wysokosc, glebokosc)
    {
        Cisnienie = cisnienie;
    }

    public override void Zaladuj(double massKg)
    {
        if (massKg > MaxKg)
            throw new OverfillException("Overfill gazu!");

        ObecneKg = massKg;
    }

    public override void Rozladuj()
    {
        ObecneKg *= 0.05; // 5% 
    }

    public void NotifyHazard(string message) => Console.WriteLine($"[HAZARD] {message}");
}
