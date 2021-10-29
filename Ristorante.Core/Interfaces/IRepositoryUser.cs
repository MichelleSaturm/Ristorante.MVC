using Ristorante.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Core.Interfaces
{
    public interface IRepositoryUser: IRepository<User>
    {
        public User GetUserByUsername(string username);
    }
}
