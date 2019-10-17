using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTeamTasksRecom.DAL;
using MyTeamTasksRecom.Models;

namespace MyTeamTasksRecom.Controllers
{
    public class FuncionarioController : Controller
    {
        public readonly FuncionarioDAO _funcionarioDAO;

        public FuncionarioController(FuncionarioDAO funcionarioDAO)
        {
            _funcionarioDAO = funcionarioDAO;

        }

        public IActionResult Index()
        {
            ViewBag.Funcionarios = _funcionarioDAO.Listar();
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(string txtNome,
            string txtDescricao, string txtPreco,
            string txtQuantidade)
        {
            Funcionario f = new Funcionario
            {
                Nome = txtNome,

            };
            _funcionarioDAO.Cadastrar(f);
            return View();
        }
    }
}
