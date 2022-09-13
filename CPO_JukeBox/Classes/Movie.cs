using CPO_JukeBox.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPO_JukeBox.Classes
{
    public class Movie : IDisk
    {
        #region Attributs
        public string title { get; set; }
        public string creatorName { get; set; }
        public TimeSpan duration { get; private set; }
        public string mainActor { get; private set; }
        public int stock { get; set; }
        public string comment { get; set; }
        #endregion

        #region Constructeur
        public Movie(string title, string creatorName, TimeSpan duration, string mainActor, int stock = 0, string comment = "")
        {
            this.title = title;
            this.creatorName = creatorName;
            this.duration = duration;
            this.mainActor = mainActor;
            this.stock = stock;
            this.comment = comment;
        }
        #endregion

        #region Fonction
        public override string ToString()
        {
            return String.Format("{0} de {1} avec {2} pour une durée de {3}. {4} en stock.\nCommentaire :\n{5}",
                this.title,
                this.creatorName,
                this.mainActor,
                (this.duration.ToString()),
                this.stock,
                this.comment);
        }
        #endregion
    }
}
