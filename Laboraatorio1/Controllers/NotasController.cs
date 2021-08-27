using Laboraatorio1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laboraatorio1.Controllers
{
    public class NotasController : Controller
    {
        // GET: Notas
        public ActionResult Index()
        {
            
                return View();
        }

        [HttpPost]
        public ActionResult Save(String Nombre, String lab1, String lab2, String lab3, String par1, String par2, String par3)
        {
            using (EstudianteEntities estudiante = new EstudianteEntities())
            {
                TblNotasEstudiante Est = new TblNotasEstudiante();
                Est.Nombre = Nombre;
                Est.lab1 = lab1;
                Est.lab2 = lab2;
                Est.lab3 = lab3;
                Est.par1 = par1;
                Est.par2 = par2;
                Est.par3 = par3;
                estudiante.TblNotasEstudiante.Add(Est);
                estudiante.SaveChanges();
            }

                return Redirect("/Notas/Resultado");
        }

        public ActionResult Historial()
        {
            using (EstudianteEntities esd = new EstudianteEntities())
            {
                var listado = esd.TblNotasEstudiante.ToList();
                return View(listado);
            }
            
        }

        
        public ActionResult Resultado(String Nombre, String lab1, String lab2, String lab3, String par1, String par2, String par3)
        {

            //_ = Nombre;
            Double Lab1 = Convert.ToInt32(lab1);
            Double Lab2 = Convert.ToDouble(lab2);
            Double Lab3 = Convert.ToDouble(lab3);
            Double Par1 = Convert.ToDouble(par1);
            Double Par2 = Convert.ToDouble(par2);
            Double Par3 = Convert.ToDouble(par3);

            ViewBag.Nombre = Nombre;
            ViewBag.lab1 = (Lab1 * 0.4);
            ViewBag.lab2 = (Lab2 * 0.4);
            ViewBag.lab3 = (Lab3 * 0.4);
            ViewBag.par1 = (Par1 * 0.6);
            ViewBag.par2 = (Par2 * 0.6);
            ViewBag.par3 = (Par3 * 0.6);



            return View();
        }

    }  
}