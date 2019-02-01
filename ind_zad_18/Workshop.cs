using System;
using System.Collections.Generic;

namespace ind_zad_18
{
    [Serializable]
    public class Workshop
    {


        public static int workshopCounter = 1; // счетчик мастерских
        private int numberWorkshop = 0, numberHouse, cost; // порядковый номер мастерской, номер дома, цена за аренду
        List<Lumber> lumberWorkshop = new List<Lumber>(); // динамический список пиломатериалов
        private int sumCost = 0; // суммарная цена

        ~Workshop()  // деструктор
        {
            Console.WriteLine("Объект 'Workshop' уничтожен!");
        }

        public Workshop() { } // по умолчанию

        public Workshop(int nh, int cs)
        {
            numberHouse = nh;
            cost = cs;
            sumCost += cost;
        }

        public Lumber this[int index]//перегруженный оператор индексирования
        {
            get
            {
                return lumberWorkshop[index];
            }
            set
            {
                lumberWorkshop[index] = value;
            }
        }

        public int NumberWorkshop(int i)
        {
            numberWorkshop = i;
            return numberWorkshop;
        }

        public int NumberHouse
        {
            set { numberHouse = value; }
            get { return numberHouse; }
        }

        public int Cost
        {
            set { cost = value; }
            get { return cost; }
        }

        public int CostSum()
        {
            return sumCost;
        }

        public void AddLumber(Lumber newLumber) // добавление объекта Lumber
        {
            lumberWorkshop.Add(newLumber);
        }

        public List<Lumber> LumberWorkshop
        {
            set { lumberWorkshop = value; }
            get { return lumberWorkshop; }
        }

        public string BriefWorkshop()
        {
            string briefWorkshop = $" - Workshop, адресс: {NumberHouse}, аренда: {CostSum()} $.";
            return briefWorkshop;
        }

        public override string ToString()
        {
            string workshop = $" - Workshop\nAдресс помещения : {NumberHouse}\nАренда в месяц вам обойдеться в : {CostSum()} $";
            return workshop;
        }
    }
}



