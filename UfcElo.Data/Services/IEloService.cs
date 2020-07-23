using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UfcElo.Data.Services
{
    public interface IEloService
    {
        double ProbabilityOfWin(double FighterElo, double FighterOpponentElo);

        bool CalculateNewElo(int BoutId);
    }
}
