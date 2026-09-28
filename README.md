# Chemistry Time

## About Game
Chemistry Time is a Educational game, where players must shoot targets containing the correct chemical symbol/formula (elements or compounds) matching the chemical name prompt shown on the screen.

This Game I made for Game Programming Assignment and I want to make Chemistry Game :D <br>
Game Engine = Unity 6000.0.60f1

## My Contribution
- Create Chemistry Weapon Logic
- Create all the code for game systems and features
- Animation Character, Animation UI
- Create Game Logic
- Create Tutorial Logic
- etc

## Key Features

### Farming
Press E to interact the crop. You will get 3 plant in inventory

### Extract
Press E to interact the Ekstraktor. You will extract 1 plant into C 45, H 45, O 6, N 4.

### Drink
Press E to interact the Combiner. You will change H 2, O 1 into H20

### Attack
Press the button to change the formula and Press space to summon fireball to attack the enemy. If the formula and the name is correct, the enemy will be died.

### Skill
Press Q to summon Shield. And press F to summon Nuke.

## Layer / Module Design

<img width="2147" height="822" alt="ChemistryTimeModule drawio" src="https://github.com/user-attachments/assets/ab6a6ca9-2af2-428f-ab6d-d9db80ab0408" />

## Modules and Features

| Name | Scene | Responsibility |
| :---: | :---: | :---: |
| Scene Controller | All Scene | Scene transitions, loading screens, state resets. |
| Audio Manager | All Scene | Plays BGM/SFX globally via audio database. |
| Best Score Manager | All Scene | Handles persistent high score tracking and reading/writing data to JSON. |
| Tutorial Manager | Main Menu | Controls trigger sequences and UI overlays for game tutorials. |
| Monologue Manager | Gameplay | Manages pop up monologues, animation. |
| Player Input | Gameplay | Handles input mapping for attacks, skill, movement, and interactions. |
| Player Movement | Gameplay | Handles the movements of player. |
| Player Interact System | Gameplay | Detects interactive objects in range via IInteractable. |
| Plant Script | Gameplay | Drives farming mechanics, growth stages, interaction states, and harvest conditions. |
| Extraktor Script | Gameplay | Controls element extraction from harvested plants, processing timers, and output generation. |
| Water Shop | Gameplay | Handles element combination logic to craft compounds (example, combining elements into Water). |
| Player Inventory | Gameplay | Manages storage, stacking, and retrieval of raw elements and harvested plants. |
| Chemistry Weapon | Gameplay | Handles attack charge inputs, checks inventory against chemical formulas, and instantiates valid attacks. |
| Bullet Database | Gameplay | Central database for projectile data, mapping names, chemical formulas, and element attributes |
| UI Manager | Gameplay | Manages gameplay UI screens including the formula dictionary, weapon switching, and defeat screens |
| Water Bar Manager | Gameplay | Tracks the water resource bar and triggers defeat conditions when reached 0. |
| Player | Gameplay | Handles player health, damage, taking hit reactions, and game-over state checks.|
| Enemy | Gameplay | Manages enemy damage output, health, formula match validation, and death callbacks. |
| Enemy Spawner | Gameplay | Controls timed enemy wave spawning, target randomization, and formula assignment.|

## Game Flow

<img width="2807" height="1147" alt="ChemistryTimeGameFlow drawio" src="https://github.com/user-attachments/assets/9a1e9c55-47f0-4acc-805d-c5eeec9327bf" />


## Unity Asset
- Bold UI System - DEMO
- Backgrounds-2D Game Ui backgrounds
- Free Simple 2D Cute Characters Pack (9 Characters + SVG + Prefabs)
- Free Quick Effects Vol. 1
- Free Game VFX Collection(URP)
