using Encuestas.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Newtonsoft.Json.Linq;
using Microsoft.Ajax.Utilities;

namespace Encuestas.Controllers
{
    public class RespuestaController : Controller
    {
        string CnString = ConfigurationManager.ConnectionStrings["ConexcionBD"].ConnectionString;
        public ActionResult Encuesta(string k, int j)
        {
            int Cod;
            using (SqlConnection cn = new SqlConnection(CnString))
            {
                SqlCommand cmd = new SqlCommand("SP_EncuestaEncabezado", cn);
                cmd.Parameters.AddWithValue("NumConsulta", 3);
                cmd.Parameters.AddWithValue("Encuesta", j);
                cmd.Parameters.AddWithValue("Nombre", k);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                Cod = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            if (Cod != 0)
            {
                IList<Detalle> list = new List<Detalle>();
                using (SqlConnection cn = new SqlConnection(CnString))
                {
                    SqlCommand cmd = new SqlCommand("SP_EncuestaDetalle", cn);
                    cmd.Parameters.AddWithValue("NumConsulta", 2);
                    cmd.Parameters.AddWithValue("IdEncuesta", Cod);
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
                ViewBag.ListaDetalleEncuesta = list;
                ViewBag.IdEncuesta = Cod;
                ViewBag.CountDetalle = list.Count();
                return View();
            }
            else
            {
                return View();
            }
        }

        public ActionResult RespuestaEncuesta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RespuestaEncuesta(int k, int j, FormCollection frm)
        {
            bool Registrado;
            string Mensaje;
            int count = 0;
            IList<Respuesta> Respuesta = new List<Respuesta>();
            for (int i = 0; i < j; i++)
            {
                string input = "Input" + count;
                string detalle = "Detalle" + count;
                Respuesta line = new Respuesta();
                line.IdEncuesta = k;
                line.IdDetalle = int.Parse(frm[detalle]);
                line.Valor = string.Format(frm[input]);
                Respuesta.Add(line);
                count++;
            }

            foreach (var item in Respuesta)
            {
                using (SqlConnection cn = new SqlConnection(CnString))
                {
                    SqlCommand cmd = new SqlCommand("SP_EncuestaRespuesta", cn);
                    cmd.Parameters.AddWithValue("NumConsulta", 1);
                    cmd.Parameters.AddWithValue("IdEncuesta", item.IdEncuesta);
                    cmd.Parameters.AddWithValue("IdDetalle", item.IdDetalle);
                    cmd.Parameters.AddWithValue("Valor", item.Valor);
                    cmd.Parameters.Add("Creado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    Registrado = Convert.ToBoolean(cmd.Parameters["Creado"].Value);
                    Mensaje = (cmd.Parameters["Mensaje"].Value.ToString());
                }
            }
            return View();
        }
        public ActionResult VerRespuestas(string k)
        {
            IList<Respuesta> list = new List<Respuesta>();
            using (SqlConnection cn = new SqlConnection(CnString))
            {
                SqlCommand cmd = new SqlCommand("SP_EncuestaRespuesta", cn);
                cmd.Parameters.AddWithValue("NumConsulta", 2);
                cmd.Parameters.AddWithValue("IdEncuesta", k);
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
                                Respuesta linea = new Respuesta();
                                linea.Pregunta = reader.GetString(reader.GetOrdinal("Titulo"));
                                linea.Valor = reader.GetString(reader.GetOrdinal("Valor"));
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
            Session["ListaRespuesta"] = list;
            return View();
        }
    }
}