# Astrododge

Astrododge is a 3D survival game built in Unity where the player must avoid incoming enemy robots while managing health and score over time.

## Gameplay Overview

The player controls a spinning UFO navigating within a block-based arena. Spherical enemy robots continuously move toward the player. Survival time determines score.

- Enemies deal damage on collision
- Player health decreases on impact
- Game ends when health reaches zero
- Score increases the longer the player survives

## Core Mechanics Implemented

- Player movement and camera control
- Enemy tracking and movement logic
- Collision-based damage system
- Health system with game-over condition
- Time-based scoring system
- Restart functionality

## Controls

- Movement: WASD / Arrow Keys  
- Camera: Mouse  

## Technical Highlights

- Scripted enemy pursuit behavior
- Modular damage system
- Organized prefab structure
- Clean game loop (Start → Survive → Game Over → Restart)

## Future Improvements

- Sound effects and feedback polish
- UI enhancements
- Difficulty scaling over time

## Built With

- Unity
- C#
