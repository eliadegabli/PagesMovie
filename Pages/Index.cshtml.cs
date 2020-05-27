using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace PagesMovie.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            runQuery();
        }

        public void runQuery()
        {

            string MySqlConnectionString = "datasource=localhost;port=3306;username=user_sms_ins;password='bgQ87as@kf';database=db_sms_ins";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);

            MySqlCommand commandDatabase = new MySqlCommand("select * From Crm_agents", databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                Console.Write("ddddddd");   
                databaseConnection.Open();

                MySqlDataReader MyReader = commandDatabase.ExecuteReader();

                if (MyReader.HasRows)
                {
                    while(MyReader.Read())
                    {
                       // Debug.WriteLine(MyReader.GetString(0) + " - " + MyReader.GetString(1) + " - " + MyReader.GetString(2) + " - " + MyReader.GetString(3) + " - " + MyReader.GetString(4));
                    }
                }
                else
                {
                    Console.WriteLine("Success");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error = " + e.Message);
            }
        }

        public void OnGet()
        {

        }
    }
}
