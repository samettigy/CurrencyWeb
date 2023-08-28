using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using CurrencyWeb.Entities.Model;

namespace CurrencyWeb.DataAPI.Helpers
{
    public static class JsonHelper
    {
        public static async Task<List<MoneyRate>> GetCurrencyInfoAsync(string currency, int id)
        {

            string satis = "S";
            List<MoneyRate> datas = new List<MoneyRate>();


            // HTTP GET.  
            using (var client = new HttpClient())
            {
                // Setting Base address.  
                //client.BaseAddress = new Uri("https://localhost:44334/");

                // Setting content type.  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Initialization.  
                HttpResponseMessage response = new HttpResponseMessage();

                // HTTP GET  

                for (int i = 0; i < 2; i++)
                {
                    string url = @"https://evds2.tcmb.gov.tr/service/evds/series=TP.DK." + currency + "." + satis + ".YTL&startDate=" + DateTime.Now.Date.AddMonths(-2).ToString("dd-MM-yyyy") + "&endDate=" + DateTime.Now.Date.ToString("dd-MM-yyyy") + "&type=json&key=7jcfZyrIVA";
                    string currencyItem = "TP_DK_" + currency + "_" + satis + "_YTL";

                    response = await client.GetAsync(url).ConfigureAwait(false);

                    // Verification  
                    if (response.IsSuccessStatusCode)
                    {
                        // Reading Response.  
                        string result = response.Content.ReadAsStringAsync().Result;
                        var arrObj = JsonConvert.DeserializeObject(result, new JsonSerializerSettings { DateFormatString = "dd-MM-yyyy" }) as JObject;


                        JArray items = (JArray)arrObj["items"];



                        if (datas.Count != 0)
                        {

                            foreach (JObject item in items)
                            {
                                if (!String.IsNullOrEmpty(item[currencyItem].ToString()))
                                {
                                    double responseBuy = (double)item[currencyItem];
                                    DateTime date = ((DateTime)item["Tarih"]).Date;

                                    datas[datas.FindIndex(x => x.Date == date)].Buy = responseBuy;

                                }
                            }
                        }
                        else
                        {
                            foreach (JObject item in items)
                            {
                                if (!String.IsNullOrEmpty(item[currencyItem].ToString()))
                                {
                                    double responseSell = (double)item[currencyItem];
                                    DateTime date = ((DateTime)item["Tarih"]).Date;

                                    datas.Add(new MoneyRate { Sell = responseSell, Date = date, CurrencyId = id });

                                }
                            }
                            satis = "A";
                        }


                    }

                }

            }
            return datas;



        }
    }
}
