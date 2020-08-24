using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PagesMovie.Models;
using Ubiety.Dns.Core.Records;

namespace PagesMovie.Pages.Players
{
    public class ShuffleModel : PageModel
    {
        private readonly PagesMovie.Data.PagePlayerContext _context;
		public ArrayList Group1 { get; set; }
		public ArrayList Group2 { get; set; }
		public ArrayList Group3 { get; set; }

		public Random r = new Random();
		public ShuffleModel(Data.PagePlayerContext context)
        {
            _context = context;

		}

        public IList<Player> Player { get; set; }
       

        public async Task OnGetAsync()
        {
            Player = await _context.Player.ToListAsync();

			getRandomGRP();
			
			
		}

		public void getRandomGRP()
		{
				ArrayList level = new ArrayList();
				Group1 = new ArrayList();
				Group2 = new ArrayList();
				Group3 = new ArrayList();
				int random;
				
				for (int i = 0; i < 5; i++)
				{
					level = getLevel((i + 1), Player);
					random = (int)(r.Next(0,3));
					Group1.Add(level[random]);
					level.RemoveAt(random);
					random = (int)(r.Next(0, 2));
					Group2.Add(level[random]);
					level.RemoveAt(random);
					Group3.Add(level[0]);
					level = new ArrayList();
			}

				shuffleArray(Group1);
				shuffleArray(Group2);
				shuffleArray(Group3);
			

		}


		public ArrayList getLevel(int num, IList<Player> group)
		{
			ArrayList levelTemp = new ArrayList();
			int s = 0;
			for (int i = 0; i < group.Count; i++)
			{
				if (group[i].Rating == num)
				{
					if (group[i].inGame == 1)
					{
						levelTemp.Add(group[i].playerName);
						//Player.RemoveAt(i);
						s++;
					}

				}
			}
			return levelTemp;
		}

		public ArrayList shuffleArray(ArrayList ar)
		{
			// If running on Java 6 or older, use `new Random()` on RHS here
			int index = 0;

			for (int i = ar.Count - 1; i > 0; i--)
			{
				index = (int)(r.Next(0, i+1));

				// Simple swap
				String a = (String)ar[index];
				ar[index] = (ar[i]);
				ar[i] = a;
			}

			return ar;
		}

	}
}

