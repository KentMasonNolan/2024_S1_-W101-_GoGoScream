
# Go Go Scream

## Overview

Welcome to the GoGoScream! Our car game where you drive faster the louder you scream. This game is developed using Unity and Photon for the multiplayer networking. Players can join lobbies, choose their cars, and race against each other in real-time.

## Table of Contents

1. [Features](#features)
2. [Installation](#installation)
3. [Usage](#usage)
4. [Game Mechanics](#game-mechanics)
6. [License](#license)

## Features

- Real-time multiplayer racing using Photon.
- Customizable cars for each player.
- Easy-to-join lobbies.
- Smooth and responsive controls.

#### Not suitable for libraries.

## Installation

### Prerequisites

- [Unity](https://unity.com/) (version 2020.3 or later recommended)
- [Photon Unity Networking (PUN)](https://assetstore.unity.com/packages/tools/network/pun-2-free-119922)

### Steps:

1.  Open the project in Unity.
2.  Import the Photon Unity Networking (PUN) package from the Unity Asset Store.
3.  Set up your Photon account and configure the Photon settings in Unity:
    -   Go to `Window` > `Photon Unity Networking` > `Photon Server Settings`.
    -   Enter your App ID from the Photon Dashboard. 
	    (b4a463e7-2687-4a37-9630-d2e2a82bf2a2)


## Usage

### Running the Game

1.  Open the `StartMenu` and hit the Play button in the Unity Editor.
2.  Follow the prompts for either online or offline play.
3.  Scream. 

### Controls

- Tilt controls are available on iPhone
- OnScreen joystick is avilable
- Scream to accelerate

## Game Mechanics

### Lobby System

-   Players can create or join lobbies using a unique lobby name.
-   The lobby creator automatically becomes the host.
-   The game starts when the host decides.

### Car Selection

-   Players can select their preferred car from a list of available cars.
-   The selected car is instantiated at the start of the race.

### Racing

-   Players race against each other in real-time.
-   The race track includes various obstacles and checkpoints.
-   The first player to complete all laps wins the race.


## License

This project is licensed under the MIT License. See the LICENSE file for details.
