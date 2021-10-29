using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ristorante.Core.Models;
using Ristorante.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ristorante.MVC.Helpers
{
    public static class MappingExtensions
    {
        public static IEnumerable<SelectListItem> FromEnumToSelectList<T>() where T : struct
        {
            return (Enum.GetValues(typeof(T))).Cast<T>().Select(
                    e => new SelectListItem() { Text = e.ToString(), Value = e.ToString() }).ToList();
        }

        #region Menu
        public static MenuViewModel ToViewModel(this Menu menu)
        {
            return new MenuViewModel
            {
                Id = menu.Id,
                Nome = menu.Nome
            };
        }

        public static IEnumerable<MenuViewModel> ToListViewModel(this IEnumerable<Menu> menus)
        {
            return menus.Select(e => e.ToViewModel());
        }

        public static Menu ToMenu(this MenuViewModel menuViewModel)
        {
            return new Menu
            {
                Id = menuViewModel.Id,
                Nome = menuViewModel.Nome
            };
        }
        #endregion

        #region Piatto

        public static PiattoViewModel ToViewModel(this Piatto piatto)
        {
            return new PiattoViewModel
            {
                Id = piatto.Id,
                Nome = piatto.Nome,
                Descrizione = piatto.Descrizione,
                Tipologia = piatto.Tipologia,
                Prezzo = piatto.Prezzo,
                MenuId = piatto.MenuId,
                Menu = piatto.Menu
                
            };
        }

        public static IEnumerable<PiattoViewModel> ToListViewModel(this IEnumerable<Piatto> piatti)
        {
            return piatti.Select(e => e.ToViewModel());
        }

        public static Piatto ToPiatto(this PiattoViewModel piattoVm)
        {
            return new Piatto
            {
                Id = piattoVm.Id,
                Nome = piattoVm.Nome,
                Descrizione = piattoVm.Descrizione,
                Tipologia = piattoVm.Tipologia,
                Prezzo = piattoVm.Prezzo,
                MenuId = piattoVm.MenuId,
                Menu = piattoVm.Menu
                

            };
        }

        #endregion


    }
}