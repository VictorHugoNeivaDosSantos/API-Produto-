using CadastrarProduto.DBConection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CadastrarProduto.Model
{
    public class ProdutoModel
    {

        public int id { get; }

        [JsonProperty("codigo")]

        public string codigo { get; set; }

        [JsonProperty("descricao")]
        public string descricao { get; set; }

        [JsonProperty("preco_custo")]
        public double preco_custo { get; set; }

    }
}
