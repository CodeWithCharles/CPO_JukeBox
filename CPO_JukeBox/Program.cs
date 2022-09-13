using CPO_JukeBox.Classes;
using System;
using System.Diagnostics;
using System.IO;
using WMPLib;

namespace CPO_JukeBox
{
    class Program
    {
        #region Hidden
        public static WindowsMediaPlayer _wmplayer;
        #endregion
        static void Main(string[] args)
        {

            Movie film1 = new Movie("matrix", "Lana Wachowski, Lilly Wachowski", 
                new TimeSpan(2,16,0), "Keanu Reeves", 1, 
                "Avec un postulat de départ fascinant, des décors volontairement décadents, et des effets visuels époustouflants.\nThe Matrix offre un portrait intriguant de notre futur proche sous une forme intelligente de narration cinématographique.");
            Movie film2 = new Movie("pacific rim", "Guillermo del Toro", 
                new TimeSpan(2, 11, 0), "Charlie Hunnam", 5, 
                "Visuellement sublime, \"Pacific Rim\" coince un peu en terme d’histoire, trop classique.\nMais jamais assez pour pouvoir atténuer le plaisir de gosse éprouvé devant un tel spectacle.");

            CD cd1 = new CD("la vraie vie", "Bigflo et Oli", 
                new TimeSpan(1, 18, 54), 15, 3, 
                "Oui, sur la forme l'album est très bon : Des tracks aux mélodies et rythmes variés, des textes travaillés, un duo efficace à la diction maitrisé.");
            CD cd2 = new CD("hey kids", "The Oral Cigarettes", 
                new TimeSpan(0, 38, 19), 10, 4, 
                "Énorme album de la part de TOC!! Je surkiffe Amy et Kuzuke no baby.\nLes pistes Everything et A-E-U-I te rentrent dans le tête et les autres sont tout aussi bien.");

            Biblio biblio = new Biblio();
            biblio.addMovie(film1, film2);
            biblio.addCD(cd1, cd2);

            Console.WriteLine(biblio.ToString());

            Console.ReadKey();

            #region Hidden
            _wmplayer = new WindowsMediaPlayer();
            #endregion

            while (true)
            {
                Console.WriteLine("Ouvrir : 1 - CD | 2 - Film | Q - Quitter : ");
                ConsoleKeyInfo selected = Console.ReadKey();
                char KeyChar = selected.KeyChar;
                if(KeyChar == '1')
                {
                    Console.Write("\nEntrez le nom d'un CD pour l'ouvrir (Q pour quitter) : ");
                } else if(KeyChar == '2')
                {
                    Console.Write("\nEntrez le nom d'un film pour l'ouvrir (Q pour quitter) : ");
                } else
                {
                    break;
                }

                string ans = Console.ReadLine().ToLower();
                
                if(biblio.ExistCD(ans) || biblio.ExistMovie(ans))
                {
                    string path = "";
                    if (KeyChar == '1' && biblio.ExistCD(ans))
                    {
                        path = getSlnDirectory() + "\\Assets\\CD\\" + ans + ".mp3";
                        if(File.Exists(path))
                        {
                            stopPlayer();
                            _wmplayer.URL = path;
                            _wmplayer.controls.play();
                        }
                    }
                    else if (KeyChar == '2' && biblio.ExistMovie(ans))
                    {
                        path = getSlnDirectory() + "\\Assets\\Movie\\" + ans + ".mp4";
                        if (File.Exists(path))
                        {
                            stopPlayer();
                            _wmplayer.openPlayer(path);
                            _wmplayer.controls.play();
                        }
                    }
                } else
                {
                    Console.WriteLine("CD ou Film indisponible");
                }

            }
        }

        public static string getSlnDirectory()
        {
            var directory = new DirectoryInfo(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString());

            while(directory != null && directory.GetDirectories("CPO_JukeBox").Length != 0)
            {
                directory = directory.Parent;
            }

            return directory.Parent.Parent.FullName;
        }

        public static void stopPlayer()
        {
            var proc = Process.GetProcessesByName("wmplayer");
            if (proc.Length > 0)
            {
                proc[proc.Length - 1].Kill();
            }
            if (_wmplayer.playState == WMPPlayState.wmppsPlaying)
            {
                _wmplayer.controls.stop();
            }
            _wmplayer.currentPlaylist.clear();
        }
    }
}
