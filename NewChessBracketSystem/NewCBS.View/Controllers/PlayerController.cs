using Microsoft.AspNetCore.Mvc;
using NewCBS.Core;
using NewCBS.Dal;
using NewCBS.View.Models;

namespace NewCBS.View.Controllers;

public class PlayerController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        PlayersModel model = new PlayersModel();
        PlayerCollection playerCollection = new(new AllPlayerData());

        model.players = playerCollection.GetPlayers();

        return View(model);
    }
}
