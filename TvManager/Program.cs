using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVLib;

namespace TvManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Show serie = new Show("Lost");
            Console.WriteLine("Show Objekt erzeugt\n");
            Season s01 = new Season(1);
            Console.WriteLine("Season Objekt erzeugt\n");
            s01.Add(new Episode(1,"Pilot"));
            s01.Add(new Episode(2, "The Tale of two towns"));
            Console.WriteLine("Folge hinzugefügt\n");
            serie.Add(s01);
            Console.WriteLine("Season zur Serie hinzugefuegt\n");
            Console.WriteLine("Serie: "+serie.Name+"\n");
            foreach (var season in serie)
            {
                Console.WriteLine("Season: " + season.Number+"\n");
                foreach (var folge in season)
                {
                    Console.WriteLine("Folge: " + folge.Number + " Name: " + folge.Name);
                }
            }
        }
    }
}
