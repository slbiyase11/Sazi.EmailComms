using Sazi.EmailComms.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sazi.EmailComms.Core.DomainServices
{
    public interface IIdentityService
    {
        Task<AuthToken> GetAccessToken(string clientId, string clientSecret);
    }
}
