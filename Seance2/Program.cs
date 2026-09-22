using System;
using System.Text;

// ---------------------------------------------------------------------------
// MINI-GLPI -- Correction des seances 1 et 2
//
//
// Organisation du projet :
//   Seance1/      la version "seance 1" : attributs prives, pas d'heritage
//   Seance2Poo/   la version "seance 2" : proprietes, heritage, collections
//
// Les deux seances definissent chacune une classe Materiel et une classe
// Imprimante -- avec le meme nom, mais pas le meme contenu, puisque la seance 2
// refond celles de la seance 1. Elles sont donc rangees dans deux NAMESPACES
// differents (MiniGlpi.Seance1 et MiniGlpi.Seance2) : c'est exactement a cela
// que servent les namespaces, eviter les collisions de noms.
// ---------------------------------------------------------------------------
class Program
{
    static void Main(string[] args)
    {
        // Sans cette ligne, les accents s'affichent de travers dans la console
        // Windows. Ce n'est pas au programme, mais cela rend la sortie lisible.
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Projet MiniGlpi -- pret.");

        bool continuer = true;

        while (continuer)
        {
            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine(" MINI-GLPI -- corrections");
            Console.WriteLine("==================================================");
            Console.WriteLine("  1 - Seance 1 : premiers pas, syntaxe et objets");
            Console.WriteLine("  2 - Seance 2 : programmation orientee objet");
            Console.WriteLine("  0 - Quitter");
            Console.Write("Votre choix : ");

            string choix = Console.ReadLine() ?? "0";

            switch (choix.Trim())
            {
                case "1":
                    // Le namespace complet, pour bien montrer d'ou vient la classe.
                    MiniGlpi.Seance1.ProgrammeSeance1.Lancer();
                    break;

                case "2":
                    MiniGlpi.Seance2.ProgrammeSeance2.Lancer();
                    break;

                case "0":
                    continuer = false;
                    break;

                default:
                    Console.WriteLine("Choix inconnu : tapez 1, 2 ou 0.");
                    break;
            }
        }

        Console.WriteLine("Au revoir.");
    }
}
