using Encuestas.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Encuestas.App_Start;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace Encuestas.Controllers
{

    public class EncuestaController : Controller
    {
        string CnString = ConfigurationManager.ConnectionStrings["ConexcionBD"].ConnectionString;

        [Session]
        public ActionResult Index()
        {
            IList<Encuesta> list = new List<Encuesta>();
            using (SqlConnection cn = new SqlConnection(CnString))
            {
                SqlCommand cmd = new SqlCommand("SP_EncuestaEncabezado", cn);
                cmd.Parameters.AddWithValue("NumConsulta", 2);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Encuesta linea = new Encuesta();
                                linea.IdEncuesta = reader.GetInt32(reader.GetOrdinal("IdEncusta"));
                                linea.IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario"));
                                linea.Nombre = reader.GetString(reader.GetOrdinal("Nombre"));
                                linea.Descripcion = reader.GetString(reader.GetOrdinal("Descripcion"));
                                list.Add(linea);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    var mensaje = e.Message;
                }
            }
            Session["ListaEncuesta"] = list;
            return View();
        }
        public ActionResult CreacionEncabezado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreacionEncabezado(Encuesta value)
        {
            bool Registrado;
            string Mensaje;
            int IdEncuesta;
            if (Session["Usuario"] != null)
            {
                Usuario u = (Usuario)Session["Usuario"];
                value.IdUsuario = u.Id;
            }
            else
            {
                return View();
            }

            using (SqlConnection cn = new SqlConnection(CnString))
            {
                SqlCommand cmd = new SqlCommand("SP_EncuestaEncabezado", cn);
                cmd.Parameters.AddWithValue("NumConsulta", 1);
                cmd.Parameters.AddWithValue("IdUsuario", value.IdUsuario);
                cmd.Parameters.AddWithValue("Nombre", value.Nombre);
                cmd.Parameters.AddWithValue("Descripcion", value.Descripcion);
                cmd.Parameters.Add("Creado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("IdEncuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.ExecuteNonQuery();

                Registrado = Convert.ToBoolean(cmd.Parameters["Creado"].Value);
                IdEncuesta = Convert.ToInt32(cmd.Parameters["IdEncuesta"].Value);
                Mensaje = (cmd.Parameters["Mensaje"].Value.ToString());
            }

            ViewData["Mensaje"] = Mensaje;
            if (Registrado)
            {
                Session["IdEncuesta"] = IdEncuesta;
                return RedirectToAction("Creacion", "Encuesta");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Creacion()
        {
            IList<Detalle> list = new List<Detalle>();
            using (SqlConnection cn = new SqlConnection(CnString))
            {
                SqlCommand cmd = new SqlCommand("SP_EncuestaDetalle", cn);
                cmd.Parameters.AddWithValue("NumConsulta", 2);
                cmd.Parameters.AddWithValue("IdEncuesta", Session["IdEncuesta"]);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Detalle linea = new Detalle();
                                linea.IdDetalle = reader.GetInt32(reader.GetOrdinal("IdDetalle"));
                                linea.IdEncuesta = reader.GetInt32(reader.GetOrdinal("IdEncusta"));
                                linea.NombreCampo = reader.GetString(reader.GetOrdinal("NombreCampo"));
                                linea.Titulo = reader.GetString(reader.GetOrdinal("Titulo"));
                                linea.EsRequerido = reader.GetString(reader.GetOrdinal("EsRequerido"));
                                linea.TipoCampo = reader.GetString(reader.GetOrdinal("TipoCampo"));
                                linea.TipoCambioValor = reader.GetString(reader.GetOrdinal("TipoCampoValor"));
                                list.Add(linea);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    var mensaje = e.Message;
                }
            }
            Session["ListaDetalle"] = list;
            return View();
        }

        [HttpPost]
        public ActionResult Creacion(Detalle value)
        {
            bool Registrado;
            string Mensaje;
            if (Session["IdEncuesta"] != null)
            {
                value.IdEncuesta = Convert.ToInt32(Session["IdEncuesta"]);
            }
            else
            {
                value.IdEncuesta = 2;
            }
            switch (value.TipoCampo)
            {
                case "T":
                    value.TipoCambioValor = "text";
                    break;
                case "N":
                    value.TipoCambioValor = "number";
                    break;
                case "D":
                    value.TipoCambioValor = "date";
                    break;
            }
            using (SqlConnection cn = new SqlConnection(CnString))
            {
                SqlCommand cmd = new SqlCommand("SP_EncuestaDetalle", cn);
                cmd.Parameters.AddWithValue("NumConsulta", 1);
                cmd.Parameters.AddWithValue("IdEncuesta", value.IdEncuesta);
                cmd.Parameters.AddWithValue("NombreCampo", value.NombreCampo);
                cmd.Parameters.AddWithValue("Titulo", value.Titulo);
                cmd.Parameters.AddWithValue("EsRequerido", value.EsRequerido);
                cmd.Parameters.AddWithValue("TipoCampo", value.TipoCampo);
                cmd.Parameters.AddWithValue("TipoCampoValor", value.TipoCambioValor);
                cmd.Parameters.Add("Creado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.ExecuteNonQuery();

                Registrado = Convert.ToBoolean(cmd.Parameters["Creado"].Value);
                Mensaje = (cmd.Parameters["Mensaje"].Value.ToString());
            }

            ViewData["Mensaje"] = Mensaje;
            if (Registrado)
            {
                return RedirectToAction("Creacion", "Encuesta");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult EditarDetalle(int k, Detalle value)
        {
            bool Actualizado;
            string Mensaje;
            switch (value.TipoCampo)
            {
                case "T":
                    value.TipoCambioValor = "text";
                    break;
                case "N":
                    value.TipoCambioValor = "number";
                    break;
                case "D":
                    value.TipoCambioValor = "date";
                    break;
            }
            using (SqlConnection cn = new SqlConnection(CnString))
            {
                SqlCommand cmd = new SqlCommand("SP_EncuestaDetalle", cn);
                cmd.Parameters.AddWithValue("NumConsulta", 3);
                cmd.Parameters.AddWithValue("IdDetalle", k);
                cmd.Parameters.AddWithValue("NombreCampo", value.NombreCampo);
                cmd.Parameters.AddWithValue("Titulo", value.Titulo);
                cmd.Parameters.AddWithValue("EsRequerido", value.EsRequerido);
                cmd.Parameters.AddWithValue("TipoCampo", value.TipoCampo);
                cmd.Parameters.AddWithValue("TipoCampoValor", value.TipoCambioValor);
                cmd.Parameters.Add("Creado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.ExecuteNonQuery();

                Actualizado = Convert.ToBoolean(cmd.Parameters["Creado"].Value);
                Mensaje = (cmd.Parameters["Mensaje"].Value.ToString());
            }

            ViewData["Mensaje"] = Mensaje;
            if (Actualizado)
            {
                return RedirectToAction("Creacion", "Encuesta");
            }
            else
            {
                return View();
            }
        }

        public ActionResult EliminarRegistro(int k)
        {
            bool Eliminado;
            string Mensaje;
            using (SqlConnection cn = new SqlConnection(CnString))
            {
                SqlCommand cmd = new SqlCommand("SP_EncuestaDetalle", cn);
                cmd.Parameters.AddWithValue("NumConsulta", 4);
                cmd.Parameters.AddWithValue("IdDetalle", k);
                cmd.Parameters.Add("Creado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.ExecuteNonQuery();

                Eliminado = Convert.ToBoolean(cmd.Parameters["Creado"].Value);
                Mensaje = (cmd.Parameters["Mensaje"].Value.ToString());
            }

            ViewData["Mensaje"] = Mensaje;
            if (Eliminado)
            {
                return RedirectToAction("Creacion", "Encuesta");
            }
            else
            {
                return View();
            }
        }

        public ActionResult EditarEncuesta(int k)
        {
            Session["IdEncuesta"] = k;
            return RedirectToAction("Creacion", "Encuesta");
        }

        public ActionResult EliminarEncuesta(int k)
        {
            bool Eliminado;
            string Mensaje;
            using (SqlConnection cn = new SqlConnection(CnString))
            {
                SqlCommand cmd = new SqlCommand("SP_EncuestaDetalle", cn);
                cmd.Parameters.AddWithValue("NumConsulta", 5);
                cmd.Parameters.AddWithValue("IdEncuesta", k);
                cmd.Parameters.Add("Creado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.ExecuteNonQuery();

                Eliminado = Convert.ToBoolean(cmd.Parameters["Creado"].Value);
                Mensaje = (cmd.Parameters["Mensaje"].Value.ToString());
            }

            ViewData["Mensaje"] = Mensaje;
            if (Eliminado)
            {
                return RedirectToAction("Index", "Encuesta");
            }
            else
            {
                return View();
            }
        }
        public ActionResult LogOut()
        {
            Session.Remove("usuario");
            return RedirectToAction("Login", "Acceso");
        }
    }
}