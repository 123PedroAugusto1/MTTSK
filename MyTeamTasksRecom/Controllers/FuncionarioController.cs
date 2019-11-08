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
    public class FuncionarioController : Controller
    {
        public readonly FuncionarioDAO _funcionarioDAO;

        public FuncionarioController(FuncionarioDAO funcionarioDAO)
        {
            _funcionarioDAO = funcionarioDAO;

        }

        public IActionResult ListagemFuncionario()
        {
            ViewBag.Funcionarios = _funcionarioDAO.Listar();
            return View();
        }
        public IActionResult Login()
        {
            ViewBag.Funcionarios = _funcionarioDAO.Listar();
            return View();
        }


        public IActionResult Cadastrar()
        {
            Funcionario funcionario = new Funcionario();
            if (TempData["Endereco"]!= null) {
                string resultado = TempData["Endereco"].ToString();
                Endereco endereco = JsonConvert.DeserializeObject<Endereco>(resultado);
                funcionario.Endereco = endereco;
            }           
            return View(funcionario);
        }

        [HttpPost]
        public IActionResult Cadastrar(Funcionario f)
        {

           
            if (ModelState.IsValid)
            {
                if (_funcionarioDAO.Cadastrar(f))
                {
                    return RedirectToAction("ListagemFuncionario");
                }
                ModelState.AddModelError
                   ("", "");
                return View(f);
            }
            return View(f);
        }

        public IActionResult Remover(int id)
        {
      
            _funcionarioDAO.Remover(id);
            return RedirectToAction("index");
        }
        public IActionResult Alterar(int ? id)
        {
            ViewBag.Funcionario = _funcionarioDAO.BuscarFuncionarioPorId(id);
            return RedirectToAction("Alterar");
        }
        [HttpPost]
        public IActionResult Alterar(String txtNome)
        {
            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult BuscarCep(Funcionario f)
        {
            string url = "https://viacep.com.br/ws/"+ f.Endereco.Cep + "/json/";
            WebClient client = new WebClient();
            TempData["Endereco"] = client.DownloadString(url);

            return RedirectToAction("Cadastrar");
        }
    }
}
