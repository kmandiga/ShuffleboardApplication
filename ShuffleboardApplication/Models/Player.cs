using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShuffleboardApplication.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public int gamesPlayed { get; set; }

        public int gamesWon { get; set; }
        
        public int CummulativePoints { get; set; }
    }
}
