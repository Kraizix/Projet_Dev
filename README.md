# Projet Dev : ADOFAI

# Description :

Recréer le jeu ADOFAI ([A Dance Of Fire And Ice](https://store.steampowered.com/app/977950/A_Dance_of_Fire_and_Ice/)) en C# sur Unity et de rajouter un mode multi ou X joueurs pour s'affronter en même temps pour essayer d'avoir le meilleur score/précision.

ADOFAI est un jeu ou le joueur déplace deux planètes qui orbitent l'une autour de l'autre successivement lorsque que le joueur appuie sur une touche en étant en rythme avec la musique. A chaque input le joueur est attribué une note (allant de "Raté" à "Parfait", une note "Raté" mets fin à la partie en cours et le joueur doit donc recommencer le niveau depuis le début) pour savoir s'il a appuyé au bon moment, à la fin de chaque niveau le joueur obtient un score de précision en fonction des notes précédentes.

# Taches :

- [x] **Jeu de base**: [6]
  - [x] Page d'accueil [1]
  - [x] Déplacement du joueur [1]
  - [x] Niveau(x) [2] + Ecran de fin de niveaux avec précision [1]
  - [x] Scores du joueur (DB/fichiers) [1]
- [x] **Menu d'options** [2]
  - [x] Audio [1]
  - [x] Graphismes [1]
- [x] **Menu de création de niveau** [5]
      (sauvegarde du niveau dans un fichier ? [exemple](<![](https://i.imgur.com/U8V5dXv.gif)>))
- [x] **Importation de niveau** [2]
      qui ont été créés par les différents joueurs
- [ ] **Menu de calibration du son** [2]
      (une musique est jouée et le joueur doit taper dès qu'il entend un certain son pour calculer le décalage du son. [exemple](https://i.imgur.com/G2adO2R.gif))
- [ ] **Ajout d'options affectant le jeu** [10?]:
  - [x] Niveau en automatique[6?]
  - [x] No Fail [2]
  - [ ] Niveau de difficultés (période dans laquelle un input est valide) [2]

**Total sans multijoueur : ≈ 27 points**

- [ ] **Mode multijoueur?** [10] : les différents joueurs se connectent dans un lobby et un joueur choisit le niveau sur lequel ils vont s'affronter, le niveau se lance chez chaque joueur et quand tout les joueurs ont fini ils arrivent sur un écran de fin avec un récapitulatif du score/précision de chaque joueur.

**Total avec multijoueur : ≈ 37 points**
