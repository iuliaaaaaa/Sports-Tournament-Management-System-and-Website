using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SynthesisAssignment.Models;

namespace SynthesisAssignment.Pages.Shared
{
    //[Authorize(Roles = "staff, player, spectator")]
    public class PlayersModel : PageModel
    {
        public List<Players> Players { get; set; }

        private DatabaseContext _db;

        public PlayersModel(DatabaseContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Players = _db.players.ToList();
        }
    }
}
