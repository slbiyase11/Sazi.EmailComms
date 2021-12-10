using Sazi.EmailComms.Core.DomainServices;
using Sazi.EmailComms.Core.Model;
using Sazi.EmailComms.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sazi.EmailComms.Services
{
    public class EmailService : IEmailService
    {
        private readonly IGenericRepository<Email> _emailRepository;

        public EmailService(IGenericRepository<Email> emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public async Task<bool> DeleteEmail(Guid emailId)
        {
            var email = await _emailRepository.Get(emailId);
            if(email != null)
            {
                //soft delete
                email.EmailStatus = EmailStatus.Deleted;
                await _emailRepository.Save();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Email>> GetEmail(Guid userid)
        {
            return await _emailRepository.Find(x => x.UserId == userid);
        }

        public async Task<IEnumerable<Email>> SearchEmails(string searchPhrase)
        {
            return await _emailRepository.Find(x => x.FromEmail.Contains(searchPhrase) || x.ToEmail.Contains(searchPhrase) || x.Subject.Contains(searchPhrase));
        }

        public async Task<IEnumerable<Email>> SearchEmails(string searchPhrase, Guid userId)
        {
            return await _emailRepository.Find(x => x.UserId == userId && ( x.FromEmail.Contains(searchPhrase) ||
            x.ToEmail.Contains(searchPhrase) || x.Subject.Contains(searchPhrase)));
        }

        //repo
        public async Task<bool> SendEmail(Email email)
        {
            //Actual Sending of email

            //save to database using repo
            try
            {
                _emailRepository.Add(email);
                await _emailRepository.Save();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task UpdateEmail(Email email)
        {
            _emailRepository.Update(email);
            await _emailRepository.Save();
        }
    }
}
