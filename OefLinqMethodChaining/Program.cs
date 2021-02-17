using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BierenLibrary;

namespace OefLinqMethodChaining
{
    class Program
    {
        static void Main(string[] args)
        {
            BierenService service = new BierenService();
            Console.WindowWidth = 160;
            #region test
            //Console.WriteLine("{0,-20}{1,-100}{2,-20}{3,-20}", "Nummer", "Naam", "Alcohol", "Brouwer");
            //foreach (Bier bier in service.Bieren)
            //{
            //    Console.WriteLine("{0,-20}{1,-100}{2,-20}{3,-20}", bier.BierNr, bier.Naam, bier.Alcohol, bier.Brouwer);
            //}
            #endregion
            #region opgave 1
            //List<Bier> meerDan7Procent = service.Bieren.Where(b => b.Alcohol > 7).ToList();
            //ShowBierenList(meerDan7Procent);
            #endregion
            #region opgave 2
            //List<Bier> delhaize = service.Bieren.Where(b => b.Naam.ToLower().Contains("delhaize")).ToList();
            //ShowBierenList(delhaize);
            #endregion
            #region opgave 3
            //List<Bier> no120 = service.Bieren.Where(b => b.BierNr == 120).ToList();
            //ShowBierenList(no120);
            #endregion
            #region opgave 4
            //List<Bier> jup5 = service.Bieren.Where(b => b.Brouwer.ToLower() == "jupiler").Where(b => b.Alcohol<=5).ToList();
            //ShowBierenList(jup5);
            #endregion
            #region opgave 5
            //List<Bier> jupartpalm = service.Bieren.Where(b => b.Brouwer.ToLower() == "jupiler"||b.Brouwer.ToLower() == "artois" || b.Brouwer.ToLower() == "palm").OrderBy(b => b.Brouwer).ToList();
            //ShowBierenList(jupartpalm);
            #endregion
            #region opgave 6
            List<String> brouwers = service.Bieren.Select(x => x.Brouwer).Distinct().ToList();
            IDictionary<string, decimal> averages = new Dictionary<string, decimal>();
            foreach (var item in brouwers)
            {
                decimal average = service.Bieren.Where(x => x.Brouwer == item).Average(x => x.Alcohol);
                averages.Add(item, Math.Round(average, 2));
            }
            foreach (var item in averages)
            {
                Console.WriteLine($"Brouwer: {item.Key} Alcohol: {item.Value}");
            }
            #endregion
        }
        static void ShowBierenList(List<Bier> bieren)
        {
            foreach (Bier bier in bieren)
            {
                Console.WriteLine("{0,-20}{1,-100}{2,-20}{3,-20}", bier.BierNr, bier.Naam, bier.Alcohol, bier.Brouwer);
            }
        }
    }
}
