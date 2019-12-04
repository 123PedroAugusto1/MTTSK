using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Empresas")]
    public class Empresa
    {
        public Empresa()
        {
            CriadoEm = DateTime.Now;
        }
        [Key]
        public int EmpresaId { get; set; }


        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "CNPJ empresa:")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome empresa:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Estado:")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Situação:")]
        public string Situacao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Bairro:")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Rua:")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Número:")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "CEP:")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Cidade:")]
        public string Municipio { get; set; }

        public DateTime CriadoEm { get; set; }
    }
}