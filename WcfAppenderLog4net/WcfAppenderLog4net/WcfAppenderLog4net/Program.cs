using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.ServiceModel;
using WcfService;
using System.Threading;

namespace WcfAppenderLog4net
{
    public class Program
    {
        // the logger will be the one called "WcfLogger" definded in App.config
        static ILog logger = LogManager.GetLogger("WcfLogger");

        static void Main(string[] args)
        {
            RaiseTheWcfServiceToTheAir();

            // tell to log4net where its config setting are(App.config file)
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo("..//..//App.config"));

            DivideNumbers();

            Console.ReadKey();
        }

        private static void DivideNumbers()
        {
            try
            {
                int j = 100;

                for (int i = 20; i >= 0; i--)
                {
                    int result = j / i;
                    logger.Info(string.Format("The result of {0} divide by {1} is {2}", j, i, result));
                    Thread.Sleep(500);
                }
            }

            catch (Exception e)
            {
                logger.Error(e.Message);
            }
        }

        private static void RaiseTheWcfServiceToTheAir()
        {
            ServiceHost sh = new ServiceHost(typeof(ServiceLogger));

            string address = "http://localhost:8080/WcfAppenderService";
            BasicHttpBinding binding = new BasicHttpBinding();
            Type contract = typeof(IServiceLogger);
            
            sh.AddServiceEndpoint(contract,binding,address);
            sh.Open();

            Console.WriteLine(string.Format("The service in the air at{0}",address));
        }
    }
}
