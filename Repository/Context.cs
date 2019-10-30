using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
     public class Context : DbContext
    {
        //Nome do DB
        public Context(DbContextOptions<Context> options ) : base(options){ }

        //Definição das classes que virarão tabela no DB
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        //fim
    }
}
