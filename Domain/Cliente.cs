using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Cliente")]
    public class Cliente : Pessoa
    {
        public Cliente()
        {
            CriadoEm = DateTime.Now;
        }
        public Empresa Empresa { get; set; }
        public override string ToString()
        {
            return Nome;
        }

    }

}
