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
    public class TarefaController : Controller
    {
        public readonly TarefaDAO _tarefaDAO;

        public readonly ProjetoDAO _projetoDAO;

        public IActionResult Index()
        {
            return View();
        }


        public TarefaController(ProjetoDAO projetoDAO, TarefaDAO tarefaDAO)
        {
            _tarefaDAO = tarefaDAO;
            _projetoDAO = projetoDAO;

        }

        public IActionResult Cadastrar()
        {
            ViewBag.Projetos = new SelectList
               (_projetoDAO.ListarTodos(), "ProjetoId",
               "Nome");
            return View();
        }

        public IActionResult ListagemTarefa()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Cadastrar(Tarefa t, int idProjeto)
        {

            t.Projeto = _projetoDAO.BuscarProjetoPorId(idProjeto);
            _tarefaDAO.CadastrarTarefa(t);
            
            return View();
        }


    }
}