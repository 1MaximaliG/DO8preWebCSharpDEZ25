using System;
using System.Collections.Generic;
using System.Text;

namespace EventsDO8
{
    public class WarpKern
    {
        private int _warpkernTemperatur = 0;//laut memoryAlpha 2.500.000°K startteperatur
        public int WarpkernTemperatur { get { return _warpkernTemperatur; } }//Property
        //ausführliche Variante
        private EventHandler _tempChange;
        public event EventHandler TempChange
        {
            add { _tempChange += value; }
            remove { _tempChange -= value; }
        }

        //Kurze schreibweise
        public event EventHandler Alert;

        public void ändereTemperatur()
        {
            Random rnd = new Random();
            int änderung = rnd.Next(-100, 201);
            if ((_warpkernTemperatur + änderung) > 0)
            {
                _warpkernTemperatur += änderung;
                _tempChange.Invoke(this, new EventArgs());
                if (_warpkernTemperatur >= 500)
                {
                    Alert.Invoke(this, new EventArgs());
                }
            }
        }
    }

    public class WarpKernKonsole
    {
        private WarpKern _kern;
        public WarpKernKonsole(WarpKern warpKern)
        {
            _kern = warpKern;
            _kern.TempChange += Anzeige;
            _kern.Alert += Warnung;
        }
        public void Anzeige(object sender, EventArgs e)
        {
            //WarpKern temp = sender as WarpKern;//möglichkeit zur verwendung der Object Sender
            Console.WriteLine("Der Warpkern hat eine Temperatur von: " + _kern.WarpkernTemperatur);
            Console.WriteLine("Zeit: " + DateTime.Now);
        }
        public void Warnung(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("RED ALERT!!!");
            Console.ResetColor();
        }
    }
    internal class StarFleet
    {
        public static void TuWas()
        {
            WarpKern kern = new WarpKern();
            WarpKernKonsole konsole = new WarpKernKonsole(kern);
            string eingabe = "";
            do
            {
                eingabe = Console.ReadLine();
                kern.ändereTemperatur();
            } while (eingabe != "stop");
        }
    }
}
