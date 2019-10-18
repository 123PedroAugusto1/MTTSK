using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyTeamTasksRecom.Controllers
{
    public class TearefaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}