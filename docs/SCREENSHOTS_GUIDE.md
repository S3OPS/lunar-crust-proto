# Screenshots Guide - What The Game Looks Like

This document provides detailed descriptions of what you'll see when playing Middle-earth Adventure RPG. While the game is best experienced by running it yourself, this guide gives you a clear picture of the visual experience.

## Quick Note

> **Want to see it yourself?** Follow the [Getting Started Guide](GETTING_STARTED.md) to download Godot 4.3 and run the game. It takes less than 5 minutes to set up!

---

## Table of Contents

1. [Main Game View](#main-game-view)
2. [Player Character](#player-character)
3. [Enemy Encounters](#enemy-encounters)
4. [HUD (Heads-Up Display)](#hud-heads-up-display)
5. [Combat Visuals](#combat-visuals)
6. [Movement & Controls](#movement--controls)
7. [Planned UI Features](#planned-ui-features)

---

## Main Game View

### When You First Launch

When you press F5 in Godot or run the exported game, you'll see:

**Environment:**
- A large, flat **green grassy plain** stretching 100 meters in all directions
- A **beautiful blue sky** with realistic atmospheric effects and horizon blending
- Realistic **lighting** from a directional sun that casts dynamic shadows
- The entire scene has a Middle-earth fantasy atmosphere

**Starting Position:**
- You spawn in the center of the world as a **blue capsule character**
- Three **red enemy orcs** are positioned around the world at various distances
- Your camera is positioned behind and above your character in third-person view

### Scene Layout

```
        🌤️ Sky (Blue-tinted with procedural clouds)
        
                    🔴 Orc Scout
                 (10m east, 5m north)


    🔴 Orc Scout                               🔵 YOU
 (-8m west, 8m north)                    (Center of world)
                                         
                                         Camera→ 🎥
                                         (5m behind you)

            🔴 Orc Scout
         (5m east, 10m south)


━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
         Green Grassy Terrain (100m × 100m)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
```

---

## Player Character

### Visual Appearance

**Shape:** 3D Capsule (cylinder with rounded ends)

**Color:** Bright Blue
- Exact color: Light Blue with cyan tint
- RGB values: (0.2, 0.6, 0.8)
- Stands out clearly against the green terrain

**Size:** 
- Height: 2 meters (about 6'7")
- Radius: 0.5 meters (about 1'8" wide)

**Shading:**
- Uses standard PBR (Physically Based Rendering) material
- Responds realistically to the directional sunlight
- Casts real-time shadows on the ground

### Camera View

The camera follows you in **third-person perspective**:
- Positioned 5 meters behind your character
- Elevated 1.5 meters above your center point
- **Mouse movement** rotates the camera smoothly around you
- The camera pivots around your character, letting you see all angles

---

## Enemy Encounters

### Orc Scouts

**Appearance:**
- **Shape:** 3D Capsule (slightly smaller than player)
- **Color:** Dark Red/Crimson (RGB: 0.8, 0.2, 0.2)
- **Size:** 
  - Height: 1.6 meters (about 5'3")
  - Radius: 0.4 meters (slightly narrower than player)

**Identification:**
- Each orc has a **floating label** above its head
- Label text: "Orc Scout"
- The label:
  - Always faces the camera (billboard effect)
  - Has a black outline for readability
  - Stays visible through walls (no depth testing)
  - Hovers 1.2 meters above the orc's center

**Behavior (Visually):**
- Orcs stand idle when far away
- When you get close, they **turn to face you**
- During combat, they **move toward you** using pathfinding
- Their color makes them stand out against the green environment

### Enemy Positions at Start

1. **Orc 1:** To your right and slightly forward (10, 1, 5)
2. **Orc 2:** To your left and behind (−8, 1, 8)
3. **Orc 3:** To your right and far back (5, 1, −10)

---

## HUD (Heads-Up Display)

The HUD appears in the **top-left corner** of your screen. It's always visible and updates in real-time.

### Level Display

```
┌─────────────┐
│  Level 1    │  ← Large yellow text
└─────────────┘    Black outline, 24px font
```

### Health Bar

```
┌────────────────────────────────┐
│ ██████████████████████ 100/100 │  ← Red bar (fully filled)
│      Health: 100 / 100         │
└────────────────────────────────┘
   300px wide × 30px tall
   Rounded corners (4px)
```

- **Color:** Red (RGB: 0.8, 0.2, 0.2)
- **Text:** White, centered
- **Updates:** Real-time as you take damage
- **Full:** Bar is completely filled at 100%
- **Empty:** Bar empties from right to left as health decreases

### Stamina Bar

```
┌────────────────────────────────┐
│ ██████████████████████ 100/100 │  ← Green bar (fully filled)
│     Stamina: 100 / 100         │
└────────────────────────────────┘
   300px wide × 30px tall
   Rounded corners (4px)
```

- **Color:** Green (RGB: 0.2, 0.8, 0.2)
- **Text:** White, centered
- **Updates:** Drains when sprinting (Shift) or using special attack
- **Regenerates:** Slowly refills when not sprinting

### Experience (XP) Bar

```
┌────────────────────────────────┐
│ ░░░░░░░░░░░░░░░░░░░░░░ 0/100   │  ← Gray/Blue bar (empty at start)
│        XP: 0 / 100             │
└────────────────────────────────┘
   300px wide × 30px tall
```

- **Color:** Default theme color (blue-gray)
- **Text:** White, centered
- **Updates:** Fills as you gain experience from defeating enemies
- **Level Up:** Resets to 0 when you level up

### Complete HUD Layout

```
┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
┃ Level 1                        ┃
┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
┃ ████████████████████ 100 / 100 ┃ ← Health (Red)
┃ Health: 100 / 100              ┃
┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
┃ ████████████████████ 100 / 100 ┃ ← Stamina (Green)
┃ Stamina: 100 / 100             ┃
┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
┃ ░░░░░░░░░░░░░░░░░░░░   0 / 100 ┃ ← XP (Gray)
┃ XP: 0 / 100                    ┃
┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
```

This HUD occupies approximately the top-left 320×170 pixels of your 1920×1080 screen.

---

## Combat Visuals

### Basic Attack (Left Mouse Button)

When you click the left mouse button:

1. An **invisible raycast** shoots forward 3 meters from your character
2. If it hits an enemy, that enemy:
   - Takes damage
   - Their health bar would decrease (if visible)
   - May be knocked back slightly
3. The attack has **no visible projectile** (it's instant melee range)

### Special AOE Attack (Right Mouse Button)

When you click the right mouse button:

1. Requires **30 stamina** (stamina bar must have at least 30)
2. Your **stamina bar drops by 30** instantly
3. All enemies within a **certain radius** around you take damage
4. This is an "Area of Effect" attack hitting multiple enemies at once

### Visual Feedback During Combat

**Your Health Bar:**
- Drops when enemies attack you
- Bar empties from right to left
- Text updates: "Health: 75 / 100" (for example)

**Your Stamina Bar:**
- Drains when sprinting
- Drains by 30 when using special attack
- Slowly regenerates (green bar refills from left to right)
- Text updates: "Stamina: 70 / 100" (for example)

**Enemy Behavior:**
- Orcs move toward you when you're in range
- They navigate around the terrain using AI pathfinding
- Red color makes it easy to track them

---

## Movement & Controls

### Walking (WASD)

- **W:** Move forward (character moves in camera's forward direction)
- **S:** Move backward
- **A:** Strafe left
- **D:** Strafe right
- Your **blue capsule** smoothly glides across the green terrain
- The **camera** follows behind you automatically

### Sprinting (Hold Shift)

When holding Shift while moving:
- Your movement speed **increases noticeably**
- Your **stamina bar (green) drains** continuously
- The stamina bar text updates in real-time
- When stamina reaches 0, you stop sprinting
- Stamina regenerates when you release Shift

Visual cue: Watch the green stamina bar decrease as you sprint!

### Jumping (Space)

- Press Space to **jump**
- Your capsule **lifts off the ground**
- Follows a realistic physics arc
- Lands back on the green terrain
- Multiple jumps are possible (no double-jump limit currently)

### Camera Control (Mouse)

- Move mouse to **look around**
- Camera **orbits** smoothly around your character
- You can see yourself from any angle
- The mouse cursor is **captured** (invisible and locked)
- Press **ESC** to release the mouse cursor

---

## Planned UI Features

The following UI elements are scripted but their scene implementations are in progress:

### Quest Journal (Press J)

**Planned appearance:**
```
┌─────────────────────────────────────┐
│  📜 Quest Journal                   │
├─────────────────────────────────────┤
│  Active Quests                      │
│                                     │
│  ✓ Tutorial Quest                  │
│    - Learn basic movement           │
│    - Defeat first enemy             │
│                                     │
│  ⧗ Save the Shire                  │
│    - Talk to Gandalf                │
│    - Find missing hobbits (0/5)     │
│                                     │
│  Completed Quests                   │
│  ✓ Welcome to Middle-earth          │
└─────────────────────────────────────┘
```

### Inventory Panel (Press I)

**Planned appearance:**
```
┌─────────────────────────────────────┐
│  🎒 Inventory                       │
├─────────────────────────────────────┤
│  [⚔️] [🛡️] [💊] [ ] [ ] [ ]        │
│  [ ] [ ] [ ] [ ] [ ] [ ]        │
│  [ ] [ ] [ ] [ ] [ ] [ ]        │
│  [ ] [ ] [ ] [ ] [ ] [ ]        │
│                                     │
│  Gold: 0                            │
└─────────────────────────────────────┘
```

### Character Sheet (Press C)

**Planned appearance:**
```
┌─────────────────────────────────────┐
│  👤 Character Stats                 │
├─────────────────────────────────────┤
│  Name: Aragorn                      │
│  Level: 1                           │
│  Class: Ranger                      │
│                                     │
│  Strength:     10                   │
│  Dexterity:    12                   │
│  Intelligence: 8                    │
│  Health:       100/100              │
│  Stamina:      100/100              │
│                                     │
│  Experience: 0 / 100                │
└─────────────────────────────────────┘
```

### Dialogue System

**Planned appearance:**
```
┌─────────────────────────────────────┐
│  💬 Gandalf the Grey                │
├─────────────────────────────────────┤
│  "Greetings, traveler! I have a     │
│   quest for you. The Shire is in    │
│   danger and we need your help."    │
│                                     │
│  [Accept Quest]                     │
│  [Ask for more information]         │
│  [Decline and walk away]            │
└─────────────────────────────────────┘
```

---

## Visual Style Summary

### Color Palette

- **Player:** Blue (0.2, 0.6, 0.8) - Heroic, trustworthy
- **Enemies:** Red (0.8, 0.2, 0.2) - Danger, hostile
- **Environment:** Green (0.3, 0.6, 0.3) - Natural, calm
- **Sky:** Blue-gray (0.3, 0.5, 0.7) - Atmospheric
- **Health:** Red (0.8, 0.2, 0.2) - Life force
- **Stamina:** Green (0.2, 0.8, 0.2) - Energy
- **UI Text:** White/Yellow - High contrast, readable

### Art Style

The current visual style is **minimalist geometric**:
- Simple capsule shapes for characters
- Flat color materials (no textures yet)
- Clear visual hierarchy through color
- Focus on gameplay clarity over visual complexity
- Perfect for prototyping and testing mechanics

This style allows players to:
- ✅ Instantly distinguish player from enemies
- ✅ Clearly see their stats at a glance
- ✅ Focus on gameplay without visual distractions
- ✅ Run the game on modest hardware

### Future Visual Plans

The game will evolve to include:
- Detailed 3D character models
- Textured environments
- Particle effects for attacks
- Weather effects (rain, snow, fog)
- Dynamic day/night lighting
- Iconic Middle-earth locations
- NPC character models

---

## Taking Your Own Screenshots

Want to capture your own screenshots?

1. **Run the game** following the [Getting Started Guide](GETTING_STARTED.md)
2. **In Godot:** Press F5 to run the game
3. **Position your view:** Use WASD and mouse to frame your shot
4. **Take screenshot:** 
   - **Windows:** Win + Print Screen
   - **macOS:** Cmd + Shift + 3
   - **Linux:** Print Screen or Shift + Print Screen

Screenshots will help you:
- Share your gameplay moments
- Report bugs with visual context
- Contribute to documentation
- Track your progress through the game

---

## Summary

Middle-earth Adventure RPG features:
- **Clean, readable visuals** with good color contrast
- **Simple geometric art style** focused on gameplay
- **Clear UI** with real-time stat tracking
- **Smooth third-person camera** that follows your character
- **Atmospheric 3D environment** with lighting and shadows
- **Distinctive visual cues** to identify friends vs. foes

The game prioritizes **gameplay clarity** and **performance** over visual complexity, making it accessible to all players while still providing an immersive Middle-earth experience.

**Ready to see it yourself?** Follow the [Getting Started Guide](GETTING_STARTED.md) and experience the game firsthand in less than 5 minutes!

---

*Last updated: January 2026*
*Game version: Godot Alpha v0.3 (Phase 3 in progress)*
