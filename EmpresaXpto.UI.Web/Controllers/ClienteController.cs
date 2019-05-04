using EmpresaXpto.Business;
using EmpresaXpto.Domain;
using EmpresaXpto.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpresaXpto.UI.Web.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IncluirCliente(ClienteViewModel clienteViewModel)
        {
            var result = 0;

            var conteudo = String.Empty;

            if (clienteViewModel.Arquivo.ContentLength > 0)
            {
                conteudo = clienteViewModel.RetornarConteudoArquivo(clienteViewModel.Arquivo.InputStream);
            }

            var totalColunas = conteudo.Split(';');

            for(int i = 0; i < totalColunas.Count(); i++)
            {
                var linhas = totalColunas[i].Split(',');

                var tempCliente = new Cliente();

                tempCliente.IdCliente = int.Parse(linhas[0]);
                tempCliente.Nome = linhas[1];
                tempCliente.Sobrenome = linhas[2];
                tempCliente.DataNascimento = DateTime.Parse(linhas[3]);
                tempCliente.Sexo = linhas[4];
                tempCliente.Email = linhas[5];
                tempCliente.Ativo = Boolean.Parse(linhas[6]);

                result = new ClienteBusiness().IncluirCliente(tempCliente);

            }

            if (result > 0)
            {
                var msg = "Arquivo importado com sucesso!";

                return Json(new { @tipo = msg.ToString(), @mensagem = msg }, JsonRequestBehavior.AllowGet);
            }

            return View("~/Views/index.cshtml");
        }

    }
}
