using CurrencyWeb.Business.Abstract;
using CurrencyWeb.DataAPI.Helpers;
using CurrencyWeb.Entities.Context;
using CurrencyWeb.Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Namotion.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Ntt;
using System.Data;
using System.Net.Http.Headers;
using System.Xml.Xsl;

namespace CurrencyWeb.DataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

       

        [HttpGet]
        [Route("GetCurrency")]
        public async Task<List<Currency>> GetCurrenyAsync()
        {

            List<Currency> data = await XmlHelper.GetAllCurrencyCode();

            return data;
        }

        [HttpGet]
        [Route("GetCurrencyById/{id}")]
        public Currency Get(int id)
        {

            return _currencyService.GetCurrencyById(id);
        }
        
        [HttpGet]
        [Route("GetMoneyRate/{currencyCode}")]
        public async Task<List<MoneyRate>> GetMoneyAsync(string currencyCode)
        {
            int id = _currencyService.GetCurrencyIdByName(currencyCode);


            List<MoneyRate> data = await JsonHelper.GetCurrencyInfoAsync(currencyCode, id);

            using (var dbContext = new CurrencyContext())
            {
                if (dbContext.MoneyRates.Count() > 0)
                {
                    dbContext.MoneyRates.RemoveRange(dbContext.MoneyRates);
                    dbContext.SaveChanges();

                }
                else
                {
                    foreach (var item in data)
                    {
                        dbContext.MoneyRates.Add(item);

                    }
                }


                dbContext.SaveChanges();
                //try
                //{
                //    // Değişiklikleri kaydet
                    
                //}
                //catch (DbUpdateException ex)
                //{
                //    // Entity Framework Core'dan gelen genel hata
                //    Console.WriteLine("DbUpdateException: " + ex.Message);

                //    // InnerException ile daha detaylı hatayı al
                //    Exception innerException = ex.InnerException;
                //    while (innerException != null)
                //    {
                //        Console.WriteLine("Inner Exception: " + innerException.Message);
                //        innerException = innerException.InnerException;
                //    }

                //    // Detaylı hata izini
                //    Console.WriteLine("Stack Trace: " + ex.StackTrace);

                //    // Özel hata kodları veya tanımlayıcılar varsa
                //    if (ex is Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
                //    {
                //        Console.WriteLine("Concurrency Exception: " + ex.Message);
                //        // Özel işlemler
                //    }
                //    else if (ex is Microsoft.EntityFrameworkCore.DbUpdateException)
                //    {
                //        Console.WriteLine("Update Exception: " + ex.Message);
                //        // Özel işlemler
                //    }
                //    else
                //    {
                //        // Diğer hata türleri için özel işlemler
                //    }
                //}


            }


            return data;
        }

        [HttpGet]
        [Route("GetMoneyRateById/{id}")]
        public MoneyRate GetMoney(int id)
        {
            return _currencyService.GetMoneyRateById(id);
        }
    }
}
