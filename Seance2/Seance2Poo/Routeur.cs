using System;

namespace MiniGlpi.Seance2;

// ---------------------------------------------------------------------------
// BONUS (hors consigne) : la demonstration de l'argument du cours.
//
// Le support annonce : "le jour ou vous ajoutez une classe Routeur, la boucle
// foreach fonctionne sans aucune modification". Cette classe le prouve : elle
// a ete ajoutee apres coup, et ni Parc, ni la boucle d'affichage de
// l'exercice 3 n'ont eu besoin d'etre touchees.
// ---------------------------------------------------------------------------
public class Routeur : Materiel
{
    public int NombrePorts { get; private set; }

    public Routeur(string modele, string numeroSerie, int age, int nombrePorts)
        : base(modele, numeroSerie, age)
    {
        NombrePorts = nombrePorts;
    }

    public override string Decrire()
    {
        return base.Decrire() + $" -- {NombrePorts} ports";
    }

    public override int NiveauPriorite()
    {
        // Un routeur en panne coupe tout le reseau : priorite haute des 4 ans.
        return Age > 4 ? 2 : 1;
    }
}
