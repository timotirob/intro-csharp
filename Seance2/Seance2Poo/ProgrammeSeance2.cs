using System;
using System.Collections.Generic;

namespace MiniGlpi.Seance2;

// ---------------------------------------------------------------------------
// SEANCE 2 - Correction des travaux pratiques (partie 6)
// ---------------------------------------------------------------------------
public class ProgrammeSeance2
{
    // =======================================================================
    // Exercice 1 : Proprietes
    // =======================================================================
    public static void Exercice1()
    {
        Titre("Exercice 1 - Les proprietes");

        // Note : a l'exercice 1, Materiel etait encore une classe CONCRETE et
        // on ecrivait new Materiel("Dell", "SN-01", 3). A l'exercice 5 (defi),
        // elle devient abstraite : on instancie donc une fille, Ordinateur.
        // La demonstration sur les proprietes est exactement la meme, puisque
        // Modele, NumeroSerie et Age sont heritees de Materiel.
        Materiel m = new Ordinateur("Dell Latitude", "SN-4471", 3, "Windows 11");

        // Point 4 : la LECTURE est autorisee partout.
        Console.WriteLine($"Modele      : {m.Modele}");
        Console.WriteLine($"Numero      : {m.NumeroSerie}");
        Console.WriteLine($"Age         : {m.Age} ans");
        Console.WriteLine($"Description : {m.Decrire()}");

        // Point 4 (suite) : l'ECRITURE depuis l'exterieur est interdite.
        // Decommentez la ligne suivante : Rider la souligne en rouge et la
        // compilation echoue avec l'erreur
        //   CS0272: The property or indexer 'Materiel.Modele' cannot be used
        //           in this context because the set accessor is inaccessible
        //
        // m.Modele = "HP EliteBook";
        //
        Console.WriteLine();
        Console.WriteLine("m.Modele = \"HP\" ne compile pas : le set est prive.");

        // En revanche, une METHODE de la classe peut modifier la propriete,
        // parce qu'elle s'execute a l'interieur de la classe.
        m.Vieillir();
        Console.WriteLine($"Apres m.Vieillir() : {m.Age} ans " +
                          "(modifie de l'interieur, donc autorise)");

        Console.WriteLine();
        Console.WriteLine("Les trois formes a connaitre :");
        Console.WriteLine("  { get; private set; } lisible partout, modifiable dans la classe");
        Console.WriteLine("  { get; set; }         lisible et modifiable partout (a eviter)");
        Console.WriteLine("  { get; }              lisible seulement, fixee au constructeur");
    }

    // =======================================================================
    // Exercice 2 : Heritage
    // =======================================================================
    public static void Exercice2()
    {
        Titre("Exercice 2 - L'heritage");

        Ordinateur poste = new Ordinateur("Dell Latitude", "SN-01", 3, "Windows 11");
        Imprimante imprimante = new Imprimante("HP LaserJet", "SN-99", 2, true);

        // Point 4 : chaque description est bien specifique.
        Console.WriteLine(poste.Decrire());
        Console.WriteLine(imprimante.Decrire());

        Console.WriteLine();
        Console.WriteLine("Les deux premieres parties de chaque ligne sont identiques :");
        Console.WriteLine("elles viennent de base.Decrire(), ecrit UNE SEULE FOIS dans la mere.");
        Console.WriteLine("Seule la fin change : c'est ce que la fille ajoute.");

        Console.WriteLine();
        // Point 3 de l'exercice 5 (defi) : la classe mere est abstraite.
        // Decommentez pour voir l'erreur :
        //   CS0144: Cannot create an instance of the abstract type
        //           or interface 'Materiel'
        //
        // Materiel generique = new Materiel("???", "SN-00", 1);
        //
        Console.WriteLine("new Materiel(...) est refuse : la classe est abstract.");
        Console.WriteLine("Seules les filles concretes sont instanciables.");
    }

    // =======================================================================
    // Exercice 3 : Collections
    // =======================================================================
    public static void Exercice3()
    {
        Titre("Exercice 3 - Les collections et le polymorphisme");

        // Point 1 : une liste de materiels.
        // Le type declare est Materiel, donc la liste accepte TOUTES ses filles.
        List<Materiel> parc = new List<Materiel>();

        // Point 2 : deux ordinateurs et deux imprimantes.
        parc.Add(new Ordinateur("Dell Latitude", "SN-01", 3, "Windows 11"));
        parc.Add(new Ordinateur("HP EliteBook", "SN-02", 6, "Ubuntu 24.04"));
        parc.Add(new Imprimante("HP LaserJet", "SN-99", 2, true));
        parc.Add(new Imprimante("Brother HL-1210", "SN-98", 7, false));

        // Bonus : un Routeur, ajoute apres coup. La boucle ci-dessous n'a pas
        // change d'une virgule -- c'est l'argument de conception du cours.
        parc.Add(new Routeur("Cisco RV340", "SN-77", 5, 4));

        // Point 3 : le parcours foreach.
        Console.WriteLine("Contenu du parc :");

        foreach (Materiel m in parc)
        {
            // Un seul appel, trois comportements differents : la methode
            // executee est celle du type REEL de l'objet, pas celle du type
            // declare (Materiel). C'est le POLYMORPHISME.
            Console.WriteLine($" - {m.Decrire()}");
        }

        // Point 4 : le nombre total.
        Console.WriteLine();
        Console.WriteLine($"{parc.Count} materiels dans le parc");

        // Les autres operations de base vues dans le cours.
        Console.WriteLine($"Premier element (indice 0) : {parc[0].Decrire()}");
        Console.WriteLine($"Dernier element (indice {parc.Count - 1}) : " +
                          $"{parc[parc.Count - 1].Decrire()}");
    }

