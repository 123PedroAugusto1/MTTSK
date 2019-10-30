using System;
using Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Projeto")]
   public class Projeto
    {
        public Projeto()
        {
            CriadoEm = DateTime.Now;
        }
        [Key]
        public int ProjetoId { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }
        public Cliente cliente {get; set; }
        public DateTime CriadoEm { get; set; }

        public override string ToString()
        {
            return Nome;

        }
    }
}