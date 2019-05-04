using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace EmpresaXpto.UI.Web.Models
{
    public class ClienteViewModel
    {
        [Required(ErrorMessage = "O Arquivo é obrigatório.")]
        public HttpPostedFileBase Arquivo { get; set; }

        internal string RetornarConteudoArquivo(Stream fileStream)
        {
            string conteudoArquivo;

            using (StreamReader reader = new StreamReader(fileStream))
            {
                conteudoArquivo = reader.ReadToEnd();
            }
            return conteudoArquivo;
        }
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }

    }

}