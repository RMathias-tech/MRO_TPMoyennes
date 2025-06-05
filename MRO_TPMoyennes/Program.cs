using System;
using System.Collections.Generic;
using System.Linq;

namespace HNI_TPmoyennes
{
    class Eleve
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
            notes.Add(note);
        }
        public float moyenneMatiere(int matiereIndex)
        {
            var matiereNotes = notes.Where(n => n.matiere == matiereIndex).Select(n => n.note);
            return matiereNotes.Any() ? matiereNotes.Average() : 0;
        }
        public float moyenneGeneral()
        {
            return notes.Any() ? notes.Average(n => n.note) : 0;
        }
    }
    class Classe
    {
        public string nomClasse { get; set; }
        public List<Eleve> eleves { get; set; }
        public List<string> matieres { get; set; }
        public Classe(string nomClasse)
        {
            this.nomClasse = nomClasse;
            this.eleves = new List<Eleve>();
            this.matieres = new List<string>();
        }
        public void ajouterEleve(string prenom, string nom)
        {
            eleves.Add(new Eleve(prenom, nom));
        }
        public void ajouterMatiere(string matiere)
        {
            matieres.Add(matiere);
        }
        public float moyenneMatiere(int matiereIndex)
        {
            return eleves.Average(e => e.moyenneMatiere(matiereIndex));
        }
        public float moyenneGeneral()
        {
            return eleves.Average(e => e.moyenneGeneral());
        }
        public static float Troncature2(float value)
        {
            return (float)(Math.Truncate(value * 100) / 100);
        }
    }
   

    class Program
    {
        static void Main(string[] args)
        {
            // Création d'une classe
            Classe sixiemeA = new Classe("6eme A");
            // Ajout des élèves à la classe
            sixiemeA.ajouterEleve("Jean", "RAGE");
            sixiemeA.ajouterEleve("Paul", "HAAR");
            sixiemeA.ajouterEleve("Sibylle", "BOQUET");
            sixiemeA.ajouterEleve("Annie", "CROCHE");
            sixiemeA.ajouterEleve("Alain", "PROVISTE");
            sixiemeA.ajouterEleve("Justin", "TYDERNIER");
            sixiemeA.ajouterEleve("Sacha", "TOUILLE");
            sixiemeA.ajouterEleve("Cesar", "TICHO");
            sixiemeA.ajouterEleve("Guy", "DON");
            // Ajout de matières étudiées par la classe
            sixiemeA.ajouterMatiere("Francais");
            sixiemeA.ajouterMatiere("Anglais");
            sixiemeA.ajouterMatiere("Physique/Chimie");
            sixiemeA.ajouterMatiere("Histoire");
            Random random = new Random();
            // Ajout de 5 notes à chaque élève et dans chaque matière
            for (int ieleve = 0; ieleve < sixiemeA.eleves.Count; ieleve++)
            {
                for (int matiere = 0; matiere < sixiemeA.matieres.Count; matiere++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        sixiemeA.eleves[ieleve].ajouterNote(new Note(matiere, (float)((6.5 +
                       random.NextDouble() * 34)) / 2.0f));
                        // Note minimale = 3
                    }
                }
            }

            Eleve eleve = sixiemeA.eleves[4];
            // Afficher la moyenne d'un élève dans une matière
            Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne en " + sixiemeA.matieres[2] + " : " +
            Classe.Troncature2(eleve.moyenneMatiere(1)) + "\n");
            // Afficher la moyenne générale du même élève
            Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne Generale : " + Classe.Troncature2(eleve.moyenneGeneral()) + "\n");
            // Afficher la moyenne de la classe dans une matière
            Console.Write("Classe de " + sixiemeA.nomClasse + ", Moyenne en " + sixiemeA.matieres[2] + " : " +
            Classe.Troncature2(sixiemeA.moyenneMatiere(1)) + "\n");
            // Afficher la moyenne générale de la classe
            Console.Write("Classe de " + sixiemeA.nomClasse + ", Moyenne Generale : " + Classe.Troncature2(sixiemeA.moyenneGeneral()) + "\n");
            Console.Read();
        }
    }
}



