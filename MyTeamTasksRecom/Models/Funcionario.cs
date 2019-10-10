using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyTeamTasksRecom.Models
{
    [Table("Funcionario")]
    public class Funcionario : Pessoa
    {
        
        public Funcionario()
        {
            CriadoEm = DateTime.Now;
        }

        public string Cargo { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public override string ToString()
        {
            return Login;
        }
        //fim
    }
}
