# Poliestireno Mod Menu
### For Plants Vs Zombies
- - -
## Description

Poliestireno Mod Menu is a game modification program developed with ImGui in C#.
- - -

## Usage
Just open the " Poliestireno Mod Menu.exe " and open Plants vs Zombies.
Should open a window like this

![image](https://github.com/Benderdll/Plants-Vs-Zombies-Mod-Menu/assets/151942083/aa60c4b3-c1d7-49c4-81b7-3ce8a737c246)


## Download and Install

(sorry I can't upload the .exe, github only allows 25MB files..)

Download the zip of Release. Extract it in a folder and open the PlantsPoliestireno.sln, and it should open Visual Studio 2022.

### Compile
Now, select this option in the top of the Visual Studio.
![image](https://github.com/Benderdll/Plants-Vs-Zombies-Mod-Menu/assets/151942083/d0e9b74b-2a02-4f92-96ea-a66fc3d64daf)
And now Go to Build -> Build Solution.

The .exe should be in : PlantsPoliestireno\bin\x86\Release\net.6.0

#### Recommended compilation
If you want a more compact final .exe you can do it with commands in the terminal ( cmd ).

Open the terminal or cmd in the folder where the .sln is in.

Then do this command : 

```bash
dotnet publish -r win-x86 -c Release -p PublishReadyToRun=true -p:PublishSingleFile=true --self-contained
```

And then the .exe with the ```cimgui.dll``` and ```SDL2.dll``` with the .exe should be in :

```PlantsPoliestireno\bin\Release\net.6.0\win-x86\publish```

\bin\Release\net6.0\win-x86\publish\

![image](https://github.com/Benderdll/Plants-Vs-Zombies-Mod-Menu/assets/151942083/291e25f7-5094-46a3-850a-ffea18c9d0a4)

## Extra information
This is my first Cheat that I made. I never code something manipulating memory, so yes, this is a simple Cheat made in C#. Im still learning.
Hope you enjoy it.

## Licenses

Mod Menu is open source under the MIT license.
