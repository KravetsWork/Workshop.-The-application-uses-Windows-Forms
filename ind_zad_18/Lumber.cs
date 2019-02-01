using System;

namespace ind_zad_18
{
    [Serializable]
    public class Lumber : Wood // пиломатериалы 
    {
        SawingOptions sawingOptions; // тип распиливания
        DateTime datetime = new DateTime(); // дата поставки 

        int marking, price = 0; // маркировка,цена
        int amountOfWood = 0; // количество древесины

        ~Lumber()  // деструктор
        {
            Console.WriteLine("Объект 'Lumber' уничтожен!");
        }

        public Lumber() { }

        public Lumber(string tWood, string hm, string ds, int amWood, DateTime dateT, SawingOptions so, int mr, int pr)
            : base(tWood, hm, ds)
        {
            sawingOptions = so;
            datetime = dateT; // дата поставки
            marking = mr;
            amountOfWood = amWood;
            price = pr;
        }

        public DateTime DateT
        {
            set { datetime = value; }
            get { return datetime; }
        }

        public int PriceAmountOfWood()
        {
            return Price * GetAmountOfWood();
        }

        public int GetAmountOfWood()
        { return amountOfWood; }

        public void SetAmountOfWood(int value)
        { amountOfWood = value; }

        public SawingOptions sawingOption
        {
            set { sawingOptions = value; }
            get { return sawingOptions; }
        }

        public int Marking
        {
            set { marking = value; }
            get { return marking; }
        }

        public int Price
        {
            set { price = value; }
            get { return price; }
        }

        public string BriefStr()
        {
            string briefstr = $"Тип древесины : {TypeOfWood} {GetAmountOfWood()} (м*м) - {PriceAmountOfWood()} ($)";
            return briefstr;
        } // вывод в listboxLumbers

        public override string ToString()
        {
            string lumberWood = $"Тип древесины : {TypeOfWood} \nВлажность : {Humidity}\nПлотность : {Density}\nДата поставки : " +
                   $"{DateT}\nТип распиливания : {sawingOption}\nМаркировка : #{Marking}\nОбъем (м*м) : {GetAmountOfWood()}\nЦена за этот тип дерева составила : {PriceAmountOfWood()} $";
            return lumberWood;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;
            Lumber otherTemperature = obj as Lumber;
            if (otherTemperature != null)
                return this.PriceAmountOfWood().CompareTo(otherTemperature.PriceAmountOfWood());
            else
                throw new ArgumentException("Ошибка типа");
        }

        public static bool operator <(Lumber fst, Lumber sec)
        {
            if (fst.CompareTo(sec) == -1)
                return true;
            else
                return false;
        }

        public static bool operator >(Lumber fst, Lumber sec)
        {
            if (fst.CompareTo(sec) == 1)
                return true;
            else
                return false;
        }

        public static bool operator <=(Lumber fst, Lumber sec)
        {
            if (fst.CompareTo(sec) == 1)
                return false;
            else
                return true;
        }

        public static bool operator >=(Lumber fst, Lumber sec)
        {
            if (fst.CompareTo(sec) == -1)
                return false;
            else
                return true;
        }

        public override bool Equals(System.Object obj)
        {
            Lumber lumb = obj as Lumber;
            if ((object)lumb == null)
            {
                return false;
            }
            return base.Equals(obj) && (TypeOfWood == lumb.TypeOfWood && Price == lumb.Price);
        }
        public bool Equals(Lumber l)
        {
            return base.Equals((Lumber)l) && (TypeOfWood == l.TypeOfWood && Price == l.Price);
        }
        public override int GetHashCode()
        {
            try
            {
                return TypeOfWood.GetHashCode() ^ Price.GetHashCode();
            }
            catch (NullReferenceException) { return 0; }
        }

        public static Lumber operator +(Lumber obj1, Lumber obj2)
        {
            Lumber obj3 = new Lumber(obj1.TypeOfWood, obj1.Humidity, obj1.Density, obj1.GetAmountOfWood(), obj1.datetime, obj1.sawingOption, obj1.Marking, obj1.Price + obj2.Price);
            return obj3;
        }

        public static bool operator ==(Lumber fst, Lumber sec)
        {
            if (ReferenceEquals(fst, sec))
            {
                return true;
            }
            if (((object)fst == null) || ((object)sec == null))
            {
                return false;
            }
            return fst.TypeOfWood == sec.TypeOfWood && fst.Humidity == sec.Density && fst.Density == sec.Density && fst.Price == sec.Price;
        }

        public static bool operator !=(Lumber fst, Lumber sec)
        {
            return !(fst == sec);
        }
    }
}
