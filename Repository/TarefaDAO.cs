using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Repository
{
    public class TarefaDAO
    {
        private readonly Context _context;

        public TarefaDAO(Context context)
        {
            _context = context;
        }
        public  void CadastrarTarefa(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
        }

        public  List<Tarefa> ListarTarefas() => _context.Tarefas.ToList();

        public List<Tarefa> BuscarTarefaPorStatus(Tarefa tarefa)
        {
            return _context.Tarefas.Where(x => x.Status == tarefa.Status).ToList();
        }
       

        public Tarefa BuscarTarefaPorId(int id)
        {
            return _context.Tarefas.FirstOrDefault(x => x.TarefaId == id);
        }

        public void Alterar(Tarefa t)
        {

            _context.Tarefas.Update(t);
            _context.SaveChanges();
            
        }



        public bool RemoverTarefa(Tarefa tarefa)
        {
            try
            {
                _context.Tarefas.Remove(tarefa);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool EditarTarefa(Tarefa t)
        {
            try
            {
                _context.Entry(t).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
