using System;
using System.Text;

namespace Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            double usdPrice;
            double eurPrice;
            int option;
            double money;
            Console.WriteLine("Введіть курс долару та євро");
            usdPrice = Convert.ToDouble(Console.ReadLine());
            eurPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Оберіть функцію: \n1. Перевести гривні в долари \n2. Перевести долари в гривні \n3. Перевести гривні в євро \n4. Перевести євро в гривні");
            option = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть суму валюти");
            money = Convert.ToDouble(Console.ReadLine());
            Converter conv = new Converter(usdPrice, eurPrice);
            if (option == 1)
            {
                Console.WriteLine(conv.uahToUsd(money).ToString() + " USD");
            }
            else if (option == 2)
            {
                Console.WriteLine(conv.usdToUah(money).ToString() + " UAH");
            }
            else if (option == 3)
            {
                Console.WriteLine(conv.uahToEur(money).ToString() + " EUR");
            }
            else
            {
                Console.WriteLine(conv.eurToUah(money).ToString() + " UAH");
            }
        }
    }

    class Converter
    {
        //private double uah;
        private double usdPrice;
        private double eurPrice;
        public Converter(double usd, double eur)
        {
            usdPrice = usd;
            eurPrice = eur;
        }
        public double uahToUsd(double money)
        {
            return (money / usdPrice);
        }
        public double usdToUah(double money)
        {
            return (money * usdPrice);
        }
        public double uahToEur(double money)
        {
            return (money / eurPrice);
        }
        public double eurToUah(double money)
        {
            return (money * eurPrice);
        }
    }
}