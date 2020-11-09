using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PagesMovie.Data;
using PagesMovie.Models;


namespace PagesMovie.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly PagesMovie.Data.PagePlayerContext _context;
        public int numofii;

        public IndexModel(PagesMovie.Data.PagePlayerContext context)
        {
            _context = context;
            numofii = _context.Player.Sum(d => d.inGame);
        }

        public IList<Player> Player { get;set; }

        public async Task OnGetAsync()
        {
            Player = await _context.Player.ToListAsync();
            
        }
    }
}
