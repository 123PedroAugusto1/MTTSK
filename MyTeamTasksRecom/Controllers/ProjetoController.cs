using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
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
            //string url = "http://localhost:64154/api/Projeto/ListarTodos";
            //WebClient client = new WebClient();

            //byte[] dataApiByte = client.DownloadData(url);

            //ViewBag.Projeto = Enc
            ViewBag.Projeto = _projetoDAO.ListarTodos();
            return View();
        }
        public IActionResult Remover(int? id)
        {
            _projetoDAO.RemoverProjeto(id);
            return RedirectToAction("ListagemProjetos");
        }
        public IActionResult tarefas(int? id)
        {
            _projetoDAO.RemoverProjeto(id);
            return RedirectToAction("ListagemProjetos");
        }

       

        [HttpPost]
       public IActionResult Cadastrar(Projeto p,int idCliente)
        {
            p.cliente = _clienteDAO.BuscarClientePorId(idCliente);
            //try
            //{
            //    //url do receitaws.com.br
            //    string url = "http://localhost:64154/api/Projeto/Cadastrar/" + p.ProjetoId;
            //    WebClient client = new WebClient();
            //    client.Encoding = System.Text.Encoding.UTF8;
            //    String teste= client.Upload(url,p.Nome);
            //    return RedirectToAction("ListagemProjeto");
            //}
            //catch (WebException e)
            //{
            //    TempData["Erro"] = e.Message;
            //}

          
          _projetoDAO.CadastrarProjeto(p);

          return RedirectToAction("ListagemProjetos");
       }

   
    }
}