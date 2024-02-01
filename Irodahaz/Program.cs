using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Irodahaz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Iroda> irodak = new();
            using StreamReader sr = new(
                path: @"..\..\..\src\irodahaz.txt",
                encoding: Encoding.UTF8);
            while (!sr.EndOfStream) irodak.Add(new(sr.ReadLine()));
            foreach (var i in irodak)
            {
                Console.WriteLine(i.ToString());
            }



            //Melyik emeleten dolgoznak a legtöbben? Írd ki az emelet számát a képernyőre.
            Console.WriteLine();
            Console.WriteLine("8.Feladat:");
            var f8 = irodak.Max(x => x.letszamok.Count());
            Console.WriteLine($"Ezen az emeleten dolgoznak a legtöbben: {f8 + 1}");




            /*Írd ki a képernyőre, hogy van-e olyan iroda, ahol kilencen vannak. Hagyományos kódolásnál
            állj meg a feldolgozással, írd ki a cég kódját és az iroda sorszámát. Ha nincs ilyen, írj ki
            hibaüzenetet. Ha LINQ-val oldod meg, akkor az eredményből az első cég fenti adatait add meg,
            majd a hibaüzenetet.*/
            Console.WriteLine();
            Console.WriteLine("9.Feladat:");
            var f9 = irodak.Where(x => x.letszamok.Contains(9));
            foreach (var i in f9)
            {
                Console.WriteLine(i.ToString());
            }


            //Írd ki a képernyőre, hogy hány irodában vannak ötnél többen.
            Console.WriteLine();
            Console.WriteLine("10.Feladat:");
            int f10 = 0;
            foreach (var i in irodak)
            {
                foreach (var item in i.letszamok)
                {
                    if (item > 5)
                    {
                        f10++;
                    }
                }
            }
            Console.WriteLine($"Ennyi irodában vannak 5-nél többen: {f10}");




            /*Melyik emeletek melyik irodáiban nem dolgozik jelenleg senki? Soronként írd ki egy új fájlba a
            cég kódját, mellé szóközzel elválasztva az iroda sorszámát / sorszámait. Ne zárd le a fájlt.*/
            Console.WriteLine();
            Console.WriteLine("11.Feladat:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A kiírás siekres!");
            Console.ResetColor();
            using StreamWriter sw = new(
                path:@"..\..\..\src\Irodahaz2.txt",
                append: false,
                encoding: Encoding.UTF8);


            string f11 = string.Empty;
            foreach (var iroda in irodak)
            {
                f11 = string.Empty;
                f11 += iroda.kod + ": ";
                for (int i = 0; i < 12; i++)
                {
                    if (iroda.letszamok[i] == 0)
                    {
                        f11 += (i + 1).ToString() + ", ";
                    }
                }
                sw.WriteLine(f11);
            }




            /*Írd ki a képernyőre, hogy a LOGMEIN kódú cég irodáiban átlagosan hány személy dolgozik?
            (egész számmal)*/
            Console.WriteLine();
            Console.WriteLine("12.Feladat:");
            var f12 = irodak.Where(x => x.kod == "LOGMEIN").Select(x => x.letszamok.Average()).FirstOrDefault();
            Console.WriteLine($"Átlagosan ennyi ember dolgozik a LOGMEIN cégnél: {Math.Round(f12)}");




            //Írd ki a képernyőre, hogy hány fő dolgozik összesen az irodaházban.
            Console.WriteLine();
            Console.WriteLine("14.Feladat:");
            var f14 = irodak.Sum(x => x.letszamok.Sum());
            Console.WriteLine($"Ennyi fő dolgozik összesen az irodaházban{f14}");




            //Írd ki a képernyőre azt az évet, amikor megtörtént az első irodabérlés.
            Console.WriteLine();
            Console.WriteLine("15.Feladat:");
            var f15 = irodak.Min(x => x.kezdDatum);
            Console.WriteLine($"Ekkor történt az első irodabérlés: {f15}");



            /*Írd ki a képernyőre, hogy hány éve nem történt új irodabérlés (a rendszerdátumhoz
            viszonyítva).*/
            Console.WriteLine();
            Console.WriteLine("16.Feladat:");
            var f16 = irodak.Max(x => x.kezdDatum);
            var datum = DateTime.Now.Year;
            var atvaltva = int.Parse(f16);
            Console.WriteLine($"{datum-atvaltva} éve nem történt új irodabérlés");
        }
    }
}