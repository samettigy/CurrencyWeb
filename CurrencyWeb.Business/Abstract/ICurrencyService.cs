using CurrencyWeb.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWeb.Business.Abstract
{
    public interface ICurrencyService
    {
        List<Currency> GetCurrencies();
        Currency GetCurrencyById(int id);
        List<MoneyRate> GetMoneyRates();
        MoneyRate GetMoneyRateById(int id);
        int GetCurrencyIdByName(string name);

    }
}
