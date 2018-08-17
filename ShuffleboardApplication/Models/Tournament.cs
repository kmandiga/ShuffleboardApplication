using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShuffleboardApplication.Models
{
    public class Tournament
    {
        
        public int TournamentID { get; set; }
        public DateTime DateCreated { get; set; }


        public int numPlayers { get; set; }

        //perhaps validate with previous tournament names
        public string TournamentName { get; set; }

        //validate by sending validation method in controllet the list and the number of players in tournament
        //if any players are repeated in invalidates
        //[Remote("duplicateUsers", "Tournament", AdditionalFields = "numPlayers", HttpMethod = "POST", ErrorMessage = "There must be unique players")]
       
        public virtual List<Player> Players { get; set; }
        public virtual List<Game> Games { get; set; }
    }
}