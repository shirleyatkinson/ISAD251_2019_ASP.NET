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

       [HttpPost]
       public IActionResult Raise_Request(Enter_Request enter_Request)
        {
            var rowsaffected = _context.Database.ExecuteSqlRaw("EXEC Enter_Request @Name, @Room, @Row, @Seat, @Problem, @ModuleID",
               new SqlParameter("@Name", enter_Request.Name.ToString()),
               new SqlParameter("@Room", enter_Request.Room.ToString()),
               new SqlParameter("@Row", enter_Request.Row),
               new SqlParameter("@Seat", enter_Request.Seat),
               new SqlParameter("@Problem", enter_Request.Problem.ToString()),
               new SqlParameter("@ModuleID", enter_Request.ModuleID));

            ViewBag.Success = rowsaffected;

            return View("Index");

        }
    }
}