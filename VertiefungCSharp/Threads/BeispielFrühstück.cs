using System.Diagnostics;
using System.Threading.Tasks;

namespace Threads
{
    internal partial class Program
    {
        class Egg { }
        class Juice { }
        class Toast { }
        class Bacon { }
        class Coffee { }

        public class BeispielFrühstück
        {
            private static Juice PourOJ()
            {
                Console.WriteLine("Pouring orange juice");
                return new Juice();
            }

            private static void ApplyJam(Toast toast)
            {
                Console.WriteLine("Putting jam on the toast");
            }

            private static void ApplyButter(Toast toast)
            {
                Console.WriteLine("Putting butter on the toast");
            }

            private static async Task<Toast> ToastBreadAsync(int slices)
            {
                for (int slice = 0; slice < slices; slice++)
                {
                    Console.WriteLine("Putting a slice of bread in the toaster");
                }
                Console.WriteLine("Start toasting...");
                await Task.Delay(3000);
                Console.WriteLine("Remove toast from toaster");
                return new Toast();
            }
            private static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
            {
                var toast = await ToastBreadAsync(number);
                ApplyButter(toast);
                ApplyJam(toast);

                return toast;
            }

            private static async Task<Bacon> FryBaconAsync(int slices)
            {
                Console.WriteLine($"putting {slices} slices of bacon in the pan");
                Console.WriteLine("cooking first side of bacon...");
                await Task.Delay(3000);
                for (int slice = 0; slice < slices; slice++)
                {
                    Console.WriteLine("flipping a slice of bacon");
                }
                Console.WriteLine("cooking the second side of bacon...");
                await Task.Delay(3000);
                Console.WriteLine("Put bacon on plate");
                return new Bacon();
            }

            private static async Task<Egg> FryEggsAsync(int howMany)
            {
                Console.WriteLine("Warming the egg pan...");
                await Task.Delay(3000);
                Console.WriteLine($"cracking {howMany} eggs");
                Console.WriteLine("cooking the eggs ...");
                await Task.Delay(3000);
                Console.WriteLine("Put eggs on plate");
                return new Egg();
            }
            private static Coffee PourCoffee()
            {
                Console.WriteLine("Pouring coffee");
                return new Coffee();
            }

            public static async Task TuWas()//Main
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                Coffee cup = PourCoffee();
                Console.WriteLine("coffee is ready");

                Task<Egg> eggsTask = FryEggsAsync(2);
                Task<Bacon> baconTask = FryBaconAsync(3);
                Task<Toast> toastTask = MakeToastWithButterAndJamAsync(2);

                List<Task> breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
                while (breakfastTasks.Count > 0)
                {
                    Task finished = await Task.WhenAny(breakfastTasks);
                    if(finished == eggsTask)
                        Console.WriteLine("eggs are ready");
                    else if(finished == baconTask)
                        Console.WriteLine("bacon is ready");
                    else
                        Console.WriteLine("toast is ready");
                    breakfastTasks.Remove(finished);
                }

                Juice oj = PourOJ();
                Console.WriteLine("oj is ready");

                sw.Stop();

                Console.WriteLine($"Breakfast is ready: {sw.ElapsedMilliseconds} ms");

            }//Ende Tuwas
        }//Ende class BeispielFrühstück
    }//Ende class Programm
}//Ende Namespace
