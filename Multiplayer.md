This file presents the current work regarding multiplayer for this project.
# Goal
The objective of the multiplayer is to connect two sessions, AR and VR, such that they can communicate to have interactive elements in one session that change the other session's environment.
# First ideas
## Multiplayer
While reading Unity's documentation for multiplayer I got introduced to "Netcode for GameObjects" (NfGO for further references) and decided to explore this package and to do its tutorial.
## Scene management
After the introduction to multiplayer, I decided to explore scene management since the architecture of the project had two distinct scenes, and I needed a way for the 2 players to choose whether they wanted to play the VR or AR session, and send them to the right scene after that.
# First Problems
## Scene management
NfGO has a built-in scene management solution so I decided to try it at first. However, it turns out that this solution only works for a one-scene-at-a-time kind of project. It means that when changing a scene with the NfGO solution, every session connected to the server will have its scene changed.
This behavior is not suitable for this project, as the players are meant to enter a different scene from one another at the beginning of the game and, most importantly, stay in it for the entire duration of the game.
## Player object
Traditionally, in NfGO, we assign a PlayerObject Unity prefab to the network manager, which is then spawned for every session connected. This prefab is however not already placed in the scene and identical for every session.
This behavior is, again, not suitable for this project because the PlayerObject vary between the AR and VR session, notably, at that time I knew that the AR player prefab has a flashlight in the camera rig, which was not in the VR player. Thus, I could not use the traditional way of dealing with PlayerObject and had to come up with my own.
## Regular objects with Network Behavior
Some objects like the fuse box had to be spawned with NfGO methods because it would communicate to the other session. however, this proved to be a problem related to the scene management one, as the spawning of objects differs depending on the scene management solution.
This part was thus not a priority because I had to figure out the scene management beforehand.
> [!NOTE] 
> At this point in the project, it was already too late to go back and find another solution for the multiplayer managing. It also felt like I could manage it and figure out a way to make things work.
# Workarounds | Current state
> [!NOTE]
> The following is what I was able to come up with after a **lot** of trial and errors

> [!NOTE]
> You will find the relevant code in [this file](https://github.com/xr20241/final-project-ctrl-s-to-save/blob/multi/Assets/MainMenu/Scripts/PlayerSpawning.cs)
## Player Object
I decided assign two different PlayerObjects in the NetworkManager as public variables. Due to how the player object spawning work, I had to force the first player to go on the VR scene and the second on the AR scene for things to work properly. When a session connects, the server receives an event and spawns the right player object on the right scene with the right ownership. 
## Scene management | Objects spawning
On the current state, the scene management does not work properly. What I figured out was that the server needs to loads every scenes additively to be able to spawn the objects correctly. As of the current state, the server loads the two scenes additively and spawns the objects at startup. Then, when a client connects, it is redirected to the right scene.
However, the problem appears when any session connects. When a scene is loaded in single mode, **every** network object is moved on that scene. It means that when both the sessions are connected, the VR session gets every object on the VR scene and the AR session gets every objects on the AR scene.
# Future work
The problem obviously resides in the scene management solution. For future work, one should either drop NfGO and try to find an other multiplayer solution, or explore complex custom scene management. One should also think about how to make the right objects communicate between each other (Fuse box in AR scene and Lights in VR scene), which should be relatively easy by using RPCs in NfGO. As I could not test it, I did not bother trying to implement it.
