using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WcfService
{
    public class ServiceLogger: IServiceLogger
    {
        #region IServiceLogger Members
        // in this service we get all messages from wcf appender
        // and simply write them
        public void NewLog(string message)
        {
            Console.WriteLine("This is from Wcf Logger");
            Console.WriteLine(message);
        }

        #endregion
    }
}
