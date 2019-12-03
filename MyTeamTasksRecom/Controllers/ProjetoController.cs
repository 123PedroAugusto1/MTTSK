using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace MyTeamTasksRecom.Controllers
{
    public class ProjetoController : Controller
    {
        public readonly ProjetoDAO _projetoDAO;

        public readonly ClienteDAO _clienteDAO;

        public IActionResult Index()
        {
            return View();
        }

        public ProjetoController(ProjetoDAO projetoDAO,ClienteDAO clienteDAO)
        {
            _projetoDAO = projetoDAO;
            _clienteDAO = clienteDAO;

        }

        public IActionResult Cadastrar()
        {
            ViewBag.Clientes = new SelectList
               (_clienteDAO.ListarTodos(), "PessoaId",
               "Nome");

            return View();
        }
        public IActionResult ListagemProjetos()
        {
            ViewBag.Projeto = _projetoDAO.ListarTodos();
            return View();
        }
        public IActionResult Remover(int? id)
        {
            _projetoDAO.RemoverProjeto(id);
            return RedirectToAction("ListagemProjetos");
        }


        [HttpPost]
       public IActionResult Cadastrar(Projeto p,int idCliente)
        {

            p.cliente = _clienteDAO.BuscarClientePorId(idCliente);
          _projetoDAO.CadastrarProjeto(p);

          return RedirectToAction("ListagemProjeto");
       }

   
    }
}