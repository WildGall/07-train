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
                int reservedWagon = 0;
                int compartment = 0;
                int wagonSV = 0;
                int passengers = 0;
                Scoreboard(startingRoute, endRoute, reservedWagon, compartment, wagonSV, passengers);
                CreateWay(out startingRoute, out endRoute);
                Train train = new Train();
                passengers = train.BuyTickets();

                while (passengers > 0)
                {
                    Scoreboard(startingRoute, endRoute, reservedWagon, compartment, wagonSV, passengers);
                    FormTarin(ref passengers, ref reservedWagon, ref compartment, ref wagonSV);
                }

                Scoreboard(startingRoute, endRoute, reservedWagon, compartment, wagonSV, passengers);
                Console.WriteLine("Поезд готов к отправке, нажмите любую клавишу, чтобы составить новый маршрут или [v], чтобы выйти..");

                if (Console.ReadLine() == "v")
                {
                    isWork = false;
                }

                Console.Clear();
            }
        }

        public void FormTarin(ref int passengers, ref int reservedWagon, ref int compartment, ref int wagonSV)
        {
            const string CommandReservedWagon = "1";
            const string CommandCompartment = "2";
            const string CommandWagonSV = "3";

            int capacityReservedWagon = 54;
            int capacityCompartment = 32;
            int capacityWagonSV = 18;

            Console.WriteLine("Добавте вагон.");
            Console.WriteLine($"{CommandReservedWagon})Плацкартный Вагон  - {capacityReservedWagon} мест.\n{CommandCompartment})Купе - {capacityCompartment}мест.\n{CommandWagonSV})Вагон СВ - {capacityWagonSV}мест.");
            Console.Write("Введите номер вагона:");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                 case CommandReservedWagon:
                    AddWagon(ref passengers, ref capacityReservedWagon, ref reservedWagon);
                    break;
                 case CommandCompartment:
                    AddWagon(ref passengers, ref capacityCompartment, ref compartment);
                    break;
                 case CommandWagonSV:
                    AddWagon(ref passengers, ref capacityWagonSV, ref wagonSV);
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

        public void Scoreboard(string startingRoute, string endRoute, int reservedCar, int compartment, int carSV, int passengers)
        {            
            Console.WriteLine("Текущий маршрут:\n");
            Console.WriteLine("Начало маршрута:" +  startingRoute );
            Console.WriteLine("Конечный пунтк:" + endRoute + "\n");
            Console.WriteLine($"Состав поезда:\nПлацкартный вагон:{reservedCar}\nКупе:{compartment}\nВагон СВ:{carSV}\n");

            if( passengers > 0) { Console.WriteLine("Необходимо разместить: " + passengers + " пасажиров"); }
            else { Console.WriteLine("Поезд укомплектован"); }
            
            Console.WriteLine("====================================================================================\n");
        }

        private void AddWagon(ref int passengers,ref int capacity,ref int wagon)
        {
            passengers -= capacity;
            wagon++;
            Console.Clear();
        }
    }

    class Train
    {   
        public int BuyTickets()
        {
            Random random = new Random();
            int quantityPassengers = random.Next(100, 1000);
            return quantityPassengers;
        }
    }
}
