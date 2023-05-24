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
            model.tournement = new Tournement(new TournementDal(model.Id), new BracketDal(model.Id));
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
            Tournement tournement = new(new TournementDal(oldModel.ID), new BracketDal(oldModel.ID));
            TournementsModel model = new();
            try
            {
                model.ID = oldModel.ID;
                tournement.AddPlayer(oldModel.name);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("add", "Cant add player, " + e.Message);
                oldModel.players = new PlayerCollection(new AllPlayerData()).GetPlayerNames();
                return View(oldModel);
            }
            return RedirectToAction("index", model);
        }

        [HttpGet]
        public IActionResult InvitePlayer(TournementModel oldModel)
        {
            AddPlayerModel model = new AddPlayerModel();
            model.ID = oldModel.Id;
            model.players = new PlayerCollection(new AllPlayerData()).GetPlayerNames();
            return View(model);
        }

        [HttpPost]
        public IActionResult InvitePlayer(AddPlayerModel oldModel)
        {
            Tournement tournement = new(new TournementDal(oldModel.ID), new BracketDal(oldModel.ID));
            TournementsModel model = new();
            try
            {
                tournement.InvitePlayer(oldModel.name);
                model.ID = oldModel.ID;
            } 
            catch (Exception e)
            {
                ModelState.AddModelError("invite", "Cant invite player, " + e.Message);
                oldModel.players = new PlayerCollection(new AllPlayerData()).GetPlayerNames();
                return View(oldModel);
            }
            return RedirectToAction("index", model);
        }

        [HttpPost]
        public IActionResult RemovePlayer(TournementModel model)
        {
            model.tournement = new Tournement(new TournementDal(model.Id), new BracketDal(model.Id));
            model.tournement.RemovePlayer(model.removeName);
            return RedirectToAction("index", model);
        }

        [HttpPost]
        public IActionResult UnInvitePlayer(TournementModel model)
        {
            model.tournement = new Tournement(new TournementDal(model.Id), new BracketDal(model.Id));
            model.tournement.UnInvitePlayer(model.removeName);
            return RedirectToAction("index", model);
        }

        [HttpPost]
        public IActionResult MakeMatches(TournementModel model)
        {
            model.tournement = new Tournement(new TournementDal(model.Id), new BracketDal(model.Id));
            model.tournement.Bracket.CreateMatches(new (model.tournement.Players));

            return RedirectToAction("index", model);
        }
    }
}
