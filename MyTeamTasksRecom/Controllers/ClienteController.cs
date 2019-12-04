using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            if (TempData["Cnpj"] != null)
            {
                string resultadoCnpj = TempData["Cnpj"].ToString();
                Empresa emp = JsonConvert.DeserializeObject<Empresa>(resultadoCnpj);
                cliente.Empresa = emp;
            }
            if (TempData["Erro"] != null)
            {
                ModelState.AddModelError("", "Informe um CNPJ válido!");
            }
            return View(cliente);
        }
        [HttpPost]
        public IActionResult BuscarCnpj(Cliente c)
        {
            try
            {
                //url do receitaws.com.br
                string url = "https://www.receitaws.com.br/v1/cnpj/" + c.Empresa.Cnpj;
                WebClient cnpj = new WebClient();
                TempData["Cnpj"] = cnpj.DownloadString(url);
                return RedirectToAction(nameof(Cadastrar));
            }
            catch (WebException e)
            {
                TempData["Erro"] = e.Message;
            }
            return RedirectToAction("Cadastrar");
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