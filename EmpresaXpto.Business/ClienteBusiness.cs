using EmpresaXpto.Domain;
using EmpresaXpto.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaXpto.Business
{
    public class ClienteBusiness
    {
        #region "Metodos Públicos"

        public int IncluirCliente(Cliente cliente)
        {
            //--------------------------------------------- Regras de Negócio

            try
            {
                //------------------------------------------ chamada da camada de acesso a dados
                ClienteRepository clienteRepository = new ClienteRepository();
                int intretorno;
                intretorno = clienteRepository.IncluirCliente(cliente);
                return intretorno;
            }
            catch (Exception erro)
            {
                throw new ArgumentException(erro.Message, erro.InnerException);
            }
        }

        #endregion
    }
}
