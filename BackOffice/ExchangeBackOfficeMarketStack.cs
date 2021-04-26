using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using YouggySWLib.Model;
using YouggySWLib.Model.API;

namespace YouggySWLib.BackOffice
{
    public class ExchangeBackOfficeMarketStack
    {
        const string urlBase = "http://api.marketstack.com/v1/";

        const string apiKey = "7c9be28ac9614e34f9278208dfb28f31";

        private int limitationForAPage;

        public ExchangeBackOfficeMarketStack(int limitationForAPage)
        {
            this.limitationForAPage = limitationForAPage;
        }

        public List<Value> GetDailyValues(string symbole, string exchange)
        {
            List<Value> values = new List<Value>();

            string responseJson = string.Empty;
            string url = urlBase + @"eod?access_key=" + apiKey + "&symbols=" + symbole + "&exchange=" + exchange;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                responseJson = reader.ReadToEnd();
            }

            DayValues dayValues = JsonConvert.DeserializeObject<DayValues>(responseJson);

            foreach (DayValue datum in dayValues.Data)
            {
                Value value = new Value();
                value.CloseValue = float.Parse(datum.Close.ToString());
                value.OpenValue = float.Parse(datum.Open.ToString());
                value.LowValue = float.Parse(datum.Low.ToString());
                value.HighValue = float.Parse(datum.High.ToString());
                value.Exchange = datum.Exchange;
                value.Symbol = datum.Symbol;
                value.DateValue = datum.Date;

                values.Add(value);
            }

            return values;
        }

        public Tickers GetSymbolsInformation(int offset = 0)
        {
            string responseJson = string.Empty;
            offset = offset * limitationForAPage;

            string url = urlBase + @"tickers?access_key=" + apiKey + "&offset=" + offset + "&limit=" + limitationForAPage;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                responseJson = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<Tickers>(responseJson);           
        }
    }
}
