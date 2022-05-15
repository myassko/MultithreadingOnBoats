using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingOnBoats
{
    public class ShipGenerator
    {
        public object Block = new object();
        public Tunnel Tunnel { get; }
        public int ShipCount { get; private set; }
        private int countShip = 1;

        public ShipGenerator(Tunnel tunnel, int shipCount)
        {
            Tunnel = tunnel;
            ShipCount = shipCount;

        }
        public void Start()
        {
            while (countShip <= ShipCount)
            {

                var ship = new Ship(CreateType(), CreateSize());
                if (Tunnel.AddShip(ship))
                {
                    //Console.WriteLine(count);
                    countShip++;
                    try
                    {
                        Thread.Sleep(100);
                    }
                    catch
                    {
                    }
                }

            }

        }

        static public Sizes CreateSize()
        {
            var a = Enum.GetValues(typeof(Sizes));
            return (Sizes)a.GetValue(new Random().Next(a.Length));
        }

        static public Types CreateType()
        {
            var a = Enum.GetValues(typeof(Types));
            return (Types)a.GetValue(new Random().Next(a.Length));
        }
    }
}
