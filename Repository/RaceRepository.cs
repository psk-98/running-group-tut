using System;
using Microsoft.EntityFrameworkCore;
using running_apps.Data;
using running_apps.Interfaces;
using running_apps.Models;

namespace running_apps.Repository;

public class RaceRepository : IRaceRepository
{
    private readonly ApplicationDBContext _context;
    public RaceRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public bool Add(Race race)
    {
        _context.Add(race);
        return Save();
    }

    public bool Delete(int id)
    {
        _context.Remove(id);
        return Save();
    }

    public async Task<IEnumerable<Race>> GetAllAsync()
    {
        return await _context.Races.ToListAsync();
    }

    public async Task<Race> GetByIdAsync(int id)
    {
        return await _context.Races.Include(a => a.Address).FirstOrDefaultAsync(i => i.Id == id);

    }

    public async Task<IEnumerable<Race>> GetRacesByCityAsync(string city)
    {
        return await _context.Races.Include(a => a.Address).Where(c => c.Address.City.Contains(city)).ToListAsync();

    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public bool Update(Race race)
    {
        _context.Update(race);
        return Save();
    }
}
