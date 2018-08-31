# BGJ-Game
My team's Brackeys Game Jam entry for August 2018.

A sample scene is provided. When creating new ones, please create a new scene.

## Types of objects
Objects can be found in the Prefabs folder.

### Player
Self-explanatory. There should only be one in the scene.

### Walls and floor
Put them in first.

### Obstacles
There are two types of obstacles: normal obstacles that act like walls and moving platforms.
You can place normal obstacles as usual, however, moving platforms require some configuration. Select a moving platform you spawned in,
and in the inspector, scroll down and you should see "Moving Platform Script". Configure the left bound and right bound. How you get
the X and Y values for that is up to you.

### Light detectors and levers
There are three types of light detectors and levers; moving ones, rotating ones and toggling ones.
Colored light detectors will only react to light of their own color. 
White light detectors detect any color of light.

To activate a lever, hover over it and press E.
To activate a light detector, light must be shone over it.

After placing them, configure the objects that should be influenced by them, as well as the desired rotation/position values or state in which the light should be when the switch is off in case you are using a toggle.

### Light sources
Place them anywhere and rotate them however you want. When you fire up the game, they will shine light forwards.
You can set their color in the inspector.
The player's goal is to get that light to an end goal using portals.

### Win detectors
You can place a win detector anywhere in the scene.
If light illuminates it, the player wins the level.

### Portals
Portals will be spawned by code. Do **NOT** spawn them in manually.


## Controls
WASD/Arrow keys to move around.
Left/right click to spawn portals.
To use levers, hover over them and press E.
