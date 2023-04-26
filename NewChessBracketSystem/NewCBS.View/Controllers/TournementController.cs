using Microsoft.AspNetCore.Mvc;
using NewCBS.Core;
using NewCBS.Dal;
using NewCBS.View.Models;

namespace NewCBS.View.Controllers
{
    public class TournementController : Controller
    {
        public IActionResult Index(TournementsModel oldModel)
        {
            TournementModel model = new TournementModel();
            model.Id = oldModel.ID;
            model.tournement = new Tournement(new TournementDal(model.Id));
            return View(model);
        }

        [HttpGet]
        public IActionResult AddPlayer(TournementModel oldModel)
        {
            AddPlayerModel model = new AddPlayerModel();
            model.ID = oldModel.Id;
            model.players = new PlayerCollection(new AllPlayerData()).GetPlayerNames();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddPlayer(AddPlayerModel oldModel)
        {
            Tournement tournement = new(new TournementDal(oldModel.ID));
            tournement.AddPlayer(oldModel.name);
            TournementsModel model = new();
            model.ID = oldModel.ID;
            return RedirectToAction("index", model);
        }
    }
}
