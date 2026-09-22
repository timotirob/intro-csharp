using System;

namespace MiniGlpi.Seance1;

// ---------------------------------------------------------------------------
// SEANCE 1 - Correction des travaux pratiques (partie 6)
//
// Chaque exercice est une methode statique : on peut les lancer une par une
// depuis le menu (Program.cs), ou toutes a la suite.
//
// "static" veut dire : la methode appartient a la classe, pas a un objet.
// On l'appelle donc ProgrammeSeance1.Exercice2() sans faire de "new".
// ---------------------------------------------------------------------------
public class ProgrammeSeance1
{
    // =======================================================================
    // Exercice 1 : Mise en route
    // =======================================================================
    public static void Exercice1()
    {
        Titre("Exercice 1 - Mise en route");

        // Etape 3 : le squelette impose par le cours affichait ceci.
        Console.WriteLine("Projet MiniGlpi -- pret.");

        // Etape 5 : trois lignes -- nom, date du jour (en dur), intitule.
        Console.WriteLine("Timothee ROBERT");
        Console.WriteLine("08/09/2026"); // date tapee a la main, comme demande
        Console.WriteLine("Mini-GLPI -- Intro");
    }

    // =======================================================================
    // Exercice 2 : Variables et calculs
    // =======================================================================
    public static void Exercice2()
    {
        Titre("Exercice 2 - Variables et calculs");

        // Point 1 : une variable par donnee, chacune avec SON type.
        string modele = "Dell Latitude 5540";
        int age = 6;                  // en annees
        double prixAchat = 1250.00;   // en euros
        bool sousGarantie = false;

        // Point 2 : la phrase recapitulative, avec interpolation $"..."
        // Rappel : en C#, les variables n'ont pas de $. Le $ prefixe la CHAINE.
        Console.WriteLine(
            $"Poste {modele} : {age} ans, achete {prixAchat:F2} EUR, " +
            $"sous garantie = {sousGarantie}");

        // Point 3 : la valeur residuelle -- 20 % du prix d'achat par annee.
        double valeurResiduelle = prixAchat - (prixAchat * 0.20 * age);

        // Point 4 : si elle est negative, on affiche "Poste amorti".
        if (valeurResiduelle < 0)
        {
            Console.WriteLine("Poste amorti");
        }
        else
        {
            // :F2 formate le nombre avec deux chiffres apres la virgule.
            Console.WriteLine($"Valeur residuelle : {valeurResiduelle:F2} EUR");
        }

        // Verification avec un poste recent, pour voir l'autre branche du if.
        int ageRecent = 2;
        double valeurRecente = prixAchat - (prixAchat * 0.20 * ageRecent);
        Console.WriteLine($"(A {ageRecent} ans, il vaudrait {valeurRecente:F2} EUR)");
    }

    // =======================================================================
    // Exercice 3 : Conditions et boucles
    // =======================================================================
    public static void Exercice3()
    {
        Titre("Exercice 3 - Conditions et boucles");

        // Point 1 : saisie de l'age, puis conversion texte -> entier.
        int age = LireEntier("Age du materiel (en annees) : ", 4);

        // Point 2 : le diagnostic. Attention a l'ORDRE des tests :
        // on teste d'abord le cas le plus large (> 5), sinon un materiel de
        // 8 ans tomberait dans "moins de 3 ans"... non, mais il faut penser
        // a enchainer les else if, pas a ecrire trois if independants.
        if (age < 3)
        {
            Console.WriteLine("Materiel recent.");
        }
        else if (age <= 5) // ici, on sait deja que age >= 3
        {
            Console.WriteLine("Materiel a surveiller.");
        }
        else
        {
            Console.WriteLine("Materiel a renouveler.");
        }

        // Point 3 : la boucle for -- N postes numerotes.
        int nombrePostes = LireEntier("Combien de postes a lister ? ", 5);

        for (int i = 1; i <= nombrePostes; i++)
        {
            Console.WriteLine($"Poste numero {i}");
        }

        // Point 4 : la boucle while -- decompte du stock.
        int stock = LireEntier("Stock de postes disponibles ? ", 3);

        while (stock > 0)
        {
            stock = stock - 1; // ou stock--;  <-- LA ligne qui evite la boucle infinie
            Console.WriteLine($"Poste attribue, reste {stock}");
        }

        Console.WriteLine("Stock epuise.");
    }

