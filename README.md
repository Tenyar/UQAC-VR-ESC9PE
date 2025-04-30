# UQAC-VR-ESC9PE
Projet de réalité virtuelle pour la session d'**hiver 2025** à l'**UQAC**


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
- public void recordItemInteraction(GameObject reference, string itemName) ---> Ajoute un object sélectionné dans le journal du joueur.
```

### Classe InteractableItem
```
public class InteractableItem : MonoBehaviour
```
Cette classe sert à ajouter chez un model 3D une couche interactif. Elle permet à un joueur de sélectionner l'objet, ajoutant un effet de surlignement avec des variables paramétrables dans l'éditeur :
```
    public string itemName;
    public bool isAnomaly;
```
### Classe Player
```
public class Player : MonoBehaviour
```
Cette classe définie le **joueur**, qui contient :
```
- Des points de vie (Health) : int
- Un journal contenant les choix du joueur : List<InteractableItem>
```
### Classe VRPlayerInteraction
```
public class VRPlayerInteraction : MonoBehaviour
```
Cette classe permet l'implémentation de l'appel à la méthode ```item.registerInteraction();``` de la classe **InteractibleItem** par le raycast et l'action d'un TriggerAction.

### Classe VRPlayerOnSelected
```
public class VRPlayerOnSelected : MonoBehaviour
```
Cette classe permet l'implémentation de l'appel à la méthode ```selectedComponent.OnSelected();``` de la classe **OnSelectedMain** et de ses enfants.

### Classe OnSelectedMain
Cette classe est un squelette (avec méthode abstraite) permettant l'implémentation de fonctionnalités personnalisées à chaque objet sélectionnable.
La méthode ```public virtual void OnSelected()``` est une méthode abstrait de la classe parent qui permet à l'enfant de définir une logique une fois sélectionné.
