using Microsoft.AspNetCore.Mvc;
using NewCBS.Core;
using NewCBS.Core.Interfaces;
using NewCBS.Dal;
using NewCBS.View.Models;

namespace NewCBS.View.Controllers
{
    public class TournementsController : Controller
    {
        IAllTournementDal _tournements = new AllTournementDal();

        public IActionResult Index()
        {
            TournementsModel model = new TournementsModel();
            model.Tournementnames = _tournements.GetAllTournementNames();
            model.MaxPlayers = new();
            model.StartTimes = new();
            model.Ids = new();
            foreach (string name in model.Tournementnames)
            {
                model.MaxPlayers.Add(_tournements.GetTournementMaxPlayers(name));
                model.StartTimes.Add(_tournements.GetTournementStartTime(name));
                model.Ids.Add(_tournements.GetTournementID(name));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult AddTournement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTournement(AddTournementModel model)
        {
            _tournements.AddTournement(model.Name, model.StartTime, model.isOpen, model.MaxPlayers, model.bracketType);
            return RedirectToAction("Index");
        }
    }
}
