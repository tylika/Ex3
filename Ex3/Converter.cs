using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Converter
{
    private decimal euro;
    private decimal dolar;

    public decimal Euro { get
        {
            return euro;
        }
        set
        {
            if (value < 0) euro = 0;
            else euro = value;
        }
    }
    public decimal Dolar
    {
        get
        {
            return dolar;
        }
        set
        {
            if (value < 0) dolar = 0;
            else dolar = value;
        }
    }
    Dictionary<string, decimal> ExchangeRate;
    public Converter(decimal euro1, decimal dolar1)
    {
        ExchangeRate = new Dictionary<string, decimal>
        {
            {"EUR", euro1 },
            {"USD", dolar1 }
        };
    }

    public decimal ConvertToUah(decimal amount, string currency)
    { decimal rate = 0;
        if (!ExchangeRate.TryGetValue(currency, out rate)) { Console.WriteLine("Невiдома валюта, повернiться на початок, щоб додати"); }
        decimal result = rate*amount;
        return result;
    }
    public decimal ConvertFromUah(decimal amount, string currency)
    {
        decimal rate = 0;
        if (!ExchangeRate.TryGetValue(currency, out rate)) { Console.WriteLine("Невiдома валюта, повернiться на початок, щоб додати"); return 0; }
        decimal result = amount / rate;
        return result;
    }
    public void AddOrEditCurrency(decimal amount, string currency)
    {
        ExchangeRate[currency]  = amount;
    }
    public void ShowCurrency()
    {
        string res = "";
        foreach(KeyValuePair<string, decimal> item in ExchangeRate)
        {
            res = "1 " + item.Key +" = " + item.Value + " грн";
            Console.WriteLine(res);
        }
       
    }
}

