using System;

namespace _07_train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Station station = new Station();
            station.Work();
        }
    }
    class Station
    {
        public void Work()
        {
            bool isWork = true;

            while (isWork)
            {
                string startingRoute = " Пусто";
                string endRoute = " Пусто";
                int passengers = 0;
                Wagon reservedWagon = new Wagon(54);
                Wagon compartment = new Wagon(32);
                Wagon wagonSV = new Wagon(18);
                Train train = new Train();
                OutputInScoreboard(startingRoute, endRoute, reservedWagon.ShowQuantity(), compartment.ShowQuantity(), wagonSV.ShowQuantity(), passengers);
                CreateWay(out startingRoute, out endRoute);
                passengers = train.AddPassengers();

                while (passengers > 0)
                {
                    OutputInScoreboard(startingRoute, endRoute, reservedWagon.ShowQuantity(), compartment.ShowQuantity(), wagonSV.ShowQuantity(), passengers);
                    FormTarin(reservedWagon, compartment, wagonSV, passengers);
                }

                OutputInScoreboard(startingRoute, endRoute, reservedWagon.ShowQuantity(), compartment.ShowQuantity(), wagonSV.ShowQuantity(), passengers);
                Console.WriteLine("Поезд готов к отправке, нажмите любую клавишу, чтобы составить новый маршрут или [j], чтобы выйти..");

                if (Console.ReadLine() == "j")
                {
                    isWork = false;
                }

                Console.Clear();
            }
        }

        public void FormTarin(Wagon reserved, Wagon compartment,Wagon wagonSV, int passengers)
        {
            const string CommandReservedWagon = "1";
            const string CommandCompartment = "2";
            const string CommandWagonSV = "3";

            Console.WriteLine("Добавте вагон.");
            Console.WriteLine($"{CommandReservedWagon})Плацкартный Вагон  - {reserved.ShowCompartment()} мест.\n{CommandCompartment})Купе - {compartment.ShowCompartment()}мест.\n{CommandWagonSV})Вагон СВ - {wagonSV.ShowCompartment()}мест.");
            Console.Write("Введите номер вагона:");

            string userInput = Console.ReadLine();            

            switch (userInput)
            {
                case CommandReservedWagon:
                    reserved.AddWagon(passengers);
                    break;
                case CommandCompartment:
                    compartment.AddWagon(passengers);
                    break;
                case CommandWagonSV:
                    wagonSV.AddWagon(passengers);
                    break;
            }
        }

        public void CreateWay(out string startingRoute, out string endRoute)
        {
            Console.Write("Введите начальный пункт маршрута:");
            startingRoute = Console.ReadLine();
            Console.Write("Введите конечный пункт маршрута:");
            endRoute = Console.ReadLine();
            Console.WriteLine("Маршрут создан.");
            Console.ReadKey();
            Console.Clear();
        }

        public void OutputInScoreboard(string startingRoute, string endRoute, int reservedCar, int compartment, int carSV, int passengers)
        {
            Console.WriteLine("Текущий маршрут:\n");
            Console.WriteLine("Начало маршрута:" + startingRoute);
            Console.WriteLine("Конечный пунтк:" + endRoute + "\n");
            Console.WriteLine($"Состав поезда:\nПлацкартный вагон:{reservedCar}\nКупе:{compartment}\nВагон СВ:{carSV}\n");

            if (passengers > 0) { Console.WriteLine("Необходимо разместить: " + passengers + " пасажиров"); }
            else { Console.WriteLine("Поезд укомплектован"); }

            Console.WriteLine("====================================================================================\n");
        }
       
    }

    class Wagon
    {
        private int _quantity;
        private int _compartment;

        public Wagon(int compartment)
        {
            _compartment = compartment;
        }

        public int AddWagon(int passengers)
        {
            passengers -= _compartment;
            _quantity++;
            Console.Clear();
            return passengers;
        }

        public int ShowQuantity()
        {
            return _quantity;
        }

        public int ShowCompartment()
        {
            return _compartment;
        }

        public int QuantityPlus()
        {
            _quantity++;
            return _quantity;
        }
    }

    class Train
    {
        public int AddPassengers()
        {
            Random random = new Random();
            int quantity = random.Next(100, 1000);
            return quantity;
        }
    }
}
