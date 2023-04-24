using Microsoft.AspNetCore.Mvc;
using NewCBS.Core;
using NewCBS.Dal;
using NewCBS.View.Models;
using System.Reflection;

namespace NewCBS.View.Controllers;

public class PlayerController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        PlayersModel model = new PlayersModel();
        PlayerCollection playerCollection = new(new AllPlayerData());

        if (model.ID > 0)
            playerCollection = new(new PlayerData(model.ID));
        model.players = playerCollection.GetPlayers();

        return View(model);
    }

    public IActionResult Index(AddPlayerModel oldmodel)
    {
        PlayersModel model = new();
        PlayerCollection playerCollection = new(new AllPlayerData());
        
        model.ID = oldmodel.ID;
        if (model.ID > 0)
            playerCollection = new(new PlayerData(model.ID));
        model.players = playerCollection.GetPlayers();

        return View(model);
    }

    [HttpPost]
    public IActionResult Index(PlayersModel model)
    {
        PlayerCollection playerCollection = new(new AllPlayerData());
        
        if (model.ID > 0)
            playerCollection = new(new PlayerData(model.ID));
        model.players = playerCollection.GetPlayers();

        return View(model);
    }

    [HttpGet]
    public IActionResult AddPlayer(PlayersModel oldModel)
    {
        AddPlayerModel model = new AddPlayerModel();
        List<string> allplayers = new PlayerCollection(new AllPlayerData()).GetPlayerNames();
        List<string> players = new PlayerCollection(new PlayerData(oldModel.ID)).GetPlayerNames();

        List<string> temp = new();
        foreach (string player in allplayers)
            if (!players.Contains(player))
                temp.Add(player);

        model.players = temp;
        model.ID = oldModel.ID;
        return View(model);
    }

    [HttpPost]
    public IActionResult AddPlayer(AddPlayerModel model)
    {
        PlayerCollection playerCollection = new(new AllPlayerData());
        if (model.ID > 0)
            playerCollection = new(new PlayerData(model.ID));

        playerCollection.AddPlayer(model.name, model.rating);
        return RedirectToAction("Index", model);
    }
}
