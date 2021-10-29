using Ristorante.Core.Interfaces;
using Ristorante.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.EF.Repositories
{
    public class RepositoryPiattoEF : IRepositoryPiatto
    {
        private readonly RistoranteContext ctx;

        public RepositoryPiattoEF(RistoranteContext context)
        {
            this.ctx = context;
        }
        public bool AddItem(Piatto item)
        {
            if (item == null)
                return false;
            ctx.Piatti.Add(item);
            ctx.SaveChanges();
            return true;
        }

        public bool DeleteItem(int id)
        {
            if (id <= 0)
                return false;

            var piattoToDelete = ctx.Piatti.Find(id);

            if (piattoToDelete == null)
                return false;
            ctx.Piatti.Remove(piattoToDelete);
            ctx.SaveChanges();
            return true;
        }

        public IEnumerable<Piatto> Fetch(Func<Piatto, bool> filter = null)
        {
            if (filter != null)
                return this.ctx.Piatti.Where(filter);
            return ctx.Piatti;
        }

        public Piatto GetById(int id)
        {
            if (id <= 0)
                return null;
            return ctx.Piatti.Find(id);
        }

        public bool UpdateItem(Piatto updatedItem)
        {
            if (updatedItem == null)
                return false;
            ctx.Entry(updatedItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            ctx.SaveChanges();
            return true;
        }
    }
}
