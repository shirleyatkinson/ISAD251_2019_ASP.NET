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
       
        public IActionResult Index()
        {
           
            return View();
        }

       
    }
}