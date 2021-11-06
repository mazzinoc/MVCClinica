using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCClinica.Data;
using MVCClinica.Repository;

namespace MVCClinica.Controllers
{
    public class MedicoController : Controller
    {
        private ClinicaContext context = new ClinicaContext();
        // GET: Medico
        public ActionResult Index()
        {            
            return View("Index", AdmMedico.Listar());
        }

        [HttpGet]
        public ActionResult Create()
        {
            Medico medico = new Medico();

            return View("Create", medico);
        }

        [HttpPost]
        public ActionResult Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                AdmMedico.Cargar(medico);
                return RedirectToAction("Index");

            }
            return View("Create", medico);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Medico medico = AdmMedico.Buscar(id);
            if (medico != null)
            {
                return View("Edit", medico);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult Edit(Medico medico)
        {
            if (ModelState.IsValid)
            {
                AdmMedico.Modificar(medico);
                return RedirectToAction("Index");
            }
            return View("Edit", medico);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Medico medico = AdmMedico.Buscar(id);

            if (medico != null)
            {
                return View("Delete", medico);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Medico medico = context.Medicos.Find(id);

            if (medico != null)
            {
                AdmMedico.Borrar(medico);
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            Medico medico = AdmMedico.Listar(id);

            if (medico != null)
            {
                return View("Detail", medico);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpGet]
        public ActionResult Especialidad(int especialidad)
        {
            AdmMedico.BuscarEspecialidad(especialidad);

            if (especialidad != null)
            {
                return View("Index", AdmMedico.BuscarEspecialidad(especialidad));
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
    }
}