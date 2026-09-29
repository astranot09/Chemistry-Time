# Chemistry Time

<img width="320" height="180" alt="Timeline 1sdsd" src="https://github.com/user-attachments/assets/c1c3374f-c620-4d3e-b5e5-beb2422e1fd4" />
<img width="320" height="180" alt="Timeline 12222" src="https://github.com/user-attachments/assets/62d261ef-0219-49c2-9d90-ff4af93f8de7" />







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

### Farming & Harvesting
Press E to interact with agricultural crops to harvest raw organic resources into your inventory.

### Element Extraction
Process harvested plants using the Extractor machine to yield raw elements ($C$, $H$, $O$, $N$).

###  Compound Synthesis (Combiner)
Combine raw elements at the Combiner station to craft required compounds (e.g., combining $H_2$ and $O$ to synthesize $H_2O$).

### Formula Combat System
Cycle through available chemical formulas and fire projectiles using Space. Correct formula matches deal fatal damage to targeted enemies!

### Active Skills
Deploy defensive Shields (Q) or trigger devastating elemental Nukes (F) when overwhelmed by enemy waves.

### Hydration Survival
Monitor your Water Bar constantly; running out of water or health triggers a game-over condition.

## Layer / Module Design

<img width="2147" height="822" alt="ChemistryTimeModule drawio" src="https://github.com/user-attachments/assets/ab6a6ca9-2af2-428f-ab6d-d9db80ab0408" />

## Modules and Features

| Name | Scene | Responsibility |
| :---: | :---: | :---: |
| Scene Controller | All Scene | Scene transitions, load screens, exit game. |
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
