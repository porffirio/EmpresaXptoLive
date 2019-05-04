using EmpresaXpto.Domain;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EmpresaXpto.Repository
{
    public class ClienteRepository
    {
        //String de conexão
        string strConexao = ConfigurationManager.ConnectionStrings["DefaultConection"].ConnectionString;

        public int IncluirCliente(Cliente cliente)
        {
            SqlConnection objConexao = new SqlConnection(strConexao);
            {
                //Comando SQL
                string instrucaoSQL = @"INSERT INTO Cliente(IdCliente,Nome,Sobrenome,DataNascimento,Sexo,Email,Ativo) 
                                        VALUES (@IdCliente,@Nome,@Sobrenome,@DataNascimento,@Sexo,@Email,@Ativo)";
                SqlCommand objCommand = new SqlCommand(instrucaoSQL, objConexao);
                objConexao.Open();
                objCommand.CommandType = CommandType.Text;
                {
                    try
                    {
                        //Parametros de entrada
                        objCommand.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                        objCommand.Parameters.AddWithValue("@Nome", cliente.Nome);
                        objCommand.Parameters.AddWithValue("@Sobrenome", cliente.Sobrenome);
                        objCommand.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento);
                        objCommand.Parameters.AddWithValue("@Sexo", cliente.Sexo);
                        objCommand.Parameters.AddWithValue("@Email", cliente.Email);
                        objCommand.Parameters.AddWithValue("@Ativo", cliente.Ativo);
                        objCommand.ExecuteNonQuery();
                        return 1;
                    }
                    catch (Exception erro)
                    {
                        throw new ArgumentException(erro.Message, erro.InnerException);
                    }
                    finally
                    {
                        objConexao.Close();
                    }
                }
            }

        }
    }
}
