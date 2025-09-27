using SongPlayer.DataAccess;
namespace SongPlayer.BusinessAccess
{
    public class FileManager
    {
        private FileManagerDAL DAL = new FileManagerDAL();
        public void SaveSongsToText(List<Song> songs, string filepath = "songs.txt")
        {
            DAL.SaveSongs(songs, filepath);
        }
        public List<Song> LoadSongsFromText(string filepath = "songs.txt")
        {
            return DAL.LoadSongs(filepath);
         }
        
    }

}