using CadastrarProduto.Interface;
using CadastrarProduto.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrarProduto.DBConection
{
    public class DBPsql : IContext
    {


        static string servidor = "localhost";
        static string user = "postgres";
        static string pw = "12345";
        static string database = "dbvenda";
        static string porta = "5432";

        string connectString = $"Server ={servidor}; Username={user}; Database={database}; Port={porta}; Password={pw};SSLMode=Prefer;";

        private NpgsqlConnection Connection;



        public DBPsql()
        {
            Connection = new NpgsqlConnection(connectString);

            Connection.Open();
        }

        public DataTable BuscaDadosDB(string sql)
        {
            NpgsqlCommand command = new NpgsqlCommand(sql,Connection);
            DataTable dados = new DataTable();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
            adapter.Fill(dados); 
            return dados;
        }

        public void ExecuteCommand(string sql)
        {

            NpgsqlCommand command = new NpgsqlCommand(sql, Connection);
            command.ExecuteNonQuery();

          

        }

        // public void AtualizarProduto(string sql)
        // {
        //    NpgsqlCommand command = new NpgsqlCommand(sql, Connection);
        //     command.ExecuteNonQuery();
        // }

        //  public DataTable RetornarIDatravesCodigo(string sql)
        //  {
        //     DataTable dados = new DataTable();
        //      NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
        //      adapter.Fill(dados);
        //      return dados;
        // } 


        // public DataTable Lista(string sql)
        // {
        //     NpgsqlCommand command = new NpgsqlCommand(sql,Connection);
        //     DataTable dados = new DataTable();
        //     NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
        //      adapter.Fill(dados);
        //     return dados;


        // }




    }
}
