using System;
using SongPlayer.BusinessAccess;

namespace SongPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Song> newSongs = new List<Song>();
            PlaylistManager playlist = new PlaylistManager();
            
            while (true)
            {
                Console.WriteLine("\nMusic Library Menu");
                Console.WriteLine("1. Create Songs (Add at least 5 songs)");
                Console.WriteLine("2. Display All Songs");
                Console.WriteLine("3. Save Songs to Text File");
                Console.WriteLine("4. Load Songs from Text File");
                Console.WriteLine("5. Insert Songs into Database");
                Console.WriteLine("6. Display All Songs from Database");
                Console.WriteLine("7. Get Song by ID (Database)");
                Console.WriteLine("8. Get Total Song Count (Database)");
                Console.WriteLine("9. Create Playlist");
                Console.WriteLine("10. Display Playlist Statistics");
                Console.WriteLine("11. Find Songs by Genre");
                Console.WriteLine("12. Play a Song (Increase PlayCount)");
                Console.WriteLine("13. Exit");
                Console.Write("Choose an option: ");
                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine() ?? "13");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid input. Please enter a number between 1 and 13. Error: {ex.Message}");
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("No. of songs to add: (default 5)");
                            int n = int.Parse(Console.ReadLine() ?? "5");
                            for (int i = 0; i < n; i++)
                            {
                                Console.WriteLine($"\nEnter details for song {i + 1}:");
                                Console.Write("Title: ");
                                string title = Console.ReadLine() ?? "";
                                Console.Write("Artist: ");
                                string artist = Console.ReadLine() ?? "";
                                Console.Write("Duration (in minutes): ");
                                double duration = double.Parse(Console.ReadLine() ?? "0");
                                Console.Write("Genre: ");
                                string genre = Console.ReadLine() ?? "";
                                Console.Write("Is Liked (true/false): ");
                                bool isLiked = bool.Parse(Console.ReadLine() ?? "false");
                                Console.Write("Play Count: ");
                                int playCount = int.Parse(Console.ReadLine() ?? "0");
                                newSongs.Add(new Song(0, title, artist, duration, genre, isLiked, playCount));
                            }
                            break;

                        case 2:
                            foreach (var song in newSongs)
                            {
                                song.DisplaySongInfo();
                            }
                            break;

                        case 3:
                            // Save songs to file
                            FileManager fmSave = new FileManager();
                            fmSave.SaveSongsToText(newSongs);
                            Console.WriteLine("Songs saved to songs.txt");
                            break;

                        case 4:
                            // Load songs from file
                            newSongs.Clear();
                            FileManager fmLoad = new FileManager();
                            newSongs = fmLoad.LoadSongsFromText();
                            Console.WriteLine("Songs loaded successfullt from songs.txt to memory");
                            break;

                        case 5:
                            // Insert songs to DB
                            Console.WriteLine($"Size  {newSongs.Count}");
                            MusicDatabase musicDB = new MusicDatabase();
                            musicDB.InsertMultipleSongs(newSongs);
                            Console.WriteLine("Songs inserted into database.");
                            break;
                        case 6:
                            // Display all songs from DB
                            Console.WriteLine("All songs in the database:");
                            MusicDatabase musicDisplayDb = new MusicDatabase();
                            List<Song> songsDB = musicDisplayDb.GetAllSongs();
                            foreach (var song in songsDB)
                            {
                                song.DisplaySongInfo();
                            }
                            break;
                        case 7:
                            Console.WriteLine("Enter SongId to fetch:");
                            int id = int.Parse(Console.ReadLine() ?? "0");
                            MusicDatabase musicByIdDb = new MusicDatabase();
                            List<Song> songsById = musicByIdDb.GetSongsByID(id);
                            if (songsById.Count == 0)
                            {
                                Console.WriteLine("No song found with that ID.");
                            }
                            else
                            {
                                foreach (var song in songsById)
                                {
                                    song.DisplaySongInfo();
                                }
                            }
                            break;
                        case 8:
                            int count = new MusicDatabase().GetSongCount();
                            Console.WriteLine($"Total songs in database: {count}");
                            break;
                        case 9:
                            Console.WriteLine("Enter Playlist Name:");
                            string playlistName = Console.ReadLine() ?? "MyPlaylist";
                            Console.WriteLine("Enter Max Songs in Playlist (default 10):");
                            int maxSongs = int.Parse(Console.ReadLine() ?? "10");
                            playlist.CreatePlaylist(playlistName, maxSongs);
                            playlist.AddMultipleSongs(newSongs);
                            break;
                        case 10:
                            playlist.GetPlaylistStatistics();
                            break;
                        case 11:
                            Console.WriteLine("Enter Genre to search:");
                            string genreSearch = Console.ReadLine() ?? "";
                            List<Song> genreSongs = playlist.FindSongsByGenre(genreSearch);
                            if (genreSongs.Count == 0)
                            {
                                Console.WriteLine("No songs found for that genre.");
                            }
                            else
                            {
                                foreach (var song in genreSongs)
                                {
                                    song.DisplaySongInfo();
                                }
                            }
                            break;
                        case 12:
                            Console.WriteLine("Plays all the songs in memory");
                            foreach (var song in newSongs)
                            {
                                song.PlaySong();
                                song.DisplaySongInfo();
                            }
                            break;
                        case 13:
                            Console.WriteLine("Exiting Music Library!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
