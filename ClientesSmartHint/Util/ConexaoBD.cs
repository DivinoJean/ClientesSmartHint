using MySql.Data.MySqlClient;
using System.Data;

namespace ClientesSmartHint.Util
{
    public class ConexaoBD
    {
        //Dados de conexão com banco de dados MySQL
        private MySqlConnection Connection;
        private string Conexao = "Server=localhost;Database=clientes_sh;Uid=root;Pwd=;Sslmode=none;charset=utf8;convert zero datetime=True";
        
        //Conexão com banco de dados MySQL
        public ConexaoBD()
        {
            Connection = new MySqlConnection(Conexao);
            Connection.Open();
        }

        //Execução da query MySQL
        public void ExecutarSQL(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql,Connection);
            Command.ExecuteNonQuery();  
        }

        //Retorno de dados
        public DataTable RetornoDataTable(string  sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter DataAdaptada = new MySqlDataAdapter(Command);
            DataTable Dados = new DataTable();
            DataAdaptada.Fill(Dados);
            return Dados;
        }
    }
}
