using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    internal class Eleve
    {
        public string prenom { get; set; }
        public string nom { get; set; }
        public List<Note> notes { get; set; }
        public Eleve(string prenom, string nom)
        {
            this.prenom = prenom;
            this.nom = nom;
            this.notes = new List<Note>();
        }
        public void ajouterNote(Note note)
        {
            if (notes.Count < 200)
            {
                notes.Add(note);
            }
        }
        public float moyenneMatiere(int matiereIndex)
        {
            var matiereNotes = notes.Where(n => n.matiere == matiereIndex).Select(n => n.note);
            return matiereNotes.Any() ? matiereNotes.Average() : 0;
        }
        public float moyenneGeneral()
        {
            var matieres = notes.Select(n => n.matiere).Distinct();
            if (!matieres.Any())
                return 0;
            return matieres.Average(m => moyenneMatiere(m));
        }
    }
}
