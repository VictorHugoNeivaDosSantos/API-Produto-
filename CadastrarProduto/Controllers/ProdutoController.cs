using CadastrarProduto.Interface;
using CadastrarProduto.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrarProduto.Controllers
{
    [ApiController]
    [Route("API")]
    public class ProdutoController : ControllerBase
    {

        private IProduto _produto;
        public ProdutoController(IProduto produtoI)
        {
            _produto = produtoI;
        }



        [HttpGet]
        [Route("BuscarProduto/{codigo}")]

        public List<ProdutoModel> BuscarProduto(string codigo)
        {

            return _produto.BuscarProduto(codigo);

        }

        [HttpGet]
        [Route("ListagemProdutos")]

        public List<ProdutoModel> Listagem()
        {
           
            return _produto.Listagem();

        }

        [HttpPost("CadastrarProduto")]
        

        public RetornoMenssege CadastrarProduto([FromBody] ProdutoModel produto)
        {     
               return  _produto.CadastrarProduto(produto);

        }

        [HttpPut]
        [Route("AtualizaProduto/{codigoDoProdutoASerAlterado}")]

        public RetornoMenssege AtualizarProduto(string codigoDoProdutoASerAlterado, [FromBody] ProdutoModel produto)
        {
            return _produto.AtualizarProduto(codigoDoProdutoASerAlterado, produto);
        }

        [HttpDelete]
        [Route("DeletarProduto/{codigo}")]

        public RetornoMenssege DeletarProduto(string codigo)
        {

          
            return _produto.DeletarProduto(codigo);
        }

    }
}
