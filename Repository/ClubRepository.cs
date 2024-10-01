using System;
using Microsoft.EntityFrameworkCore;
using running_apps.Data;
using running_apps.Interfaces;
using running_apps.Models;

namespace running_apps.Repository;

public class ClubRepository : IClubRepository
{
    private readonly ApplicationDBContext _context;
    public ClubRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public bool Add(Club club)
    {
        _context.Add(club);
        return Save();
    }

    public bool Delete(int id)
    {
        _context.Remove(id);
        return Save();
    }

    public async Task<IEnumerable<Club>> GetAllAsync()
    {
        return await _context.Clubs.ToListAsync();
    }

    public async Task<Club> GetByIdAsync(int id)
    {
        return await _context.Clubs.Include(a => a.Address).FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<IEnumerable<Club>> GetClubByCityAsync(string city)
    {
        return await _context.Clubs.Include(a => a.Address).Where(c => c.Address.City.Contains(city)).ToListAsync();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public bool Update(Club club)
    {
        _context.Update(club);
        return Save();
    }
}
