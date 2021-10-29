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
    public class MenuController : Controller
    {
        private readonly IMainBusinessLayer mainBl;

        public MenuController(IMainBusinessLayer bl)
        {
            this.mainBl = bl;
        }

        public IActionResult Index()
        {
            
            var result = mainBl.FetchMenus();
            
            var resultMapping = result.ToListViewModel();
            return View(resultMapping);
        }

        //GET Menu/Detail/{id}
        [LogFilterAttribute]
        public IActionResult Detail(int id)
        {
            if (id <= 0)
                return View("NotFound");
            var piatti = mainBl.FetchPiatti(p => p.MenuId == id);
            var resultMapped = piatti.ToListViewModel();
            return View(resultMapped);
        }

        //HTTP GET Menu/Create
        [LogFilterAttribute]
        [Authorize(Policy = "Ristoratore")]
        public IActionResult Create()
        {
            return View(new MenuViewModel());
        }

        //HTTP POST Menu/Create
        [LogFilterAttribute]
        [HttpPost]
        public IActionResult Create(MenuViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model == null)
            {
                return View("ExceptionError", new ResultBL(false, "Sorry, something went wrong!"));
            }
            

            Menu newMenu = model.ToMenu();
            var result = mainBl.CreateMenu(newMenu);
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
            var menuToEdit = mainBl.GetMenuById(id);
            if (menuToEdit == null)
                return View("NotFound");
            var menuViewModel = menuToEdit.ToViewModel();
            return View(menuViewModel);
        }

        //POST Menu/Edit/ + dati menu
        [LogFilterAttribute]
        [HttpPost]
        public IActionResult Edit(MenuViewModel menuVm)
        {
            if (!ModelState.IsValid)
            {
                return View(menuVm);
            }
            if (menuVm == null)
                return View("ExceptionError", new ResultBL(false, "Sorry, something went wrong!"));
            

            var menuToEdit = menuVm.ToMenu();
            var result = mainBl.EditMenu(menuToEdit);
            if (!result.Success)
            {
                return View("ExceptionError", result);
            }
            return View("Detail", menuVm);
        }

    }
}