    // =======================================================================
    // Exercice 4 : La classe Parc
    // =======================================================================
    public static void Exercice4()
    {
        Titre("Exercice 4 - La classe Parc");

        // Point 3 : on cree un Parc et on le remplit.
        Parc parc = ConstruireParcDeDemonstration();

        Console.WriteLine($"Nombre total : {parc.NombreTotal()} materiels");
        Console.WriteLine();

        Console.WriteLine("AfficherTout() :");
        parc.AfficherTout();

        // Point 4 : les materiels de plus de 5 ans.
        Console.WriteLine();
        Console.WriteLine($"A renouveler (plus de 5 ans) : {parc.CompterARenouveler()}");
        Console.WriteLine($"Age moyen du parc : {parc.AgeMoyen():F1} ans");

        Console.WriteLine();
        Console.WriteLine("Difference avec l'exercice 3 : la liste n'est plus dans Main,");
        Console.WriteLine("elle est privee dans Parc. Main ne peut plus la vider par");
        Console.WriteLine("accident : il doit passer par les methodes du Parc.");
    }

    // =======================================================================
    // Exercice 5 (DEFI) : La classe abstraite et la priorite
    // =======================================================================
    public static void Exercice5()
    {
        Titre("Exercice 5 (defi) - Classe abstraite et priorite");

        // Point 1 : Materiel est abstract, avec abstract int NiveauPriorite().
        //           Voir Seance2Poo/Materiel.cs.
        // Point 2 : chaque fille l'implemente a sa facon.
        // Point 3 : new Materiel(...) est refuse -- voir l'exercice 2.

        Parc parc = ConstruireParcDeDemonstration();

        Console.WriteLine("Niveau de priorite de chaque materiel :");

        foreach (Materiel m in parc.ObtenirTous())
        {
            Console.WriteLine($" - niveau {m.NiveauPriorite()} : {m.Decrire()}");
        }

        // Point 4 : la methode ObtenirPrioritaires() du Parc.
        Console.WriteLine();
        List<Materiel> prioritaires = parc.ObtenirPrioritaires();
        Console.WriteLine($"Materiels prioritaires (niveau 2) : {prioritaires.Count}");

        foreach (Materiel m in prioritaires)
        {
            Console.WriteLine($" - {m.Decrire()}");
        }

        Console.WriteLine();
        Console.WriteLine("Notez le resultat : une imprimante de 7 ans n'est PAS");
        Console.WriteLine("prioritaire, alors qu'un ordinateur de 6 ans l'est. La regle");
        Console.WriteLine("n'est donc pas la meme selon la famille -- exactement ce que");
        Console.WriteLine("abstract permet d'exprimer : la mere impose la question,");
        Console.WriteLine("chaque fille donne sa reponse.");
    }

