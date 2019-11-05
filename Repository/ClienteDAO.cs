using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class ClienteDAO: IRepository<Cliente>
    {
        private readonly Context _context;

        public ClienteDAO(Context context)
        {
            _context = context;
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

        }
        public Cliente BuscarClientePorId(int? id)
        {
            return _context.Clientes.Find(id);
        }

        public void Remover(int id)
        {
            _context.Clientes.Remove(BuscarClientePorId(id));
            _context.SaveChanges();
        }

        public void Alterar(Funcionario funcionario)
        {
            _context.Entry(funcionario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        bool IRepository<Cliente>.Cadastrar(Cliente objeto)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ListarTodos()
        {
            return _context.Clientes.ToList();
        }

        public Cliente BuscarPorId(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
