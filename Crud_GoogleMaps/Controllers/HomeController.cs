using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crud_GoogleMaps.Models;
using System.Data.Entity;

namespace Crud_GoogleMaps.Controllers
{
    public class HomeController : Controller
    {

        MyDataContext db = new MyDataContext();
        
        Persona persona = new Persona();

        public ActionResult Index(int id = 0)
        {
            var personaId = GetPersona(id);
            ViewBag.Listado = db.Persona.ToList();

            if (id < 1 || personaId == null)
            {
                ViewBag.Crud = "Registrar";
                return View(persona);
            }
            else
            {
                ViewBag.Crud = "Modificar";
                return View(GetPersona(id));
            }
        }

        [HttpPost]
        public ActionResult Index(Persona p)
        {
            if (ModelState.IsValid)
            {
                var persona = GetPersona(p.Nombre, p.Apellido);
                
                if (p.Id == 0)
                {
                    ViewBag.Crud = "Registrar";

                    if (persona != null)
                    {
                        ViewBag.Message = "Ya hay una Persona con los mismos datos";
                    }
                    else
                    {
                        db.Persona.Add(p);
                        ViewBag.Message = "Se Registró Persona";
                    }
                }
                else
                {
                    ViewBag.Crud = "Modificar";

                    if (persona != null)
                    {
                        ViewBag.Message = "Ya hay una Persona con los mismos datos";
                    }
                    else
                    {
                        db.Entry(p).State = EntityState.Modified;
                        ViewBag.Message = "Se Grabaron los cambios";
                    }
                }
                db.SaveChanges();
                ViewBag.Listado = db.Persona.ToList();
                return View("Index", p);
            }
            else
            {
                if (p.Id == 0)
                    ViewBag.Crud = "Registrar";
                else
                    ViewBag.Crud = "Modificar";

                ViewBag.Message = "Aún no ha terminado de llenar los campos";
                ViewBag.Listado = db.Persona.ToList();
                return View("Index", p);
            }
        }
        public ActionResult Delete(int id = 0)
        {
            var personaId = GetPersona(id);
            if (personaId == null)
            {
                ViewBag.Crud = "Eliminar";
                ViewBag.Message = "No se encontró Persona";
            }
            else
            {
                db.Persona.Remove(personaId);
                db.SaveChanges();
                ViewBag.Crud = "Eliminado";
                ViewBag.Message = "Se eliminó Persona";
            }
            ViewBag.Listado = db.Persona.ToList();
            return View("Index", personaId);
        }
        
        public Persona GetPersona(int id)
        {
            Persona persona = new Persona();

            persona = db.Persona.Find(id);
             
            return persona;
        }

        public Persona GetPersona(string nombre, string apellido)
        {
            Persona persona = new Persona();

            persona = db.Persona.Where(p=> p.Nombre.Equals(nombre) && p.Apellido.Equals(apellido)).FirstOrDefault();

            return persona;
        }
    }
}