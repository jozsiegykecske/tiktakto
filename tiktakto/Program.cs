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
      Kirajzol();
      
      int lepesekSzama = 0;
      int jatekos = 1;
      int sor = 0;
      int oszlop = 0;
      while (lepesekSzama<9)
      {
        Console.WriteLine($"{jatekos}. játékos lép.");
        do
        {
          LepesBeker(out sor,out oszlop);
        } while (!Elhelyez(sor,oszlop,jatekos));
        JatekosCsere(ref jatekos);
        lepesekSzama++;
        Kirajzol();
      }
      Console.ReadKey();
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
      sor = Convert.ToInt32(Console.ReadLine());
      Console.Write("Melyik oszlop?:");
      oszlop = Convert.ToInt32(Console.ReadLine());
    }
    static void Kirajzol()
    {
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          Console.Write(jatekter[i,j] + " ");
        }
        Console.WriteLine();
      }
    }
  }
}