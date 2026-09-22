using System;

namespace MiniGlpi.Seance1;

// ---------------------------------------------------------------------------
// SEANCE 1 - Exercice 5 (DEFI) : L'imprimante
//
// Remarque importante : a ce stade, on ne connait pas encore l'heritage.
// Cette classe recopie donc modele et numeroSerie, exactement comme
// Materiel le fait. C'est de la duplication, et c'est genant -- c'est
// precisement le probleme que l'heritage resoudra en seance 2.
// ---------------------------------------------------------------------------
public class Imprimante
{
    private string modele;
    private string numeroSerie;
    private bool estCouleur;
    private int nombrePagesImprimees;

    public Imprimante(string leModele, string leNumeroSerie, bool couleur)
    {
        modele = leModele;
        numeroSerie = leNumeroSerie;
        estCouleur = couleur;
        nombrePagesImprimees = 0; // une imprimante neuve n'a rien imprime
    }

    // Point 2 : l'affichage precise "couleur" ou "noir et blanc".
    public void Afficher()
    {
        // L'operateur ternaire condition ? valeurSiVrai : valeurSiFaux
        // est un raccourci pour un if/else qui produit une valeur.
        string type = estCouleur ? "couleur" : "noir et blanc";

        Console.WriteLine(
            $"Imprimante {modele} (n° {numeroSerie}) -- {type} -- " +
            $"{nombrePagesImprimees} pages imprimees");
    }

    // Point 3 : imprimer augmente le compteur de pages.
    public void Imprimer(int pages)
    {
        // On se protege d'un appel absurde (pages negatives).
        if (pages <= 0)
        {
            Console.WriteLine("Nombre de pages invalide : rien n'est imprime.");
            return; // "return" dans une methode void : on sort tout de suite.
        }

        nombrePagesImprimees = nombrePagesImprimees + pages;
    }

    // Point 4 : au-dela de 10 000 pages, il faut une maintenance.
    public bool BesoinMaintenance()
    {
        return nombrePagesImprimees > 10000;
    }
}
