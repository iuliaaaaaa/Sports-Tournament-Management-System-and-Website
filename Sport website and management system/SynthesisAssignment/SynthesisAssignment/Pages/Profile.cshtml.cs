using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SynthesisAssignment.Models;

namespace SynthesisAssignment.Pages
{
    [Authorize(Roles = "staff, player, spectator")]
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public User ReadOnlyUser { get; set; }

        private DatabaseContext _db;

        public ProfileModel(DatabaseContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            ReadOnlyUser = _db.GetByUser(DatabaseContext.LoggedInUsername);
        }
    }
}
