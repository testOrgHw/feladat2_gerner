using System;
using System.Collections.Generic;

namespace ModernLangToolsApp
{
    class Program
    {
        static void MessageReceived(string message)
        {
            Console.WriteLine(message);
        }

        public static void fill(JediCouncil jc)
        {
            //adjuk hozzá a jediket a council-hoz
            jc.Add(new Jedi("Anakin", 27000));
            jc.Add(new Jedi("Obi-wan", 19000));
            jc.Add(new Jedi("Shaak Ti", 4000));
            jc.Add(new Jedi("Ashoka", 4500));
        }

        static void Main(string[] args)
        {
            //hozzunk létre egy tanácsot
            JediCouncil council = new JediCouncil();
            //iratkozzunk fel a függvénnyel2
            council.CouncilChanged += MessageReceived;

            //töltsük fel a tanácsot
            fill(council);

            council.WhoIsBeginner();

            //eltávolítjuk a jediket
            council.Remove();
            council.Remove();
            council.Remove();
            council.Remove();
            Console.ReadKey();
        }
    }
}
