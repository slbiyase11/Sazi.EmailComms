using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sazi.EmailComms.Core.Model
{
    public class Email
    {
        public Guid EmailId { get; set; }
        public Guid UserId { get; set; }
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public EmailStatus EmailStatus { get; set; }

        public virtual User User { get; set; }

    }
}
