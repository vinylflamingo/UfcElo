using System;
using UfcElo.Data.Models;

namespace UfcElo.Data.Services
{
    public interface IEloService
    {
        (Fighter RedFighter, Fighter BlueFighter) CalculateNewElo((Fighter RedFighter, Fighter BlueFighter) fighters, Bout bout);
        (Fighter RedFighter, Fighter BlueFighter) FindFighterByBoutId(int BoutId);
        double ProbabilityOfWin(double FighterElo, double FighterOpponentElo);
        bool UpdateNewElo((Fighter, Fighter) fighters);
    }
}