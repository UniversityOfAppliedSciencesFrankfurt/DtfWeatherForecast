using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurableTask;
using System.Xml.XPath;
using System.Xml;


namespace DtfWeatherForecast
{
   public class WForecastsTask : TaskActivity<string,string>
    {
        /// <summary>
        /// This Task will find out Weather Forecast for particular City
        /// </summary>
        /// <param name="context">TaskContext Type</param>
        /// <param name="input">It will take WOIED code of any particular City</param>
        /// <returns>It will return weather forecast details</returns>
        /// 
        protected override string Execute(TaskContext context, string input)
        {
            string weatherForecasts = string.Empty;
            string woeidCodeUri = string.Format("http://xml.weather.yahoo.com/forecastrss?w={0}&u=c", input);
            XmlDocument doc = new XmlDocument();
            doc.Load(woeidCodeUri);

            // Set up namespace manager for XPath  
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");

            XmlNode channel = doc.SelectSingleNode("rss").SelectSingleNode("channel");
            XmlNodeList nodes = doc.SelectNodes("/rss/channel/item/yweather:forecast", ns);

            var title = channel.SelectSingleNode("title", ns).InnerText;
            var date = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", ns).Attributes["date"].Value;
            var condition = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", ns).Attributes["text"].Value;
            var temp = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", ns).Attributes["temp"].Value;
            var forecast = "";
            for (int i = 0; i < nodes.Count; i++)
            {
                forecast += nodes.Item(i).Attributes["day"].Value + " - " + nodes.Item(i).Attributes["date"].Value + " " + nodes.Item(i).Attributes["text"].Value + ". High: " + nodes.Item(i).Attributes["high"].Value + " Low: " + nodes.Item(i).Attributes["low"].Value + "\n";
            }



            Console.WriteLine("{0}\n------------------------------\n{1}\n\nCurrent Condition : \n{2}, {3} C\n\nForecast : \n\n{4}",
                title, date, condition, temp, forecast);



            return weatherForecasts = string.Format("{0}\n------------------------------\n{1}\n\nCurrent Condition : \n{2}, {3} C\n\nForecast : \n\n{4}",
                title, date, condition, temp, forecast);
        }
    }
}
