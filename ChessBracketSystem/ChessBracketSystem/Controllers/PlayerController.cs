using ChessBracketSystem.Core;
using ChessBracketSystem.Dal;
using ChessBracketSystem.View.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChessBracketSystem.View.Controllers
{
    public class PlayerController : Controller
    {
        private PlayerCollectionDal PlayerDal = new PlayerCollectionDal();

        public IActionResult Index()
        {
            PlayerModel model = new PlayerModel();
            model.Players = PlayerDal.GetPlayers();
            return View(model);
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
            Player player = new(model.ID, model.name, model.rating);
            PlayerDal.Add(player);
            return RedirectToAction("AddPlayer");
        }

        [HttpPost]
        public IActionResult RemovePlayer(PlayerModel model)
        {
            Player player = new(model.RemoveID, model.RemoveName, model.RemoveRating);
            PlayerDal.Remove(player);
            return RedirectToAction("Index");
        }
    }
}
