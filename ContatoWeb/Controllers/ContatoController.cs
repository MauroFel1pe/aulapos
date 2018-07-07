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
        private SqlConnection conn = new SqlConnection("Server=tcp:aualposmauro.database.windows.net,1433;Initial Catalog=bdcontato;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        
        // Teste
        public string Get()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"select * from contato for json auto";

            SqlDataReader reader = cmd.ExecuteReader();

            conn.Close();
            return reader.GetString(0);
        }
    }

    public class Contato
    {
        public int ContatoId { get; set; }
        public string  Nome { get; set; }
        public string Email { get; set; }
    }
}
