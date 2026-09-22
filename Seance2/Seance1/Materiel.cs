using System;

namespace MiniGlpi.Seance1;

// ---------------------------------------------------------------------------
// SEANCE 1 - Partie 5 + Exercice 4 : la classe Materiel
//
// Version "seance 1" : les donnees sont des ATTRIBUTS PRIVES (private),
// ecrits en camelCase. La seance 2 remplacera tout cela par des PROPRIETES
// { get; private set; } en PascalCase : voir MiniGlpi.Seance2.Materiel.
// ---------------------------------------------------------------------------
public class Materiel
{
    // Les ATTRIBUTS : les donnees que possede chaque materiel.
    // private = accessibles uniquement a l'interieur de la classe.
    private string modele;
    private string numeroSerie;
    private int age;

    // Le CONSTRUCTEUR : appele quand on cree un materiel avec "new".
    // Il recoit les valeurs de depart et remplit les attributs.
    // Il porte TOUJOURS le nom de la classe et n'a pas de type de retour.
    public Materiel(string leModele, string leNumeroSerie, int lAge)
    {
        modele = leModele;
        numeroSerie = leNumeroSerie;
        age = lAge;
    }

    // Une METHODE : un traitement que le materiel sait faire.
    // "void" = elle ne retourne rien, elle se contente d'afficher.
    public void Afficher()
    {
        Console.WriteLine($"{modele} (n° {numeroSerie}) -- {age} ans");
    }

    // Une methode qui RETOURNE une valeur (ici, un booleen).
    public bool EstARenouveler()
    {
        return age > 5;
    }

    // --- Exercice 4, point 3 -------------------------------------------
    // Fait vieillir le materiel d'un an. Elle modifie l'attribut prive :
    // c'est autorise, car nous sommes a l'interieur de la classe.
    public void AugmenterAge()
    {
        age = age + 1; // ou : age++;
    }

    // --- Exercice 4, point 4 -------------------------------------------
    // Attention a la consigne : cette methode RETOURNE une chaine,
    // elle n'affiche rien. C'est l'appelant (Main) qui decide quoi en faire.
    public string Diagnostic()
    {
        if (age > 5)
        {
            return "a renouveler";
        }
        else if (age >= 3)
        {
            return "a surveiller";
        }
        else
        {
            return "recent";
        }
    }

    // Petit accessoire utile pour l'exercice 6 (trouver le plus ancien).
    // En seance 1 on ne connait pas encore les proprietes : on ecrit donc
    // un accesseur "a la PHP / a la Java", qui retourne l'attribut prive.
    public int ObtenirAge()
    {
        return age;
    }
}
