using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SynthesisAssignment.DataAccess;
using SynthesisAssignment.Models;

namespace SynthesisAssignment.Pages
{
    //[Authorize(Roles = "staff, player, spectator")]
    public class TournamentsModel : PageModel
    {

        public List<Tournament> Tournaments { get; set; }

        private DatabaseContext _db;

        public TournamentsModel(DatabaseContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Tournaments = _db.tournaments.ToList();
        }

        //[Authorize(Roles = "staff, player, spectator")]
        //public IActionResult OnPostSignUp()
        //{
        //    TournamentSystem.SignUpUser(User.Identity.Name, );
        //}
    }
}
