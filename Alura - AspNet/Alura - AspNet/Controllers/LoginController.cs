using Alura___AspNet.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alura___AspNet.Controllers
{

    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Autentica(tbUsuarios usuario)
        {
            UsuarioDAO dao = new UsuarioDAO();

            var usuarioLogado = dao.Autentica(usuario);

            if (usuarioLogado != null)
            {
                Session["usuarioLogado"] = usuarioLogado;
                return RedirectToAction("Index", "Produto");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }

}