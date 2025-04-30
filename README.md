# UQAC-VR-ESC9PE
Projet de réalité virtuelle pour la session d'hiver 2025 à l'UQAC


## Documentation 

### Classe GameManager
```
public class GameManager : MonoBehaviour
```
Cette classe sert pour la majorité du gameplay et de la logique du jeu.
Il a comme méthode principale les suivantes :
```
- private void initPlayerStatus() ---> Qui initialise la vie et autres paramètres du joueur
- public bool checkPlayer() ---> Qui vérifie les choix du joueur et retourne vrai ou faux si il a réussit un niveau
- public void finishLevel(string sceneName) ---> Qui permet un retour au lobby
```
