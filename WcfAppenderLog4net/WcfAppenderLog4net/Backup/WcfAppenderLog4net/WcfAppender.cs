using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Appender;
using log4net.Core;
using System.ServiceModel;
using WcfService;

namespace WcfAppenderLog4net
{
    public class WcfAppender : AppenderSkeleton
    {
        // instanse of IServiceLogger that will 
        // hold channel to wcf service
        static IServiceLogger Service;

        public WcfAppender()
        {
            // the logger initialize this class automatically
            // the first thing to do is to get channel to service
            // in order ot send messages to service.
            CreateChannelToWcfService();
        }

        private static void CreateChannelToWcfService()
        {
            // address for service
            EndpointAddress address = new EndpointAddress(new Uri("http://localhost:8080/WcfAppenderService"));
            // binding for service
            BasicHttpBinding binding = new BasicHttpBinding();

            // get channel to wcf service from channelFactory class
            Service = ChannelFactory<IServiceLogger>.CreateChannel(binding, address);
        }

        #region AppenderSkeleton Members

        protected override void Append(LoggingEvent loggingEvent)
        {
            // append the level message and the content to one string
            string message = string.Format("{0}, {1}",
            loggingEvent.Level.DisplayName,
            loggingEvent.RenderedMessage);

            // send this string message to wcf service
            Service.NewLog(message);
        }

        #endregion
    }
}
