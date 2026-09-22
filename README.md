# Mini-GLPI — corrections des séances 1 et 2

Correction complète des TP des deux premiers supports Bloc 2 :

- `02-B2-Intro-S1-Cours-TP-Syntaxe-Objets.pdf` — exercices 1 à 6
- `01-B2-Intro-S2-Cours-TP-POO.pdf` — exercices 1 à 6

Tronc commun **et** paliers Défi sont traités.

## Lancer

Le `Main` affiche un menu : séance 1 ou séance 2, puis un exercice (ou `T` pour
tous). Depuis le dossier de la solution :

```bash
dotnet run --project Seance2
```

## Organisation

```
Seance2/
├── Program.cs                     class Program + static void Main (squelette complet)
├── Seance1/                       namespace MiniGlpi.Seance1
│   ├── Materiel.cs                attributs privés, Afficher, EstARenouveler,
│   │                              AugmenterAge (exo 4.3), Diagnostic (exo 4.4)
│   ├── Imprimante.cs              exo 5 (défi) — duplication assumée, sans héritage
│   └── ProgrammeSeance1.cs        Exercice1() … Exercice6()
└── Seance2Poo/                    namespace MiniGlpi.Seance2
    ├── Materiel.cs                abstract, propriétés { get; private set; },
    │                              virtual Decrire, abstract NiveauPriorite
    ├── Ordinateur.cs              : Materiel, base(...), override
    ├── Imprimante.cs              : Materiel, EstCouleur
    ├── Routeur.cs                 bonus : prouve que la boucle foreach ne change pas
    ├── Parc.cs                    composition, Ajouter, NombreTotal, AfficherTout,
    │                              CompterARenouveler, ObtenirPrioritaires, ObtenirTous
    └── ProgrammeSeance2.cs        Exercice1() … Exercice6()
```

### Pourquoi deux namespaces

Les deux séances définissent chacune une classe `Materiel` et une classe
`Imprimante`, avec le même nom mais pas le même contenu : la séance 2 refond
celles de la séance 1 (attributs privés → propriétés, puis héritage, puis
classe abstraite). Les garder toutes les deux permet de montrer l'avant/après ;
les deux namespaces évitent la collision de noms.

## Les trois erreurs de compilation à montrer

Trois lignes sont volontairement en commentaire dans `Seance2Poo/ProgrammeSeance2.cs`.
Les décommenter en cours produit exactement l'erreur attendue — vérifié :

| Exercice | Ligne à décommenter | Erreur |
|---|---|---|
| S2 exo 1.4 | `m.Modele = "HP EliteBook";` | `CS0272` — l'accesseur set n'est pas accessible |
| S2 exo 5.3 | `new Materiel("???", "SN-00", 1)` | `CS0144` — impossible d'instancier une classe abstract |
| S2 exo 6.3 | `parc.ObtenirTous().Add(...)` | `CS1061` — `IReadOnlyList<Materiel>` ne contient pas `Add` |

## Questions rédigées

Les deux questions « à noter » / « à rédiger » sont traitées, et le programme
affiche la réponse :

- **S1 exo 6.4** — cinq variables séparées : impraticable ; il manque un
  conteneur (`List<T>`) et une boucle. → `ProgrammeSeance1.Exercice6()`
- **S2 exo 6.4** — pourquoi la lecture seule est plus sûre que la liste
  publique. → `ProgrammeSeance2.Exercice6()`

## Points de vigilance signalés en commentaire

- `virtual` côté mère **et** `override` côté fille (l'erreur la plus fréquente
  en venant de PHP)
- `virtual` propose, `abstract` impose
- `.Count` est une propriété, pas `.size()` (passerelle Java)
- l'ordre des `else if` dans le diagnostic par âge
- la ligne `stock--` qui évite la boucle infinie
- `(double)total / Count` pour éviter la division entière
- `Console.ReadLine()` peut retourner `null` : le projet a `<Nullable>enable</Nullable>`
- « au-delà de 10 000 pages » → `> 10000` et non `>= 10000` (cas limite testé)

## Notes

- `TargetFramework` : `net10.0`, SDK 10.0.400. Compile sans aucun avertissement.
- `Console.OutputEncoding = Encoding.UTF8` dans `Main` pour les accents sous Windows.
- Le `Materiel.cs` qui était à la racine du projet a été remplacé par
  `Seance2Poo/Materiel.cs` (même classe, version complète).
- `int.Parse` est conservé comme le demande la séance 1 ; une valeur par défaut
  évite juste le plantage si on valide sans rien taper. `int.TryParse` arrive en
  séance 3.
