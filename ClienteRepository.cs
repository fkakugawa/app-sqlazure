using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace app_sqlazure
{

    public class ClienteRepository : IClienteRepository
    {

        IConfiguration _configuration;
        public ClienteRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string GetConnection()
        {
            //var conn = _configuration.GetSection("ConnectionStrings").GetSection("ClientesConnection").Value;
            var conn = _configuration.GetSection("AppConnection").Value;
            return conn;
        }
        int IClienteRepository.Add(Cliente cliente)
        {
            var connection = this.GetConnection();
            using(var cn = new SqlConnection(connection))
            {
                var novo = cn.Execute("INSERT INTO TBClientes (Nome, Email) VALUES (@Nome, @Email)",
                    //new { Nome = cliente.Nome, Email=cliente.Email }
                    cliente
                    );
                return novo;
            }

        }

        IEnumerable<Cliente> IClienteRepository.GetAll()
        {
            var connection = this.GetConnection();
            using(var cn = new SqlConnection(connection))
            {
                var clientes = cn.Query<Cliente>("SELECT * FROM TBClientes");
                return clientes;
            }
        }
    }
}