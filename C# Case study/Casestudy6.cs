using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsHubPortal
{
    // Song Class
    public class Song
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public string SongGenre { get; set; }
    }

    // IPlaylist Interface
    public interface IPlaylist
    {
        void Add(Song song);
        void Remove(int songId);
        Song GetSongById(int songId);
        Song GetSongByName(string songName);
        List<Song> GetAllSongs();
    }

    // MyPlayList Class
    public class MyPlayList : IPlaylist
    {
        public static List<Song> myPlayList = new List<Song>();
        private readonly int capacity;

        public MyPlayList()
        {
            capacity = 20;
        }

        public void Add(Song song)
        {
            string[] validGenres = { "Pop", "HipHop", "Soul Music", "Jazz", "Rock", "Disco", "Melody", "Classic" };

            if (myPlayList.Count >= capacity)
            {
                Console.WriteLine("Playlist is full. Cannot add more than 20 songs.");
                return;
            }

            if (!validGenres.Contains(song.SongGenre))
            {
                Console.WriteLine("Invalid Genre. Allowed genres: Pop, HipHop, Soul Music, Jazz, Rock, Disco, Melody, Classic");
                return;
            }

            myPlayList.Add(song);
            Console.WriteLine("Song added successfully!");
        }

        public void Remove(int songId)
        {
            Song songToRemove = myPlayList.FirstOrDefault(s => s.SongId == songId);
            if (songToRemove != null)
            {
                myPlayList.Remove(songToRemove);
                Console.WriteLine("Song removed successfully.");
            }
            else
            {
                Console.WriteLine("Song not found.");
            }
        }

        public Song GetSongById(int songId)
        {
            return myPlayList.FirstOrDefault(s => s.SongId == songId);
        }

        public Song GetSongByName(string songName)
        {
            return myPlayList.FirstOrDefault(s => s.SongName.Equals(songName, StringComparison.OrdinalIgnoreCase));
        }

        public List<Song> GetAllSongs()
        {
            return myPlayList;
        }
    }

    // Program Class
    class Program
    {
        static void Main(string[] args)
        {
            MyPlayList playlist = new MyPlayList();

            while (true)
            {
                Console.WriteLine("\nEnter:\n1: Add Song\n2: Remove Song by Id\n3: Get Song By Id\n4: Get Song by Name\n5: Get All Songs\n6: Exit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Song newSong = new Song();
                        Console.Write("Enter Song Id: ");
                        newSong.SongId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Song Name: ");
                        newSong.SongName = Console.ReadLine();
                        Console.Write("Enter Song Genre: ");
                        newSong.SongGenre = Console.ReadLine();
                        playlist.Add(newSong);
                        break;

                    case "2":
                        Console.Write("Enter Song Id to remove: ");
                        int removeId = Convert.ToInt32(Console.ReadLine());
                        playlist.Remove(removeId);
                        break;

                    case "3":
                        Console.Write("Enter Song Id to search: ");
                        int searchId = Convert.ToInt32(Console.ReadLine());
                        Song foundById = playlist.GetSongById(searchId);
                        if (foundById != null)
                        {
                            Console.WriteLine($"Song Found: {foundById.SongId}, {foundById.SongName}, {foundById.SongGenre}");
                        }
                        else
                        {
                            Console.WriteLine("Song not found.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter Song Name to search: ");
                        string searchName = Console.ReadLine();
                        Song foundByName = playlist.GetSongByName(searchName);
                        if (foundByName != null)
                        {
                            Console.WriteLine($"Song Found: {foundByName.SongId}, {foundByName.SongName}, {foundByName.SongGenre}");
                        }
                        else
                        {
                            Console.WriteLine("Song not found.");
                        }
                        break;

                    case "5":
                        List<Song> allSongs = playlist.GetAllSongs();
                        if (allSongs.Count > 0)
                        {
                            Console.WriteLine("\nSongs in Playlist:");
                            foreach (var song in allSongs)
                            {
                                Console.WriteLine($"{song.SongId} - {song.SongName} - {song.SongGenre}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Playlist is empty.");
                        }
                        break;

                    case "6":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}

