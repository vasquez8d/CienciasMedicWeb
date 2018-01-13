using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sol_CienciasMedicWeb.Models;

namespace Sol_CienciasMedicWeb.Logic
{
    public class TallerLogic
    {
        private readonly DB_A27E8E_norman8dEntities _context = new DB_A27E8E_norman8dEntities();
        public List<TBL08_TALLERES> GetTalleres()
        {
            return (from u in _context.TBL08_TALLERES select u).ToList();
        }
    }
}