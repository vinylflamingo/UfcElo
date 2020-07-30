using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UfcElo.Data.Models;

namespace UfcElo.Data.Services
{
    public interface IFighterData
    {
        IEnumerable<Fighter> GetAll();
        IEnumerable<Fighter> GetAllOrderByEloRating();
        Fighter GetFighter(int id);
        void Add(Fighter fighter);
        void Update(Fighter fighter);
        void Delete(int id);

    }
}
