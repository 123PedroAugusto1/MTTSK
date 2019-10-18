using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTeamTasksRecom.DAL;
using MyTeamTasksRecom.Models;

namespace MyTeamTasksRecom.Controllers
{
    public class ProjetoController : Controller
    {
        public readonly ProjetoDAO _projetoDAO;
        public IActionResult Index()
        {
            return View();
        }

        public ProjetoController(ProjetoDAO projetoDAO)
        {
            _projetoDAO = projetoDAO;

        }

        public IActionResult Cadastrar()
        {
            return View();
        }


        //[HttpPost]
        //public IActionResult Cadastrar(string txtNome, string txtStatus,string txtNomeCliente)
        //{
        //    Projeto projeto = new Projeto
        //    {
        //        Nome = txtNome,
        //        Status = txtStatus,
        //    };

        //    _projetoDAO.CadastrarProjeto(projeto);

        //    return View();
        //}

        //public IActionResult Remover(int id)
        //{
        //    _projetoDAO.RemoverProjeto(id);
        //    return RedirectToAction("index");
        //}
    }
}