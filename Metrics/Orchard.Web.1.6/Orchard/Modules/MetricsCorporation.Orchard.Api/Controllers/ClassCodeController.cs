using System.Collections.Generic;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.Models;
using MetricsCorporation.BL.Services;
using Orchard;
using Orchard.Localization;
using Orchard.Mvc;
using System.Linq;
using System.Text;


namespace MetricsCorporation.Orchard.Api.Controllers
{
    [Authorize]
    public class ClassCodeController : ApiController
    {

        private readonly ICrud<ClassCodeModel> _service;
        private readonly IHttpContextAccessor _accessor;
        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public ClassCodeController(IOrchardServices orchardServices, ICrud<ClassCodeModel> service, IHttpContextAccessor accessor)
        {
            Services = orchardServices;
            T = NullLocalizer.Instance;

            _service = service;
            _accessor = accessor;
        }

        [HttpPost]
        public string Get(string id)
        {
            List<ClassCodeModel> Response = null;
            List<ClassCodeAjaxReturn> classCodeAjaxReturns = null;

            if (ModelState.IsValid)
            {
                UserModel currentUser = null;

                var session = _accessor.Current().Session;
                if (session != null)
                    currentUser = session["CurrentUser"] as UserModel;

                Response = ((ClassCodeService)_service).GetAllClassCodes().ToList();

                var result = Response.GroupBy(co => co.Code).Select(grp => grp.ToList()).ToList();

                classCodeAjaxReturns = new List<ClassCodeAjaxReturn>();
                for (int i = 0; i < 10; i++)
                {
                    ClassCodeAjaxReturn classCode = new ClassCodeAjaxReturn();
                    classCode.Code = i.ToString();
                    classCode.Id = i.ToString();
                    classCode.Childrens = new List<ClassCodeAjaxReturn>();
                    classCodeAjaxReturns.Add(classCode);
                }

                foreach (var res in result)
                {
                    ClassCodeAjaxReturn ajax;
                    ClassCodeAjaxReturn ajaxChild;

                    switch (string.IsNullOrEmpty(res[0].Code) ? string.Empty : res[0].Code[0].ToString())
                    {
                        case "0":
                            ajax = new ClassCodeAjaxReturn();
                            ajax.Id = res[0].Id.ToString();
                            ajax.Code = res[0].Code;
                            ajax.Description = res[0].Description;
                            ajax.Childrens = new List<ClassCodeAjaxReturn>();
                            foreach (var re in res)
                            {
                                ajaxChild = new ClassCodeAjaxReturn();
                                ajaxChild.Id = re.Id.ToString();
                                ajaxChild.Code = re.Code;
                                ajaxChild.Description = re.Description;
                                ajax.Childrens.Add(ajaxChild);

                            }
                            classCodeAjaxReturns[0].Childrens.Add(ajax);
                            break;
                        case "1":
                            ajax = new ClassCodeAjaxReturn();
                            ajax.Id = res[0].Id.ToString();
                            ajax.Code = res[0].Code;
                            ajax.Description = res[0].Description;
                            ajax.Childrens = new List<ClassCodeAjaxReturn>();
                            foreach (var re in res)
                            {
                                ajaxChild = new ClassCodeAjaxReturn();
                                ajaxChild.Id = re.Id.ToString();
                                ajaxChild.Code = re.Code;
                                ajaxChild.Description = re.Description;
                                ajax.Childrens.Add(ajaxChild);

                            }
                            classCodeAjaxReturns[1].Childrens.Add(ajax);
                            break;
                        case "2":
                            ajax = new ClassCodeAjaxReturn();
                            ajax.Id = res[0].Id.ToString();
                            ajax.Code = res[0].Code;
                            ajax.Description = res[0].Description;
                            ajax.Childrens = new List<ClassCodeAjaxReturn>();
                            foreach (var re in res)
                            {
                                ajaxChild = new ClassCodeAjaxReturn();
                                ajaxChild.Id = re.Id.ToString();
                                ajaxChild.Code = re.Code;
                                ajaxChild.Description = re.Description;
                                ajax.Childrens.Add(ajaxChild);

                            }
                            classCodeAjaxReturns[2].Childrens.Add(ajax);
                            break;
                        case "3":
                            ajax = new ClassCodeAjaxReturn();
                            ajax.Id = res[0].Id.ToString();
                            ajax.Code = res[0].Code;
                            ajax.Description = res[0].Description;
                            ajax.Childrens = new List<ClassCodeAjaxReturn>();
                            foreach (var re in res)
                            {
                                ajaxChild = new ClassCodeAjaxReturn();
                                ajaxChild.Id = re.Id.ToString();
                                ajaxChild.Code = re.Code;
                                ajaxChild.Description = re.Description;
                                ajax.Childrens.Add(ajaxChild);

                            }
                            classCodeAjaxReturns[3].Childrens.Add(ajax);
                            break;
                        case "4":
                            ajax = new ClassCodeAjaxReturn();
                            ajax.Id = res[0].Id.ToString();
                            ajax.Code = res[0].Code;
                            ajax.Description = res[0].Description;
                            ajax.Childrens = new List<ClassCodeAjaxReturn>();
                            foreach (var re in res)
                            {
                                ajaxChild = new ClassCodeAjaxReturn();
                                ajaxChild.Id = re.Id.ToString();
                                ajaxChild.Code = re.Code;
                                ajaxChild.Description = re.Description;
                                ajax.Childrens.Add(ajaxChild);

                            }
                            classCodeAjaxReturns[4].Childrens.Add(ajax);
                            break;
                        case "5":
                            ajax = new ClassCodeAjaxReturn();
                            ajax.Id = res[0].Id.ToString();
                            ajax.Code = res[0].Code;
                            ajax.Description = res[0].Description;
                            ajax.Childrens = new List<ClassCodeAjaxReturn>();
                            foreach (var re in res)
                            {
                                ajaxChild = new ClassCodeAjaxReturn();
                                ajaxChild.Id = re.Id.ToString();
                                ajaxChild.Code = re.Code;
                                ajaxChild.Description = re.Description;
                                ajax.Childrens.Add(ajaxChild);

                            }
                            classCodeAjaxReturns[5].Childrens.Add(ajax);
                            break;
                        case "6":
                            ajax = new ClassCodeAjaxReturn();
                            ajax.Id = res[0].Id.ToString();
                            ajax.Code = res[0].Code;
                            ajax.Description = res[0].Description;
                            ajax.Childrens = new List<ClassCodeAjaxReturn>();
                            foreach (var re in res)
                            {
                                ajaxChild = new ClassCodeAjaxReturn();
                                ajaxChild.Id = re.Id.ToString();
                                ajaxChild.Code = re.Code;
                                ajaxChild.Description = re.Description;
                                ajax.Childrens.Add(ajaxChild);

                            }
                            classCodeAjaxReturns[6].Childrens.Add(ajax);
                            break;
                        case "7":
                            ajax = new ClassCodeAjaxReturn();
                            ajax.Id = res[0].Id.ToString();
                            ajax.Code = res[0].Code;
                            ajax.Description = res[0].Description;
                            ajax.Childrens = new List<ClassCodeAjaxReturn>();
                            foreach (var re in res)
                            {
                                ajaxChild = new ClassCodeAjaxReturn();
                                ajaxChild.Id = re.Id.ToString();
                                ajaxChild.Code = re.Code;
                                ajaxChild.Description = re.Description;
                                ajax.Childrens.Add(ajaxChild);

                            }
                            classCodeAjaxReturns[7].Childrens.Add(ajax);
                            break;
                        case "8":
                            ajax = new ClassCodeAjaxReturn();
                            ajax.Id = res[0].Id.ToString();
                            ajax.Code = res[0].Code;
                            ajax.Description = res[0].Description;
                            ajax.Childrens = new List<ClassCodeAjaxReturn>();
                            foreach (var re in res)
                            {
                                ajaxChild = new ClassCodeAjaxReturn();
                                ajaxChild.Id = re.Id.ToString();
                                ajaxChild.Code = re.Code;
                                ajaxChild.Description = re.Description;
                                ajax.Childrens.Add(ajaxChild);

                            }
                            classCodeAjaxReturns[8].Childrens.Add(ajax);
                            break;
                        case "9":
                            ajax = new ClassCodeAjaxReturn();
                            ajax.Id = res[0].Id.ToString();
                            ajax.Code = res[0].Code;
                            ajax.Description = res[0].Description;
                            ajax.Childrens = new List<ClassCodeAjaxReturn>();
                            foreach (var re in res)
                            {
                                ajaxChild = new ClassCodeAjaxReturn();
                                ajaxChild.Id = re.Id.ToString();
                                ajaxChild.Code = re.Code;
                                ajaxChild.Description = re.Description;
                                ajax.Childrens.Add(ajaxChild);

                            }
                            classCodeAjaxReturns[9].Childrens.Add(ajax);
                            break;
                    }
                }
            }
            string gradChildNodes = string.Empty;
            string tempChildNodes = string.Empty;
            string parentNodes = string.Empty;
            string childNodes = string.Empty;
            string final = string.Empty;
            foreach (ClassCodeAjaxReturn classCodes in classCodeAjaxReturns)
            {
                if (classCodes.Childrens.Count() > 1)
                {
                    childNodes = string.Empty;
                    foreach (ClassCodeAjaxReturn a in classCodes.Childrens)
                    {
                        tempChildNodes = string.Empty;
                        if (a.Childrens.Count() > 1)
                        {
                            gradChildNodes = string.Empty;
                            foreach (ClassCodeAjaxReturn b in a.Childrens)
                            {
                                gradChildNodes += "{ data: '" + b.Description.Replace("'", "") + "' , attr: { className: 'classCode', 'data-classCode': '" + b.Code + "', id: '" + "grandChild_" + b.Id + "',class:'leaveChild'} }" + ",";
                            }
                            gradChildNodes = gradChildNodes.Substring(0, gradChildNodes.Length - 1);
                            tempChildNodes = "{ id: '" + a.Id + "',data: '" + a.Code + "',attr: { id: '" + "child_" + a.Id + "' , 'data-classCode': '" + a.Code + "' },children: [" + gradChildNodes + "] }" + ",";
                        }
                        else
                        {
                            gradChildNodes = "{ data: '" + a.Description.Replace("'", "") + "' , attr: { className: 'classCode', 'data-classCode': '" + a.Code + "', id: '" + "grandChild_" + a.Id + "',class:'leaveChild'} }";
                            tempChildNodes = "{ id: '" + a.Id + "',data: '" + a.Code + "',attr: { id: '" + "child_" + a.Id + "', 'data-classCode': '" + a.Code + "' },children: [" + gradChildNodes + "] }" + ",";
                        }
                        childNodes += tempChildNodes;
                    }
                    childNodes = childNodes.Substring(0, childNodes.Length - 1);
                    parentNodes = "{ id: '" + classCodes.Id + "',data: '" + classCodes.Code + "',attr: { id: '" + "parent_" + classCodes.Id + "' , 'data-classCode': '" + classCodes.Code + "'},children: [" + childNodes + "] }" + ",";
                }
                else
                {
                    parentNodes = "{ id: '" + classCodes.Id + "',data: '" + classCodes.Code + "',attr: { id: '" + "parent_" + classCodes.Id + "' , 'data-classCode': '" + classCodes.Code + "'}}" + ",";
                }
                final += parentNodes;
                parentNodes = string.Empty;
            }
            final = final.TrimEnd(',');
            return "[" + final + "]";
        }

        // GET api/county
        //public IEnumerable<StateCountyModel> Get()
        //{
        //    return _service.GetAll();
        //}

        // GET api/county/5
        //public string Get(string id)
        //{
        //    return "value";
        //}

        // POST api/county
        public void Post([FromBody]string value)
        {
        }

        // PUT api/county/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/county/5
        public void Delete(int id)
        {
        }

        //private void GetChild()
        //{
        //    string[] data = new string[10];
        //    for (int i = 0; i < 10; i++)
        //    {
        //        data[i] = "{id : node'" + i + "', data:'" + i + "' attr {} ,children [Children '" + i + "']}";
        //    }
        //}

    }
}
