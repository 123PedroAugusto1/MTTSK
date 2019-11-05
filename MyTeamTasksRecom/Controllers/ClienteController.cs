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
        public IActionResult ListagemCliente()
        {
            ViewBag.Cliente = _clienteDAO.ListarTodos();
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(string Nome)
        {
            Cliente cliente = new Cliente
            {
                Nome = Nome
         
            };
            _clienteDAO.Cadastrar(cliente);
            
            return View();
        }

        public IActionResult Remover(int id)
        {

            _clienteDAO.Remover(id);
            return RedirectToAction("ListagemCliente");
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