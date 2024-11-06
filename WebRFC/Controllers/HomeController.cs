using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebRFC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("Inicio");
        }

        public ActionResult Iniciar()
        {
            return View("Agregar");
        }

        public ActionResult Agregar(E_rfc rfc)
        {
            try
            {
                N_rfc n_rfc = new N_rfc();

                string rfc_generado = n_rfc.RFC(rfc);
                rfc.RFC= rfc_generado;
                n_rfc.Agregar(rfc);

                TempData["mensaje"] = $"{rfc_generado}";
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }

            return View("Agregado");
        }

        public ActionResult irBD()
        {
            List<E_rfc> lista = new List<E_rfc>();
            int totalActivos = 0;

            try
            {
                N_rfc negocio = new N_rfc();

                lista = negocio.Mostrar_todos();
                totalActivos = negocio.mostrartotal();

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            ViewBag.TotalActivos = totalActivos;
            return View("BaseDeDatos", lista);
        }

        public ActionResult irEditar(int idUsuario)
        {
            E_rfc rfc = new E_rfc();

            try
            {
                N_rfc negocio = new N_rfc();

                rfc = negocio.Mostrar_Id(idUsuario);
            }
            catch(Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View("EditarId", rfc);
        }

        public ActionResult irEliminar(int idUsuario)
        {
            E_rfc rfc = new E_rfc();

            try
            {
                N_rfc negocio = new N_rfc();

                rfc = negocio.Mostrar_Id(idUsuario);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View("EliminarId", rfc);
        }

        public ActionResult Actualizar(E_rfc rfc)
        {
            try
            {
                N_rfc n_Rfc = new N_rfc();

                n_Rfc.Actualizar(rfc);
                TempData["mensaje"] = $"Los datos de {rfc.nombre}, se actualizaron correctamente.";
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return RedirectToAction("irBD");
        }

        public ActionResult Eliminar(E_rfc rfc)
        {
            try
            {
                N_rfc n_Rfc = new N_rfc();

                n_Rfc.Eliminar(rfc);
                TempData["mensaje"] = $"Los datos de {rfc.nombre}, se eliminaron correctamente.";
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return RedirectToAction("irBD");
        }

        public ActionResult Buscar(string textoBusqueda)
        {
            List<E_rfc> rfc = new List<E_rfc>();
            try
            {
                N_rfc negocio = new N_rfc();
                rfc = negocio.Buscar(textoBusqueda);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View("Busqueda", rfc);
        }


        public ActionResult irAtras()
        {
            return RedirectToAction("irBD");
        }
    }
}