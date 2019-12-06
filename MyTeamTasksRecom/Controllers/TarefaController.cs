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
        public readonly FuncionarioDAO _funcionarioDAO;

        public readonly ProjetoDAO _projetoDAO;

        public IActionResult Index()
        {
            return View();
        }
       

        public TarefaController(ProjetoDAO projetoDAO, TarefaDAO tarefaDAO, FuncionarioDAO funcionarioDAO)
        {
            _tarefaDAO = tarefaDAO;
            _projetoDAO = projetoDAO;
            _funcionarioDAO = funcionarioDAO;

        }
        public IActionResult VerTarefa(int id)
        {
            ViewBag.Assinatura = new SelectList
            (_funcionarioDAO.ListarTodos(), "PessoaId",
            "Nome");
            return View(_tarefaDAO.BuscarTarefaPorId(id));
        }
        public IActionResult VerTarefa2(int id)
        {
            ViewBag.Assinatura = new SelectList
            (_funcionarioDAO.ListarTodos(), "PessoaId",
            "Nome");
            return View(_tarefaDAO.BuscarTarefaPorId(id));
        }
        public IActionResult Cadastrar()
        {
            ViewBag.Projetos = new SelectList
               (_projetoDAO.ListarTodos(), "ProjetoId",
               "Nome");
            ViewBag.Requisitante = new SelectList
              (_funcionarioDAO.ListarTodos(), "PessoaId",
              "Nome");
            ViewBag.Assinatura = new SelectList
              (_funcionarioDAO.ListarTodos(), "PessoaId",
              "Nome");
            return View();
        }

        public IActionResult ListagemTarefa()
        {
            ViewBag.Tarefa = _tarefaDAO.ListarTarefas();
            return View();
        }
        public IActionResult ListagemProjetos()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Tarefa t, int idProjeto,int idAssinatura,int idRequisitante)
        {

            t.Projeto = _projetoDAO.BuscarProjetoPorId(idProjeto);
            t.Assinatura = _funcionarioDAO.BuscarFuncionarioPorId(idAssinatura);
            t.Requisitante = _funcionarioDAO.BuscarFuncionarioPorId(idRequisitante);
            _tarefaDAO.CadastrarTarefa(t);
            
            return RedirectToAction("ListagemTarefa");
        }
        [HttpPost]
        public IActionResult Alterar(Tarefa t)
        {
            _tarefaDAO.Alterar(t);
            return RedirectToAction("ListagemTarefa");
        }
        [HttpPost]
        public IActionResult Alterar2(Tarefa t)
        {
            _tarefaDAO.Alterar(t);
            return RedirectToAction("MenuDev","Funcionario");
        }

    }
}