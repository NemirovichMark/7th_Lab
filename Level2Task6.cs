using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Windows.Markup;

class HelloWorld
{

    class Sportsmens
    {
        public string Surname;
        public double[] rez1;
        public double[] rez2;
        public double obshrez;

    }
    class Sportsmens1 : Sportsmens
    {
        public string Razryad;
        public Sportsmens1(string surname1, double[] rez11, double[] rez22, string Raz)
        {
            this.Surname = surname1;
            this.rez1 = rez11;
            this.rez2 = rez22;
            double obshrez1 = 0;
            for (int i = 0; i < 5; i++)
            {
                obshrez1 = obshrez1 + rez11[i];
                obshrez1 = obshrez1 + rez22[i];
            }
            this.obshrez = obshrez1;
            this.Razryad = Raz;
        }
    }
    static int Main()
    {
        Console.WriteLine("Enter the number of sportsmens: ");
        int n;
        int.TryParse(Console.ReadLine(), out n);
        if (n <= 0) { Console.WriteLine("Incorrect data!!!"); return 0; }
        Sportsmens[] sportsmens = new Sportsmens[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter the surname of sportmen number " + (i + 1) + ":");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter the results of first jump of sportmen number " + (i + 1) + ":");
            double[] rez11 = new double[5];
            string[] line;
            while (true)
            {
                line = Console.ReadLine().Split(" ");
                if (line.Length != 5) { Console.WriteLine("Re-enter the row!"); continue; }
                else break;
            }
            for (int j = 0; j < 5; j++)
            {
                double x;
                if (double.TryParse(line[j], out x) == false) { Console.WriteLine("Incorrect data!!!"); return 0; }
                double.TryParse(line[j], out x);

                rez11[j] = x;
            }
            Console.WriteLine("Enter the results of second jump of sportmen number " + (i + 1) + ":");
            double[] rez22 = new double[5];
            string[] line1;
            while (true)
            {
                line1 = Console.ReadLine().Split(" ");
                if (line1.Length != 5) { Console.WriteLine("Re-enter the row!"); continue; }
                else break;
            }
            for (int j = 0; j < 5; j++)
            {
                double x;
                if (double.TryParse(line1[j], out x) == false) { Console.WriteLine("Incorrect data!!!"); return 0; }
                double.TryParse(line1[j], out x);
                rez22[j] = x;
            }
            Console.WriteLine("Enter the Sports category:");
            string gh = Console.ReadLine();
            sportsmens[i] = new Sportsmens1(surname, rez11, rez22, gh);
        }
        int left = 0;
        int right = sportsmens.Length - 1;

        while (left < right)
        {
            for (int i = left; i < right; i++)
            {
                if (sportsmens[i].obshrez < sportsmens[i + 1].obshrez)
                {
                    Sportsmens x = sportsmens[i];
                    sportsmens[i] = sportsmens[i + 1];
                    sportsmens[i + 1] = x;
                }

            }
            right--;

            for (int i = right; i > left; i--)
            {
                if (sportsmens[i - 1].obshrez < sportsmens[i].obshrez)
                {
                    Sportsmens x = sportsmens[i];
                    sportsmens[i] = sportsmens[i - 1];
                    sportsmens[i - 1] = x;
                }
            }
            left++;
        }
        Console.WriteLine("The list of TOP: ");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(sportsmens[i].Surname + " - " + sportsmens[i].obshrez);

        }

        return 0;
    }
}
