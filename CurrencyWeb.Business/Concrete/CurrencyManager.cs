using CurrencyWeb.Business.Abstract;
using CurrencyWeb.DAL.Abstract;
using CurrencyWeb.DAL.Concrete;
using CurrencyWeb.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWeb.Business.Concrete
{
    public class CurrencyManager : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository; 
        public CurrencyManager()
        {
            _currencyRepository = new CurrencyRepository();
        }

        public List<Currency> GetCurrencies()
        {
            return _currencyRepository.GetCurrencies();
        }

        public Currency GetCurrencyById(int id)
        {
            return _currencyRepository.GetCurrencyById(id);
        }

        public int GetCurrencyIdByName(string name)
        {
            return _currencyRepository.GetCurrencyIdByName(name);
        }

        public MoneyRate GetMoneyRateById(int id)
        {
            return _currencyRepository.GetMoneyRateById(id);
        }

        public List<MoneyRate> GetMoneyRates()
        {
            return _currencyRepository.GetMoneyRates();
        }
    }
}
