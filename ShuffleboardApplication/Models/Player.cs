using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShuffleboardApplication.Models
{
    public class Player
    {

        public int PlayerID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        public string LastName { get; set; }

        [StringLength(15, MinimumLength = 3)]
        [Remote("UsernameAvailable", "Player", HttpMethod = "POST", ErrorMessage ="Username Already Exists. Please enter another one.")]
        [Required]
        public string Username { get; set; }

        public int gamesPlayed { get; set; }

        public int gamesWon { get; set; }
        
        public int CummulativePoints { get; set; }

        //public List<int> gamesPlayedIn { get; set; }
    }
    
}
