using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Xml;
using System.Data;
using System.Net;
using System.Text.RegularExpressions;
using System.Security.Principal;
using System.Web.UI;
using AppControleReceita.Models;

namespace AppControleReceita.Controllers
{
    public class LoginController : Controller
    {

        DataContext db = new DataContext();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        #region [Autenticar]
        [HttpPost]
        [AllowAnonymous]
        public string Autenticar(string pUsuario, string pSenha)
        {
            string lRetorno = string.Empty;

            //var lSegUsuario = db.Dbseg_usuario.Where(x=> x.USU_NOME.Equals(pUsuario) && x.USU_SENHA.Equals(pSenha) && x.USU_STATUS.Equals("A")).ToList();

            //if (lSegUsuario.Count == 1)
            if(true)
            {
                //Session["Sessao"] = lSegUsuario[0];
                return "1";
            }
            else
            {
                return "0";
            }

            

        }
        #endregion

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            try
            {
                Session["Sessao"] = null;
                return RedirectToAction("Index", "Login");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Login");
            }

        }
    }
}