using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    [XmlRoot("Jedi")]
    public class Jedi
    {
        //ezt lehet auto propertyvel csinálni
        [XmlAttribute("Név")]
        public string Name { set; get; }
        //Mivel nem auto propertyket használunk, ezért létre kell hozzunk egy privát attribútumot amely utána állíthatunk
        [XmlAttribute("_MidiChlorianSzám")]
        private int _midiChlorianCount;

        public Jedi(string name, int midiChlorianCount)
        {
            Name = name;
            MidiChlorianCount = midiChlorianCount;
        }

        [XmlAttribute("MidiChlorianSzám")]
        public int MidiChlorianCount
        {
            //itt kérdezzük le a privát attribútumot
            get { return _midiChlorianCount; }
            //itt pedig ha nem negatív a szám, beállítjuk. Negatív szám esetén kivételt dobunk
            set
            {
                if (value < 11) throw new ArgumentException("You are not a true jedi!");
                else _midiChlorianCount = value;
            }
        }

        [Description("Feladat2")]
        public Jedi Clone()
        {
            //elöször kiírjuk a mostani objektumunkat
            XmlSerializer serializer = new XmlSerializer(typeof(Jedi));
            FileStream stream = new FileStream("jedi.txt", FileMode.Create);
            //azért kell a 'this', ugyanis ez a metódus a Jedi osztályhoz tartozik, és ezt az osztályt szerializáljuk
            serializer.Serialize(stream, this);
            stream.Close();

            //itt már beolvassuk a fájlt, egy lokális változóba, amivel visszatérünk
            XmlSerializer ser = new XmlSerializer(typeof(Jedi));
            FileStream fs = new FileStream("jedi.txt", FileMode.Open);
            Jedi clone = (Jedi)ser.Deserialize(fs);
            fs.Close();

            return clone;
        }
    }
}
