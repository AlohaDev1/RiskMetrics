using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Services;
using MetricsCorporation.Helpers;
using MetricsCorporation.Models;

namespace MetricsCorporation.Controllers
{
    public class ContactsController : ApiController
    {
        private readonly ICrud<UserCreditsModel> _fileUserCredits;

        public ContactsController(ICrud<UserCreditsModel> fileUserCredits)
        {
            _fileUserCredits = fileUserCredits;
        }

        // GET api/contacts
        public IEnumerable<ContactModel> Get(string companyName)
        {
            string companyId = JigsawHelper.GetCompanyId(companyName);

            if (!string.IsNullOrEmpty(companyId))
            {
                return JigsawHelper.GetContacts(companyId);
            }

            return null;
        }

        // GET api/contacts/5
        public ContactModel Get(int id)
        {
            var user = ((UserCreditsService)_fileUserCredits).GetByUserId(SessionHelper.CurrentUser.Id);

            if (user.Credits >= 5)
            {
                user.Credits = user.Credits - 5;
                _fileUserCredits.Update(user);
                return JigsawHelper.GetPurchasedContact(id);
            }

            return null;
        }

        // POST api/contacts
        public void Post([FromBody]string value)
        {
        }

        // PUT api/contacts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/contacts/5
        public void Delete(int id)
        {
        }
    }
}
