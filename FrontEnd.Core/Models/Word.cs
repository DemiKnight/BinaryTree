using System;
using System.Collections.Generic;
using System.Text;

namespace FrontEnd.Core.Models
{
    class Word
    {
        public String StoredWord { get; set; }

        public HashSet<Location> LocationsInText
        {
            get;
            set;
        }

        public int Occurrences => LocationsInText.Count;

    }
}
