using System;
using System.Runtime.CompilerServices;
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;    
        Converter converter = new Converter(45.0m, 41.0m);
        while (true)
        {
            Console.WriteLine("Оберiть дію");
            Console.WriteLine("1.Конвертувати валюту в гривнi");
            Console.WriteLine("2.Конвертувати гривні в валюту ");
            Console.WriteLine("3.Додати нову валюту, або змiнити курс");
            Console.WriteLine("4.Подивитися доступні валюти");
            Console.WriteLine("5.Завершити роботу");
            int choise = int.Parse(Console.ReadLine());
            if (choise == 1)
            {
                ConvertToUah(converter);
            }
            else if (choise == 2)
            {
                ConvertFromUah(converter);
            }
            else if (choise == 3)
            {
                AddOrEditCurrency(converter);
            }
            else if (choise == 4)
            {
                converter.ShowCurrency();
            }
            else if (choise == 5) 
            {
                return; 
            }
            else
            {
                Console.WriteLine("Введіть потрiбний номер зi спискy");
            }
        }
        void ConvertToUah(Converter converter)
        {
            decimal amount;
            string currency;
            Console.WriteLine("Введiть валюту");
            currency = Console.ReadLine();
            Console.WriteLine($"Введіть суму в {currency}");
            amount = decimal.Parse(Console.ReadLine());
            decimal result = converter.ConvertToUah(amount, currency);
            if (result>0) Console.WriteLine($"{amount} {currency} = {result} грн");
        }
        void ConvertFromUah(Converter converter)
        {
            decimal amount;
            string currency;
            Console.WriteLine("Введiть валюту");
            currency = Console.ReadLine();
            Console.WriteLine("Введіть суму в грн");
            while (!decimal.TryParse(Console.ReadLine(), out amount) || amount<=0)
            {
                Console.WriteLine("Введіть коректну суму.");
            }
            decimal result = converter.ConvertFromUah(amount, currency);
            if (result > 0)  Console.WriteLine($"{amount} грн = {result} {currency}");
        }
        void AddOrEditCurrency (Converter converter)
        {
            string currency;
            decimal rate= 0;
            Console.WriteLine("Введiть валюту");
            currency= Console.ReadLine();
            Console.WriteLine($"Введiть курс {currency}");
            rate = decimal.Parse(Console.ReadLine());
            converter.AddOrEditCurrency(rate, currency);
            Console.WriteLine("done");
        }

    }
}