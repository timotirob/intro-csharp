using System;

namespace MiniGlpi.Seance2;

// ---------------------------------------------------------------------------
// SEANCE 2 - Exercice 2 : une classe FILLE.
//
// ": Materiel" se lit "Ordinateur HERITE de Materiel".
// En Java, on ecrirait "class Ordinateur extends Materiel".
//
// Un ordinateur EST un materiel, PLUS un systeme d'exploitation.
// ---------------------------------------------------------------------------
public class Ordinateur : Materiel
{
    public string SystemeExploitation { get; private set; }

    public Ordinateur(string modele, string numeroSerie, int age, string os)
        : base(modele, numeroSerie, age) // appelle le constructeur de la mere
    {
        // Les trois donnees communes sont deja rangees par base(...).
        // Ici, on ne s'occupe que de ce qui est PROPRE a l'ordinateur.
        SystemeExploitation = os;
    }

    // override : on REDEFINIT la methode Decrire() de la mere.
    // Rappel du piege venant de PHP : il faut LES DEUX mots-cles,
    // virtual cote mere (pour autoriser) et override cote fille (pour faire).
    public override string Decrire()
    {
        // base.Decrire() recupere la description commune : on ne reecrit pas
        // ce que la mere sait deja faire, on la complete.
        return base.Decrire() + $" -- OS : {SystemeExploitation}";
    }

    // --- Exercice 5 (defi) ---------------------------------------------
    // La mere declare NiveauPriorite() en abstract : nous SOMMES OBLIGES
    // de l'ecrire ici, sinon Ordinateur ne compile pas.
    // Consigne : un ordinateur de plus de 5 ans est prioritaire (niveau 2).
    public override int NiveauPriorite()
    {
        if (Age > 5)
        {
            return 2;
        }

        return 1;
    }
}
