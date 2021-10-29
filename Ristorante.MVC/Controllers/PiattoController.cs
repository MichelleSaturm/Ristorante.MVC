using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ristorante.Core.Interfaces;
using Ristorante.Core.Models;
using Ristorante.MVC.Filters;
using Ristorante.MVC.Helpers;
using Ristorante.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ristorante.MVC.Controllers
{
    public class PiattoController : Controller
    {
        private readonly IMainBusinessLayer mainBl;

        public PiattoController(IMainBusinessLayer bl)
        {
            this.mainBl = bl;
        }

        public IActionResult Index()
        {

            var result = mainBl.FetchMenus();

            var resultMapping = result.ToListViewModel();
            return View(resultMapping);
        }

        //HTTP GET Piatto/Create
        [LogFilterAttribute]
        [Authorize(Policy = "Ristoratore")]
        public IActionResult Create()
        {
            return View(new PiattoViewModel());
        }

        //HTTP POST Piatto/Create
        [LogFilterAttribute]
        [HttpPost]
        public IActionResult Create(PiattoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model == null)
            {
                return View("ExceptionError", new ResultBL(false, "Sorry, something went wrong!"));
            }
           
            Piatto newPiatto = model.ToPiatto();
            var result = mainBl.CreatePiatto(newPiatto);
            if (!result.Success)
            {
                return View("ExceptionError", result);
            }
            return RedirectToAction(nameof(Index));
        }

        //GET Menu/Edit/Id
        [LogFilterAttribute]
        [Authorize(Policy = "Ristoratore")]
        public IActionResult Edit(int id)
        {
            if (id <= 0)
                return View("NotFound");
            var piattoToEdit = mainBl.GetMenuById(id);
            if (piattoToEdit == null)
                return View("NotFound");
            var piattoViewModel = piattoToEdit.ToViewModel();
            return View(piattoViewModel);
        }

        //POST Menu/Edit/ + dati menu
        [LogFilterAttribute]
        [HttpPost]
        public IActionResult Edit(PiattoViewModel piattoVm)
        {
            if (!ModelState.IsValid)
            {
                return View(piattoVm);
            }
            if (piattoVm == null)
                return View("ExceptionError", new ResultBL(false, "Sorry, something went wrong!"));


            var piattoToEdit = piattoVm.ToPiatto();
            var result = mainBl.EditPiatto(piattoToEdit);
            if (!result.Success)
            {
                return View("ExceptionError", result);
            }
            return View("Detail", piattoVm);
        }

        [Authorize(Policy = "Ristoratore")]
        [Route("Menu/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return Json(false);
            //chiamata al BL
            var result = mainBl.DeletePiatto(id);
            return Json(result.Success);
        }

    }
}