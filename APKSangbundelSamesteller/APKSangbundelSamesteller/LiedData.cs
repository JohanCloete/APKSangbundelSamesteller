using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APKSangbundelSamesteller
{
    public class LiedData
    {
        // Andersins is dit 'n Gesang.
        public bool IsPsalm;

        public int Nommer;

        public string Variasie;

        public List<int> VerseList;

        public LiedInfo liedInfo;

        public LiedData()
        {
            IsPsalm = false;
            Nommer = 0;
            Variasie = string.Empty;
            VerseList = new List<int>();

            liedInfo = new LiedInfo();
        }
    }
}
