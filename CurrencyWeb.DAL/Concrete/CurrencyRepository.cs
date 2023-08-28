using CurrencyWeb.DAL.Abstract;
using CurrencyWeb.Entities.Context;
using CurrencyWeb.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWeb.DAL.Concrete
{
    public class CurrencyRepository : ICurrencyRepository
    {
        public List<Currency> GetCurrencies()
        {
            using (var currencyContext = new CurrencyContext())
            {
                return currencyContext.Currencies.ToList();
            }
        }

        public Currency GetCurrencyById(int id)
        {
            using (var currencyContext = new CurrencyContext())
            {
                return currencyContext.Currencies.Find(id);
            }
        }

        public int GetCurrencyIdByName(string name)
        {
            using (var currencyContext = new CurrencyContext())
            {
                return currencyContext.Currencies.FirstOrDefault(c=>c.Code == name).Id;
            }
        }

        public MoneyRate GetMoneyRateById(int id)
        {
            using (var currencyContext = new CurrencyContext())
            {
                return currencyContext.MoneyRates.Find(id);
            }
        }

        public List<MoneyRate> GetMoneyRates()
        {
            using (var currencyContext = new CurrencyContext())
            {
                return currencyContext.MoneyRates.ToList();
            }
        }
    }
}
