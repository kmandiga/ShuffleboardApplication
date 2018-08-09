using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShuffleboardApplication.Models
{
    public class Tournament
    {
        public int TournamentID { get; set; }
        public DateTime DateCreated { get; set; }
        public string TournamentName { get; set; }
        public List<Player> PlayersInTournament { get; set; }
        public List<Game> GamesInTournament { get; set; }
    }
}