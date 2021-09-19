using CadastrarProduto.Interface;
using CadastrarProduto.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrarProduto.UTL
{
    public class Produto : IProduto
    {
        private IContext _context;

        public Produto(IContext context)
        {
            _context = context;

        }

        public RetornoMenssege CadastrarProduto(ProdutoModel produto)
        {
            //DBPsql psql = new DBPsql();
            RetornoMenssege retorno = new RetornoMenssege();
            try
            {
                string sql = $"insert into produto(codigo,descricao,preco_custo) values ('{produto.codigo}','{produto.descricao}','{produto.preco_custo}');";
                _context.ExecuteCommand(sql);

                retorno.result = true;
                retorno.ErroMenseger = "Produto cadastrado com sucesso";
            }
            catch (Exception e)
            {
                retorno.result = false;
                retorno.ErroMenseger = "Erro ao cadastrar o produto" + e.Message;

            }

            return retorno;



        }

        public List<ProdutoModel> BuscarProduto(string codigo)
        {

            string sql = $"select * from produto where codigo = '{codigo}' ";
            DataTable dados = _context.BuscaDadosDB(sql);
            List<ProdutoModel> lista = new List<ProdutoModel>();
            ProdutoModel item;

            if (dados.Rows.Count > 0)
            {


                item = new ProdutoModel
                {
                    codigo = dados.Rows[0]["codigo"].ToString(),
                    descricao = dados.Rows[0]["descricao"].ToString(),
                    preco_custo = Convert.ToDouble(dados.Rows[0]["preco_custo"])
                };


                lista.Add(item);
            }
            return lista;





        }

        public RetornoMenssege AtualizarProduto(string codigoDoProdutoASerAlterado, ProdutoModel produto)
        {

            string SelectId = $"Select id from produto where codigo = '{codigoDoProdutoASerAlterado}'";
            RetornoMenssege retorno = new RetornoMenssege();
            if (_context.BuscaDadosDB(SelectId).Rows.Count > 0)
            {


                try
                {

                    if (produto.codigo == null)
                    {
                        produto.codigo = codigoDoProdutoASerAlterado;
                    }
                    string sql = $"update produto set codigo = '{produto.codigo}', descricao = '{produto.descricao}', preco_custo = '{produto.preco_custo}'  where id = {_context.BuscaDadosDB(SelectId).Rows[0]["id"]};";
                    _context.ExecuteCommand(sql);

                    retorno.result = true;
                    retorno.ErroMenseger = "Produto alterado com sucesso";
                }
                catch (Exception e)
                {


                    retorno.result = false;
                    retorno.ErroMenseger = "Erro ao alterar o produto " + e.Message;
                }

            }
            else
            {

                retorno.result = false;
                retorno.ErroMenseger = "ID não encontarda";

            }

            return retorno;
        }

        public List<ProdutoModel> Listagem()
        {
            RetornoMenssege retorno = new RetornoMenssege();
            string sql = "select * from produto;";
            DataTable dados = new DataTable();
            dados = _context.BuscaDadosDB(sql);
            List<ProdutoModel> lista = new List<ProdutoModel>();
            ProdutoModel item;

            if (dados.Rows.Count > 0)
            {

                for (int i = 0; i < dados.Rows.Count; i++)
                {

                    item = new ProdutoModel
                    {
                        codigo = dados.Rows[i]["codigo"].ToString(),
                        descricao = dados.Rows[i]["descricao"].ToString(),
                        preco_custo = Convert.ToDouble(dados.Rows[i]["preco_custo"])

                    };

                    lista.Add(item);
                }



            }

            return lista;

        }


        public RetornoMenssege DeletarProduto(string codigo)
        {
            RetornoMenssege retorno = new RetornoMenssege();            
            string sql = $"delete from produto where codigo = '{codigo}';";
            try
            {
                _context.ExecuteCommand(sql);
                retorno.result = true;
                retorno.ErroMenseger = "Produto excluído";
            }
            catch (Exception e)
            {
                retorno.result = false;
                retorno.ErroMenseger = "Produto não encontrado para ser excluído";
            }

            return retorno;

        }
    }

}
