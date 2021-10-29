using Ristorante.Core.Interfaces;
using Ristorante.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.EF.Repositories
{
    public class RepositoryUserEF : IRepositoryUser
    {
        private readonly RistoranteContext _ctx;

        public RepositoryUserEF(RistoranteContext context)
        {
            _ctx = context;
        }

        public bool AddItem(User item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Fetch(Func<User, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                return null;
            return _ctx.Users.FirstOrDefault(u => u.Username.Equals(username));
        }

        public bool UpdateItem(User updatedItem)
        {
            throw new NotImplementedException();
        }
    }
}
