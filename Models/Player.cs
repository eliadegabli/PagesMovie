using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PagesMovie.Models
{
    public class Player
    {
        [Display(Name = "מספר פלאפון")]
        public int ID { get; set; }

        [Display(Name = "שם השחקן")]
        public string playerName { get; set; }

        [Display(Name = "משתתף במשחק")]
        public int inGame { get; set; }

        [Display(Name = "רמה")]
        public int Rating { get; set; }

        public static int numOfInGame = 0;


    }
}
