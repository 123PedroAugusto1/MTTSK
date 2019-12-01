using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class FuncionarioDAO : IRepository<Funcionario>
    {
        private readonly Context _context;

        public FuncionarioDAO(Context context)
        {
            _context = context;
        }
           
        public bool Cadastrar(Funcionario funcionario)
        {
            try
            {
                _context.Funcionarios.Add(funcionario);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<Funcionario> Listar()
        {
            return _context.Funcionarios.ToList();
        }
        public  Funcionario BuscarFuncionarioPorId(int? id)
        {
            return _context.Funcionarios.Find(id);
        }

        public Funcionario BuscarFuncionarioPorLogin(String Login )
        {
           return _context.Funcionarios.Find(Login);
        }

        public void Remover(int id)
        {           
            _context.Funcionarios.Remove(BuscarFuncionarioPorId(id));
            _context.SaveChanges();
        }

        public void Alterar(Funcionario f)
        {
            _context.Funcionarios.Update(f);
            _context.SaveChanges();
        }

        public List<Funcionario> ListarTodos()
        {
            return _context.Funcionarios.ToList();
        }

        public Funcionario BuscarPorId(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
