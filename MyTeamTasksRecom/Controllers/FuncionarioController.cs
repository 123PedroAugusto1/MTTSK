using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Repository;

namespace MyTeamTasksRecom.Controllers
{

    public class FuncionarioController : Controller
    {
        public readonly FuncionarioDAO _funcionarioDAO;
        private readonly UserManager<UsuarioLogado> _userManager;
        private readonly SignInManager<UsuarioLogado> _signInManager;

        public FuncionarioController(FuncionarioDAO funcionarioDAO,
            UserManager<UsuarioLogado> userManager,
            SignInManager<UsuarioLogado> signInManager)
        {
            _funcionarioDAO = funcionarioDAO;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult ListagemFuncionario()
        {
            ViewBag.Funcionarios = _funcionarioDAO.Listar();
            return View();
        }
        public IActionResult Login()
        {

            return View();
        }

            public IActionResult Index()
        {

            return View();
        }
        public IActionResult AtivarFuncionario()
        {
            if (TempData["BuscaFunci2"] != null)
            {
                string dados = TempData["BuscaFunci2"].ToString();
                Funcionario result = JsonConvert.DeserializeObject<Funcionario>(dados);

                return View(result);
            }
            return View();
        }
        public IActionResult DesativarFuncionario()
        {
            if (TempData["BuscaFunci"] != null)
            {
                string dados = TempData["BuscaFunci"].ToString();
                Funcionario result = JsonConvert.DeserializeObject<Funcionario>(dados);
                
                return View(result);
            }
            return View();
        }
        public IActionResult MenuAdm()
        {
            return View();
        }
        public IActionResult MenuGestor()
        {
            return View();
        }
        public IActionResult MenuDev()
        {
            return View();
        }
        public IActionResult Cadastrar()
        {
            Funcionario funcionario = new Funcionario();
            if (TempData["Endereco"] != null) {
                string resultado = TempData["Endereco"].ToString();
                Endereco endereco = JsonConvert.DeserializeObject<Endereco>(resultado);
                funcionario.Endereco = endereco;
            }
            return View(funcionario);
        }
        [HttpPost]
        public async Task<IActionResult> Login(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                return View(funcionario);
             }
            var user = await _userManager.FindByEmailAsync(funcionario.Login);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user,funcionario.Senha, false,false );
                if (result.Succeeded)
                {
                    Funcionario f = _funcionarioDAO.BuscarFuncionarioPorLogin(funcionario.Login);
                    if(f.Cargo == 1)
                    {
                        return RedirectToAction("MenuAdm");
                    }
                    else if(f.Cargo == 2)
                    {
                        return RedirectToAction("MenuGestor");
                    }
                    else
                    {
                        return RedirectToAction("MenuDev");
                    }
                   
                        
                    
                }
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Cadastrar(Funcionario f)
        {
            if (ModelState.IsValid)
            {
                UsuarioLogado usuarioLogado = new UsuarioLogado
                {
                    Email = f.Login,
                    UserName = f.Login

                };
                IdentityResult result = await _userManager.
                    CreateAsync(usuarioLogado, f.Senha);

                if (result.Succeeded)
                {
                    if (_funcionarioDAO.Cadastrar(f))
                    {
                        return RedirectToAction("ListagemFuncionario");
                    }
                    ModelState.AddModelError
                       ("", "");
                }
                else
                {
                    AdicionarErros(result);
                }

                return View(f);
            }
            return View(f);
        }

        private void AdicionarErros(IdentityResult result)
        {
            foreach (var erro in result.Errors)
            {
                ModelState.AddModelError
                    ("", erro.Description);
            }
        }

        public async Task<IActionResult> Remover(int id)
        {

            _funcionarioDAO.Remover(id);
            return RedirectToAction("ListagemFuncionario");
        }
        public IActionResult Alterar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Alterar(Funcionario f)
        {
            _funcionarioDAO.Alterar(f);
            return RedirectToAction("ListagemFuncionario");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> BuscarCep(Funcionario f)
        {
            string url = "https://viacep.com.br/ws/" + f.Endereco.Cep + "/json/";
            WebClient client = new WebClient();
            TempData["Endereco"] = client.DownloadString(url);

            return RedirectToAction("Cadastrar");

        }


       [HttpPost]
       public IActionResult BuscarFuncionarioPorLogin(Funcionario f)
       {
            TempData["BuscaFunci"] = JsonConvert.SerializeObject(_funcionarioDAO.BuscarFuncionarioPorLogin(f.Login));

            return RedirectToAction(nameof(DesativarFuncionario));
       }
        [HttpPost]
        public IActionResult BuscarFuncionarioPorLogin2(Funcionario f)
        {
            TempData["BuscaFunci2"] = JsonConvert.SerializeObject(_funcionarioDAO.BuscarFuncionarioPorLogin(f.Login));

            return RedirectToAction(nameof(AtivarFuncionario));
        }
        [HttpPost]
        public async Task<IActionResult> DesativarFuncionario(Funcionario f)
        {
            _funcionarioDAO.Desativar(f);
            return RedirectToAction("ListagemFuncionario");
        }
        [HttpPost]
        public async Task<IActionResult> AtivarFuncionario(Funcionario f)
        {
            _funcionarioDAO.Ativar(f);
            return RedirectToAction("ListagemFuncionario");
        }


    }
}
