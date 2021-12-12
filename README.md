# OptimizedClevoFan
Clevo Fan Tool for x170km-g laptop (and others!)

# License:
MIT -> https://en.wikipedia.org/wiki/MIT_License
Use at your own risk!! 

# Installation:
1. Install NTPostDrvSetup
2. Launch OptimizedClevoFan.exe

# Configuration:
In the configuration.json there are most of the values.
Some of them can be set in the GUI.

# Features:
- Fan temperature check and RPM modification will be executed every XXX ms (250ms by default)
- Temp is taken in average of the last number of temperatures (configurable, 4 records by default)
- Increments in RPM are fast (configurable, by default 2.5%)
- Decrements in RPM are slow (configurable, by default 0.1%)
- Temperature can be configured from 0 to infinite, in steps of whatever is configured (by default 5 degrees)
- Any number of fans are configurable (2 by default, but more can be added and a scroll bar will appear).
- Fan extra RPM to force more fan power... this is usefull in case you are going to play games and you want to keep your computer cold as ice!
- Minimum fan RPM % will be 80% of the fan which is running at max RPMs. For example: If your CPU is at 80ºC and 100% RPM, your GPU fan will run at 80% no matter what temperature is it.

# Credits:
Thanks to @djsubtronic (https://github.com/djsubtronic/ClevoFanControl) because I based in his ClevoFanControl 0.3 to do the communication with the computer fans.

