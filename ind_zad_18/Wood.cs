using System;

namespace ind_zad_18
{
    [Serializable]
    public class Wood // древесина
    {
        string typeOfWood; // тип древесины
        string humidity, density; // Влажность, плотность 
        int amountOfWood = 0; // количество древесины

        ~Wood()  // деструктор
        {
            Console.WriteLine("Объект 'Wood' уничтожен!");
        }

        public Wood() { }

        public Wood(string tWood, string hm, string ds)
        {
            typeOfWood = tWood;
            humidity = hm;
            density = ds;
        }

        public string TypeOfWood
        {
            set { typeOfWood = value; }
            get { return typeOfWood; }
        }

        public string Humidity
        {
            set { humidity = value; }
            get { return humidity; }
        }

        public string Density
        {
            set { density = value; }
            get { return density; }
        }

        public int AmountOfWood
        {
            set { amountOfWood = value; }
            get { return amountOfWood; }
        }

        //public override string ToString()
        //{
        //    string wood = " type : " + TypeOfWood + "-humidity : " + Humidity + " density : " + Density;
        //    return wood;
        //}
    }
}
