using CadastrarProduto.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrarProduto.Interface
{
   public interface IContext
    {

        void ExecuteCommand(string sql);

        DataTable BuscaDadosDB(string sql);
    }
}
