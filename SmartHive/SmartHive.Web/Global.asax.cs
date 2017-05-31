using Newtonsoft.Json.Linq;
using SmartHive.Services;
using SmartHive.Services.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SmartHive.Web
{
    public class MvcApplication : System.Web.HttpApplication
    { 
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Thread thread = new Thread(SendNotifications);
            thread.Start();
        }

        private void SendNotifications()
        {
            while (true)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    try
                    {
                        Task<string> response = httpClient.GetStringAsync($"https://api.thingspeak.com/channels/279981/feeds.json?api_key=EXO847SOXW7L55HJ");
                        JObject json = JObject.Parse(response.Result);
                        IList<JToken> results = json["feeds"].Children().ToList();
                        IList<JsonHive> hives = new List<JsonHive>();
                        EmailService es = new EmailService();
                        SMSSenderService ss = new SMSSenderService();

                        foreach (var result in results)
                        {
                            JsonHive hiveRes = result.ToObject<JsonHive>();
                            hives.Add(hiveRes);
                        }

                        foreach (var hive in hives)
                        {
                            if (int.Parse(hive.Temperature) < 15 || int.Parse(hive.Temperature) > 30)
                            {
                                es.SendAsync("undestroyablee@gmail.com", "Notification", $"The temperature in the hive is {hive.Temperature}. You might go check it!");
                                ss.SendAsync("+359 89 873 9493", $"The temperature in the hive is {hive.Temperature}. You might go check it!");
                            }

                            if (int.Parse(hive.Humidity) < 40 || int.Parse(hive.Humidity) > 80)
                            {
                                es.SendAsync("undestroyablee@gmail.com", "Notification", $"The temperature in the hive is {hive.Temperature}. You might go check it!");
                                ss.SendAsync("+359 89 873 9493", $"The humidity in the hive is {hive.Humidity}. You might go check it!");
                            }
                        }

                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                }

                Thread.Sleep(1 * 1000); // Only do this every 30 seconds
            }
        }
    }
}
