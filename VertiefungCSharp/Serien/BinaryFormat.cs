using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using MemoryPack;
//dotnet add package MemoryPack
//oder über manager installieren
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
        public partial class BinaryFormatNeu
        {
            //partial, erlaubt es dem Compiler, den Serialisierungs-Code bereits vorab extrem optimiert zu generieren.

            //Es kann hier auch MessagePack verwendet werden, was platformübergleifend besser arbeitet,
            //aber nicht an die Performance von MemoryPack ran kommt

            [MemoryPackable]
            partial class MemHero
            {
                public string Name;
                public MemHero Partner;

                [MemoryPackIgnore]
                public string Stuff;

                private int _age;
                [MemoryPackConstructor]
                public MemHero() { }
                public MemHero(string name, int age)
                {
                    Name = name;
                    this._age = age;
                }

                public int GetAge()
                {
                    return _age;
                }
            }
            public static void TuWas()
            {
                static async Task BinaryExample()
                {
                    MemHero batman = new MemHero("Batman", 42);


                    // Serialisierung
                    using (FileStream stream =
                        File.Create("Batman.dat"))
                    {
                        await MemoryPackSerializer.SerializeAsync(stream, batman);
                    }

                    // Deserialisierung
                    MemHero batmanCopy;
                    using (FileStream stream =
                        File.OpenRead("Batman.dat"))
                    {
                        batmanCopy =
                           await MemoryPackSerializer.DeserializeAsync<MemHero>(stream);
                    }

                    Console.WriteLine(batmanCopy.Name);
                    Console.WriteLine(batmanCopy.GetAge());

                }
            }
        }//Ende BinaryFormatNeu
        public class BinaryFormatNativNeu
        {

            [Serializable]
            class NativHero
            {
                public string Name;
                public NativHero Partner;

                [NonSerialized]
                public string Stuff;

                private int age;
                public NativHero()
                {

                }
                public NativHero(string name, int age)
                {
                    Name = name;
                    this.age = age;
                }

                public int GetAge()
                {
                    return age;
                }
            }
            public static void TuWas()
            {
                static void BinaryExample()
                {
                    NativHero batman = new NativHero("Batman", 42);



                    // Serialisierung
                    using (BinaryWriter stream = new BinaryWriter(File.Open("Bat.bin", FileMode.Create)))
                    {
                        stream.Write(batman.Name);
                        stream.Write(batman.Partner.Name);
                    }

                    // Deserialisierung
                    NativHero batmanCopy;
                    using (BinaryReader stream =
                        new BinaryReader(File.Open("Bat.bin", FileMode.Open)))
                    {
                        batmanCopy = new NativHero
                        {
                            Name = stream.ReadString(),
                            Partner = new NativHero { Name = stream.ReadString() }
                        };
                    }
                    Console.WriteLine(batmanCopy.Name);
                    Console.WriteLine(batmanCopy.GetAge());
                }
            }
        }//Ende BinaryFormatNativNeu
    }//Ende Programm
}//Ende Namespace
