using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sazi.EmailComms.Core.Model
{
    public class AppSettings
    {
        public string ConfigurationCacheTime { get; set; }
        public string WorkflowStateCacheTime { get; set; }
        public string ChannelName { get; set; }
        public string ChannelPassword { get; set; }
        public string IdentityProviderUrl { get; set; }
        public string Scope { get; set; }
    }
}
