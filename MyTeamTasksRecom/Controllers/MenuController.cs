using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyTeamTasksRecom.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult MenuCadastrosFuncionarios()
        {
            return View();
        }

        public IActionResult MenuCadastrosClientes()
        {
            return View();
        }

        public IActionResult MenuCadastrosProjetos()
        {
            return View();
        }
    }
}