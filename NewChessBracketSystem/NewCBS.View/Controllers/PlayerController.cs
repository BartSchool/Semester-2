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

    [HttpPost]
    public IActionResult Index(PlayersModel model)
    {
        PlayerCollection playerCollection = new(new AllPlayerData());
        try
        {
            playerCollection.RemovePlayer(model.name);
        }
        catch (Exception e)
        {
            ModelState.AddModelError("remove", "Cant remove player, " + e.Message);
            model.players = playerCollection.GetPlayers();
            return View(model);
        }

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult AddPlayer()
    {
        AddPlayerModel model = new AddPlayerModel();
        return View(model);
    }

    [HttpPost]
    public IActionResult AddPlayer(AddPlayerModel model)
    {
        PlayerCollection playerCollection = new(new AllPlayerData());
        try
        {
            playerCollection.AddPlayer(model.name, model.rating);
        } 
        catch (Exception e)
        {
            ModelState.AddModelError("add", "Cant add player, " + e.Message);
            return View(model);
        }

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult EditPlayer(PlayersModel model)
    {
        EditPlayerModel newModel = new();
        PlayerCollection playerCollection = new(new AllPlayerData());
        Player player = playerCollection.GetPlayer(model.name);
        newModel.name = player.Name;
        newModel.rating = player.Ranking;
        return View(newModel);
    }

    [HttpPost]
    public IActionResult EditPlayer(EditPlayerModel model)
    {
        PlayerCollection playerCollection = new(new AllPlayerData());
        Player player = playerCollection.GetPlayer(model.name);
        playerCollection.EditPlayer(model.name, model.newName, model.newrating);
        return RedirectToAction("Index");
    }
}
