# Visual Overview - Middle-earth Adventure RPG

This document provides a visual overview of how the game looks and its key visual features.

## Game Environment

### Main Scene Layout

The game takes place in a 3D environment with the following elements:

```
┌─────────────────────────────────────────────────────────────────┐
│  Level 1                                                         │
│  ┌──────────────────────────────┐                               │
│  │ Health:  100 / 100           │  (Red bar)                    │
│  └──────────────────────────────┘                               │
│  ┌──────────────────────────────┐                               │
│  │ Stamina: 100 / 100           │  (Green bar)                  │
│  └──────────────────────────────┘                               │
│  ┌──────────────────────────────┐                               │
│  │ XP:      0 / 100             │  (Blue/Gray bar)              │
│  └──────────────────────────────┘                               │
│                                                                  │
│                                                                  │
│                                        🔴                        │
│                                      Orc Scout                   │
│                                                                  │
│                                                                  │
│                    🔵                                           │
│                   Player                                         │
│                                                                  │
│                                                                  │
│                              🔴                                  │
│                            Orc Scout                             │
│                                                                  │
│                                                                  │
│═══════════════════════════════════════════════════════════════  │
│                      Green Grassy Ground                         │
│═══════════════════════════════════════════════════════════════  │
│                                                                  │
└─────────────────────────────────────────────────────────────────┘
```

### Color Scheme

#### Player Character
- **Color**: Blue capsule (RGB: 0.2, 0.6, 0.8)
- **Shape**: 3D capsule (0.5m radius, 2m height)
- **Position**: Starts at center of the world (0, 2, 0)
- **Camera**: Third-person camera positioned 5 units behind the player, 1.5 units above player's center

#### Enemies (Orcs)
- **Color**: Red capsule (RGB: 0.8, 0.2, 0.2)
- **Shape**: 3D capsule (0.4m radius, 1.6m height)
- **Label**: "Orc Scout" floating above enemy
- **Positions**: 
  - Orc 1: (10, 1, 5)
  - Orc 2: (-8, 1, 8)
  - Orc 3: (5, 1, -10)

#### Environment
- **Ground**: Large green plane (100m x 100m, RGB: 0.3, 0.6, 0.3)
- **Sky**: Procedural sky with horizon color (RGB: 0.64625, 0.65575, 0.67075)
- **Background**: Blue-tinted atmosphere (RGB: 0.3, 0.5, 0.7)
- **Lighting**: Directional light with shadows enabled, positioned to create natural daylight

## User Interface (HUD)

### HUD Components

The HUD is positioned in the top-left corner with the following bars:

```
┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
┃ Level 1                      ┃  ← Yellow text with black outline
┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
┃ ██████████████████ 100 / 100 ┃  ← Health Bar (Red, 300px x 30px)
┃ Health: 100 / 100            ┃
┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
┃ ██████████████████ 100 / 100 ┃  ← Stamina Bar (Green, 300px x 30px)
┃ Stamina: 100 / 100           ┃
┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
┃ ░░░░░░░░░░░░░░░░░░ 0 / 100   ┃  ← XP Bar (Gray, 300px x 30px)
┃ XP: 0 / 100                  ┃
┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
```

### Bar Specifications

1. **Level Label**
   - Font size: 24px
   - Color: Yellow (RGB: 1, 1, 0.6)
   - Outline: 4px black outline

2. **Health Bar**
   - Background: Red (RGB: 0.8, 0.2, 0.2)
   - Minimum size: 300px x 30px
   - Rounded corners (4px radius)
   - White text centered: "Health: X / Y"

3. **Stamina Bar**
   - Background: Green (RGB: 0.2, 0.8, 0.2)
   - Minimum size: 300px x 30px
   - Rounded corners (4px radius)
   - White text centered: "Stamina: X / Y"

4. **XP Bar**
   - Background: Default (gray/blue)
   - Minimum size: 300px x 30px
   - White text centered: "XP: X / Y"

## Window Settings

- **Resolution**: 1920x1080 (Full HD)
- **Display Mode**: Fullscreen (mode=2)
- **Stretch Mode**: Canvas items
- **Aspect**: 16:9

## Visual Effects

### Lighting
- **Directional Light**: Positioned at an angle to simulate sunlight
- **Shadows**: Real-time shadow casting enabled
- **Environment**: Procedural sky with automatic horizon blending

### Post-Processing
- **Glow**: Enabled for enhanced visual quality
- **Tonemap**: Filmic tonemapping (mode 2)
- **Background**: 3D sky with atmospheric effects

## Game States

### Normal Gameplay
The camera follows the player in third-person view. The player (blue capsule) can move around the green ground plane while enemies (red capsules) are visible in various positions.

### Combat
When the player attacks:
- A raycast extends 3 units forward from the player
- If it hits an enemy, damage is dealt
- Special attack (AOE) affects enemies in a radius around the player

### Navigation
- Ground has navigation mesh for AI pathfinding
- Enemies can navigate around the terrain to reach the player
- Navigation area: 100m x 100m centered at origin

## Visual Style

The game uses a **minimalist geometric style** with:
- Simple capsule meshes for characters
- Flat color materials
- Clear visual distinction between player (blue) and enemies (red)
- Clean, uncluttered UI
- Fantasy-themed color palette (greens, blues, reds)

## Planned Visual Enhancements

Based on the repository, these visual features are planned:

1. **Quest Journal UI** - Panel for viewing active quests
2. **Inventory Panel** - Grid-based item management
3. **Dialogue System** - NPC conversation interface
4. **Day/Night Cycle** - Dynamic lighting changes
5. **Weather Effects** - Rain, snow, fog
6. **Treasure Chests** - Loot containers
7. **Boss Encounters** - Unique enemy designs
8. **Achievement Notifications** - Pop-up alerts

## Controls Visual Feedback

While not directly visible in the scene, the game responds to these controls:

- **WASD**: Character movement (player capsule moves across ground)
- **Mouse**: Camera rotation around player
- **Shift**: Sprint (stamina bar drains, character moves faster)
- **Space**: Jump (player capsule lifts off ground)
- **Left Mouse**: Attack (brief animation/effect toward enemy)
- **Right Mouse**: Special AOE attack (area effect around player)
- **I/C/J/M**: Toggle UI panels (when implemented)
- **ESC**: Pause/Release mouse

## Technical Notes

### 3D Rendering
- **Engine**: Godot 4.3 (Forward+ rendering)
- **Physics**: 3D physics with collision layers
  - Layer 1: Environment
  - Layer 2: Player
  - Layer 3: Enemies
  - Layer 4: Interactables
  - Layer 5: Projectiles

### Performance
- Target: 60 FPS at 1920x1080
- Simple geometry for optimal performance
- Efficient physics collision detection

---

**Note**: This game is currently in active development. The visual design is intentionally simple during the prototype phase, with plans for enhanced graphics, models, and effects in future releases.
