using Sazi.EmailComms.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sazi.EmailComms.Core.DomainServices
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
        Task<IEnumerable<Email>> GetEmail(Guid userid);
        Task UpdateEmail(Email email);
        Task<bool> DeleteEmail(Guid emailId);
        Task<IEnumerable<Email>> SearchEmails(string searchPhrasel);
        Task<IEnumerable<Email>> SearchEmails(string searchPhrase, Guid userId);
    }
}
