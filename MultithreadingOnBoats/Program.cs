﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace MultithreadingOnBoats
{
    internal class Program
    {
        public const int PierLoadersCount = 3;

        static public void Start()
        {
            var tunnel = new Tunnel();
            ShipGenerator generator = new ShipGenerator(tunnel, 10);
            PierLoader BananaPierLoader = new PierLoader(tunnel, Types.Banana);
            PierLoader BreadPierLoader = new PierLoader(tunnel, Types.Bread);
            PierLoader ClothesPierLoader = new PierLoader(tunnel, Types.Clothe);

            Thread GeneratorThread = new Thread(new ThreadStart(generator.Start));
            GeneratorThread.Name = "Генерация";

            Thread BananaThread = new Thread(new ThreadStart(BananaPierLoader.Start));
            BananaThread.Name = "Бананы";

            Thread BreadThread = new Thread(new ThreadStart(BreadPierLoader.Start));
            BreadThread.Name = "Хлеб";

            Thread ClothesThread = new Thread(new ThreadStart(ClothesPierLoader.Start));
            ClothesThread.Name = "Одежда";

            List<Tuple<PierLoader, Thread>> pierLoadersAndThreads = new List<Tuple<PierLoader, Thread>>();
            pierLoadersAndThreads.Add(Tuple.Create<PierLoader, Thread>(BananaPierLoader, BananaThread));
            pierLoadersAndThreads.Add(Tuple.Create<PierLoader, Thread>(BreadPierLoader, BreadThread));
            pierLoadersAndThreads.Add(Tuple.Create<PierLoader, Thread>(ClothesPierLoader, ClothesThread));

            GeneratorThread.Start();
            BananaThread.Start();
            BreadThread.Start();
            ClothesThread.Start();

            GeneratorThread.Join();
            Console.WriteLine("Генератор закончил работу\n");
            StopPierLoaders(pierLoadersAndThreads);


            BananaThread.Join();
            Console.WriteLine("Причал с бананами заверишл работу");

            BreadThread.Join();
            Console.WriteLine("Причал с хлебом завершил  работу");

            ClothesThread.Join();
            Console.WriteLine("Причал с одеждой заверишл работу");
        }

        static public void StopPierLoaders(List<Tuple<PierLoader, Thread>> pierLoadersList)
        {
            Thread.Sleep(10000);
            for (int i = 0; i < PierLoadersCount; i++)
            {
                try
                {
                    pierLoadersList[i].Item1.Break();
                    pierLoadersList[i].Item2.Interrupt();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        static void Main(string[] args)
        {
            Thread SecondaryThread = new Thread(Start);
            SecondaryThread.Name = "Многопоточность на корабликах";
            SecondaryThread.Start();

            SecondaryThread.Join();
            Console.WriteLine($"Поток {SecondaryThread.Name} закончил работу");
        }
    }
}