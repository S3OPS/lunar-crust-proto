# MIDDLE-EARTH ADVENTURE RPG — Dummy-Proof Setup (Windows)

## One Command Install
Open PowerShell inside the repo and run:

```powershell
powershell -ExecutionPolicy Bypass -File .\tools\install.ps1 -AutoRun
```

On macOS/Linux with PowerShell 7+ installed:
```powershell
pwsh -ExecutionPolicy Bypass -File ./tools/install.ps1 -AutoRun
```

## What It Does
- Creates a local config in `%LOCALAPPDATA%\MiddleEarthRPG`
- Copies the RPG game config
- Creates a launcher script
- Launches Unity Hub (if installed)

## Run Later
```powershell
powershell -ExecutionPolicy Bypass -File "$env:LOCALAPPDATA\MiddleEarthRPG\run.ps1"
```

## Open in Unity
1. Open Unity Hub
2. Add the project folder
3. Open the project
4. **⚠️ IMPORTANT: Open the Main scene**
   - In Unity, go to `Assets/Scenes` in the Project panel (bottom)
   - Double-click **Main.unity** to open it
   - The Hierarchy panel (left) should show game objects like "World Builder", "Player", etc.
   - If you only see "Main Camera" and "Directional Light", you're in the wrong scene!
5. Press **Play** (▶️ button at top center)

## Controls
- **WASD**: Move your character
- **Mouse**: Look around
- **Shift**: Sprint
- **Space**: Jump
- **Walk into objects**: Interact with NPCs, chests, and locations

## Gameplay Guide
### Getting Started
1. Start in the center of Middle-earth
2. Check your HUD (top-left) for active quests and character stats
3. Walk to The Shire (green area, southwest) to begin your adventure

### Completing Quests
- **The Shire's Burden**: Collect Lembas Bread from chests and explore the Old Forest
- **Fellowship of the Ring**: Find and talk to Gandalf, Legolas, and Gimli
- **Riders of Rohan**: Travel to the golden plains and defeat Orc Scouts
- **The Path to Mordor**: Venture into the dark lands and face the ultimate challenge

### Tips
- Defeating enemies grants experience and gold
- Opening treasure chests rewards you with items and gold
- Discovering new locations grants bonus experience
- Level up to increase your stats and become more powerful
