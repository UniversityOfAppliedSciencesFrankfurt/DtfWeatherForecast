using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurableTask;

namespace DtfWeatherForecast
{
    public class WfTaskOrchestration : TaskOrchestration<string,string>
    {
        /// <summary>
        /// Task Orchestration for scheduling Tasks
        /// </summary>
        /// <param name="context"></param>
        /// <param name="input"></param>
        /// <returns>It will return a string type value</returns>
        /// 
        public override async Task<string> RunTask(OrchestrationContext context, string input)
        {
            string woeidCode = await context.ScheduleTask<string>(typeof(WOEIDLookupTask), input);
            var wForecasts = await context.ScheduleTask<string>(typeof(WForecastsTask), woeidCode);
            return wForecasts;
        }
    }
}
