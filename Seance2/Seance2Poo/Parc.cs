using System;
using System.Collections.Generic; // necessaire pour List<T> et IReadOnlyList<T>

namespace MiniGlpi.Seance2;

// ---------------------------------------------------------------------------
// SEANCE 2 - Partie 5 + Exercice 4 (+ defis 5 et 6) : la classe Parc.
//
// C'est une COMPOSITION : le parc est compose de materiels. Il ne HERITE pas
// de Materiel (un parc n'est pas un materiel), il en POSSEDE.
//   heritage    = "est un"      (Ordinateur est un Materiel)
//   composition = "est compose de" (Parc est compose de Materiel)
// ---------------------------------------------------------------------------
public class Parc
{
    // La liste est PRIVEE : personne ne doit la manipuler directement
    // de l'exterieur. Toute modification passera par la methode Ajouter().
    private List<Materiel> lesMateriels;

    public Parc()
    {
        // Sans cette ligne, lesMateriels vaudrait null et le premier
        // Ajouter() provoquerait une NullReferenceException.
        lesMateriels = new List<Materiel>();
    }

    // --- Exercice 4, point 2 -------------------------------------------
    public void Ajouter(Materiel m)
    {
        lesMateriels.Add(m);
    }

    public int NombreTotal()
    {
        // .Count est une PROPRIETE : pas de parentheses.
        // (En Java, ce serait .size() -- avec des parentheses.)
        return lesMateriels.Count;
    }

    public void AfficherTout()
    {
        if (lesMateriels.Count == 0)
        {
            Console.WriteLine("Le parc est vide.");
            return;
        }

        // LE POLYMORPHISME EN ACTION : la variable est declaree Materiel,
        // mais c'est la version Decrire() du type REEL de l'objet qui
        // s'execute (celle d'Ordinateur, celle d'Imprimante, celle de Routeur).
        foreach (Materiel m in lesMateriels)
        {
            Console.WriteLine($" - {m.Decrire()}");
        }
    }

    // --- Exercice 4, point 4 -------------------------------------------
    // Compte les materiels de plus de 5 ans.
    public int CompterARenouveler()
    {
        int compteur = 0;

        foreach (Materiel m in lesMateriels)
        {
            // On peut lire m.Age depuis l'exterieur de Materiel grace au
            // "get" public de la propriete. On passe ici par la methode
            // EstARenouveler(), qui place la regle metier au bon endroit.
            if (m.EstARenouveler())
            {
                compteur++;
            }
        }

        return compteur;
    }

    // --- Exercice 5 (defi), point 4 ------------------------------------
    // Retourne les materiels de niveau 2.
    //
    // Remarquez qu'on ne teste NULLE PART le type de l'objet : pas de
    // "if (m is Ordinateur)". Chaque materiel sait lui-meme quelle est sa
    // priorite. Ajouter une famille de materiel ne change pas cette methode.
    public List<Materiel> ObtenirPrioritaires()
    {
        List<Materiel> prioritaires = new List<Materiel>();

        foreach (Materiel m in lesMateriels)
        {
            if (m.NiveauPriorite() == 2)
            {
                prioritaires.Add(m);
            }
        }

        return prioritaires;
    }

    // --- Exercice 6 (defi), point 1 ------------------------------------
    // Expose la liste en LECTURE SEULE : on peut consulter, pas modifier.
    //
    // IReadOnlyList<Materiel> n'offre ni Add, ni Remove, ni Clear.
    // Le compilateur refusera donc parc.ObtenirTous().Add(...).
    public IReadOnlyList<Materiel> ObtenirTous()
    {
        return lesMateriels.AsReadOnly();
    }

    // Bonus : l'age moyen du parc, pour montrer un calcul sur la collection.
    public double AgeMoyen()
    {
        if (lesMateriels.Count == 0)
        {
            return 0; // eviter la division par zero
        }

        int total = 0;

        foreach (Materiel m in lesMateriels)
        {
            total = total + m.Age;
        }

        // Attention : total et Count sont des int. Sans le (double), C#
        // ferait une division ENTIERE et 17 / 5 donnerait 3, pas 3,4.
        return (double)total / lesMateriels.Count;
    }
}
