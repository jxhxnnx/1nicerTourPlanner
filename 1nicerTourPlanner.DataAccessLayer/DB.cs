using _1nicerTourPlanner.Models;
using System;
using System.Collections.Generic;
using Npgsql;
using Newtonsoft.Json.Linq;
using System.IO;

namespace _1nicerTourPlanner.DataAccessLayer
{
    public class DB : IDataAccess
    {
        private string connectionString;
        NpgsqlConnection con;
        public DB()
        {
            //get connection string from json
            connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=passwort;Database=TourPlanner;";
            con = GetConnection(connectionString);
        }
        private static NpgsqlConnection GetConnection(string connectionString)
        {
            return new NpgsqlConnection(@connectionString);
        }
        public List<TourLog> GetLogs(int tourID)
        {
            List<TourLog> logList = new List<TourLog>();
            con.Open();
            var query = "SELECT date, distance, tot_time, rating, name, report, tour_id FROM public.\"Logs\" where tour_id = @tourID;";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Parameters.AddWithValue("tourID", tourID);
            cmd.Prepare();
            using NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                logList.Add(new TourLog()
                {
                    Date = reader.GetDateTime(0),
                    Distance = reader.GetInt32(1),
                    TotalTime = reader.GetInt32(2),
                    Rating = reader.GetInt32(3),
                    Name = reader.GetString(4),
                    Report = reader.GetString(5),
                    TourID = reader.GetInt32(6)
                });
            }
            con.Close();
            return logList;
        }

        public List<Tour> GetTours()
        {
            List<Tour> tourList = new List<Tour>();
            con.Open();
            var query = "SELECT name, description, distance, tour_id FROM public.\"Tours\";";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Prepare();
            using NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tourList.Add(new Tour(){Name = reader.GetString(0), 
                                        Description = reader.GetString(1), 
                                        Distance = reader.GetInt32(2), 
                                        TourID = reader.GetInt32(3)});
            }
            con.Close();
            return tourList;  
        }

        public void AddTour(string name, string description, float distance)
        {
            con.Open();
            var query = "INSERT INTO public.\"Tours\"(name, description, distance) VALUES(@name, @description, @distance); ";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("description", description);
            cmd.Parameters.AddWithValue("distance", distance);
            cmd.Prepare();
            cmd.ExecuteReader();
            con.Close();
        }

        public void DeleteTour(Tour currentTour)
        {
            con.Open();
            var query = "DELETE FROM public.\"Tours\" WHERE name = @name; ";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Parameters.AddWithValue("name", currentTour.Name);
            cmd.Prepare();
            cmd.ExecuteReader();
            con.Close();
        }
    }
}
