using _1nicerTourPlanner.Models;
using System;
using System.Collections.Generic;
using Npgsql;

namespace _1nicerTourPlanner.DataAccessLayer
{
    public class DB : IDataAccess
    {
        private string connectionString;
        public DB()
        {

            //get connection data e.g. from config file
            connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=passwort;Database=TourPlanner;";
            //GetConnection(connectionString);
        }
        private static NpgsqlConnection GetConnection(string connectionString)
        {
            return new NpgsqlConnection(@connectionString);
        }
        public List<TourLog> GetLogs()
        {
            //select SQL query


            return new List<TourLog>()
            {
                new TourLog(){Name = "Log1"},
                new TourLog(){Name = "Log2"},
                new TourLog(){Name = "Log3"},
                new TourLog(){Name = "Log4"},
                new TourLog(){Name = "Log5"}
            };
        }

        public List<Tour> GetTours()
        {
            List<Tour> tourList = new List<Tour>();
            
            using NpgsqlConnection con = GetConnection(connectionString);
            con.Open();
            var query = "SELECT name, description, distance, tour_id FROM public.\"Tours\";";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Prepare();
            using NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tourList.Add(new Tour(){Name = reader.GetString(0), 
                                        Description = reader.GetString(1), 
                                        Distance = reader.GetInt32(2) });
            }
            con.Close();

            return tourList;  
        }
    }
}
