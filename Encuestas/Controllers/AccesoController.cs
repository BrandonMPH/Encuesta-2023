using Encuestas.App_Start;
using Encuestas.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Encuestas.Controllers
{
    public class AccesoController : Controller
    {
        string cnString = ConfigurationManager.ConnectionStrings["ConexcionBD"].ConnectionString;

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(Usuario value)
        {
            bool Registrado;
            string Mensaje;
            value.Clave = ConvertirSha256(value.Clave);
            using (SqlConnection cn = new SqlConnection(cnString))
            {
                SqlCommand cmd = new SqlCommand("SP_RegistroUsuario", cn);
                cmd.Parameters.AddWithValue("Usuario", value.NombreUsuario);
                cmd.Parameters.AddWithValue("Correo", value.Correo);
                cmd.Parameters.AddWithValue("Clave", value.Clave);
                cmd.Parameters.Add("Resgistrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.ExecuteNonQuery();

                Registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                Mensaje = (cmd.Parameters["Mensaje"].Value.ToString());
            }

            ViewData["Mensaje"] = Mensaje;
            if (Registrado)
            {
                return RedirectToAction("Login", "Acceso");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(Usuario value)
        {
            value.Clave = ConvertirSha256(value.Clave);
            using (SqlConnection cn = new SqlConnection(cnString))
            {
                SqlCommand cmd = new SqlCommand("SP_ValidarUsuario", cn);
                cmd.Parameters.AddWithValue("Usuario", value.NombreUsuario);
                cmd.Parameters.AddWithValue("Clave", value.Clave);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                value.Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            if (value.Id != 0)
            {
                Session["usuario"] = value;
                return RedirectToAction("Index", "Encuesta");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }
        }

        public static string ConvertirSha256(string clave)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(Encoding.UTF8.GetBytes(clave));
                foreach (byte b in result)
                    sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}