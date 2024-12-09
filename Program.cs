using System.ComponentModel.DataAnnotations;

List<Barlang> lista = new List<Barlang>();

FileStream fs = new FileStream("barlangok.txt", FileMode.Open);
StreamReader sr = new StreamReader(fs);
sr.ReadLine();
while (!sr.EndOfStream)
{
    string sor = sr.ReadLine();
    Barlang b = new Barlang(sor);
    lista.Add(b);
}
sr.Close();
fs.Close();


Console.WriteLine("4. feladat: Barlangok szama: " + lista.Count);

double atlag = 0;
for (int i = 0; i < lista.Count; i++)
{
    if (lista[i].Telepules.StartsWith("Miskolc"))
    {
        atlag += lista[i].Melyseg;
    }
}
atlag = atlag / lista.Count;
atlag = Math.Round(atlag, 3);
Console.WriteLine("5. feladat: Az atlagos melyseg: " + atlag + " m");

Console.Write("6. feladat: Kérem a védettségi szintet: ");
string vedettseg = Console.ReadLine();
string hosszvedett = "\tNincs ilyen vedettsegi szinttel barlang az adatok kozott!";
int leghosszabb = 0;
for (int i = 0; i < lista.Count; i++)
{
    if (lista[i].Vedettseg == vedettseg && lista[i].Hossz > leghosszabb)
    {
        leghosszabb = lista[i].Hossz;
        hosszvedett = "\tAzon: " + lista[i].Azon + "\n" +
                      "\tNev: " + lista[i].Nev + "\n" +
                      "\tHossz: " + lista[i].Hossz + " m\n" +
                      "\tMelyseg: " + lista[i].Melyseg + " m\n" +
                      "\tTelepules: " + lista[i].Telepules;
    }
}

Console.WriteLine(hosszvedett);

Console.WriteLine("7. feladat: Statisztika");
int vedett = 0;
int fokozottanvedett = 0;
int megkuvedett = 0;
for (int i = 0; i < lista.Count; i++)
{
    lista[i].Nev.Count();
    if (lista[i].Vedettseg == "fokozottan védett") { fokozottanvedett++; }
    else if (lista[i].Vedettseg == "megkülönböztetetten védett") { megkuvedett++; }
    else if (lista[i].Vedettseg == "védett") { vedett++; }
    leghosszabb = lista[i].Hossz;
}
Console.WriteLine("\tfokozottan vedett:-----------> " + fokozottanvedett + " db\n" +
                  "\tmegkulonboztetetten vedett:--> " + megkuvedett + " db\n" +
                  "\tvedett:----------------------> " + vedett + " db\n");
