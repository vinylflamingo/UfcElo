using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UfcElo.Web.Models;

namespace UfcElo.Data.Services
{
    public interface IFighterData
    {
        IEnumerable<Fighter> GetAll();

    }
}
