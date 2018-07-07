using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace ContatoWeb.Controllers
{
    public class ContatoController : ApiController
    {
        private SqlConnection conn = new SqlConnection("Server=tcp:aulaposmauro2.database.windows.net,1433;Initial Catalog=bdcontato2;Persist Security Info=False;User ID=mauro;Password=a1a2a3a4a5a6_;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        
        // Teste
        public List<Contato> Get()
        {
            var lista = new List<Contato>();

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"select * from contato";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Contato c = new Contato()
                {
                    ContatoId = (int)reader["ContatoId"],
                    Nome = (string)reader["Nome"],
                    Email = (string)reader["Email"]
                };
                lista.Add(c);
            }

            conn.Close();

            return lista;
        }
    }

    public class Contato
    {
        public int ContatoId { get; set; }
        public string  Nome { get; set; }
        public string Email { get; set; }
    }
}
