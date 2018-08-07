using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShuffleboardApplication.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public DateTime Date { get; set; }
        public string P1 { get; set; }
        public string P2 { get; set; }
        public int P1Score { get; set; }
        public int P2Score { get; set; }

   
        
        //public ICollection<Game> PlayersInGame { get; set; }

    }
}