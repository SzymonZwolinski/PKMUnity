<h2>PKMUnity</h2>
PKMUnity is my first attempt at creating classic GBA like RPG.<br>

<h2>Introduction</h2>
With PKMUnity, I wanted to fullfill my childhood dream of creating a classic turn-based RPG game. 

> [!NOTE]
> This repository contains only code, with a few abstract class implementations. 

<h2>Technologies</h2>
- <strong>Unity</strong>: Game engine.<br>
- <strong>Newtonsoft Json Unity Package</strong>: Serialize and Deserialize trival implementation of saves.<br>

<h2>Project specifications</h2>
<h3>Movement and camera</h3>
The game is three-dimensional with third person camera. Player can move his controlled model, with the keyboard by pressing "W" to move forward, "S" to move backwards, "A" to rotate model to the left, "D" to rotate model to 
the right. Player movement speed can be increased by pressing the "Shift" key. While holding "Scroll" button on the mouse, player can rotate the camera around the playable model. <br>
<h3>Scenes</h3>
- Main Menu<br>
- Adventure Scene (v1 in Enum)<br>
- Battle Scene (battleScene in enum)<br><br>
In the adventure scene, the player has ability to walk. By pressing the "P" button can check its team. The battle scene can be invoked by walking into "UnitSpawnFileds" with a randomized chance every step in it. In the battle scene, the player can:<br>
- Choose 1 of max 4 attacks availible to the player unit that is in battle <br>
- Change current unit in battle <br>
- Try to escape from battle <br>
- Use items <br>
- Try to capture enemy unit <br>
<br>
Every selected action end player turn and calculates the damage or chance of the player's action. The battle scene can be reverted to the adventure scene by defeating enemy unit, capturing it, or escape.
 <h3>Units, teams and enemies</h3>
In the game, each unit is distinct, possessing unique characteristics. As units level up, their statistics experience improvement. Additionally, units are equipped with a maximum of four available attacks. Units can have one or two types that represents is nature. Types are used also by attacks and during combat are used to calculate damage multipliers.<br>

![Weaknesses](https://github.com/SzymonZwolinski/PKMUnity/assets/92259367/0809e703-f5d2-44c1-98ea-84eb958dd517)

>[!TIP]
> Arrows on image means multiplyers:<br>
> ${\color{red}Red - x0.5}$<br>
> ${\color{green}Green - x2}$<br>
> ${\color{black}Black - x1}$<br>
>Fire type attack on water unit does 0.5 of its damage.<br>
>Wind type attack does 0.75 of its damage on Water-Earth typed unit.

>[!NOTE]
>Units models should be placed in the Resources folder and linked to their corresponding units property.

The player is limited to a team size of six units. When the player's team exceeds this limit, units are automatically sent to storage. Notably, the initial unit in the player's team is always the "FireElemental" added at the start of the game. <br>

During combat scenarios, enemy units adhere to the same rules as player units. Importantly, each player action in combat may be either preceded or followed by a turn from an enemy unit.<br>

<h2>Units, items and attacks factory</h2>
Every implementation of Units, items, or attacks should also be added to the corresponding enum. Creating new kind of abstract classses is implemented as static factory pattern. Directories contains enum name of implementacion and a delegate to initalizing methods. 

