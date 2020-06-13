# MageLight
***
A strategic lane defense game where you battle against different elemental beasts. Built using C# for Unity and animated using Unity's 2D Skeletal and Keyframe animation systems.

# Project Structure
***
This repository consists of four folders:-

1. [Assets](Assets)
2. [Final_Game_Builds](Final_Game_Builds)
3. [Packages](Packages)
4. [Project Settings](ProjectSettings)

Out which the [Assets](Assets) and [Final_Game_Builds](Final_Game_Builds) are the only files to be concerned with if a user wants to understand the inner workings of the game or play the final build, respectively.

## Assets
This consists of the all the entities used to make the game. These entities (assets) can be categorized as:-
1. [Animations](Assets/Animations)
2. [Audio](Assets/Audio)
3. [Fonts](Assets/Fonts)
4. [Images](Assets/Images)
5. [Materials](Assets/Material)
6. [Prefabs](Assets/Prefabs)
7. [Scenes](Assets/Scenes)
8. [Scripts](Assets/Scripts)
9. [Sprites](Assets/Sprites) 
10. [VFX](Assets/VFX)

## Builds
The [Final_Game_Builds](Final_Game_Builds) folder consists of two final builds of the game. These builds are:-

1. A standalone PC build ---->[PC](Final_Game_Builds/MageLight_PC)
2. A WebGL build         ---->[WebGL](Final_Game_Builds/MageLight_Web)

# Running the Game
***
To run the game using the PC build :-

- Download the Repository.
- Open the [Final_Game_Builds](Final_Game_Builds) folder.
- Open the [MageLight_PC](Final_Game_Builds/MageLight_PC) folder.
- Double click the `MageLight.exe` executable to run the game.

To run the game using the WebGL build :-

- Download the Repository.
- Open the [Final_Game_Builds](Final_Game_Builds) folder.
- Open the [MageLight_Web](Final_Game_Builds/MageLight_Web) folder.
- Right Click the `index.html` and chose `open with` **Microsoft Edge** or **Mozilla Firefox** (*Only these two browsers can run WEBGL builds without further configurations*)

# Instructions and Controls
***
- Chose an arsenal of wizards to deploy on to the playing field using the defender bar at the bottom of your screen.
- 'Mouse over' different wizards within the defender bar to figure out their details such as:-

   - **Cost to deploy**
   - **Health**
   - **Damage Inflicted Per Shot**
   - **Special Abilities.**

## Controls
- Use the `Mouse` to navigate through UI menus (*Start Menu, Pause Menu, Options Menu, Enemy Details Viewing Section (**Also known as Beasts of MageLight**) and Game Over Screen*)
- Use `Mouse over` to hover over the different wizard types in your defender bar before dropping them to view their details.
- Use `Left Mouse Click` to select which wizard to deploy.
- Use `Left Mouse Click` on the playing field to deploy selected wizard. 
- Use `Escape` to toggle the Pause Menu.

# Further Information

For detailed design specifications please refer to the [Wiki](https://github.com/HishamJaffar98/MageLight/wiki/MageLight-Design) of this respository.

