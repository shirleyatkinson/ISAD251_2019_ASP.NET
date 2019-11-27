using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ISAD251_2019_ASP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Text;

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

            Alert(enter_Request);

            ViewBag.Success = rowsaffected;

            return View("Index");

        }

        private void Alert(Enter_Request enter_Request)
        {
            //SMB109 URI
            string URI = "http://192.168.0.50/api/stlaB2I6VZ8O80Qepc-1xfmLrHgyTFvB9IGupaQz/lights/";

            //colours are Red 0 or 65535, Orange = 10?, yellow = 12750, Green = 25500, Blue = 46920
            int[] lightsArray = new int[] { 0, 5000, 12750, 25500, 46920 };

            //Get the row ID plus the seat ID to map to the lights
            URI = URI + enter_Request.Row.ToString() + "/state";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new
                    System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent content = new StringContent("{\"on\" : true, \"hue\": "
                    + lightsArray[enter_Request.Seat - 1].ToString() + "}",
                    Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync(URI, content).Result;
            }





        }
    }
}