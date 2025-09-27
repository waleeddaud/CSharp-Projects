namespace SongPlayer
{
    public class Song
    {
        public Song(int songId, string title, string artist, double duration, string genre,
            bool isLiked = false, int playCount = 0)
        {
            SongId = songId;
            Title = title;
            Artist = artist;
            Duration = duration;
            Genre = genre;
            IsLiked = isLiked;
            PlayCount = playCount;
        }
        public int SongId { get; set; }  //Primary Key
        public string? Title { get; set; }
        public string? Artist { get; set; }
        public double Duration { get; set; }
        public string? Genre { get; set; }
        public bool IsLiked { get; set; }
        public int PlayCount { get; set; }

        public void PlaySong(){
            this.PlayCount++;
        }
        public override string ToString(){
            return $"Title: {Title}, Artist: {Artist}, Duration: {Duration} mins, Genre: {Genre}, Liked: {IsLiked}, Play Count: {PlayCount}";
        }
        public void DisplaySongInfo()
        {
            Console.WriteLine(this.ToString()); 
        }
        
    }
}

/* Attributes
• SongId (int) 
• Title (string) 
• Artist (string) 
• Duration (double - in minutes) 
• Genre (string) 
• IsLiked (bool) 
• PlayCount (int) 
*/
