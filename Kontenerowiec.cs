namespace APBD_1;

public class Kontenerowiec
{
    public string Nazwa { get; } // nazwa statku
    public double MaxPredkosc { get; } // maksymalna prędkość statku
    public int MaxLiczbaKontenerow { get; } // maksymalna liczba kontenerów 
    public double DopuszczalnaLadownoscWTonach { get; } // dopuszczalna ładowność w tonach
    public List<Kontener> Kontenery { get; } // lista kontenerów znajdujących się na statku
    
    public Kontenerowiec(string nazwa, double maxPredkosc, int maxKontenerow, double dopuszczalnaLadownoscWTonach)
    {
        Nazwa = nazwa;
        MaxPredkosc = maxPredkosc;
        MaxLiczbaKontenerow = maxKontenerow;
        DopuszczalnaLadownoscWTonach = dopuszczalnaLadownoscWTonach;
        Kontenery = new List<Kontener>(); // inicjalizacja listy kontenerów
    }

    // metoda dodająca kontener na statek
    public void ZaladujKontener(Kontener container)
    {
        if (Kontenery.Count >= MaxLiczbaKontenerow)
            throw new Exception("Dostępne miejsce na statku zostało przekroczone!");
        if ((OgolnaWagaKg() + container.ObecneKg + container.MasaPustegoKontenera) > DopuszczalnaLadownoscWTonach * 1000)
            throw new Exception("Dopuszczalna waga na statku została przekroczona!");

        Kontenery.Add(container); // dodanie kontenera do listy
    }

    // obliczanie całkowitej wagi kontenerów na statku
    public double OgolnaWagaKg() =>
        Kontenery.Sum(c => c.ObecneKg + c.MasaPustegoKontenera);

    // usuwanie kontenera po numerze seryjnym
    public void UnloadContainer(string serialNumber) =>
        Kontenery.RemoveAll(c => c.numerSeryjny == serialNumber);

    // podmiana kontenera na nowy po numerze seryjnym
    public void ReplaceContainer(string oldSerial, Kontener newKontener)
    {
        int index = Kontenery.FindIndex(c => c.numerSeryjny == oldSerial); // wyszukiwanie kontenera po numerze
        if (index == -1) throw new Exception("Kontener nie znaleziony");
        Kontenery[index] = newKontener; // podmiana kontenera
    }

    // przeniesienie kontenera na inny statek
    public void TransferContainer(Kontenerowiec targetShip, string serialNumber)
    {
        Kontener container = Kontenery.FirstOrDefault(c => c.numerSeryjny == serialNumber)
                              ?? throw new Exception("Kontener nie znaleziony");
        targetShip.ZaladujKontener(container); // załadowanie kontenera na docelowy statek
        Kontenery.Remove(container); // usunięcie kontenera z obecnego statku
    }

    // wypisywanie informacji o statku i jego ładunku
    public void WypiszInformacje()
    {
        Console.WriteLine($"Statek: {Nazwa}, Predkosc: {MaxPredkosc}, Kontenery: {Kontenery.Count}");
        foreach (var c in Kontenery)
            Console.WriteLine($" - {c.numerSeryjny}, Load: {c.ObecneKg} kg");
    }
}
