using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Endereco")]
    public class Endereco
    {
        public Endereco()
        {

        }
        [Key]
        public int id { get; set; }
        [Display (Name = "Rua:")]
        public String Logradouro { get; set; }
        public String Cep { get; set; }
        public String Bairro{ get; set; }
        public String Localidade { get; set; }
        public String Uf { get; set; }
    }
}
