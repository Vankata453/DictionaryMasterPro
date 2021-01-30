# DictionaryMasterPro
Dictionary MasterPro is a really simple dictionary creator made with C#. It can support multiple dictionaries at once.

(Dictionary MasterPro is still in pre-release, so if it says it's on version 1.0, this is not currently the case.)

<b>(It's also still not recommended to use it for editing some kind of important dictionaries or other stuff. This may result in Data Loss! For now, use it only for testing!)</b>

<h1>Features:</h1>

- Really easy dictionary creation
- Easily listing the dictionary and reviewing it
- Saving the dictionary to a text file (planned for the 1.0 release)

(In the main 1.0 release, there will be an ````addbatch```` command, which allows you to add many dictionary items in an easier way.)

(Opening text files and continuing to edit them is a feature that may be added into the future, but still not promised yet...)

<h1>Commands:</h1>

<h3>Global:</h3>

````new [name]```` - creates a new dictionary and selects it (for editing)
<br>
````rename [newName]```` - renames the currently selected dictionary to a specified new name
<br>
````end!!!```` - Exits Dictionary MasterPro
<br>
````?```` - Shows all Dictionary MasterPro commands (the ones shown here)

<h3>When in dictionary editing mode:</h3>

````add [key] - [value]```` - add a new dictionary item
<br>
````del```` (or ````delete````) ````[keyOrValue]```` - deletes an already existing dictionary item
<br>
````select [dictionaryName]```` - select another already existing dictionary (for editing)
<br>
````list```` - list the contents of the currently selected dictionary
