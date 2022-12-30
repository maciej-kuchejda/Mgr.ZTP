using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuchejda.ZTP.BusinessCard.Reciver.Configuration
{
    public class QueueConfiguration
    {
        public string ConnectionString { get; set; }
        public string QueueName { get; set; }
    }
}
