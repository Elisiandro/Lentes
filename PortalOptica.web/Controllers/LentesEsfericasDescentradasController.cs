using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PortalOptica.web.Models;

namespace PortalOptica.web.Controllers
{
    public class LentesEsfericasDescentradasController : Controller
    {
        // GET: LentesEsfericasDescentradas

        private static LenteEsfericaDescentrada _lentes = new LenteEsfericaDescentrada();

        public ActionResult Index()
        {
            return View();
        }

        // GET: LentesEsfericasDescentradas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public LenteEsfericaDescentrada Ler()
        {
            LenteEsfericaDescentrada model = new LenteEsfericaDescentrada();
            model.Diametro = 1;
            model.TamanhoArmacao = 1;
            model.Dnp = 1;
            model.Rx = 1;
            model.IndiceRefracao = 1.499;
            model.CurvaBase = 1;
            //model.FatorConversao = 1;
            //model.NovaDiopdria = 1;
            //model.CurvaOposta = 1;
            //model.Descentracao = 1;
            //model.DiferencaBorda = 1;
            //model.EspessuraTotal = 1;
            //model.EspessuraOposta = 1;
            //model.EspessuraMinima = 1;

            return model;
        }

        // GET: LentesEsfericasDescentradas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LentesEsfericasDescentradas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calculo([FromForm]LenteEsfericaDescentrada model)
        {

            
            
            
            double _fatorConversao = Math.Round(((1.530 - 1) / (model.IndiceRefracao - 1)), 2);
            double nd = Math.Round(_fatorConversao * model.Rx,2);
            double co = Math.Round(nd - (model.CurvaBase),2);
            double _x = Math.Round((model.Diametro / 2),2);

            double e = 2.00;
            if (nd <= 0.50)                
                e = 2.00;//if (nd >= 0.00 && nd <= 0.50)
            else if (nd >= 0.51 && nd <= 1.00)
                e = 1.8;
            else if (nd >= 1.01 && nd <= 2.50)
                e = 1.6;
            else if (nd >= 2.51 && nd <= 4.50)
                e = 1.4;
            else if (nd >= 4.51 && nd <= 6.50)
                e = 1.2;
            else if (nd >= 6.51 && nd <= 8.00)
                e = 1.0;
            else if (nd >= 8.01)
                e = 0.8;
            
            double ezao = Math.Round( Math.Abs((((_x * _x) * Math.Abs(nd)) / 1000) + e),2);
            double ds = Math.Round((model.TamanhoArmacao / 2) - model.Dnp,2);
            double db = Math.Round((0.019 * model.Diametro * ds * Math.Abs(nd) * 0.1),2);
            double et = Math.Round(ezao + (db / 2),2);
            
            double eo = e + db;
            double provaReal = eo - e;

            if (model.Rx < 0) //Lente negativa
            {
                eo = et - db;
                provaReal = et - eo;
            }

            //PROVA REAL
            bool isOk = (db == Math.Round(provaReal,2));

            ViewBag.FatorConversao = _fatorConversao.ToString();
            ViewBag.NovaDiopdria = nd.ToString();
            ViewBag.CurvaOposta = co.ToString();
            ViewBag.Descentracao = ds.ToString() + " mm";
            ViewBag.DiferencaBorda = db.ToString() + " mm";
            ViewBag.Ezao = ezao.ToString() + " mm";
            ViewBag.EspessuraTotal = et.ToString() + " mm";
            ViewBag.EspessuraOposta = eo.ToString() + " mm";
            ViewBag.EspessuraMinima = e.ToString() + " mm";
            ViewBag.ProvaReal = (isOk ? "SIM" : "NÃO");

            return View("Create");
        }

        // POST: LentesEsfericasDescentradas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LentesEsfericasDescentradas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LentesEsfericasDescentradas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LentesEsfericasDescentradas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LentesEsfericasDescentradas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}