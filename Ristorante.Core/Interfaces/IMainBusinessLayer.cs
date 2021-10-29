using Ristorante.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Core.Interfaces
{
    public interface IMainBusinessLayer
    {
        #region Menu
        IEnumerable<Menu> FetchMenus(Func<Menu, bool> filter = null);
        Menu GetMenuById(int id);
        ResultBL CreateMenu(Menu newMenu);
        ResultBL EditMenu(Menu modifiedMenu);

        #endregion

        #region Piatto
        IEnumerable<Piatto> FetchPiatti(Func<Piatto, bool> filter = null);
        Piatto GetPiattoById(int id);
        ResultBL CreatePiatto(Piatto newPiatto);
        ResultBL EditPiatto(Piatto modifiedPiatto);
        ResultBL DeletePiatto(int id);

        #endregion

        #region User

        User GetUserByUsername(string username);
        User GetUserById(int id);

        #endregion

    }
}
