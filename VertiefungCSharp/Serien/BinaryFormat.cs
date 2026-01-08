using System.Runtime.Serialization.Formatters.Binary;

namespace Serien
{
    internal partial class Program
    {
        //public class BinaryFormat
        //{

        //    [Serializable]
        //    class Hero
        //    {
        //        public string Name;
        //        public Hero Partner;

        //        [NonSerialized]
        //        public string Stuff;

        //        private int age;

        //        public Hero(string name, int age)
        //        {
        //            Name = name;
        //            this.age = age;
        //        }

        //        public int GetAge()
        //        {
        //            return age;
        //        }
        //    }
        //    public static void TuWas()
        //    {
        //        static void BinaryExample()
        //        {
        //            Hero batman = new Hero("Batman", 42);

        //            BinaryFormatter binform = new BinaryFormatter();

        //            // Serialisierung
        //            using (FileStream stream =
        //                File.Create("Batman.dat"))
        //            {
        //                binform.Serialize(stream, batman);
        //            }

        //            // Deserialisierung
        //            Hero batmanCopy;
        //            using (FileStream stream =
        //                File.OpenRead("Batman.dat"))
        //            {
        //                batmanCopy =
        //                    binform.Deserialize(stream) as Hero;
        //            }

        //            Console.WriteLine(batmanCopy.Name);
        //            Console.WriteLine(batmanCopy.GetAge());
                    
        //        }
        //    }
        //}
    }
}
