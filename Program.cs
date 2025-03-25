using APBD_1;

class Program
{
    static void Main()
    {
        var statek = new Kontenerowiec("Titanic", 20, 5, 200);
        var plyn = new KontenerPlyn(10000, 3000, 250, 600, true);
        var gaz = new KontenerGaz(5000, 2000, 200, 500, 10);
        var chlodnia = new KontenerChlodniczy(8000, 2500, 260, 580, "Bananas", 5);

        try
        {
            plyn.Zaladuj(4000);
            gaz.Zaladuj(3000);
            chlodnia.Zaladuj(7000);

            statek.ZaladujKontener(plyn);
            statek.ZaladujKontener(gaz);
            statek.ZaladujKontener(chlodnia);

            statek.WypiszInformacje();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}