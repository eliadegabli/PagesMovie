using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagesMovie.Data;
using PagesMovie.Models;
using MySql.Data.MySqlClient;

namespace PagesMovie
{
    public class IndexModel : PageModel
    {
        private readonly PagesMovie.Data.PagesMovieContext _context;
        

        public IndexModel(PagesMovie.Data.PagesMovieContext context)
        {
            _context = context;
            ans = runQuery();
        }

        public string ans="empty";
        public IList<Movie> Movie { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }
        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;
            var movies = from m in _context.Movie
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }

        public string runQuery()
        {
            MySqlCommand commandDataba;
            MySqlDataAdapter datadapter;

            string MySqlConnectionString = "datasource=31.168.252.120;port=3306;username=user_sms_ins;password='bgQ87as@kf';database=db_sms_ins";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);

            MySqlCommand commandDatabase = new MySqlCommand("select * From Crm_agents", databaseConnection); 
            commandDatabase.CommandTimeout = 60;

            try
            {
               ans = "steel empty";
                databaseConnection.Open();

                MySqlDataReader MyReader = commandDatabase.ExecuteReader();

                if (MyReader.HasRows)
                {
                    ans = "steel empty 2";
                    while (MyReader.Read())
                    {
                       ans = (MyReader.GetString(0) + " - " + MyReader.GetString(1) + " - " + MyReader.GetString(2) + " - " + MyReader.GetString(3) + " - " + MyReader.GetString(4));
                    }
                }
                else
                {
                    ans = "steel empty 3";
                }
            }
            catch (Exception e)
            {
                ans = "steel empty - error";
            }
            return ans;
        }
    }
}
