using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Qc.WestcnSdk.Models.Domain;

namespace Qc.WestcnSdk.Sample.Pages.Domain
{
    public class AnalysisListModel : PageModel
    {
        private readonly WestcnDomainService _service;
        public AnalysisListModel(WestcnDomainService service)
        {
            _service = service;
        }

        public DomainAnalysisRecordPageModel AnalysisList { get; set; }

        public IActionResult OnGet(string domain, int nowpage = 1)
        {
            AnalysisList = _service.GetDomainAnalysisList(domain, 20, nowpage)?.Data;
            return Page();
        }
    }
}