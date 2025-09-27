using SongPlayer.DataAccess;
namespace SongPlayer.BusinessAccess
{
    public class MusicDatabase
    {
        private MusicDatabaseDAL DAL = new MusicDatabaseDAL();
        public void InsertSong(Song song)
        {
            DAL.AddSong(song);
        }
        public void InsertMultipleSongs(List<Song> songs)
        {
            foreach (Song song in songs)
            {
                DAL.AddSong(song);
            }
        }
        public List<Song> GetAllSongs()
        {
            return DAL.GetAllSongs();
        }
        public int GetSongCount()
        {
            return DAL.GetSongCount();
        }
        public List<Song> GetSongsByID(int id)
        {
            return DAL.GetSongsByID(id);
        }

    }
}