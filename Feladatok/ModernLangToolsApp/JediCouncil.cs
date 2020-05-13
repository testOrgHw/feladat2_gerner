using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ModernLangToolsApp
{
    //delegát típus definiálása
    public delegate void CouncilChangedDelegate(string message);

    [Description("Feladat3")]
    class JediCouncil
    {
        public event CouncilChangedDelegate CouncilChanged;

        List<Jedi> members = new List<Jedi>();
        public void Add(Jedi newJedi)
        {
            members.Add(newJedi);
            if (CouncilChanged != null)
                CouncilChanged("Új taggal bővültünk");
        }
        public void Remove()
        {
            // Eltávolítja a lista 0. pozícióban lévő elemét
            members.RemoveAt(0);
            if (CouncilChanged != null)
            {
                if (members.Count > 0)
                    CouncilChanged("Zavart érzek az erőben");
                else
                    CouncilChanged("A tanács elesett!");
            }
        }


        [Description("Feladat4")]
        public List<Jedi> GetBeginners()
        {
            //a FindAll metódus egy predikátumot vár
            return members.FindAll(isUnder300);
        }

        //predikátum
        public bool isUnder300(Jedi j)
        {
            return j.MidiChlorianCount < 300;
        }

        public void WhoIsBeginner()
        {
            //elöször megkérdezzük ki kezdö
            List<Jedi> jedis = GetBeginners();

            //utána kiírjuk a neveiket
            foreach (Jedi j in jedis)
            {
                Console.WriteLine(j.Name);
            }
        }

    }
}
