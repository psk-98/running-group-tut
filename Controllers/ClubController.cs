using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using running_apps.Data;
using running_apps.Interfaces;
using running_apps.Models;

namespace running_apps.Controllers;

public class ClubController : Controller
{
    private readonly IClubRepository _clubRepo;
    public ClubController(IClubRepository clubRepo)
    {
        _clubRepo = clubRepo;
    }

    // GET: ClubController
    public async Task<IActionResult> Index()
    {
        var clubs = await _clubRepo.GetAllAsync();

        return View(clubs);
    }

    public async Task<IActionResult> Detail(int id)
    {
        Club club = await _clubRepo.GetByIdAsync(id);

        return View(club);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Club club)
    {
        if (!ModelState.IsValid) return View(club);

        _clubRepo.Add(club);
        return RedirectToAction(nameof(Index));
    }
}

