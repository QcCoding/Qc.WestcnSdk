using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Qc.WestcnSdk.Sample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WestcnDomainService _service;
        public IndexModel(WestcnDomainService service)
        {
            _service = service;
        }
        public IActionResult OnPostGetTest()
        {
            //return new JsonResult(new { msg = _service.GetDomainAnalysisList("941vip.com") }, new JsonSerializerSettings() { Formatting = Formatting.Indented });
            return new JsonResult(new { msg = _service.ModifyDomainAnalysisRecord("941vip.com", 67333431, "127.0.0.1", 60) }, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
