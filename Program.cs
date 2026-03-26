using System;
using System.Data;
using System.Media;

class Program
{
    static void Main()
    {
        // DataTable erstellen
        DataTable dt = new DataTable("ZufallsDaten");
        dt.Columns.Add("ID", typeof(int));
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("Wert", typeof(long));

        // 10 Zeilen mit Zufallsdaten füllen
        var random = new Random();
        for (int i = 0; i < 10; i++)
        {
            var row = dt.NewRow();
            row["ID"] = i + 1;
            row["Name"] = $"Eintrag_{random.Next(1000, 9999)}";
            row["Wert"] = random.NextInt64(1_000_000_000L, 9_000_000_000L);
            dt.Rows.Add(row);
        }

        // DataTable ausgeben
        Console.WriteLine("DataTable Inhalt:");
        Console.WriteLine(new string('-', 50));
        foreach (DataRow row in dt.Rows)
        {
            Console.WriteLine($"{row["ID"]}\t{row["Name"]}\t{row["Wert"]}");
        }

        // Sound abspielen (benötigt .wav-Datei oder Resource)
        try
        {
            using var player = new SoundPlayer(@"C:\Windows\Media\ding.wav");
            player.PlaySync();
            Console.WriteLine("\nSound abgespielt!");
        }
        catch
        {
            Console.WriteLine("\nSound-Datei nicht gefunden.");
        }

        Console.WriteLine("Drücke Enter zum Beenden...");
        Console.ReadLine();
    }
}