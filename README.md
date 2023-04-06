# maristice_app
### May 6th 2018
Save file manager for Maristice

Download the latest release from [here](https://github.com/shadax1/maristice_app/releases) and place it into your game folder. You can either start the game followed by the save file manager or start the save file manager which will automatically start the game.

![demo pic](https://raw.githubusercontent.com/shadax1/maristice_app/master/demo%20pic.png)

## Save files
I have also included my save files [here](https://github.com/shadax1/maristice_app/releases).

In order to use them, you will need a `saves` folder, which will contain the saves you want to use with the manager, placed inside your game folder.
To load a save file, you have to suspend the game which will bring you back to the title screen where the `Continue` option will now be visible, then select a save from the manager and click `Load save`, finally you can select `Continue` and you will be at the save file's location.

## Memory addresses used
This manager also allows giving yourself lives and potions.

All addresses are static which makes coding this very simple:
```csharp
lives => Maristice.exe+FB598
blue_potion => Maristice.exe+FB528
yellow_potion => Maristice.exe+FB52C
purple_potion => Maristice.exe+FB524
green_potion => Maristice.exe+FB520
```
