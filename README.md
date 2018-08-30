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
There are two types of light detectors and levers; moving ones and rotating ones.

To activate a lever, hover over it and press E.
To activate a light detector, light must be shone over it.

After placing them, configure the objects that should be influenced by them, as well as the desired rotation/position values.

### Light sources
Place them anywhere and rotate them however you want. When you fire up the game, they will shine light forwards.
The player's goal is to get that light to an end goal using portals. (Not implemented yet, pending)

### Portals
Portals will be spawned by code. Do **NOT** spawn them in manually.


## Controls
WASD/Arrow keys to move around.
Left/right click to spawn portals.
To use levers, hover over them and press E.
