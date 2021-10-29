using Ristorante.Core.Interfaces;
using Ristorante.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.EF.Repositories
{
    public class RepositoryMenuEF : IRepositoryMenu
    {

        private readonly RistoranteContext ctx;

        public RepositoryMenuEF(RistoranteContext context)
        {
            this.ctx = context;
        }

        public bool AddItem(Menu item)
        {
            if (item == null)
                return false;
            ctx.Menus.Add(item);
            ctx.SaveChanges();
            return true;
        }

        public bool DeleteItem(int id)
        {
            if (id <= 0)
                return false;

            var menuToDelete = ctx.Menus.Find(id);

            if (menuToDelete == null)
                return false;
            ctx.Menus.Remove(menuToDelete);
            ctx.SaveChanges();
            return true;
        }

        public IEnumerable<Menu> Fetch(Func<Menu, bool> filter = null)
        {
            if (filter != null)
                return this.ctx.Menus.Where(filter);
            return ctx.Menus;
        }

        public Menu GetById(int id)
        {
            if (id <= 0)
                return null;
            return ctx.Menus.Find(id);
        }

        public bool UpdateItem(Menu updatedItem)
        {
            if (updatedItem == null)
                return false;
            ctx.Entry(updatedItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            ctx.SaveChanges();
            return true;
        }
    }
}
