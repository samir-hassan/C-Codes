using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alura___AspNet.DAO
{
    public class ProdutosDAO
    {

        public IList<tb_produtos2> Lista()
        {
            using (var db = new masterEntities2())
            {
                return db.tb_produtos2.ToList<tb_produtos2>();
            }
        }

        public void AdicionaDb(tb_produtos2 product)
        {
            using (var db = new masterEntities2())
            {
                db.tb_produtos2.Add(new tb_produtos2() { Nome = product.Nome, Preco = product.Preco, Quantidade = product.Quantidade, id = product.id });
                db.SaveChanges();
            }
        }

        public tb_produtos2 GetDetailsProduct(int id)
        {
            using (var db = new masterEntities2())
            {
                return db.tb_produtos2
                     .Where(p => p.id == id)
                     .FirstOrDefault();
            }
        }

        public void Atualiza(tb_produtos2 produto)
        {
            using (var db = new masterEntities2())
            {
                db.Entry(produto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}