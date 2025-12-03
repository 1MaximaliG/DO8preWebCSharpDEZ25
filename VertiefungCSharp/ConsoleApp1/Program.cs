using System.Collections;

namespace ConsoleApp1
{
    public class StringStack
    {
        private string[] array;
        public int Count { get; private set; } = 0;
        public StringStack(int capacity)
        {
            array = new string[capacity];
        }

        public void Push(string element)
        {
            array[Count] = element;
            Count++;
        }
        public string Pop()
        {
            Count--;
            string element = array[Count];
            array[Count] = default(string);
            return element;
        }
    }
    public class IntStack
    {
        private int[] array;
        public int Count { get; private set; } = 0;
        public IntStack(int capacity)
        {
            array = new int[capacity];
        }

        public void Push(int element)
        {
            array[Count] = element;
            Count++;
        }
        public int Pop()
        {
            Count--;
            int element = array[Count];
            array[Count] = default(int);
            return element;
        }
    }
    public class ObjectStack
    {
        private object[] array;
        public int Count { get; private set; } = 0;
        public ObjectStack(int capacity)
        {
            array = new object[capacity];
        }

        public void Push(object element)
        {
            array[Count] = element;
            Count++;
        }
        public object Pop()
        {
            Count--;
            object element = array[Count];
            array[Count] = default(object);
            return element;
        }
    }
    public class GenericStack<T>
    {
        private T[] array;
        public int Count { get; private set; } = 0;
        public GenericStack(int capacity)
        {
            array = new T[capacity];
        }

        public void Push(T element)
        {
            array[Count] = element;
            Count++;
        }
        public T Pop()
        {
            Count--;
            T element = array[Count];
            array[Count] = default(T);
            return element;
        }
    }
    //Beispiel IComparer
    public class Mensch : IComparable<Mensch>
    {
        public string Name { get; set; }
        public int Alter { get; set; }
        public string Adresse { get; set; }
        public int CompareTo(Mensch? other)
        {
            return Alter.CompareTo(other.Alter);
        }
    }
    //Alternative für SortedList mit einem Comparer-Objekt
    public class MenschComparer : IComparer<Mensch>
    {
        public int Compare(Mensch x, Mensch y)
        {
            if (x == null & y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.Alter.CompareTo(y.Alter);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Selbstgebauter Stack ->string->integer-> Object
            //StringStack stst = new StringStack(5);
            //stst.Push("HAllo");
            //stst.Push("klasse");
            //stst.Push("DO8");
            //Console.WriteLine(stst.Pop());
            //Console.WriteLine(stst.Pop());
            //stst.Push("Für Saruman");
            //Console.WriteLine(stst.Pop());
            //Console.WriteLine(stst.Pop());
            //ObjectStack os = new ObjectStack(5);
            //os.Push("HAllo");
            //os.Push(234);

            //Einfache Collection
            Hashtable table = new Hashtable();
            table.Add(1, "Eins");
            table.Add("Eins", "123456");
            table.Add(true, "Wahr");

            //Console.WriteLine(table["Eins"]);
            table[true] = "mehr Wahr!!!";
            //foreach(DictionaryEntry item in table)
            //{
            //    Console.WriteLine(item.Key);
            //    Console.WriteLine(item.Value);
            //}
            //foreach (var item in table)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(table);
        

            //Beispiel IComparer
            SortedList<Mensch, string> mListe = new SortedList<Mensch, string>();
            Mensch eins = new Mensch();
            eins.Name = "Peter";
            eins.Alter = 42;
            Mensch zwei = new Mensch();
            zwei.Name = "Hannah";
            zwei.Alter = 33;
            Mensch drei = new Mensch();
            drei.Name = "Bilbo";
            drei.Alter = 111;

            mListe.Add(eins, "Hausmeister");
            mListe.Add(zwei, "Mechanikerin");
            mListe.Add(drei, "Meisterdieb");
            foreach (var item in mListe)
            {
                Console.WriteLine(item.Key.Name);
            }
            //Alternative mit IConparer:
            SortedList<Mensch, string> mcListe = new SortedList<Mensch, string>(new MenschComparer());
            //hier analog wie oben
            //...
        }
    }
}
