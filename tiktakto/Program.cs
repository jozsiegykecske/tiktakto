using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace tiktakto
{
  class Program
  {
    static char[,] jatekter = new char[3,3];
    static void Main(string[] args)
    {
      Inicializal();
      int lepesekSzama = 0;
      int jatekos = 1;
      int sor = 0;
      int oszlop = 0;
      Console.Write("Ember kezd vagy gép?(e/g):");
      if (Console.ReadLine()=="g")
      {
        jatekos = 2;
      }
      while (lepesekSzama<9)
      {
        Console.WriteLine($"{jatekos}. játékos lép.");
        if (jatekos==1)
        {
          do
          {
            LepesBeker(out sor, out oszlop);

          } while (!Elhelyez(sor, oszlop, jatekos));
          //Ellenorzes(jatekos);

          LepesEredmenye(ref lepesekSzama, ref jatekos);
          Console.WriteLine();
        }
        if (jatekos==2)
        {
          Mesterseges200IqsIntelligencia();
          //Ellenorzes(jatekos);
          LepesEredmenye(ref lepesekSzama, ref jatekos);
          Kirajzol();
          Console.WriteLine();
        }
      }
      Console.ReadKey();
    }
    private static void Mesterseges200IqsIntelligencia()
    {
      Random rnd = new Random();
      int sor;
      int oszlop;
      do
      {
        sor = rnd.Next(0, 3);
        oszlop = rnd.Next(0, 3);
      } while (!(jatekter[sor,oszlop] == '.'));
      jatekter[sor, oszlop] = 'O';
    }
    private static void LepesEredmenye(ref int lepesekSzama, ref int jatekos)
    {
      if (Ellenorzes(jatekos))
      {
        Console.WriteLine($"{jatekos}. játékos nyert!");
        lepesekSzama = 10;
      }
      JatekosCsere(ref jatekos);
      lepesekSzama++;
    }
    private static bool Ellenorzes(int jatekos)
    {
      // mit számoljunk (x vagy o)
      // Sorok, Oszlopok átlók
      // meg áll találatkor
      char mit = jatekos == 1 ? 'X' : 'O';
      bool nyert = SorokVizsgalata(mit);
      if (nyert) return true;
      nyert = Oszlopokvizsgálata(mit);
      if (nyert) return true;
      nyert = AtlokVizsgalata(mit);
      return nyert;
    }
    private static bool AtlokVizsgalata(char mit)
    {
      if (jatekter[0,0]== mit && jatekter[0,0] == jatekter[1,1] && jatekter[1,1] == jatekter[2,2])
      {
        return true;
      }
      else if (jatekter[0, 2] == mit && jatekter[0, 2] == jatekter[1, 1] && jatekter[1, 1] == jatekter[2, 0])
      {
        return true;
      }
      return false;
    }
    private static bool Oszlopokvizsgálata(char mit)
    {
      for (int i = 0; i < 3; i++)
      {
        int darab = 0;
        for (int j = 0; j < 3; j++)
        {
          if (jatekter[j, i] == mit)
          {
            darab++;
          }
        }
        if (darab > 2)
        {
          return true;
        }
      }
      return false;
    }
    private static bool SorokVizsgalata(char mit)
    {
      for (int i = 0; i < 3; i++)
      {
        int darab = 0;
        for (int j = 0; j < 3; j++)
        {
          if (jatekter[i, j] == mit)
          {
            darab++;
          }
        }
        if (darab > 2)
        {
          return true;
        }
      }
      return false;
    }
    private static bool Elhelyez(int sor, int oszlop, int jatekosszama)
    {
      if (jatekter[sor,oszlop]=='.')
      {
        if (jatekosszama == 1)
        {
          jatekter[sor, oszlop] = 'X';
        }
        else
        {
          jatekter[sor, oszlop] = 'O';
        }
        return true;
      }
      else
      {
        return false;
      }
    }
    private static void Inicializal()
    {
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          jatekter[i, j] = '.';
        }
      }
    }
    static private void JatekosCsere(ref int jatekos)
    {
      jatekos = 3 - jatekos;
    }
    private static void LepesBeker(out int sor, out int oszlop)
    {
      Console.Write("Melyik sor?:");
      sor = Convert.ToInt32(Console.ReadLine())-1;
      Console.Write("Melyik oszlop?:");
      oszlop = Convert.ToInt32(Console.ReadLine())-1;
    }
    static void Kirajzol()
    {
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          SzinesbenKiir(jatekter[i,j]);
        }
        Console.WriteLine();
      }
    }

    private static void SzinesbenKiir(char ch)
    {
      ConsoleColor eredeti = Console.ForegroundColor;

      switch (ch)
      {
        case 'X': Console.ForegroundColor = ConsoleColor.Green;
          break;
        case 'O': Console.ForegroundColor = ConsoleColor.Red;
          break;
        default: Console.ForegroundColor = ConsoleColor.Yellow;
          break;
      }
      Console.Write($"{ch} ");
      Console.ForegroundColor = eredeti;
    }
  }
}