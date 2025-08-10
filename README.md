# Shipwrecked Survivors
A Unity-based 2D multiplayer game where players collect shells, avoid hazards, and compete for the highest score before losing all their lives. This README explains the full functionality, code structure, and how to get started.

## Game Overview
Shipwrecked Survivors is a local multiplayer game for up to 3 players. Each player controls a character, collects falling shells, and tries to survive as long as possible. The game ends when all lives are lost, and the final and high scores are displayed.

## Gameplay
- Movement: Each player uses unique input axes to move their character around the screen.
- Collecting Shells: Players collect shells for points. Different shells can have different point values and spawn probabilities.
- Lives: Players lose a life if they miss a shell (it falls below a certain point).
- Game Over: When all lives are lost, the game displays scores and the high score.

## Project Structure
- Assets — Main game assets, scripts, prefabs, scenes, and resources.
- Scenes — Contains the main Unity scene(s).
- Assets/Scripts/ — (Scripts are in the root of Assets in this project.)
- Resources — (Empty, but used for runtime asset loading if needed.)
- Settings — Render pipeline and scene templates.
- Assets/TextMesh Pro/ — Fonts, materials, and shaders for UI text.
- docs — Documentation and web build output.

## Scripts and Core Logic
GameManager.cs
Instantiates player objects at spawn points.
Assigns player IDs and links UI elements for score display.
LogicScript.cs
Manages player score, lives, and high score.
Handles adding score, losing lives, updating UI, and triggering game over.
PlayerMovement.cs
Handles player movement based on input axes.
Supports up to 3 players with separate controls.
Flips sprite based on movement direction.
PlayerScore.cs
Tracks and updates each player's score.
Updates the UI with the current score.
PlayerLabel.cs
Displays the player number above each character.
ShellSpawnScript.cs
Spawns shells at random positions along the top of the screen.
Uses weighted random selection for different shell types.
ShellWeight.cs
Struct for defining shell prefab and its spawn weight.
ShelllMovingScript.cs
Moves shells downward.
Destroys shells that fall below a certain point and causes the player to lose a life.
ShellScript.cs
Handles shell collection by players.
Awards points, plays sound, and destroys the shell on collection.
GameObjectBoundaries.cs
Keeps player objects within the visible screen area.
GameOver.cs
Manages the game over UI.
Displays final scores and high score.
Handles game restart.

## Assets
### Sprites: Player, shells, backgrounds, and UI elements.
### Audio: Sound effects for collecting shells and losing lives.
### Prefabs: Player, shells, and other game objects.
### Animations: Player and shell movement/idle/death.
## UI and Audio
- Uses TextMesh Pro for crisp, flexible UI text.
- UI displays player scores, lives, and game over information.
- Audio feedback for collecting shells and losing lives.
## How to Run
- Open the project in Unity (recommended version: 2021.3+).
- Open the main scene in SampleScene.unity.
- Press Play to start the game.

## Controls
- Player 1: WASD (customizable in Input settings)
- Player 2/3: Custom axes (see PlayerMovement.cs)
- Collect shells, avoid missing them, and try to beat the high score!

## Extending the Game
- Add new shell types by creating new prefabs and updating ShellWeight.
- Adjust spawn rates and weights in ShellSpawnScript.
- Add new player abilities or hazards by extending the scripts.
- Customize UI and audio by replacing assets in the Assets folder.

## Credits
- Developed by DroneDealer.
- Uses Unity, TextMesh Pro, and open-source or custom assets.
- For any questions or contributions, please open an issue or pull request on the repository.
