using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace APi.Controllers
{
    [Route("api/Projeto")]
    [ApiController]
    public class ProjetoController : Controller
    {
        private readonly ProjetoDAO _projetoDAO;
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "teste" };
        }
      

        public ProjetoController(ProjetoDAO projetoDAO)
        {
            _projetoDAO = projetoDAO;
        }

        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListarTodos()
        {
            return Ok(_projetoDAO.ListarTodos());
        }

        [HttpPost]
        [Route("Cadastrar/{id}")]
        public IActionResult Cadastrar([FromBody]Projeto projeto)
        {
            _projetoDAO.Cadastrar(projeto);
            return Created("", projeto);
        }


    }
}