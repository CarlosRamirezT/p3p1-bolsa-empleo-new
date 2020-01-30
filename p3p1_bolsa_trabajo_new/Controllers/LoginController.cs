using System.Linq;
using System.Web.Mvc;
using p3p1_bolsa_trabajo_new.Models;

namespace p3p1_bolsa_trabajo_new.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            using (p3p1BolsaTrabajoEntities1 db = new p3p1BolsaTrabajoEntities1())
            {
                var details = db.Usuarios.Where(x => x.email == usuario.email && x.password_usuario == usuario.password_usuario).FirstOrDefault();
                if (details == null)
                {
                    ViewBag.ErrorMessage = "Usuario no encontrado";
                    return View("Login", usuario);
                }
                else
                {
                    Session["id_usuarios"] = details.id_usuarios;
                    return RedirectToAction("IndexAdmin", "Ofertas");
                }
            }
        }
    }
}