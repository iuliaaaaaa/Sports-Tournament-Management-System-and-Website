using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SynthesisAssignment.Models
{
    [Table("tournaments")]
    public class Tournament
    {
        [Key]
        public int Id { get; set; }
        public string Sport { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int MinNoPlayers { get; set; }
        public int MaxNoPlayers { get; set; }
        public string TournamentSystem { get; set; }


    }
}
