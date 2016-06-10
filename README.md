Picroxx Creator is a small program intended to streamline level creation for Picroxx (https://github.com/Substance12/Picroxx/).

Substance12, if you're reading this, I didn't commit this to your repo because I don't want my massively unoptimized code weighing it down.

Currently, only the 5x5 level creator is fully working - 10x10 will crash upon saving, at the moment.

To create a level using this utility:
- Fill in the puzzle's squares - you don't have to put Xs or anything
- Input the "gamemode", "letter", and "number" variables, if you'd like to - the program won't fail if there's no input
- Click the "Parse" button and enter a filename - no extension required
The program will generate two files upon saving - a .lua file containing the puzzle's code (to be parsed by the homebrew app) and a 10x10 .png file that can be used as the level's preview image.

I'm simply making this to mess around with VB - yes, I've heard C# is better, IDGAF