using System.Linq.Expressions;

List<string> osvenyek = new List<string>();
using (StreamReader sr = new StreamReader("osvenyek.txt"))
{
    while (!sr.EndOfStream)
    {
        string adat = sr.ReadLine();
        osvenyek.Add(adat);
    }
    sr.Close();
}

List<int> dobasok = new List<int>();
using (StreamReader sr = new StreamReader("dobasok.txt"))
{
    string adat = sr.ReadLine();
    dobasok = adat.Split().Select(int.Parse).ToList();
    sr.Close();
}
Console.WriteLine();
Console.WriteLine("2. feladat");
Console.WriteLine($"A dobások száma: {dobasok.Count()}");
Console.WriteLine($"Az ösvények száma: {osvenyek.Count()}");
Console.WriteLine();
Console.WriteLine("3. feladat");
int osvenyHossz = 0;
for (int i = 1; i < osvenyek.Count; i++)
{
    if (osvenyek[i].Length > osvenyek[osvenyHossz].Length)
    {
        osvenyHossz = i;
    }
}
Console.WriteLine($"Az egyik leghosszabb a {osvenyHossz + 1}. ösvény, hossza: {osvenyek[osvenyHossz].Length}");
Console.WriteLine();
Console.WriteLine("4. feladat");
Console.Write("Adja meg egy ösvény sorszámát: ");
int oszvenySzama = int.Parse(Console.ReadLine());
Console.Write("Adja meg a játékosok számát: ");
int jatekosSzama = int.Parse(Console.ReadLine());
string osveny = osvenyek[oszvenySzama - 1];
Console.WriteLine();
Console.WriteLine("5. feladat");
Dictionary<char, int> statisztika = new Dictionary<char, int>();
foreach (char betu in osveny)
{
    if (!statisztika.ContainsKey(betu))
    {
        statisztika[betu] = 0;
    }
    statisztika[betu]++;
}

foreach (var betukSzama in statisztika)
{
    Console.WriteLine($"{betukSzama.Key}: {betukSzama.Value} darab");
}
using (StreamWriter sw = new StreamWriter("kulonleges.txt"))
{
    try {
        int sorszam = 0;
        foreach (char mezo in osveny)
        {
            sorszam++;
            if (mezo != 'M')
            {
                sw.WriteLine($"{sorszam}\t{mezo}");
            }
        }
        Console.WriteLine();
        Console.WriteLine("6. feladat");
        Console.WriteLine("A fájlbaírás sikeres volt!");
        sw.Close();
    }
    catch {
        Console.WriteLine();
        Console.WriteLine("6. feladat");
        Console.WriteLine("A fájlbaírás sikertelen volt!");
        sw.Close();
    }
}