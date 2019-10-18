using Microsoft.EntityFrameworkCore;
using MyTeamTasksRecom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTeamTasksRecom.DAL
{
    public class ClienteDAO
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
        public List<Cliente> Listar()
        {
            return _context.Clientes.ToList();
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
    }
}
