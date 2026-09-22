using System;

namespace MiniGlpi.Seance2;

// ---------------------------------------------------------------------------
// SEANCE 2 - la classe MERE, refondue.
//
// Elle a evolue en trois etapes au fil des exercices :
//   Exercice 1 : les attributs prives deviennent des PROPRIETES
//                { get; private set; }, en PascalCase.
//   Exercice 2 : elle devient une classe MERE, avec Decrire() marquee virtual
//                pour que les filles puissent la redefinir.
//   Exercice 5 : elle devient ABSTRAITE, avec une methode abstract
//                NiveauPriorite() que chaque fille DOIT ecrire.
//
// "abstract" sur la classe = on ne peut plus ecrire new Materiel(...).
// C'est voulu : un "materiel generique" n'existe pas dans la realite.
// ---------------------------------------------------------------------------
public abstract class Materiel
{
    // Une PROPRIETE : lisible de l'exterieur (get public),
    // modifiable seulement a l'interieur de la classe (private set).
    // C'est l'equivalent en une ligne du couple "private $modele + getModele()"
    // que vous ecriviez en PHP, ou de "private String modele + getModele()"
    // en Java.
    public string Modele { get; private set; }
    public string NumeroSerie { get; private set; }
    public int Age { get; private set; }

    // Le constructeur d'une classe abstraite existe bel et bien : il sera
    // appele par les constructeurs des filles, via ": base(...)".
    // Il est "protected" par convention : seules les filles s'en servent.
    protected Materiel(string modele, string numeroSerie, int age)
    {
        // On peut ecrire ici : on est a l'interieur de la classe.
        Modele = modele;
        NumeroSerie = numeroSerie;
        Age = age;
    }

    // virtual : les classes filles POURRONT redefinir cette methode.
    // La mere fournit une version par defaut, correcte pour tout materiel.
    public virtual string Decrire()
    {
        return $"{Modele} (n° {NumeroSerie}), {Age} ans";
    }

    // abstract : AUCUN corps ici. Chaque fille DEVRA l'ecrire, sinon le code
    // ne compile pas. Formule a retenir : virtual propose, abstract impose.
    public abstract int NiveauPriorite();

    // Regle metier commune a tous les materiels : on la met donc dans la mere,
    // une seule fois. Elle sert a Parc.CompterARenouveler().
    public bool EstARenouveler()
    {
        return Age > 5;
    }

    // Methode commune, utile pour la demonstration de l'exercice 1.
    public void Vieillir()
    {
        Age = Age + 1; // autorise : le "set" est prive, mais on est dedans
    }
}