    // =======================================================================
    // Exercice 4 : La classe Materiel
    // =======================================================================
    public static void Exercice4()
    {
        Titre("Exercice 4 - La classe Materiel");

        // Point 2 : trois materiels differents, fabriques avec le meme moule.
        Materiel poste1 = new Materiel("Dell Latitude", "SN-4471", 6);
        Materiel poste2 = new Materiel("HP EliteBook", "SN-8802", 2);
        Materiel poste3 = new Materiel("Lenovo ThinkPad", "SN-1203", 4);

        poste1.Afficher();
        poste2.Afficher();
        poste3.Afficher();

        Console.WriteLine();

        // Point 3 : AugmenterAge() -- avant / apres.
        Console.WriteLine("Avant vieillissement :");
        poste2.Afficher();

        poste2.AugmenterAge();
        poste2.AugmenterAge(); // deux ans de plus, pour changer de categorie

        Console.WriteLine("Apres deux appels a AugmenterAge() :");
        poste2.Afficher();

        Console.WriteLine();

        // Point 4 : Diagnostic() RETOURNE une chaine -- c'est Main qui affiche.
        Console.WriteLine($"poste1 : {poste1.Diagnostic()}");
        Console.WriteLine($"poste2 : {poste2.Diagnostic()}");
        Console.WriteLine($"poste3 : {poste3.Diagnostic()}");

        // Et la methode de la partie 5, pour memoire.
        if (poste1.EstARenouveler())
        {
            Console.WriteLine("Le premier poste doit etre renouvele.");
        }
    }

    // =======================================================================
    // Exercice 5 (DEFI) : L'imprimante
    // =======================================================================
    public static void Exercice5()
    {
        Titre("Exercice 5 (defi) - L'imprimante");

        Imprimante couleur = new Imprimante("HP Color LaserJet", "IMP-001", true);
        Imprimante noirBlanc = new Imprimante("Brother HL-1210", "IMP-002", false);

        couleur.Afficher();
        noirBlanc.Afficher();

        Console.WriteLine();

        // Point 3 : on imprime, le compteur monte.
        couleur.Imprimer(250);
        couleur.Imprimer(1200);
        couleur.Afficher();

        // Point 4 : le seuil de maintenance.
        Console.WriteLine($"Maintenance necessaire ? {couleur.BesoinMaintenance()}");

        noirBlanc.Imprimer(12500); // on depasse volontairement 10 000
        noirBlanc.Afficher();
        Console.WriteLine($"Maintenance necessaire ? {noirBlanc.BesoinMaintenance()}");

        // Cas limite : exactement 10 000 pages. La consigne dit "au-dela",
        // donc > 10000 et non >= : a 10 000 pile, pas de maintenance.
        Imprimante pile = new Imprimante("Test seuil", "IMP-003", false);
        pile.Imprimer(10000);
        Console.WriteLine($"A 10 000 pages pile : {pile.BesoinMaintenance()} (attendu : False)");
    }

