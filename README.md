# PuzzleDefender

A 2D tower defense style game built in Unity where enemies spawn and march toward a goal. Your job is to stop them before they get there.

---

## How to Play

### Objective
Prevent enemies from reaching the green goal on the right side of the grid. You start with 3 lives. Every enemy that reaches the goal costs you 1 life. Lose all 3 and the game is over.

### Controls
| Input | Action |
|---|---|
| Arrow Keys / WASD | Move the player |
| Mouse Click on Enemy | Destroy the enemy (+10 score) |

### How to Destroy Enemies
- Move your mouse over an enemy — it flashes **white** to show it is clickable
- **Left click** it to destroy it and earn **+10 score**
- If you miss and the enemy reaches the green goal, you lose **1 life**

### How to Lose
- Let 3 enemies reach the goal without clicking them
- Lives count down: 3 → 2 → 1 → 0
- When lives hit 0 the game freezes — **Game Over**

---

## Game Objects

| Object | Color | Description |
|---|---|---|
| Player | Blue | Controlled by the player using arrow keys |
| FastEnemy | Yellow | Spawns first, moves at speed 2 |
| TankEnemy | Purple | Spawns every 3rd wave, moves at speed 1, bigger |
| Goal | Green | Right side of the grid — enemies march toward this |
| SpawnPoint | Left edge | Where all enemies appear |
| Grid Tiles | Gray | 7x7 grid that forms the game board |

---

## Enemy Behaviour

Enemies spawn at the left edge of the grid and automatically find the nearest target tagged `Target`. They move in a grid-based pattern — horizontal movement first, then vertical — until they reach the goal.

- A new enemy spawns every **4 seconds**
- Every **3rd enemy** is a TankEnemy, the rest are FastEnemies
- Enemies flash white when hovered to indicate they are clickable

---

## Scoring

| Action | Points |
|---|---|
| Click and destroy an enemy | +10 |

Score is displayed on screen via the UI and tracked by the GameManager.

---

## Project Structure

```
Assets/
├── Prefabs/
│   ├── FastEnemy.prefab
│   ├── TankEnemy.prefab
│   └── Tile Prefab.prefab
├── Scenes/
│   └── MainScene.unity
└── Scripts/
    ├── Core/
    │   ├── Character.cs        — Abstract base class for Player and Enemy
    │   ├── GameManager.cs      — Singleton, manages score, lives, game over
    │   └── UIManager.cs        — Updates score and lives text on screen
    ├── Enemy/
    │   ├── Enemy.cs            — Base enemy class, movement, click to kill
    │   ├── FastEnemy.cs        — Fast enemy subclass (speed 2, yellow)
    │   ├── TankEnemy.cs        — Tank enemy subclass (speed 1, purple)
    │   ├── IEnemyState.cs      — State pattern interface
    │   ├── MoveState.cs        — Grid-based movement logic
    │   └── IdleState.cs        — Idle state, enemy does nothing
    ├── Grid/
    │   └── GridManager.cs      — Generates the 7x7 grid, exposes edge positions
    ├── Patterns/
    │   └── EnemyFactory.cs     — Factory pattern, spawns enemies continuously
    └── Player/
        └── Player.cs           — Handles player movement input
```

---

## Programming Concepts Used

### Object Oriented Programming
- `Character` is an abstract base class inherited by both `Player` and `Enemy`
- `Enemy` is further inherited by `FastEnemy` and `TankEnemy`
- Each subclass overrides `Start()` to set its own speed, color and size

### Design Patterns

**Singleton — GameManager**
Only one GameManager exists at a time. Any script can access it via `GameManager.Instance` without needing a reference.

**Factory — EnemyFactory**
The EnemyFactory decides which enemy type to create and handles all spawning logic. The rest of the game never calls `Instantiate` directly for enemies.

**State — IEnemyState**
Enemies have a current state that controls their behaviour each frame. `MoveState` moves the enemy toward the goal. `IdleState` does nothing. States can be swapped at runtime.

### Algorithms

**Searching — FindNearestTarget()**
When an enemy spawns it loops through all GameObjects tagged `Target`, calculates the distance to each one and picks the closest. This is a linear search with O(n) complexity where n is the number of targets.

**Pathfinding — MoveState**
Enemies move in a grid-based pattern. Each frame the difference between the enemy position and target position is calculated. If the X difference is greater the enemy moves horizontally, otherwise it moves vertically. This gives structured step-by-step movement rather than diagonal movement.

---

## Setup Requirements

- Unity 2022 or later
- Universal Render Pipeline (URP) 2D
- TextMeshPro (included with Unity)

### Scene Setup Checklist
- `GridManager` GameObject with `Tile Prefab` assigned
- `EnemyFactory` GameObject with `FastEnemy` and `TankEnemy` prefabs assigned
- `SpawnPoint` GameObject in the scene
- `Goal` GameObject in the scene tagged `Target`
- `GameManager` GameObject in the scene
- `Player` GameObject in the scene
- `UIManager` GameObject with `Score Text` and `Lives Text` assigned
- `FastEnemy` and `TankEnemy` prefabs each have a `Circle Collider 2D` component (Is Trigger OFF)

---

## Known Limitations

- No restart button — to replay, stop and press Play again in the Unity Editor
- Player cannot physically block enemies — click enemies to destroy them instead
- No audio or animations

---

*Built with Unity — PuzzleDefender*
