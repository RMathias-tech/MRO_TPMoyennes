using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    // Classes fournies par HNI Institut
    class Note
    {
        public int matiere { get; set; }
        public float note { get; set; }
        public Note(int m, float n)
        {
            matiere = m;
            note = n;
        }
    }
}
