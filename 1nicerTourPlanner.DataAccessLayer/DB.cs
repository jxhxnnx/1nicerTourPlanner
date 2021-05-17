using _1nicerTourPlanner.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace _1nicerTourPlanner.DataAccessLayer
{
    public class DB : IDataAccess
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
            try
            {
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
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

            return logList;
        }

        public void ModifyTour(int tourID, string name, string description, float distance)
        {
            try
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
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }


        }

        public List<Tour> GetTours()
        {
            List<Tour> tourList = new List<Tour>();
            try
            {
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
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

            return tourList;
        }

        public void AddTour(string name, string description, float distance, string start, string destination, string imagepath)
        {
            try
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
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }

        public void DeleteTour(Tour currentTour)
        {
            DeleteLogs(currentTour.TourID);
            try
            {
                con.Open();
                var query = "DELETE FROM public.\"Tours\" WHERE name = @name; ";
                using NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("name", currentTour.Name);
                cmd.Prepare();
                cmd.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }


        }
        public void DeleteLogs(int tourID)
        {
            try
            {
                con.Open();
                var query = "DELETE FROM public.\"Logs\" WHERE tour_id = @tourID; ";
                using NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("tourID", tourID);
                cmd.Prepare();
                cmd.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }

        public void CopyTour(Tour currentTour)
        {
            try
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
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }

        public void AddLog(DateTime date, float distance, float totTime, int tourID, string name, string report, int rating, bool alone, string vehicle, string weather, string traveller, float speed)
        {
            try
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
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }

        public bool NameExists(string name)
        {
            int count = 0;
            try
            {
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

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

            if (count != 0)
            {
                return true;
            }
            return false;
        }
        public void DeleteSingleLog(TourLog tlog)
        {
            try
            {
                con.Open();
                var query = "DELETE FROM public.\"Logs\" WHERE log_id = @logID; ";
                using NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("logID", tlog.logID);
                cmd.Prepare();
                cmd.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }
        public void ModifyLog(TourLog tlog)
        {
            try
            {
                con.Open();
                var query = "UPDATE public.\"Logs\" SET date = @date, distance = @distance, tot_time = @totTime, " +
                    "name = @name, report = @report, rating = @rating, " +
                    "alone = @alone, vehicle = @vehicle, weather = @weather, traveller = @traveller, speed = @speed " +
                    "WHERE log_id = @logID";
                using NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("date", tlog.Date);
                cmd.Parameters.AddWithValue("distance", tlog.Distance);
                cmd.Parameters.AddWithValue("totTime", tlog.TotalTime);
                cmd.Parameters.AddWithValue("name", tlog.Name);
                cmd.Parameters.AddWithValue("report", tlog.Report);
                cmd.Parameters.AddWithValue("rating", tlog.Rating);
                cmd.Parameters.AddWithValue("alone", tlog.Alone);
                cmd.Parameters.AddWithValue("vehicle", tlog.Vehicle);
                cmd.Parameters.AddWithValue("weather", tlog.Weather);
                cmd.Parameters.AddWithValue("traveller", tlog.Traveller);
                cmd.Parameters.AddWithValue("speed", tlog.Speed);
                cmd.Parameters.AddWithValue("logID", tlog.logID);
                cmd.Prepare();
                cmd.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }

        public int GetIDtoName(string name)
        {
            int id = 0;
            try
            {
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
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

            return id;
        }
    }
}
