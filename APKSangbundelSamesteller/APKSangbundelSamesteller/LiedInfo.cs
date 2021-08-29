using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APKSangbundelSamesteller
{
    public class LiedInfo
    {
        // Tipe 0 - Vers pas in op een
        // Tipe 1 - Vers moet op 2 slides ingepas word
        // Tipe 2 - Vers moet op 3 slide ingepas word.
        public int Tipe { get; set; }
        public int HoeveelheidVerse { get; set; }

        public string LiedNaam { get; set; }
    }
}
