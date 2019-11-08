using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain
{
    [Table("Funcionario")]
    public class Funcionario : Pessoa
    {
        
        public Funcionario()
        {
            CriadoEm = DateTime.Now;
            Endereco = new Endereco();

        }

        public int Cargo { get; set; }
        [Display(Name = "Login:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Login { get; set; }
        [Display(Name = "Senha:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Senha { get; set; }
        public Endereco Endereco { get; set; }

        public override string ToString()
        {
            return Login;
        }
        //fim
    }
}
