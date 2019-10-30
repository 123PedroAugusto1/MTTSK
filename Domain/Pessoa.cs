using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Pessoa
    {
        public Pessoa()
        {
            CriadoEm = DateTime.Now;
        }
        [Key]
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public DateTime CriadoEm { get; set; }

        public override string ToString()
        {
            return "ID: " + PessoaId +
                "\nNome: " + Nome;
        }
    }
}




