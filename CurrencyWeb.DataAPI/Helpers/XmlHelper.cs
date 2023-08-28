using CurrencyWeb.Entities.Context;
using CurrencyWeb.Entities.Model;
using System;
using System.Xml;
using System.Xml.Linq;

namespace CurrencyWeb.DataAPI.Helpers
{
    public class XmlHelper
    {

        public static async Task<List<Currency>> GetAllCurrencyCode()
        {

            string xmlUrl = "https://www.tcmb.gov.tr/kurlar/today.xml";
            XDocument xmlDoc = XDocument.Load(xmlUrl);

            List<Currency> currencyList = new List<Currency>();

           
            using (var dbContext = new CurrencyContext())
            {
                var currencyElements = xmlDoc.Descendants("Currency");

                if (dbContext.Currencies.Count() > 0)
                {
                    dbContext.Currencies.RemoveRange(dbContext.Currencies);
                    dbContext.SaveChanges();

                }

                foreach (var currencyElement in currencyElements)
                {
                    var currencyCode = currencyElement.Attribute("CurrencyCode").Value;


                    var currencyRate = new Currency
                    {
                        Code = currencyCode
                    };



                    currencyList.Add(currencyRate);
                    dbContext.Currencies.Add(currencyRate);
                }

                dbContext.SaveChanges();
            }

            return currencyList;


    }

    }
}

