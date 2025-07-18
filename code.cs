using System;
using System.Linq;
using System.Threading;
using HtmlAgilityPack;

class Program
{
    static void Main()
    {
        string decimalSembol = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        string yesterday = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
        string encodedDate = Uri.EscapeDataString(yesterday);
        string link = $"https://attijarinet.attijariwafa.com/particulier/public/coursdevise/search?dateCours={encodedDate}&typeOperation=Virement";

        Console.WriteLine($"Oluşan link: {link}\n");

        var doc = new HtmlWeb().Load(link);

        var headers = doc.DocumentNode.SelectNodes("//thead//th");
        if (headers == null) { Console.WriteLine("Başlık bulunamadı."); return; }

        int nameIdx = headers.ToList().FindIndex(h => h.InnerText.ToLower().Contains("libellé"));
        int rateIdx = headers.ToList().FindIndex(h => h.InnerText.ToLower().Contains("vente"));

        var rows = doc.DocumentNode.SelectNodes("//tr");
        if (rows == null || nameIdx == -1 || rateIdx == -1) { Console.WriteLine("Satır bulunamadı."); return; }

        var targets = new[] { "EURO", "DOLLARS USD", "LIVRE STERLING" };

        foreach (var row in rows)
        {
            var cells = row.SelectNodes("td");
            if (cells == null || cells.Count <= rateIdx) continue;

            string name = cells[nameIdx].InnerText.Trim().ToUpper();
            if (!targets.Any(t => name.Contains(t))) continue;

            string raw = cells[rateIdx].InnerText.Trim().Replace(",", decimalSembol).Replace(".", decimalSembol);

            if (double.TryParse(raw, out double rate))
                Console.WriteLine($"{name}: {rate}");
        }

        Console.ReadLine(); 
    }
}
