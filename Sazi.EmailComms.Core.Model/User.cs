using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sazi.EmailComms.Core.Model
{
    public class User
    {
        public Guid UserId { get; set; }

        public String Username { get; set; }

        public String IDNumber { get; set; }

        public String EmailAddress { get; set; }

        public virtual List<Email> Emails { get; set; }
    }
}
