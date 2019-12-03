using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class ProjetoDAO : IRepository<Projeto>
    {
        private readonly Context _context;

        public ProjetoDAO(Context context)
        {
            _context = context;
        }
        public void CadastrarProjeto(Projeto p)
        {
            _context.Projetos.Add(p);
            _context.SaveChanges();
        }


        public Projeto BuscarProjetoPorNome(string nome)
        {
            return _context.Projetos.FirstOrDefault(x => x.Nome.Equals(nome));
        }

        public  List<Projeto> BuscarProjetoPorstatus(Projeto p)
        {
            return _context.Projetos.Where(x => x.Status == p.Status).ToList();
        }
        public Projeto BuscarProjetoPorId(int? id)
        {
            return _context.Projetos.Find(id);
        }

        public bool RemoverProjeto(int? id)
        {
            try
            {   
                _context.Projetos.Remove(BuscarProjetoPorId(id));
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AlterarProjeto(Projeto p)
        {
            try
            {
                _context.Entry(p).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Cadastrar(Projeto objeto)
        {
            throw new NotImplementedException();
        }

        public List<Projeto> ListarTodos()
        {
            return _context.Projetos.ToList();
        }

        public Projeto BuscarPorId(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
