using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;


namespace WcfService
{
    // this contract of our wcf service
    [ServiceContract]
    public interface IServiceLogger
    {
        [OperationContract]
        void NewLog(string message);
    }
}
