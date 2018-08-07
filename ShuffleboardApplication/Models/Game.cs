using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShuffleboardApplication.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public DateTime Date { get; set; }

        [Required]
        public string P1 { get; set; }

        [Required]
        public string P2 { get; set; }

        [Range(0,70)]
        [Required]
        public int P1Score { get; set; }

        [Range(0, 70)]
        [Required]
        public int P2Score { get; set; }

        public int margin { get; set; }

        //public ICollection<Game> PlayersInGame { get; set; }

    }
}