using System;
using System.Collections.Generic;
using System.Text;

namespace CPO_JukeBox.Classes
{
    public class Biblio
    {
        #region Attributs
        public List<CD> cds { get; private set; }
        public List<Movie> movies { get; private set; }
        #endregion

        #region Constructeurs
        public Biblio()
        {
            this.cds = new List<CD>();
            this.movies = new List<Movie>();
        }
        #endregion

        #region Fonctions
        public override string ToString()
        {
            string result = "";
            foreach (Movie movie in this.movies)
            {
                result += movie.ToString() + "\n\n";
            }
            foreach (CD cd in this.cds)
            {
                result += cd.ToString() + "\n\n";
            }

            return result;
        }

        public bool ExistCD(string cdTitle)
        {
            bool contains = false;
            foreach(CD cdCheck in this.cds)
            {
                if(cdCheck.title == cdTitle)
                {
                    contains = true;
                    break;
                }
            }
            return contains; 
        }

        public bool ExistMovie(string movieTitle)
        {
            bool contains = false;
            foreach(Movie movieCheck in this.movies)
            {
                if(movieCheck.title == movieTitle)
                {
                    contains = true;
                    break;
                }
            }
            return contains;
        }
        #endregion

        #region Méthodes
        public void addCD(params CD[] cdsToAdd)
        {
            foreach(CD newCD in cdsToAdd)
            {
                this.cds.Add(newCD);
            }
        }

        public void addMovie(params Movie[] moviesToAdd)
        {
            foreach(Movie newMovie in moviesToAdd)
            {
                this.movies.Add(newMovie);
            }
        }
        #endregion
    }
}
