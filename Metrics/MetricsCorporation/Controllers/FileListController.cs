using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.Models;

namespace MetricsCorporation.Controllers
{
    public class FileListController : ApiController
    {
        private readonly ICrud<FileListModel> _fileListService;

        public FileListController(ICrud<FileListModel> fileListService)
        {
            _fileListService = fileListService;
        }

        // GET api/filelist
        public IEnumerable<FileListModel> Get()
        {
            return _fileListService.GetAll();
        }

        // GET api/filelist/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/filelist
        public FileListModel Post(FileListModel model)
        {
            if (ModelState.IsValid)
            {
                return _fileListService.Create(model);
            }

            return null;
        }

        // PUT api/filelist/5
        public HttpResponseMessage Put(int id, FileListModel model)
        {
            if (ModelState.IsValid)
            {
                _fileListService.Update(model);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE api/filelist/5
        public HttpResponseMessage Delete(int id)
        {
            if (id == 0)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            _fileListService.Delete(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