    // =======================================================================
    // Exercice 6 (DEFI) : Le mini-inventaire, sans liste
    // =======================================================================
    public static void Exercice6()
    {
        Titre("Exercice 6 (defi) - Le mini-inventaire");

        // Point 1 : cinq materiels... dans cinq variables separees.
        Materiel m1 = new Materiel("Dell Latitude", "SN-001", 7);
        Materiel m2 = new Materiel("HP EliteBook", "SN-002", 2);
        Materiel m3 = new Materiel("Lenovo ThinkPad", "SN-003", 6);
        Materiel m4 = new Materiel("Asus ExpertBook", "SN-004", 4);
        Materiel m5 = new Materiel("Acer TravelMate", "SN-005", 9);

        m1.Afficher();
        m2.Afficher();
        m3.Afficher();
        m4.Afficher();
        m5.Afficher();

        Console.WriteLine();

        // Point 2 : compter ceux "a renouveler", avec des conditions.
        int aRenouveler = 0;

        if (m1.EstARenouveler()) { aRenouveler++; }
        if (m2.EstARenouveler()) { aRenouveler++; }
        if (m3.EstARenouveler()) { aRenouveler++; }
        if (m4.EstARenouveler()) { aRenouveler++; }
        if (m5.EstARenouveler()) { aRenouveler++; }

        Console.WriteLine($"Materiels a renouveler : {aRenouveler} sur 5");

        Console.WriteLine();

        // Point 3 : le plus ancien.
        // Technique : on suppose que le premier est le plus vieux, puis on
        // compare avec chacun des suivants et on remplace si besoin.
        Materiel plusAncien = m1;

        if (m2.ObtenirAge() > plusAncien.ObtenirAge()) { plusAncien = m2; }
        if (m3.ObtenirAge() > plusAncien.ObtenirAge()) { plusAncien = m3; }
        if (m4.ObtenirAge() > plusAncien.ObtenirAge()) { plusAncien = m4; }
        if (m5.ObtenirAge() > plusAncien.ObtenirAge()) { plusAncien = m5; }

        Console.Write("Materiel le plus ancien : ");
        plusAncien.Afficher();

        Console.WriteLine();

        // Point 4 : la question a noter.
        Console.WriteLine("Question : cette approche est-elle pratique ?");
        Console.WriteLine("  Non. Pour cent materiels il faudrait cent variables et cent");
        Console.WriteLine("  lignes de if : le code grossirait proportionnellement aux");
        Console.WriteLine("  donnees, ce qui est le signe d'une mauvaise structure.");
        Console.WriteLine("  Il nous manque deux choses :");
        Console.WriteLine("   - un CONTENEUR pour ranger les materiels ensemble (List<T>) ;");
        Console.WriteLine("   - une BOUCLE pour les parcourir sans les nommer un par un.");
        Console.WriteLine("  C'est l'objet de la seance 2 : les collections.");
    }

    // =======================================================================
    // Menu de la seance 1
    // =======================================================================
    public static void Lancer()
    {
        bool continuer = true;

        while (continuer)
        {
            Console.WriteLine();
            Console.WriteLine("=== SEANCE 1 : syntaxe et objets ===");
            Console.WriteLine("  1 - Exercice 1 : mise en route");
            Console.WriteLine("  2 - Exercice 2 : variables et calculs");
            Console.WriteLine("  3 - Exercice 3 : conditions et boucles (saisies clavier)");
            Console.WriteLine("  4 - Exercice 4 : la classe Materiel");
            Console.WriteLine("  5 - Exercice 5 (defi) : l'imprimante");
            Console.WriteLine("  6 - Exercice 6 (defi) : le mini-inventaire");
            Console.WriteLine("  T - Tous (sauf le 3, qui demande des saisies)");
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
    // Petits outils partages par les exercices
    // =======================================================================

    private static void Titre(string texte)
    {
        Console.WriteLine();
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine(texte);
        Console.WriteLine("--------------------------------------------------");
    }

    // Saisie d'un entier au clavier, comme a l'exercice 3.
    //
    // Console.ReadLine() retourne un string (toujours), et int.Parse le
    // convertit en entier. Deux details :
    //  - le "?? " gere le cas ou ReadLine() retourne null (fin de flux) ;
    //    c'est necessaire parce que le projet active <Nullable>enable</Nullable>.
    //  - si l'utilisateur valide sans rien taper, on prend une valeur par
    //    defaut plutot que de planter. En seance 3, int.TryParse fera cela
    //    proprement, y compris quand l'utilisateur tape "bonjour".
    private static int LireEntier(string question, int valeurParDefaut)
    {
        Console.Write(question);
        string saisie = Console.ReadLine() ?? "";

        if (saisie.Trim() == "")
        {
            Console.WriteLine($"(rien saisi : on prend {valeurParDefaut})");
            return valeurParDefaut;
        }

        return int.Parse(saisie); // version "seance 1" : suppose une saisie correcte
    }
}
