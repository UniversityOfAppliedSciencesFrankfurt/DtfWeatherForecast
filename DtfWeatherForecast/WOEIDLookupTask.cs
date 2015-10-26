using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurableTask;
using System.Xml;


namespace DtfWeatherForecast
{
   public class WOEIDLookupTask : TaskActivity<string,string>
    {
       /// <summary>
       /// It will take a city name from a Form Application CityList and find out WOIED code for this city
       /// </summary>
       /// <param name="context">This is TaskContext Type</param>
       /// <param name="input">This will take input out side of this Task</param>
       /// <returns>It will return WOIED code of a particular City</returns>
       /// 
        protected override string Execute(TaskContext context, string input)
        {
            CityList cityList = new CityList();
            cityList.ShowDialog();
            string woeidCode = string.Empty;
            string url = string.Format("http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20geo.places%20where%20text%3D%22{0}%20DE%22&format=xml", cityList.cityName);

            XmlTextReader reader1 = new XmlTextReader(url);
            while (reader1.Read())
            {
                if (reader1.Name == "woeid")
                {
                    if (reader1.Read())
                    {
                        woeidCode = reader1.Value;
                    }
                    break;
                }
            }
            return woeidCode;
        }
    }
}
