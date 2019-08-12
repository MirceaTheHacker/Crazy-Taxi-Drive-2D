# Crazy-Taxi-Drive-2D

2D RACING GAME – CRAZY TAXI RIDE  
Contents of the game:  
CAR – WHEELS (rotations are already made, need to see the interaction with the terrain how adaptable is it), BODY PART (will move according to the suspension effect of the car, therefore will need to make it as natural as possible), STEARING WHEEL (will be static, no need to edit it), EXHAUST PIPE WITH SMOKE (starts smoking only when player starts the engine with W. More smoke on the exhaust pipe when player presses accelerates with W. Less smoke from the pipe when player only breaks or just stays with the engine running), HEADLIGHTS (must light when starting the engine. Starting the engine will be made with W), DRIVER (only the head, to be moved when climbing and stuff according to the proper law of physics. When the head will hit the floor, the game restarts at the last checkpoint). Human character to be taken with the taxi.  
Other contents:  
Rocks, Lava, moving terrains (like static line images), button to press on the bridge such that it can move to you, a small elevator door to be opened when bridge line arrives at the car. LIGHTS for headlights, SMOKE effect for exhaust pipe. Grass for the terrain that is not doing anything, only for design. STRIPES FOR THE TAXI. Another human character to be taken by the taxi.
COLORS and background:  
The car will be yellow as a taxi. The background will be with clouds and sunshine and a city on the back. The terrain itself will a static grey asphalt.   

CHECKPOINTS:  
At a distance span of 50meters, converted to units, there will be a RESPAWN point with a flag. When the checkpoint is passed, the state of the game is saved into that point and player can return only on that checkpoint. The number of checkpoints made are limited, based on the user’s remaining lives. There will be 5 LIVES in a shape of hearts for the user. A COMPLETED LEVEL WILL BE SAVED AS THE LAST INSTANCE OF THE GAME WHEN IS CROSSED.

TERRAIN:  
The field will need to be challenging, but also easy to understand and doable. First state of the GAME will be with basic terrain (up hill and down hill). Need to check how the car operates with the physics first. The second state of the game will contain more steep environment, to make the game more challenging. The states of the game that I am talking about right now are actually levels in the game.  

LEVELS:  
We will make 5 levels in total. The first level will be with a basic terrain (uphill and downhill, only to test the physics of the game). A level will be completed once the FINISH FLAG is crossed. The second level will be with more steep terrain, checking the logical part of the brain of the player. The third level of the game will be with rocks and shit that are moving to destroy your head. The forth level will be with elevators and moving terrains in order to trick you to enter in the lava or something like that. The fifth and final level will be with all of the above in order to be the most challenging.  
DISTANCE OF THE LEVELS:  
The average distance of the level is 300 meters. That means, on average the player will need to cross 6 checkpoints in order to finish a level. Once the FINISH flag is crossed, a CONGRATS message is shown and player will move to the next level, that means a new state of the game, with the car starting from the left corner.  


