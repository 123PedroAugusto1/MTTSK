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


        public ClienteController(ClienteDAO clienteDAO)
        {
            _clienteDAO = clienteDAO;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cadastrar()
        {
            Cliente cliente = new Cliente();
            return View(cliente);
        }
        public IActionResult ListagemCliente()
        {
            ViewBag.Cliente = _clienteDAO.ListarTodos();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Cliente c)
        {
            _clienteDAO.Cadastrar(c);            
            return RedirectToAction("ListagemCliente");
        }


    }
}