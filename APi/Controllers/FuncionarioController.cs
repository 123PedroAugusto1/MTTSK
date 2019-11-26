using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace APi.Controllers
{
    [Route("api/Funcionario")]
    [ApiController]
    public class FuncionarioController : Controller
    {
        private readonly FuncionarioDAO _funcinarioDAO;

        public FuncionarioController(FuncionarioDAO funcionarioDAO)
        {
            _funcinarioDAO = funcionarioDAO;
        }
        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListarTodos()
        {
            return Ok(_funcinarioDAO.ListarTodos());
        }

        [HttpGet]
        [Route("BuscarPorId/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Funcionario funcionario = _funcinarioDAO.BuscarFuncionarioPorId(id);
            if (funcionario!= null) {
                return Ok(funcionario);
            }
            return NotFound(new {msg ="Funcionario não encontrado"});
        }

        [HttpPost]
        [Route("Cadastrar/{id}")]
        public IActionResult Cadastrar([FromBody]Funcionario funcionario)
        {
            _funcinarioDAO.Cadastrar(funcionario);
            return Created("", funcionario);
        }
    }
}