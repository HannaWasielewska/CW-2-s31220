namespace APBD_1;

public class KontenerChlodniczy : Kontener
{
    public string TypProduktu { get; }
    public double Temperatura { get; }

    public KontenerChlodniczy(double max, double masaPustegoKontenera, double wysokosc, double glebokosc, string typProduktu, double temperatura)
        : base("C", max, masaPustegoKontenera, wysokosc, glebokosc)
    {
        TypProduktu = typProduktu;
        Temperatura = temperatura;
    }

    public override void Zaladuj(double massKg)
    {
        if (massKg > MaxKg)
            throw new OverfillException("Overfill w kontenerze chlodniczym!");
        ObecneKg = massKg;
    }

    public override void Rozladuj() => ObecneKg = 0;
}
