using Alura___AspNet.DAO;
using Alura___AspNet.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alura___AspNet.Controllers
{
    [AutorizacaoFilter]
    public class ProdutoController : Controller
    {
        //[Route("produtos", Name="ListaProdutos")]
        
        public ActionResult Index()
        {
            ProdutosDAO dao = new ProdutosDAO();
            var listaProdutos = dao.Lista();
            return View(listaProdutos);

        }

        public ActionResult Cadastro()
        {
            ViewBag.product = new tb_produtos2();
            return View();
        }

        // Ao Colcoar a clausula [HttpPost] o metodo obriga que só receba os valores por metodo Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adiciona(tb_produtos2 product)
        {

            if (product.Preco < 0)
            {
                ModelState.AddModelError("PrecoInvalido", "Valor Inválido");
            }

            if (ModelState.IsValid)
            {
                var dao = new ProdutosDAO();

                dao.AdicionaDb(product);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.product = product;
                return View("Cadastro");
            }
        }

        [Route("produtos/{id}", Name = "VisualizaProduto")]
        public ActionResult Visualiza(int id)
        {

            ProdutosDAO dao = new ProdutosDAO();

            tb_produtos2 produto = dao.GetDetailsProduct(id);

            ViewBag.produto = produto;

            return View();
        }

        public ActionResult DecrementaQtd(int id)
        {

            ProdutosDAO dao = new ProdutosDAO();

            var produto = dao.GetDetailsProduct(id);

            produto.Quantidade--;
            dao.Atualiza(produto);

            return Json(produto);
        }
    }
}