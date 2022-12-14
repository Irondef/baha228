using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выбор задания: 1, 2, 3");
            int numb = Convert.ToInt32(Console.ReadLine());
            switch (numb) {
                case 1:
                    CurrencyExchange.Exchange();
                    break;
                case 2:
                    MultiplicationTable.Multiplicate();
                    break;
                case 3:
                    Cinema.FillPlaces();
                    Cinema.AddClient();
                    break;
            }
        }
    }

    public static class CurrencyExchange { // Задание 1
        
        static double[] currencyArray = {1.0, 1.02, 0.012, 0.016};
        static string[] currencyNameArray = {"usd", "eur", "kgs", "rub"};

        public static void Exchange() {
            Console.WriteLine("Введите вашу валюту: usd, eur, kgs, rub");
            string currency = Console.ReadLine()!;
            double sum;
            double newsum;
            switch(currency) {
                case "usd":
                    Message("usd");
                    sum = Convert.ToDouble(Console.ReadLine());
                    newsum = currencyArray[0] * sum;
                    for (int i = 0; i < currencyArray.Length; i++)
                    {
                        if(i == 0) continue;
                        Console.WriteLine("{0} usd = {1} {2}", sum, newsum / currencyArray[i], currencyNameArray[i]);
                    }
                    break;
                case "eur":
                    Message("eur");
                    sum = Convert.ToDouble(Console.ReadLine());
                    newsum = currencyArray[1] * sum;
                    for (int i = 0; i < currencyArray.Length; i++)
                    {
                        if(i == 1) continue;
                        Console.WriteLine("{0} eur = {1} {2}", sum, newsum / currencyArray[i], currencyNameArray[i]);
                    }
                    break;
                case "kgs":
                    Message("kgs");
                    sum = Convert.ToDouble(Console.ReadLine());
                    newsum = currencyArray[2] * sum;
                    for (int i = 0; i < currencyArray.Length; i++)
                    {
                        if(i == 2) continue;
                        Console.WriteLine("{0} kgs = {1} {2}", sum, newsum / currencyArray[i], currencyNameArray[i]);
                    }
                    break;
                case "rub":
                    Message("rub");
                    sum = Convert.ToDouble(Console.ReadLine());
                    newsum = currencyArray[3] * sum;
                    for (int i = 0; i < currencyArray.Length; i++)
                    {
                        if(i == 3) continue;
                        Console.WriteLine("{0} rub = {1} {2}", sum, newsum / currencyArray[i], currencyNameArray[i]);
                    }
                    break;
                default:
                    break;
            }
        }

        static void Message(string currentCurrency) {
            Console.WriteLine("Введите сумму {0}, которое вы хотите обменять", currentCurrency);
        }
    }

    public static class MultiplicationTable { //Задание 2
        public static void Multiplicate() {
            int multiplicateNum = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0} * {1} = {2}", multiplicateNum, i, multiplicateNum * i);
            }
        }
    }

    public static class Cinema { //Задание 3

        static int[] placeNum = new int[90]; //90 - количество мест
        static int[] placeOcuppied = new int[90];

        public static void FillPlaces() {
            for (int i = 0; i < placeNum.Length; i++)
            {
                placeNum[i] = i;
            }
        }

        public static void AddClient() {

            int ticketsSold = 0;
            int ticketPrice = 0;
            int soldTicketPrice = 0;
            bool isOccupied = false;

            Console.WriteLine("Введите номер места, для брони (10 - 90). Занятые места: ");
            for (int i = 1; i < 9; i++)
            {
                ticketPrice = ticketPrice + 100;
                Console.WriteLine();
                for (int x = 0; x < 10; x++)
                {
                    isOccupied = false;
                    for (int z = 0; z < placeOcuppied.Length; z++)
                    {
                        if (placeOcuppied[z] == placeNum[i*10+x])
                        {
                            Console.Write("[{0}] ", placeNum[i*10+x]);
                            ticketsSold++;
                            soldTicketPrice = soldTicketPrice + ticketPrice;
                            isOccupied = true;
                        }
                    }
                    if(isOccupied == true) continue;
                    Console.Write("{0} ", placeNum[i*10+x]);
                }
            }
            Console.WriteLine("Продано билетов:{0}, на сумму {1}", ticketsSold, ticketsSold * soldTicketPrice);
            int chosenPlace = Convert.ToInt32(Console.ReadLine());
            placeOcuppied[chosenPlace] = chosenPlace;
            AddClient();
        }

    }
