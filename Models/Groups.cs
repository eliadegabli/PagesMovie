using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagesMovie.Models
{
    public class Groups
    {
        private ArrayList Group1 { get; set; }
        private ArrayList Group2 { get; set; }
        private ArrayList Group3 { get; set; }


        public void getRandomGRP()
        {

            Group1 = new ArrayList(5);
            Group2 = new ArrayList(5);
            Group3 = new ArrayList(5);

        }
    }

}
