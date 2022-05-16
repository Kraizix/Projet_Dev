# Projet Dev : ADOFAI

# Description :

Recréer le jeu ADOFAI ([A Dance Of Fire And Ice](https://store.steampowered.com/app/977950/A_Dance_of_Fire_and_Ice/)) en C# sur Unity et de rajouter un mode multi ou X joueurs pour s'affronter en même temps pour essayer d'avoir le meilleur score/précision.

ADOFAI est un jeu ou le joueur déplace deux planètes qui orbitent l'une autour de l'autre successivement lorsque que le joueur appuie sur une touche en étant en rythme avec la musique. A chaque input le joueur est attribué une note (allant de "Raté" à "Parfait", une note "Raté" mets fin à la partie en cours et le joueur doit donc recommencer le niveau depuis le début) pour savoir s'il a appuyé au bon moment, à la fin de chaque niveau le joueur obtient un score de précision en fonction des notes précédentes.

# Taches :

- [x] **Jeu de base**: [6]
  - [x] Page d'accueil [1]
  - [x] Déplacement du joueur [1]
  - [x] Niveau(x) [2] + Ecran de fin de niveaux avec précision [1]
  - [ ] Scores du joueur (fichiers) [1]
- [x] **Menu d'options** [2]
  - [x] Audio [1]
  - [x] Graphismes [1]
- [x] **Menu de création de niveau** [5]
      (sauvegarde du niveau dans un fichier ? [exemple](<![](https://i.imgur.com/U8V5dXv.gif)>))
- [x] **Importation de niveau** [2]
      qui ont été créés par les différents joueurs
- [ ] **Menu de calibration du son** [2]
      (une musique est jouée et le joueur doit taper dès qu'il entend un certain son pour calculer le décalage du son. [exemple](https://i.imgur.com/G2adO2R.gif))
- [x] **Ajout d'options affectant le jeu** [10?]:
  - [x] Niveau en automatique[6?]
  - [x] No Fail [2]
  - [x] Niveau de difficultés (période dans laquelle un input est valide) [2]

**Total sans multijoueur : ≈ 27 points**

- [ ] **Mode multijoueur?** [10] : les différents joueurs se connectent dans un lobby et un joueur choisit le niveau sur lequel ils vont s'affronter, le niveau se lance chez chaque joueur et quand tout les joueurs ont fini ils arrivent sur un écran de fin avec un récapitulatif du score/précision de chaque joueur.

**Total avec multijoueur : ≈ 37 points**

# Lancer Le Projet:

- git clone
- importer le projet dans unity
- Ouvrir Le projet (Long chargement la première fois qu'on ouvre le projet pour la première fois à cause des dépendances)
- Dans l'onglet File, sélectionner "Build and run"

La résolution de base du projet est 1920x1080.

Il faut absolument build le projet, l'affichage dans l'éditeur d'unity est cassé.

# Déplacements:

Il suffit d'appuyer sur n'importe quelle touche du clavier pour lorsque la planète est sur une tuile

# Editeur de niveau:

Il faut se rendre sur la case en haut à gauche du menu principal
Pour ajouter des tuiles dans le menu principal il faut appuyer soit sur les flèches directionnelles soit sur les touches "UDRL" (Up Down Right Left)
Pour sauvegarder un niveau il faut au minimum 3 tuiles et le nom du niveau, si le bpm est à 0 il sera automatiquement monté à 80, pour charger un niveau il faut mettre le nom du fichier à charger dans l'input du level name.
Pour jouer un niveau il faut au minimum 3 tuiles et le nom du niveau

L'emplacement de tous les niveaux de l'éditeur sont, seront et doivent être à cet emplacement :
`C:\Users\%USER%\AppData\LocalLow\DefaultCompany\Adofai`

# Différents modes de jeu:

Le mode automatique joue le niveau automatiquement en essayant d'avoir une précision parfaite (ça marche pas tout le temps)

Le mode no fail passe automatiquement à la prochaine case lorsqu'on l'a loupé

On ne peut pas combiner les 2 modes et il faut les activer dans les paramètres dans le menu principal

Le slider "Accuracy" permet de modifier la distance maximale pour valider l'input (plus c'est faible plus c'est dur)
