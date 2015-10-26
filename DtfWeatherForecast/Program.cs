using DurableTask;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtfWeatherForecast
{
    class Program
    {
        static void Main(string[] args)
        {
            run();
        }
        private static void run()
        {
            string connectionString = ConfigurationManager.AppSettings["SbConnStr"];
            string taskHubName = ConfigurationManager.AppSettings["TaskHubName"];

            TaskHubClient taskHubClient = new TaskHubClient(taskHubName, connectionString);
            TaskHubWorker taskHubWorker = new TaskHubWorker(taskHubName, connectionString);

            taskHubWorker.CreateHub();
            OrchestrationInstance instance = taskHubClient.CreateOrchestrationInstance(typeof(WfTaskOrchestration), "Hello");

            taskHubWorker.AddTaskOrchestrations(typeof(WfTaskOrchestration));
            taskHubWorker.AddTaskActivities(new WOEIDLookupTask(), new WForecastsTask());
            taskHubWorker.Start();

            Console.WriteLine("Press any key to quit.");
            Console.ReadLine();


            taskHubWorker.Stop(true);
        }

    }
}
