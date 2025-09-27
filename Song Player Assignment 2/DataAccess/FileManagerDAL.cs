using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace SongPlayer.DataAccess
{
    public class FileManagerDAL
    {
        public void SaveSongs(List<Song> songs, string filepath = "songs.txt")
        {
            FileStream fs = new FileStream(filepath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            foreach (Song song in songs)
            {
                string data = JsonSerializer.Serialize(song);
                sw.WriteLine(data);
            }
            sw.Close();
            fs.Close();
        }
        public List<Song> LoadSongs(string filepath = "songs.txt")
        {
            if (!File.Exists(filepath))
                return new List<Song>();
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            List<Song> songs = new List<Song>();
            string? line;
            while ( (line = sr.ReadLine() ) != null ){
                Song? song = JsonSerializer.Deserialize<Song>(line);
                if (song != null)
                {
                    songs.Add(song);      
                }
            }
            sr.Close();
            fs.Close();
            return songs;
        }

    }
}