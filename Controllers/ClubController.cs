using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using running_apps.Data;
using running_apps.Interfaces;
using running_apps.Models;
using running_apps.ViewModels;

namespace running_apps.Controllers;

public class ClubController : Controller
{
    private readonly IClubRepository _clubRepo;
    private readonly IPhotoService _photoService;
    public ClubController(IClubRepository clubRepo, IPhotoService photoService)
    {
        _clubRepo = clubRepo;
        _photoService = photoService;
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
    public async Task<IActionResult> Create(CreateClubViewModel clubVM)
    {
        if (!ModelState.IsValid)
        {
            var result = await _photoService.UploadPhotoAsync(clubVM.Image);

            var club = new Club
            {
                Title = clubVM.Title,
                Image = result.Url.ToString(),
                Description = clubVM.Description,
                // AddressId = clubVM.AddressId,
                ClubCategory = clubVM.ClubCategory
            };

            _clubRepo.Add(club);
            return RedirectToAction(nameof(Index));


        }
        else ModelState.AddModelError("", "Photo upload failed");

        return View(clubVM);
    }
}

