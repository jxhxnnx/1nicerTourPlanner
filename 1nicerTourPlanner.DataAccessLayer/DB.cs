using _1nicerTourPlanner.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace _1nicerTourPlanner.DataAccessLayer
{
    public class DB : IDataAccess
    {
        private string connectionString;
        NpgsqlConnection con;
        public DB()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
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
            var query = "SELECT date, distance, tot_time, rating, name, report, tour_id,  alone, vehicle, weather, traveller, speed, log_id FROM public.\"Logs\" where tour_id = @tourID;";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Parameters.AddWithValue("tourID", tourID);
            cmd.Prepare();
            using NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                logList.Add(new TourLog()
                {
                    Date = reader.GetDateTime(0),
                    Distance = reader.GetFloat(1),
                    TotalTime = reader.GetFloat(2),
                    Rating = reader.GetInt32(3),
                    Name = reader.GetString(4),
                    Report = reader.GetString(5),
                    TourID = reader.GetInt32(6),
                    Alone = reader.GetBoolean(7),
                    Vehicle = reader.GetString(8),
                    Weather = reader.GetString(9),
                    Traveller = reader.GetString(10),
                    Speed = reader.GetFloat(11),
                    logID = reader.GetInt32(12)
                });
            }
            con.Close();
            return logList;
        }

        public void ModifyTour(int tourID, string name, string description, float distance)
        {
            con.Open();
            var query = "UPDATE public.\"Tours\" SET name = @name, description = @description, distance = @ distance WHERE tour_id = @tourID; ";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Parameters.AddWithValue("tourID", tourID);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("description", description);
            cmd.Parameters.AddWithValue("distance", distance);
            cmd.Prepare();
            cmd.ExecuteReader();
            con.Close();
        }

        public List<Tour> GetTours()
        {
            List<Tour> tourList = new List<Tour>();
            con.Open();
            var query = "SELECT name, description, distance, tour_id, start, destination, imagepath FROM public.\"Tours\";";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Prepare();
            using NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tourList.Add(new Tour()
                {
                    Name = reader.GetString(0),
                    Description = reader.GetString(1),
                    Distance = reader.GetInt32(2),
                    TourID = reader.GetInt32(3),
                    Start = reader.GetString(4),
                    Destination = reader.GetString(5),
                    Imagepath = reader.GetString(6)
                });
            }
            con.Close();
            return tourList;
        }

        public void AddTour(string name, string description, float distance, string start, string destination, string imagepath)
        {
            con.Open();
            var query = "INSERT INTO public.\"Tours\"(name, description, distance, start, destination, imagepath) VALUES(@name, @description, @distance, @start, @destination, @imagepath); ";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("description", description);
            cmd.Parameters.AddWithValue("distance", distance);
            cmd.Parameters.AddWithValue("start", start);
            cmd.Parameters.AddWithValue("destination", destination);
            cmd.Parameters.AddWithValue("imagepath", imagepath);
            cmd.Prepare();
            cmd.ExecuteReader();
            con.Close();
        }

        public void DeleteTour(Tour currentTour)
        {
            DeleteLogs(currentTour.TourID);
            con.Open();
            var query = "DELETE FROM public.\"Tours\" WHERE name = @name; ";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Parameters.AddWithValue("name", currentTour.Name);
            cmd.Prepare();
            cmd.ExecuteReader();
            con.Close();
        }
        public void DeleteLogs(int tourID)
        {
            con.Open();
            var query = "DELETE FROM public.\"Logs\" WHERE tour_id = @tourID; ";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Parameters.AddWithValue("tourID", tourID);
            cmd.Prepare();
            cmd.ExecuteReader();
            con.Close();
        }

        public void CopyTour(Tour currentTour)
        {
            string name = currentTour.Name + "-Copy";
            con.Open();
            var query = "INSERT INTO public.\"Tours\"(name, description, distance, start, destination, imagepath) VALUES(@name, @description, @distance, @start, @destination, @imagepath); ";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("description", currentTour.Description);
            cmd.Parameters.AddWithValue("distance", currentTour.Distance);
            cmd.Parameters.AddWithValue("start", currentTour.Start);
            cmd.Parameters.AddWithValue("destination", currentTour.Destination);
            cmd.Parameters.AddWithValue("imagepath", currentTour.Imagepath);
            cmd.Prepare();
            cmd.ExecuteReader();
            con.Close();
        }

        public void AddLog(DateTime date, float distance, float totTime, int tourID, string name, string report, int rating, bool alone, string vehicle, string weather, string traveller, float speed)
        {
            con.Open();
            var query = "INSERT INTO public.\"Logs\"(date, distance, tot_time, tour_id, name, report, rating, alone, vehicle, weather, traveller, speed) " +
                "VALUES(@date, @distance, @totTime, @tourID, @name, @report, @rating, @alone, @vehicle, @weather, @traveller, @speed); ";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Parameters.AddWithValue("date", date);
            cmd.Parameters.AddWithValue("distance", distance);
            cmd.Parameters.AddWithValue("totTime", totTime);
            cmd.Parameters.AddWithValue("tourID", tourID);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("report", report);
            cmd.Parameters.AddWithValue("rating", rating);
            cmd.Parameters.AddWithValue("alone", alone);
            cmd.Parameters.AddWithValue("vehicle", vehicle);
            cmd.Parameters.AddWithValue("weather", weather);
            cmd.Parameters.AddWithValue("traveller", traveller);
            cmd.Parameters.AddWithValue("speed", speed);
            cmd.Prepare();
            cmd.ExecuteReader();
            con.Close();
        }

        public bool NameExists(string name)
        {
            int count = 0;
            con.Open();
            var query = "SELECT count(*) FROM public.\"Tours\" where name = @name;";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Prepare();
            using NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }
            con.Close();
            if (count != 0)
            {
                return true;
            }
            return false;
        }
        public void DeleteSingleLog(TourLog log)
        {
            con.Open();
            var query = "DELETE FROM public.\"Logs\" WHERE log_id = @logID; ";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Parameters.AddWithValue("logID", log.logID);
            cmd.Prepare();
            cmd.ExecuteReader();
            con.Close();
        }
        public void ModifyLog(TourLog log)
        {
            con.Open();
            var query = "UPDATE public.\"Logs\" SET date = @date, distance = @distance, tot_time = @totTime, " +
                "name = @name, report = @report, rating = @rating, " +
                "alone = @alone, vehicle = @vehicle, weather = @weather, traveller = @traveller, speed = @speed " +
                "WHERE log_id = @logID";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Parameters.AddWithValue("date", log.Date);
            cmd.Parameters.AddWithValue("distance", log.Distance);
            cmd.Parameters.AddWithValue("totTime", log.TotalTime);
            cmd.Parameters.AddWithValue("name", log.Name);
            cmd.Parameters.AddWithValue("report", log.Report);
            cmd.Parameters.AddWithValue("rating", log.Rating);
            cmd.Parameters.AddWithValue("alone", log.Alone);
            cmd.Parameters.AddWithValue("vehicle", log.Vehicle);
            cmd.Parameters.AddWithValue("weather", log.Weather);
            cmd.Parameters.AddWithValue("traveller", log.Traveller);
            cmd.Parameters.AddWithValue("speed", log.Speed);
            cmd.Parameters.AddWithValue("logID", log.logID);
            cmd.Prepare();
            cmd.ExecuteReader();
            con.Close();
        }

        public int GetIDtoName(string name)
        {
            int id = 0;
            con.Open();
            var query = "SELECT tour_id FROM public.\"Tours\" where name = @name;";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Prepare();
            using NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = reader.GetInt32(0);
            }
            con.Close();
            return id;
        }
    }
}
