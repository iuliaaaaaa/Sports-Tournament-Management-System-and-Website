using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynthesisAssignment.Models
{
    public static class DatabaseUser
    {
        public static User GetByUser(this DatabaseContext db, string u)
        {
            return db.Users.FirstOrDefault(x => x.Username == u);
        }
    }
}
