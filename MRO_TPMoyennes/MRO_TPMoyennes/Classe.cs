using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    internal class Classe
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
            if (eleves.Count >= 30)
            {
                Console.WriteLine("La classe est pleine, impossible d'ajouter un nouvel élève.");
                return;
            }
            eleves.Add(new Eleve(prenom, nom));
        }
        public void ajouterMatiere(string matiere)
        {
            if (matieres.Count >= 10)
            {
                Console.WriteLine("impossible d'ajouter une nouvelle matière.");
                return;
            }
            matieres.Add(matiere);
        }
        public float moyenneMatiere(int matiereIndex)
        {
            return eleves.Average(e => e.moyenneMatiere(matiereIndex));
        }
        public float moyenneGeneral()
        {
            if (matieres.Count == 0)
                return 0;
            return Enumerable.Range(0, matieres.Count).Average(i => moyenneMatiere(i));
        }
        public static float Troncature2(float value)
        {
            return (float)(Math.Truncate(value * 100) / 100);
        }
    }
}
