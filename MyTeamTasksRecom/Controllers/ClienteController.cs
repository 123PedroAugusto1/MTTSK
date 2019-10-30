using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Repository;


namespace MyTeamTasksRecom.Controllers
{
    public class ClienteController : Controller
    {
        public readonly ClienteDAO _clienteDAO;
        public IActionResult Index()
        {
            return View();
        }
    
        public ClienteController(ClienteDAO clienteDAO)
        {
            _clienteDAO = clienteDAO;

        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(string txtNome)
        {
            Cliente cliente = new Cliente
            {
                Nome = txtNome,

            };
            _clienteDAO.Cadastrar(cliente);
            
            return View();
        }

        public IActionResult Remover(int id)
        {

            _clienteDAO.Remover(id);
            return RedirectToAction("index");
        }
        //public IActionResult Alterar(int? id)
        //{
        //    ViewBag.Funcionario = _funcionarioDAO.BuscarFuncionarioPorId(id);
        //    return RedirectToAction("Alterar");
        //}
        //[HttpPost]
        //public IActionResult Alterar(String txtNome)
        //{
        //    return RedirectToAction("index");
        //}
    }
}