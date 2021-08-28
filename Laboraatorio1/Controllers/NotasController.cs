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
        public ActionResult Resultado(String Nombre, String lab1, String lab2, String lab3, String par1, String par2, String par3)
        {
            string nombre = Nombre;
            Double Lab1 = Convert.ToDouble(lab1);
            Double Lab2 = Convert.ToDouble(lab2);
            Double Lab3 = Convert.ToDouble(lab3);
            Double Par1 = Convert.ToDouble(par1);
            Double Par2 = Convert.ToDouble(par2);
            Double Par3 = Convert.ToDouble(par3);

            
            Double Laboratorio1 = (Lab1 * 0.40);
            Double Parcial1 = (Par1 * 0.60);
            Double Periodo1 = ((Laboratorio1 + Parcial1) / 3);
            Double Laboratorio2 = (Lab2 * 0.40);
            Double Parcial2 = (Par2 * 0.60);
            Double Periodo2 = ((Laboratorio2 + Parcial2) / 3);
            Double Laboratorio3 = (Lab3 * 0.40); 
            Double Parcial3 = (Par2 * 0.60);
            Double Periodo3 = ((Laboratorio3 + Parcial3) / 3);
            Double PeriodoFinal = (Periodo1 + Periodo2 + Periodo3);

            ViewBag.Nombre = nombre;
            ViewBag.lab1 = Laboratorio1;
            ViewBag.par1 = Parcial1;
            ViewBag.promedi1 = Periodo1;
            ViewBag.lab2 = Laboratorio2;
            ViewBag.par2 = Parcial2;
            ViewBag.promedi2 = Periodo2;
            ViewBag.lab3 = Laboratorio3;
            ViewBag.par3 = Parcial3;
            ViewBag.promedi3 = Periodo3;
            ViewBag.Pf = PeriodoFinal;





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

            return View();
        }

        public ActionResult Historial()
        {
            using (EstudianteEntities esd = new EstudianteEntities())
            {
                var listado = esd.TblNotasEstudiante.ToList();
                return View(listado);
            }
            
        }

        
        //public ActionResult Resultado(String Nombre, String lab1, String lab2, String lab3, String par1, String par2, String par3)
        //{

        //    ////_ = Nombre;
        //    //Double Lab1 = Convert.ToDouble(lab1);
        //    //Double Lab2 = Convert.ToDouble(lab2);
        //    //Double Lab3 = Convert.ToDouble(lab3);
        //    //Double Par1 = Convert.ToDouble(par1);
        //    //Double Par2 = Convert.ToDouble(par2);
        //    //Double Par3 = Convert.ToDouble(par3);

        //    ViewBag.Nombre = Nombre;
        //    ViewBag.lab1 = (Lab1 * 0.4);
        //    ViewBag.lab2 = (Lab2 * 0.4);
        //    ViewBag.lab3 = (Lab3 * 0.4);
        //    ViewBag.par1 = (Par1 * 0.6);
        //    ViewBag.par2 = (Par2 * 0.6);
        //    ViewBag.par3 = (Par3 * 0.6);



        //    return View();
        //}

    }  
}