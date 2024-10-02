using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using running_apps.Data;
using running_apps.Interfaces;
using running_apps.Models;

namespace running_apps.Controllers;

public class RaceController : Controller
{
    private readonly IRaceRepository _raceRepo;
    public RaceController(IRaceRepository raceRepo)
    {
        _raceRepo = raceRepo;
    }
    // GET: RaceController
    public async Task<ActionResult> Index()
    {
        var races = await _raceRepo.GetAllAsync();

        return View(races);
    }

    public async Task<IActionResult> Detail(int id)
    {
        Race race = await _raceRepo.GetByIdAsync(id);

        return View(race);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Race race)
    {
        if (!ModelState.IsValid) return View(race);

        _raceRepo.Add(race);

        return RedirectToAction(nameof(Index));
    }
}

