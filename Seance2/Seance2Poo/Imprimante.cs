using System;

namespace MiniGlpi.Seance2;

// ---------------------------------------------------------------------------
// SEANCE 2 - Exercice 2, point 3 : la seconde classe fille.
//
// Comparez avec MiniGlpi.Seance1.Imprimante : la version de la seance 1
// recopiait modele et numeroSerie. Ici, ils sont HERITES -- plus aucune
// duplication. C'est tout l'interet de l'heritage.
// ---------------------------------------------------------------------------
public class Imprimante : Materiel
{
    public bool EstCouleur { get; private set; }

    public Imprimante(string modele, string numeroSerie, int age, bool estCouleur)
        : base(modele, numeroSerie, age)
    {
        EstCouleur = estCouleur;
    }

    public override string Decrire()
    {
        string type = EstCouleur ? "couleur" : "noir et blanc";
        return base.Decrire() + $" -- {type}";
    }

    // --- Exercice 5 (defi) ---------------------------------------------
    // Consigne : une imprimante est TOUJOURS de niveau 1.
    public override int NiveauPriorite()
    {
        return 1;
    }
}
