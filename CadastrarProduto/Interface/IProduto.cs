using CadastrarProduto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrarProduto.Interface
{
    public interface IProduto
    {

        RetornoMenssege CadastrarProduto(ProdutoModel produto);
        RetornoMenssege AtualizarProduto(string codigoDoProdutoASerAlterado, ProdutoModel produto);
        List<ProdutoModel> BuscarProduto(string codigo);
        List<ProdutoModel> Listagem();
        RetornoMenssege DeletarProduto(string codigo);



    }
}
