using ChessBracketSystem.Core;
using ChessBracketSystem.Dal;
using ChessBracketSystem.View.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChessBracketSystem.View.Controllers
{
    public class TournamentController : Controller
    {
        private TournementCollectionDal _tournementCollection = new();

        public IActionResult Index()
        {
            TournementModel model = new TournementModel();
            model.tournements = new List<Tournement>();
            foreach (Tournement tournement in _tournementCollection.list)
                model.tournements.Add(tournement);
            return View(model);
        }
    }
}
