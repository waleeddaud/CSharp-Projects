using System;
using System.Collections.Generic;
using Npgsql;
// Note 
// I have used postgres as my Database due to space constraints on my system I was unable to run microsoft sql server, changes are very minimal to what Sir taught in Class
namespace SongPlayer.DataAccess
{
    public class MusicDatabaseDAL
    {
        private string connectionString = "Host=localhost;Port=5432;Database=Songs;Username=postgres;Password=hihello";
        public void AddSong(Song song)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            string query =
    $"INSERT INTO Songs (Title, Artist, Duration, Genre, IsLiked, PlayCount) " +
    $"VALUES ('{song.Title}', '{song.Artist}', {song.Duration}, '{song.Genre}', {song.IsLiked.ToString().ToLower()}, {song.PlayCount});";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Console.WriteLine($"Song '{song.Title}' added to database.");
        }

        public List<Song> GetAllSongs()
        {
            List<Song> songs = new List<Song>();
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            string query = "SELECT * FROM Songs ORDER BY SongId";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            conn.Open();
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                songs.Add(new Song
                (
                    Convert.ToInt32(reader["SongId"]),
                    reader["Title"]?.ToString() ?? "",
                    reader["Artist"]?.ToString() ?? "",
                    Convert.ToDouble(reader["Duration"]),
                    reader["Genre"]?.ToString() ?? "",
                    Convert.ToBoolean(reader["IsLiked"]),
                    Convert.ToInt32(reader["PlayCount"])
                ));
            }
            conn.Close();

            return songs;
        }

        public int GetSongCount()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            string query = "SELECT Count(*) FROM Songs";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            conn.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return count;
        }

        public List<Song> GetSongsByID(int id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            string query = $"SELECT * FROM Songs where SongId = {id}";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            conn.Open();
            List<Song> songs = new List<Song>();
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                songs.Add(new Song
                (
                    Convert.ToInt32(reader["SongId"]),
                    reader["Title"]?.ToString() ?? "",
                    reader["Artist"]?.ToString() ?? "",
                    Convert.ToDouble(reader["Duration"]),
                    reader["Genre"]?.ToString() ?? "",
                    Convert.ToBoolean(reader["IsLiked"]),
                    Convert.ToInt32(reader["PlayCount"])
                ));
            }
            conn.Close();

            return songs;
        }
    }
}