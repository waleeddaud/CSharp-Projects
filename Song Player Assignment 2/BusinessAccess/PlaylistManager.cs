namespace SongPlayer.BusinessAccess
{
    public class PlaylistManager
    {
        // No data access layer needed for Playlist as its purely inmemory storage.
        private List<Song> AllSongs = new List<Song>();
        private string? PlaylistName;
        private int MaxSongs;

        public void AddMultipleSongs(List<Song> songs)
        {
            
            int totalSongs = AllSongs.Count + songs.Count;
            if (totalSongs > MaxSongs)
            {
                Console.WriteLine($"Cannot add songs. Playlist has already {MaxSongs} songs.");
                return;
            }
            foreach (Song song in songs)
            {
                if (this.AllSongs.Count >= MaxSongs) break;
                this.AllSongs.Add(song);
            }

        }

        public void CreatePlaylist(string name, int maxSongs = 10)
        {
            this.PlaylistName = name;
            this.MaxSongs = maxSongs;
            this.AllSongs = new List<Song>();
        }

        public List<Song> FindSongsByGenre(string genre)
        {
            List<Song> songs = new List<Song>();
            foreach (Song song in this.AllSongs)
            {
                if (song.Genre == genre)
                {
                    songs.Add(song);
                }
            }
            return songs;
        }
        private double GetTotalDuration()
        {
            double total = 0;
            foreach (Song song in AllSongs)
            {
                total += song.Duration;
            }
            return total;
        }
        private int GetLikedSongsCount()
        {
            int count = 0;
            foreach (Song song in AllSongs)
            {
                if (song.IsLiked) count++;
            }
            return count;
        }
        public void GetPlaylistStatistics()
        {
            Console.WriteLine("\n------------Playlist Statistics------------");
            Console.WriteLine($"Playlist Name: {this.PlaylistName}");
            Console.WriteLine("Total Songs: " + this.AllSongs?.Count);
            Console.WriteLine("Total Duration: " + this.GetTotalDuration()+ " minutes");
            Console.WriteLine("Count of Liked Songs: " + this.GetLikedSongsCount());
            Console.WriteLine("-------------------------------------------\n");
        }

    }
}
