using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alura___AspNet.DAO
{
    public class UsuarioDAO
    {
        public tbUsuarios Autentica(tbUsuarios usuario)
        {

            using (var db = new masterEntities3())
            {

                tbUsuarios usuarioEncontrado = db.tbUsuarios.Where(p => p.Nome == usuario.Nome && p.Senha == usuario.Senha).FirstOrDefault();

                return usuarioEncontrado;
            }
        }
    }


}