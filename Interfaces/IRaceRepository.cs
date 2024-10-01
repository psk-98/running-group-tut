using System;
using running_apps.Models;

namespace running_apps.Interfaces;

public interface IRaceRepository
{

    Task<IEnumerable<Race>> GetAllAsync();
    Task<Race> GetByIdAsync(int id);
    Task<IEnumerable<Race>> GetRacesByCityAsync(string city);
    bool Add(Race race);
    bool Update(Race race);
    bool Delete(int id);
    bool Save();
}