    // =======================================================================
    // Exercice 6 (DEFI) : Lecture seule et encapsulation
    // =======================================================================
    public static void Exercice6()
    {
        Titre("Exercice 6 (defi) - Lecture seule et encapsulation");

        Parc parc = ConstruireParcDeDemonstration();

        // Points 1 et 2 : on recupere la liste en lecture seule et on l'affiche.
        IReadOnlyList<Materiel> tous = parc.ObtenirTous();

        Console.WriteLine($"Lecture autorisee : {tous.Count} materiels.");

        foreach (Materiel m in tous)
        {
            Console.WriteLine($" - {m.Decrire()}");
        }

        // L'acces par indice fonctionne aussi : la lecture n'est pas bridee.
        Console.WriteLine($"tous[0] = {tous[0].Decrire()}");

        // Point 3 : le test de securite. Decommentez pour voir l'erreur :
        //   CS1061: 'IReadOnlyList<Materiel>' does not contain a definition
        //           for 'Add'
        //
        // parc.ObtenirTous().Add(new Ordinateur("Pirate", "SN-666", 1, "DOS"));
        //
        Console.WriteLine();
        Console.WriteLine("Point 3 - ce que dit le compilateur :");
        Console.WriteLine("  IReadOnlyList<Materiel> n'a pas de methode Add. L'erreur est");
        Console.WriteLine("  detectee A LA COMPILATION, pas a l'execution : le programme");
        Console.WriteLine("  fautif ne peut meme pas etre lance. C'est exactement le");
        Console.WriteLine("  comportement voulu -- la protection est verifiee par le");
        Console.WriteLine("  compilateur, elle ne repose pas sur la discipline du");
        Console.WriteLine("  developpeur ni sur un test qui pourrait etre oublie.");

        // Point 4 : la reponse redigee.
        Console.WriteLine();
        Console.WriteLine("Point 4 - pourquoi la lecture seule est plus sure :");
        Console.WriteLine();
        Console.WriteLine("  Si on ecrivait public List<Materiel> LesMateriels { get; private");
        Console.WriteLine("  set; }, le private set ne protegerait que la REFERENCE : il");
        Console.WriteLine("  empecherait de remplacer la liste par une autre, mais pas d'agir");
        Console.WriteLine("  sur son CONTENU. N'importe qui pourrait ecrire");
        Console.WriteLine("  parc.LesMateriels.Clear() et vider le parc, sans que le Parc en");
        Console.WriteLine("  sache rien. Exposer une reference, c'est donner un acces complet");
        Console.WriteLine("  a ce qu'elle designe.");
        Console.WriteLine();
        Console.WriteLine("  Avec AsReadOnly(), l'exterieur recoit une vue qui n'offre aucune");
        Console.WriteLine("  operation de modification. Toute ecriture doit donc repasser par");
        Console.WriteLine("  Ajouter(), c'est-a-dire par un point d'entree UNIQUE et CONTROLE :");
        Console.WriteLine("  le Parc peut y verifier la validite, refuser un doublon de numero");
        Console.WriteLine("  de serie, journaliser l'operation, prevenir une interface...");
        Console.WriteLine();
        Console.WriteLine("  C'est le controle d'acces applique aux collections : on ne choisit");
        Console.WriteLine("  pas entre \"tout ouvert\" et \"tout ferme\", on separe le DROIT DE");
        Console.WriteLine("  LIRE, accorde largement, du DROIT D'ECRIRE, reserve a la classe");
        Console.WriteLine("  qui est responsable de la coherence des donnees. Meme logique que");
        Console.WriteLine("  { get; private set; } sur une propriete, transposee a une liste.");
    }

    // =======================================================================
    // Menu de la seance 2
    // =======================================================================
    public static void Lancer()
    {
        bool continuer = true;

        while (continuer)
        {
            Console.WriteLine();
            Console.WriteLine("=== SEANCE 2 : programmation orientee objet ===");
            Console.WriteLine("  1 - Exercice 1 : proprietes");
            Console.WriteLine("  2 - Exercice 2 : heritage");
            Console.WriteLine("  3 - Exercice 3 : collections et polymorphisme");
            Console.WriteLine("  4 - Exercice 4 : la classe Parc");
            Console.WriteLine("  5 - Exercice 5 (defi) : classe abstraite et priorite");
            Console.WriteLine("  6 - Exercice 6 (defi) : lecture seule et encapsulation");
            Console.WriteLine("  T - Tous");
            Console.WriteLine("  0 - Retour");
            Console.Write("Votre choix : ");

            string choix = Console.ReadLine() ?? "0";

            switch (choix.Trim().ToUpper())
            {
                case "1": Exercice1(); break;
                case "2": Exercice2(); break;
                case "3": Exercice3(); break;
                case "4": Exercice4(); break;
                case "5": Exercice5(); break;
                case "6": Exercice6(); break;
                case "T":
                    Exercice1();
                    Exercice2();
                    Exercice3();
                    Exercice4();
                    Exercice5();
                    Exercice6();
                    break;
                case "0": continuer = false; break;
                default: Console.WriteLine("Choix inconnu."); break;
            }
        }
    }

    // =======================================================================
    // Outils partages
    // =======================================================================

    // Le meme parc de demonstration pour les exercices 4, 5 et 6 : cela evite
    // de recopier cinq Ajouter() dans chaque exercice.
    private static Parc ConstruireParcDeDemonstration()
    {
        Parc parc = new Parc();

        parc.Ajouter(new Ordinateur("Dell Latitude", "SN-01", 3, "Windows 11"));
        parc.Ajouter(new Ordinateur("HP EliteBook", "SN-02", 6, "Ubuntu 24.04"));
        parc.Ajouter(new Ordinateur("Lenovo ThinkPad", "SN-03", 8, "Windows 10"));
        parc.Ajouter(new Imprimante("HP LaserJet", "SN-99", 2, true));
        parc.Ajouter(new Imprimante("Brother HL-1210", "SN-98", 7, false));
        parc.Ajouter(new Routeur("Cisco RV340", "SN-77", 5, 4));

        return parc;
    }

    private static void Titre(string texte)
    {
        Console.WriteLine();
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine(texte);
        Console.WriteLine("--------------------------------------------------");
    }
}
