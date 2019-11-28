using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Qc.WestcnSdk.Models.Domain;

namespace Qc.WestcnSdk.Sample.Pages.Domain
{
    public class ManagerModel : PageModel
    {
        private readonly WestcnDomainService _service;
        public ManagerModel(WestcnDomainService service)
        {
            _service = service;
        }

        public DomainRecordPageModel DomainList { get; set; }

        public IActionResult OnGet(int nowpage = 1)
        {
            DomainList = _service.GetDomainList(20, nowpage)?.Data;
            return Page();
        }
    }
}