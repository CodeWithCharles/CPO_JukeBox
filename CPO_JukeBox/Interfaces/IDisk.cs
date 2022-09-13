using System;
using System.Collections.Generic;
using System.Text;

namespace CPO_JukeBox.Interfaces
{
    public interface IDisk
    {
        string title { get; set; }
        string creatorName { get; set; }
        TimeSpan duration { get; }
        int stock { get; set; }
        string comment { get; set; }
    }
}
