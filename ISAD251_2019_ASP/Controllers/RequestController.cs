using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ISAD251_2019_ASP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ISAD251_2019_ASP.Controllers
{
    public class RequestController : Controller
    {
        private readonly ISAD251_SAtkinsonContext _context;

        public RequestController(ISAD251_SAtkinsonContext context)
        {
            _context = context;
        }
       
        public IActionResult Index()
        {
            IEnumerable<SelectListItem> ModuleList = (from p in _context.ShModule.AsEnumerable()
                                                      select new SelectListItem
                                                      {
                                                          Text = p.Code,
                                                          Value = p.ModuleId.ToString()
                                                      }).ToList();
            ViewBag.Modules = ModuleList;
            return View();
        }

       
    }
}