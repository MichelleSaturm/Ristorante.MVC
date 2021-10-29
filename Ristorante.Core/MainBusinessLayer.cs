using Ristorante.Core.Interfaces;
using Ristorante.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Core
{
    public class MainBusinessLayer : IMainBusinessLayer
    {

        private readonly IRepositoryMenu repoMenu;
        private readonly IRepositoryPiatto repoPiatto;
        private readonly IRepositoryUser repoUser;

        public MainBusinessLayer(IRepositoryMenu repoMenu, IRepositoryPiatto repoPiatto, IRepositoryUser repoUser)
        {
            this.repoMenu = repoMenu;
            this.repoPiatto = repoPiatto;
            this.repoUser = repoUser;
        }


        #region Menu
        public IEnumerable<Menu> FetchMenus(Func<Menu, bool> filter = null)
        {
            return this.repoMenu.Fetch(filter);
        }

        public Menu GetMenuById(int id)
        {
            if (id <= 0)
                return null;
            return this.repoMenu.GetById(id);
        }

        public ResultBL CreateMenu(Menu newMenu)
        {
            if (newMenu == null)
                return new ResultBL(false, "Invalid Menu Data!");
            var result = repoMenu.AddItem(newMenu);

            return new ResultBL(result, result ? "Done!" : "Error! Something went wrong!");
        }

        public ResultBL EditMenu(Menu modifiedMenu)
        {
            if (modifiedMenu == null)
                return new ResultBL(false, "Invalid Menu Data!");
            var result = repoMenu.UpdateItem(modifiedMenu);

            return new ResultBL(result, result ? "Done!" : "Error! Something went wrong!");
        }

        
        #endregion

        #region Piatto
        public IEnumerable<Piatto> FetchPiatti(Func<Piatto, bool> filter = null)
        {
            return this.repoPiatto.Fetch(filter);
        }

        public Piatto GetPiattoById(int id)
        {
            if (id <= 0)
                return null;
            return this.repoPiatto.GetById(id);
        }

        
        public ResultBL CreatePiatto(Piatto newPiatto)
        {
            if (newPiatto == null)
                return new ResultBL(false, "Invalid Menu Data!");
            var result = repoPiatto.AddItem(newPiatto);

            return new ResultBL(result, result ? "Done!" : "Error! Something went wrong!");
        }

        public ResultBL EditPiatto(Piatto modifiedPiatto)
        {
            if (modifiedPiatto == null)
                return new ResultBL(false, "Invalid Menu Data!");
            var result = repoPiatto.UpdateItem(modifiedPiatto);

            return new ResultBL(result, result ? "Done!" : "Error! Something went wrong!");
        }

        public ResultBL DeletePiatto(int id)
        {
            if (id <= 0)
                return new ResultBL(false, "Invalid ID");

            var result = repoPiatto.DeleteItem(id);

            return new ResultBL(result, result ? "Done!" : "Error! Something went wrong!");
        }


        #endregion

        #region User

        public User GetUserByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                return null;
            return repoUser.GetUserByUsername(username);
        }

        public User GetUserById(int id)
        {
            if (id <= 0)
                return null;
            return this.repoUser.GetById(id);
        }
        #endregion
    }
}
