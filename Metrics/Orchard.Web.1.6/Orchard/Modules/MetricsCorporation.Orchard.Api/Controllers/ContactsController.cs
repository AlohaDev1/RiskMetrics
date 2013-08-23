using System;
using System.Collections.Generic;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Services;
using MetricsCorporation.Models;
using MetricsCorporation.Orchard.Api.Helpers;
using Orchard.Mvc;

namespace MetricsCorporation.Orchard.Api.Controllers
{
    [Authorize]
    public class ContactsController : ApiController
    {
        private readonly ICrud<UserCreditsModel> _fileUserCredits;
        private readonly IHttpContextAccessor _accessor;

        public ContactsController(ICrud<UserCreditsModel> fileUserCredits, IHttpContextAccessor accessor)
        {
            _fileUserCredits = fileUserCredits;
            _accessor = accessor;
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
            var session = _accessor.Current().Session;
            if (session != null)
            {
                var fileList = session["CurrentUser"] as UserModel;
                if (fileList != null)
                {
                    var user = ((UserCreditsService)_fileUserCredits).GetByUserId(fileList.Id);

                    if (user.Credits >= 5)
                    {
                        user.Credits = user.Credits - 5;
                        _fileUserCredits.Update(user);
                        return JigsawHelper.GetPurchasedContact(id);
                    }
                }
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
