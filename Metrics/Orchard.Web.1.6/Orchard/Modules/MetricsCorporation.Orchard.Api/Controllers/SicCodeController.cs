using System.Collections.Generic;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.Models;
using Orchard;
using Orchard.Localization;
using Orchard.Mvc;
using MetricsCorporation.BL.Services;
using System.Linq;
using System.Text;

namespace MetricsCorporation.Orchard.Api.Controllers
{
    [Authorize]
    public class SicCodeController : ApiController
    {

        private readonly ICrud<SicCodeModel> _service;

        private readonly IHttpContextAccessor _accessor;

        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public SicCodeController(IOrchardServices orchardServices, ICrud<SicCodeModel> service, IHttpContextAccessor accessor)
        {
            Services = orchardServices;
            T = NullLocalizer.Instance;

            _service = service;
            _accessor = accessor;
        }

        [HttpPost]
        public string Get(string id)
        {
            List<SicCodeModel> Response = null;
            StringBuilder leafChild = new StringBuilder();
            StringBuilder secondLeafChild = new StringBuilder();
            StringBuilder thridLeafChild = new StringBuilder();
            StringBuilder parentNode = new StringBuilder();
            string secondLeafRange = string.Empty;
            string thirdLeafRange = string.Empty;
            string parentNodeRange = string.Empty;
            string temp = string.Empty;

            if (ModelState.IsValid)
            {
                Response = ((SicCodeService)_service).GetAllSicCodes().ToList();
                var result = Response.GroupBy(co => co.Division_Letter).Select(grp => grp.ToList()).ToList();
                foreach (var res in result)
                {
                    var sicCode2s = res.GroupBy(co => co.SIC_2_Digit_Code).Select(grp => grp.ToList()).ToList();
                    foreach (var sicCode2 in sicCode2s)
                    {
                        var sicCode3 = sicCode2.GroupBy(co => co.SIC_3_Digit_Code).Select(grp => grp.ToList()).ToList();
                        foreach (var sicCode4 in sicCode3)
                        {
                            foreach (var leaf in sicCode4)
                            {
                                leafChild.Append("{ data: '" + leaf.SIC_4_Digit_Code + " " + leaf.SIC_4_Digit_Code_Name.Replace("'", "") + "' , attr: { className: 'classCode', 'data-sicCode' : '" + leaf.SIC_4_Digit_Code + "', id: '" + "leaf_" + leaf.Id + "'} }" + ",");
                            }
                            secondLeafRange = " [" + sicCode4.Select(co => co.SIC_4_Digit_Code).ToArray()[0] + "-" + sicCode4.Select(co => co.SIC_4_Digit_Code).ToArray()[sicCode4.Select(co => co.SIC_4_Digit_Code).ToArray().Length - 1] + "]";
                            leafChild.Remove(leafChild.Length - 1, 1);
                            secondLeafChild.Append("{ data: '" + sicCode4[0].SIC_3_Digit_Code + " " + sicCode4[0].SIC_3_Digit_Code_Name.Replace("'", "") + secondLeafRange + "' , attr: { className: 'classCode','data-sicCode' : '" + secondLeafRange.Trim(']', '[', ' ').Replace('-', ',') + "' , id: '" + "grandChild_" + sicCode4[0].Id + "'}, children : [" + leafChild + " ] }" + ",");
                            leafChild.Clear();
                        }
                        thirdLeafRange = " [" + sicCode3[0].Select(co => co.SIC_3_Digit_Code).ToArray()[0] + "-" + sicCode3[sicCode3.Count - 1].Select(co => co.SIC_3_Digit_Code).ToArray()[sicCode3[sicCode3.Count - 1].Select(co => co.SIC_3_Digit_Code).ToArray().Length - 1] + "]";
                        temp = sicCode3[0].Select(co => co.SIC_4_Digit_Code).ToArray()[0] + "," + sicCode3[sicCode3.Count - 1].Select(co => co.SIC_4_Digit_Code).ToArray()[sicCode3[sicCode3.Count - 1].Select(co => co.SIC_4_Digit_Code).ToArray().Length - 1];
                        thridLeafChild.Append("{ data: '" + sicCode3[0].Select(co => co.SIC_2_Digit_Code).ToArray()[0] + " " + sicCode3[0].Select(co => co.SIC_2_Digit_Code_Name).ToArray()[0].Replace("'", "") + thirdLeafRange + "' , attr: { className: 'classCode','data-sicCode' : '" + temp + "', id: '" + "child_" + sicCode3[0].Select(co => co.Id).ToArray()[0] + "'}, children : [" + secondLeafChild + "] }" + ",");
                        secondLeafChild.Clear();
                        temp = string.Empty;
                    }
                    parentNodeRange = " [" + sicCode2s[0].Select(co => co.SIC_2_Digit_Code).ToArray()[0] + "-" + sicCode2s[sicCode2s.Count - 1].Select(co => co.SIC_2_Digit_Code).ToArray()[0] + "]";
                    thridLeafChild.Remove(thirdLeafRange.Length - 1, 1);
                    temp = sicCode2s[0].Select(co => co.SIC_4_Digit_Code).ToArray()[0] + "," + sicCode2s[sicCode2s.Count - 1].Select(co => co.SIC_4_Digit_Code).ToArray()[sicCode2s[sicCode2s.Count - 1].Select(co => co.SIC_4_Digit_Code).ToArray().Length - 1];
                    parentNode.Append("{ data: '" + res.Select(co => co.Division_Letter).ToArray()[0] + " " + res.Select(co => co.Division_Name).ToArray()[0] + parentNodeRange + "' , attr: { className: 'classCode','data-sicCode' : '" + temp + "', id: '" + "parent_" + res.Select(co => co.Division_Letter).ToArray()[0] + "'}, children : [" + thridLeafChild + "] }" + ",");
                    thridLeafChild.Clear();
                    temp = string.Empty;
                }
            }
            return "[" + parentNode.Remove(parentNode.Length-1,1) + "]";
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
    }
}
