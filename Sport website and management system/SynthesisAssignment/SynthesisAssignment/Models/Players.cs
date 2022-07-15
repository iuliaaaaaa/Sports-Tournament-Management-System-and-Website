using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SynthesisAssignment.Models
{
    [Table("players")]
    public class Players
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }

    }
}
